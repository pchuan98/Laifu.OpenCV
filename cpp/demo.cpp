#include <iostream>
#include <iostream>
#include <fstream>
#include <string>
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

using namespace std;
using namespace cv;

/**
 * @brief
 *
 * @param img1 左边图片
 * @param img2
 */
void glimpse(const cv::Mat &img1, const cv::Mat &img2)
{
    int width = img1.cols;
    int height = img1.rows;

    int overlap = 0;
    int offset = 0;
    while (true)
    {
        cv::Mat merged(height + offset, (width - overlap) * 2, img1.type());
        merged.setTo(0);

        img1(cv::Rect(0, 0, width - overlap, height)).copyTo(merged(cv::Rect(0, 0, width - overlap, height)));
        img2(cv::Rect(overlap, 0, width - overlap, height)).copyTo(merged(cv::Rect(width - overlap, offset, width - overlap, height)));

        cv::imshow("merged", merged);

        int key = cv::waitKey(0);
        if (key == 106 && overlap < width - 1) // j
            overlap += 1;
        else if (key == 107 && overlap > 1) // k
            overlap -= 1;
        // h
        else if (key == 104 && offset < height - 1)
            offset += 1;
        // l
        else if (key == 108 && offset > 1)
            offset -= 1;
        else if (key == 27) // ESC
        {
            merged.release();
            break;
        }
        else
            continue;

        std::cout << "overlap: " << overlap << "\toffset: " << offset << std::endl;
    }
}

/**
 * @brief 尝试两两合并的拼接方式
 *
 */
void twomergetwo()
{
    auto img1 = cv::imread("D:/.test/test_human/0709/src/1_16.tif");
    auto img2 = cv::imread("D:/.test/test_human/0709/src/1_17.tif");
    // auto img1 = cv::imread("D:\\.test\\stitch2\\4-3.jpg");
    // auto img2 = cv::imread("D:\\.test\\stitch2\\4-4.jpg");
    auto img3 = cv::imread("D:/.test/test_human/0709/src/1_18.tif");

    auto img1f = cv::UMat();
    auto img2f = cv::UMat();
    auto img3f = cv::UMat();

    img1.convertTo(img1f, CV_32F);
    img2.convertTo(img2f, CV_32F);
    img3.convertTo(img3f, CV_32F);

    int width = img1.cols;
    int height = img1.rows;

    int overlap = 113;
    int offset = 4;

    auto corner1 = cv::Point(0, 0);
    auto corner2 = cv::Point(width - overlap * 2, offset);

    // glimpse(img1, img2);

    UMat mask1(height, width, CV_8U, Scalar(255));
    UMat mask2(height, width, CV_8U, Scalar(255));

    mask1(Rect(width - overlap, 0, overlap, height)) = 0;
    mask2(Rect(0, 0, overlap, height)) = 0;

    vector<UMat> imagefs = {img1f, img2f};
    vector<Point> corners = {corner1, corner2};
    vector<UMat> masks_warped = {mask1, mask2};
    vector<Size> sizes = {img1.size(), img2.size()};

    Ptr<cv::detail::SeamFinder> seam_finder;
    auto seam_find_type = 0;
    if (seam_find_type == 0)
        seam_finder = makePtr<detail::NoSeamFinder>();
    else if (seam_find_type == 1)
        seam_finder = makePtr<detail::VoronoiSeamFinder>();
    else if (seam_find_type == 2)
        seam_finder = makePtr<detail::GraphCutSeamFinder>(cv::detail::GraphCutSeamFinderBase::COST_COLOR);
    else if (seam_find_type == 3)
        seam_finder = makePtr<detail::GraphCutSeamFinder>(cv::detail::GraphCutSeamFinderBase::COST_COLOR_GRAD);
    else if (seam_find_type == 4)
        seam_finder = makePtr<detail::DpSeamFinder>(cv::detail::DpSeamFinder::COLOR);
    else if (seam_find_type == 5)
        seam_finder = makePtr<detail::DpSeamFinder>(cv::detail::DpSeamFinder::COLOR_GRAD);
    if (!seam_finder)
    {
        cout << "Can't create the following seam finder '" << seam_find_type << "'\n";
        return;
    }

    seam_finder->find(imagefs, corners, masks_warped);

    imshow("mask1", masks_warped[0]);
    imshow("mask2", masks_warped[1]);
    waitKey(0);

    auto blender = cv::detail::Blender::createDefault(cv::detail::Blender::MULTI_BAND, false);
    cv::detail::MultiBandBlender *mb = dynamic_cast<cv::detail::MultiBandBlender *>(blender.get());
    auto dst_sz = cv::detail::resultRoi(corners, sizes).size();
    float blend_width = sqrt(static_cast<float>(dst_sz.area())) * 5 / 100.f;
    mb->setNumBands(static_cast<int>(ceil(log(1000) / log(2.)) - 1.));
    cout << "band num: " << mb->numBands() << endl;

    blender->prepare(corners, sizes);

    Mat warped1, warped2;
    img1.convertTo(warped1, CV_16SC3, 256, -65535 / 2);
    img2.convertTo(warped2, CV_16SC3, 256, -65535 / 2);

    cv::imshow("warped1", warped1);
    cv::imshow("warped2", warped2);
    waitKey(0);

    Mat dilate1, dilate2;
    cv::dilate(masks_warped[0], dilate1, Mat());
    cv::dilate(masks_warped[1], dilate2, Mat());

    blender->feed(warped1, masks_warped[0], corners[0]);
    blender->feed(warped2, masks_warped[1], corners[1]);

    Mat result, mask;
    blender->blend(result, mask);

    imshow("result", result);
    waitKey(0);
}

int main()
{
    twomergetwo();

    cout << "program end" << endl;
}