/**
 * @file old.cpp
 * @author pchuan98 (haeer98@outlook.com)
 * @brief
 * @version 0.1
 * @date 2024-09-06
 *
 * @copyright Copyright (c) 2024
 *
 */

#include <numeric>
#include <cmath>

#include <iostream>
#include <string>
#include <fstream>
#include "opencv2/opencv_modules.hpp"
#include <opencv2/core/utility.hpp>
#include "opencv2/imgcodecs.hpp"
#include "opencv2/highgui.hpp"
#include "opencv2/stitching/detail/autocalib.hpp"
#include "opencv2/stitching/detail/blenders.hpp"
#include "opencv2/stitching/detail/timelapsers.hpp"
#include "opencv2/stitching/detail/camera.hpp"
#include "opencv2/stitching/detail/exposure_compensate.hpp"
#include "opencv2/stitching/detail/matchers.hpp"
#include "opencv2/stitching/detail/motion_estimators.hpp"
#include "opencv2/stitching/detail/seam_finders.hpp"
#include "opencv2/stitching/detail/warpers.hpp"
#include "opencv2/stitching/warpers.hpp"
#include "opencv2/xfeatures2d.hpp"
#include "opencv2/xfeatures2d/nonfree.hpp"

#include <vector>
#include <future>
#include <mutex>
#include <iostream>
#include <stack>
#include <filesystem>
using namespace std;
using namespace cv;
using namespace detail;
namespace fs = std::filesystem;

#pragma region Header

void ResizeShow(InputArray &img, const string &name = "test", const int size = 1000);

template <typename T>
String ToStringEx(const T &value, int width = 5);

class Semaphore
{
public:
    explicit Semaphore(int count) : count_(count) {}

    void acquire()
    {
        unique_lock<mutex> lock(mutex_);
        while (count_ == 0)
        {
            condition_.wait(lock);
        }
        count_--;
    }

    void release()
    {
        unique_lock<mutex> lock(mutex_);
        count_++;
        condition_.notify_one();
    }

private:
    mutex mutex_;
    condition_variable condition_;
    int count_;
};

const Ptr<Feature2D> MatchFinder = xfeatures2d::SURF::create();
// const Ptr<Feature2D> MatchFinder = ORB::create();
constexpr double MatchConfidence = 0.8;

typedef struct OffsetMatchInfo
{
    double scale = 1;

    vector<double> x = {};
    vector<double> y = {};

    double mean_x = 0;
    double mean_y = 0;
    double std_x = 0;
    double std_y = 0;

    double score = -1;
} OffsetMatchInfo;

// left top right bottom
// from top to bottom and from left to right
typedef struct MatchFlag
{
    int x = 0; // from 0
    int y = 0; // from 0

    bool isMatched = false; // reserved

    // the parameter that determines the position coms from witch direction
    vector<bool> edges = vector<bool>(4);

    // the margin of the image
    vector<Point> margin = vector<Point>(4);

    MatchFlag *left = nullptr;

    MatchFlag *top = nullptr;

    MatchFlag *right = nullptr;

    MatchFlag *bottom = nullptr;

    // reference coordinate point
    MatchFlag *coordinate = nullptr;

    // final position
    Point target = Point(0, 0);
} MatchFlag;

/**
 * @brief match two images. The scale collection is [n * step + start <= end] (n>=1) with step step.
 *
 * @param img1
 * @param img2
 * @param start
 * @param end
 * @param step
 * @return Point
 */
Point MatchSingle(const Mat &img1, const Mat &img2, double start = 0.3, double end = 0.7, double step = 0.1);

/**
 * @brief
 *
 * @param img1
 * @param img2
 * @param start
 * @param end
 * @param step
 * @return Point
 */
Point Match(const Mat &img1, const Mat &img2, double start = 0.3, double end = 0.7, double step = 0.1);

/**
 * @brief
 *
 * @param imgs
 * @param rows
 * @param cols
 * @param start
 * @param end
 * @param step
 * @return vector<MatchFlag>
 */
vector<MatchFlag> MatchAll(const vector<Mat> &imgs, int rows, int cols, double start = 0.3, double end = 0.7, double step = 0.1);

/**
 * @brief
 *
 * @param imgs
 * @param rows
 * @param cols
 * @param start
 * @param end
 * @param step
 * @return vector<MatchFlag>
 */
vector<MatchFlag> QuickMatchAll(const vector<Mat> &imgs, int rows, int cols, double start = 0.3, double end = 0.7, double step = 0.1);

#pragma endregion

#pragma region CPP

void ResizeShow(InputArray &img, const string &name, const int size)
{
    auto scale = 1.0;
    double row = img.rows(), col = img.cols();

    while (!(row < size && col < size))
    {
        scale -= 0.01;
        row = img.rows() * scale;
        col = img.cols() * scale;
    }

    Mat rmat;
    resize(img, rmat, Size(), scale, scale);

    imshow(name, rmat);
}

template String ToStringEx(const int &value, int width);
template String ToStringEx(const float &value, int width);
template String ToStringEx(const double &value, int width);

template <typename T>
String ToStringEx(const T &value, int width)
{
    std::string str = std::to_string(value);
    if (str.length() > width)
        str = str.substr(0, width);
    else if (str.length() < width)
        str += std::string(width - str.length(), ' ');
    else if (str.length() == width)
        str = str;
    return str;
}

double Mean(const std::vector<double> &values)
{
    auto sum = std::accumulate(values.begin(), values.end(), 0.0);
    return sum / static_cast<double>(values.size());
}

// 计算标准差
double StandardDeviation(const std::vector<double> &values)
{
    const double mean_value = Mean(values);
    double variance = 0.0;
    for (const double val : values)
    {
        variance += (val - mean_value) * (val - mean_value);
    }
    variance /= static_cast<double>(values.size());
    return std::sqrt(variance);
}

void CalculateScore(OffsetMatchInfo &omi)
{
    vector x(omi.x);
    vector y(omi.y);

    vector<double> cull_x;
    vector<double> cull_y;

    // if (x.size() != y.size())
    //     throw exception("x and y must have the same size.");
    if (x.size() < 5)
        return;

    auto count = static_cast<int>(ceil(x.size() * 0)) + 1;

    sort(x.begin(), x.end());
    sort(y.begin(), y.end());

    double minx = x[count - 1];
    double maxx = x[x.size() - count];
    double miny = y[count - 1];
    double maxy = y[y.size() - count];

    for (size_t i = 0; i < x.size(); i++)
        if (omi.x[i] >= minx &&
            omi.x[i] <= maxx &&
            omi.y[i] >= miny &&
            omi.y[i] <= maxy)
        {
            cull_x.push_back(x[i]);
            cull_y.push_back(y[i]);
        }

    omi.x = cull_x;
    omi.y = cull_y;

    omi.mean_x = Mean(cull_x);
    omi.mean_y = Mean(cull_y);
    omi.std_x = StandardDeviation(cull_x);
    omi.std_y = StandardDeviation(cull_y);

    omi.score = (1.0 / sqrt(omi.std_x) + 1.0 / sqrt(omi.std_y) * pow(cull_x.size(), 0.5));
}

void ProcessScale(const Mat &img1, const Mat &img2, double scale, OffsetMatchInfo &omi)
{
    Mat dst1, dst2;

    resize(img1, dst1, Size(), scale, scale);
    resize(img2, dst2, Size(), scale, scale);

    vector<ImageFeatures> features(2);

    try
    {
        computeImageFeatures(MatchFinder, dst1, features[0]);
        computeImageFeatures(MatchFinder, dst2, features[1]);

        features[0].img_idx = 0;
        features[1].img_idx = 1;

        const auto matcher = makePtr<AffineBestOf2NearestMatcher>(false, false, MatchConfidence);

        vector<MatchesInfo> matches;
        (*matcher)(features, matches);
        matcher->collectGarbage();

        for (const auto &match : matches[1].matches)
        {
            const auto p1 = features[0].keypoints[match.queryIdx].pt / scale;
            const auto p2 = features[1].keypoints[match.trainIdx].pt / scale;

            omi.x.push_back(p1.x - p2.x);
            omi.y.push_back(p1.y - p2.y);

            omi.scale = scale;
        }

        CalculateScore(omi);
    }
    catch (const std::exception &e)
    {
        cout << e.what() << "\n";

        dst1.release();
        dst2.release();

        omi.scale = -1;
    }
}

Point MatchSingle(const Mat &img1, const Mat &img2, double start, double end, double step)
{
    Mat dst1, dst2;
    vector<OffsetMatchInfo> omis;

    auto n = 1;

    cout << "scale\tcount\tmean_x\t\tmean_y\t\tstd_x\t\tstd_y\t\tscore"
         << "\n-----------------------------------------------------------------------------------------\n";

    while ((n++) * step + start <= end)
    {
        OffsetMatchInfo moi;
        auto scale = (n++) * step + start;

        ProcessScale(img1, img2, scale, moi);
        omis.push_back(moi);

        cout << ToStringEx(scale, 3) << "\t"
             << ToStringEx(static_cast<int>(moi.x.size())) << "\t"
             << ToStringEx(moi.mean_x, 15) << "\t"
             << ToStringEx(moi.mean_y, 15) << "\t"
             << ToStringEx(moi.std_x, 15) << "\t"
             << ToStringEx(moi.std_y, 15) << "\t"
             << ToStringEx(moi.score, 15)
             << endl;
    }

    sort(omis.begin(), omis.end(),
         [](const OffsetMatchInfo &a, const OffsetMatchInfo &b)
         { return a.score > b.score; });

    if (omis.empty() || omis[0].std_x > 100 || omis[0].std_y > 100 || omis[0].score < 0)
    {
        return {0, 0};
    }

    return {static_cast<int>(omis[0].mean_x), static_cast<int>(omis[0].mean_y)};
}

Point Match(const Mat &img1, const Mat &img2, double start, double end, double step)
{
    auto count = static_cast<int>(floor((end - start) / step));

    vector<OffsetMatchInfo> omis(count);
    vector<thread> threads(count);

    for (int i = 0; i < count; i++)
        threads[i] = thread(ProcessScale, img1, img2, (i + 1) * step + start, ref(omis[i]));

    for (auto &t : threads)
        t.join();

    sort(omis.begin(), omis.end(),
         [](const OffsetMatchInfo &a, const OffsetMatchInfo &b)
         { return a.score > b.score; });

    sort(omis.begin(), omis.end(),
         [](const OffsetMatchInfo &a, const OffsetMatchInfo &b)
         { return a.score > b.score; });

    if (omis.empty() || omis[0].std_x > 100 || omis[0].std_y > 100 || omis[0].score < 0)
    {
        return {0, 0};
    }

    return {static_cast<int>(omis[0].mean_x), static_cast<int>(omis[0].mean_y)};
}

void ProcessMatch(int current, int neighbor, const Mat &img1, const Mat &img2, vector<MatchFlag> &flags, int direction, double start, double end, double step, mutex &mtx, Semaphore &sem)
{
    auto match = Match(img1, img2, start, end, step);
    lock_guard lock(mtx);

    if (direction == 0)
    { // left-right
        flags[neighbor].right = &flags[current];
        flags[current].left = &flags[neighbor];

        if (!(match.x == 0 && match.y == 0))
        {
            flags[neighbor].edges[2] = true;
            flags[current].edges[0] = true;

            flags[neighbor].margin[2] = match;
            flags[current].margin[0] = match;
        }
    }
    else
    { // top-bottom
        flags[neighbor].bottom = &flags[current];
        flags[current].top = &flags[neighbor];

        if (!(match.x == 0 && match.y == 0))
        {
            flags[neighbor].edges[3] = true;
            flags[current].edges[1] = true;

            flags[neighbor].margin[3] = match;
            flags[current].margin[1] = match;
        }
    }

    sem.release(); // Release the semaphore when done
}

void DFSFlagsMatch(MatchFlag &flag)
{
    if (flag.isMatched)
        return;

    stack<MatchFlag *> flagsStack;

    flag.coordinate = &flag;
    flag.target = Point(0, 0);

    flagsStack.push(&flag);

    while (!flagsStack.empty())
    {
        auto currentFlag = flagsStack.top();

        flagsStack.pop();
        currentFlag->isMatched = true;

        if (currentFlag->edges[0] && !currentFlag->left->isMatched)
        {
            currentFlag->left->coordinate = currentFlag->coordinate;
            currentFlag->left->target = currentFlag->target - currentFlag->margin[0];

            flagsStack.push(currentFlag->left);
        }

        if (currentFlag->edges[1] && !currentFlag->top->isMatched)
        {
            currentFlag->top->coordinate = currentFlag->coordinate;
            currentFlag->top->target = currentFlag->target - currentFlag->margin[1];

            flagsStack.push(currentFlag->top);
        }

        if (currentFlag->edges[2] && !currentFlag->right->isMatched)
        {
            currentFlag->right->coordinate = currentFlag->coordinate;

            auto target = currentFlag->target;
            auto margin = currentFlag->margin;

            currentFlag->right->target = currentFlag->target + currentFlag->margin[2];

            flagsStack.push(currentFlag->right);
        }

        if (currentFlag->edges[3] && !currentFlag->bottom->isMatched)
        {
            currentFlag->bottom->coordinate = currentFlag->coordinate;
            currentFlag->bottom->target = currentFlag->target + currentFlag->margin[3];

            flagsStack.push(currentFlag->bottom);
        }
    }
}

void AutoArrangeMatchFlags(vector<MatchFlag> &flags)
{
    for (auto &flag : flags)
        flag.isMatched = false;

    for (auto &flag : flags)
        DFSFlagsMatch(flag);
}

vector<MatchFlag> QuickMatchAll(const vector<Mat> &imgs, int rows, int cols, double start, double end, double step)
{
    auto size = rows * cols;
    vector<MatchFlag> flags(size);
    vector<future<void>> futures;
    mutex mtx;

    Semaphore sem(static_cast<int>(std::thread::hardware_concurrency() * 0.5));

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            auto current = i * cols + j;
            auto left = i * cols + j - 1;
            auto top = (i - 1) * cols + j;

            auto flag = &flags[current];
            flag->x = j;
            flag->y = i;

            if (i != 0)
            {
                sem.acquire(); // Acquire a permit before creating a new thread
                futures.emplace_back(async(launch::async, ProcessMatch, current, top, cref(imgs[top]), cref(imgs[current]), ref(flags), 1, start, end, step, ref(mtx), ref(sem)));
            }

            if (j != 0)
            {
                sem.acquire(); // Acquire a permit before creating a new thread
                futures.emplace_back(async(launch::async, ProcessMatch, current, left, cref(imgs[left]), cref(imgs[current]), ref(flags), 0, start, end, step, ref(mtx), ref(sem)));
            }

            cout << i << "	" << j << endl;
        }
    }

    for (auto &fut : futures)
    {
        fut.get();
    }

    AutoArrangeMatchFlags(flags);
    return flags;
}

vector<MatchFlag> MatchAll(const vector<Mat> &imgs, int rows, int cols, double start, double end, double step)
{
    auto size = rows * cols;
    vector<MatchFlag> flags(size);

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            auto current = i * cols + j;
            auto left = i * cols + j - 1;
            auto top = (i - 1) * cols + j;

            auto flag = &flags[current];

            flag->x = j;
            flag->y = i;

            // only match left and top
            if (i != 0)
            {
                auto match = Match(imgs[top], imgs[current], start, end, step);
                flags[top].bottom = &flags[current];
                flags[current].top = &flags[top];

                if (!(match.x == 0 && match.y == 0))
                {
                    flags[top].edges[3] = true;
                    flags[current].edges[1] = true;

                    flags[top].margin[3] = match;
                    flags[current].margin[1] = match;
                }
            }

            if (j != 0)
            {
                auto match = Match(imgs[left], imgs[current], start, end, step);

                flags[left].right = &flags[current];
                flags[current].left = &flags[left];

                if (!(match.x == 0 && match.y == 0))
                {
                    flags[left].edges[2] = true;
                    flags[current].edges[0] = true;

                    flags[left].margin[2] = match;
                    flags[current].margin[0] = match;
                }
            }
        }
    }

    AutoArrangeMatchFlags(flags);
    return flags;
}

#pragma endregion

Mat CubeMat(int width, int height, int mWidth, int nHeight, bool reverse = false)
{

    Mat img(height, width, CV_8U, cv::Scalar((reverse ? 0 : 255)));

    auto startX = (width - mWidth) / 2;
    auto startY = (height - nHeight) / 2;

    rectangle(img, cv::Point(startX, startY), cv::Point(startX + mWidth, startY + nHeight), cv::Scalar((reverse ? 255 : 0)), cv::FILLED);
    return img;
}

int main()
{
    fs::path root = R"(D:\.test\wafer\A0)";
}