/**
 * @file models.cpp
 * @author pchuan98 (haeer98@outlook.com)
 * @brief Test models
 * @version 0.1
 * @date 2024-09-05
 *
 * @copyright Copyright (c) 2024
 *
 */

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

#ifdef HAVE_OPENCV_XFEATURES2D
#include "opencv2/xfeatures2d.hpp"
#include "opencv2/xfeatures2d/nonfree.hpp"
#endif

using namespace std;
using namespace cv;
using namespace cv::detail;

#pragma region SHOW

double WINDOWSCALE = 1;

template <typename T>
void ResizeShow(T *img, const string &name = "test", const int size = 1000, const bool wait = true);

void OnMouseMove(int event, int x, int y, int, void *userdata)
{
    if (event == EVENT_MOUSEMOVE)
    {
        Mat &img = *(Mat *)userdata;

        auto ax = x / WINDOWSCALE;
        auto ay = y / WINDOWSCALE;

        if (img.type() == CV_16SC3)
        {
            auto az = img.at<Vec3s>(ay, ax);
            cout << "x: " << ax << "\ty: " << ay << "\tvalue: " << az << endl;
        }
    }
}

template void ResizeShow(Mat *img, const string &name, const int size, const bool wait);
template void ResizeShow(UMat *img, const string &name, const int size, const bool wait);

template <typename T>
void ResizeShow(T *img, const string &name, const int size, const bool wait)
{
    if (img->empty())
    {
        cout << "Image is empty!" << endl;
        return;
    }

    namedWindow(name, WINDOW_AUTOSIZE);
    setMouseCallback(name, OnMouseMove, (void *)img);

    WINDOWSCALE = 1.0;
    double row = img->rows, col = img->cols;

    while (!(row < size && col < size))
    {
        WINDOWSCALE -= 0.01;
        row = img->rows * WINDOWSCALE;
        col = img->cols * WINDOWSCALE;
    }

    Mat rmat;
    resize(*img, rmat, Size(), WINDOWSCALE, WINDOWSCALE);

    imshow(name, rmat);
    if (wait)
        waitKey(0);
}

#pragma endregion

int main()
{
    vector<Mat> images = {
        imread("D:\\.test\\stitch2\\4-3.jpg"),
        imread("D:\\.test\\stitch2\\4-4.jpg"),
        // imread("D:\\.test\\stitch2\\4-5.jpg"),
        // imread("D:\\.test\\stitch2\\4-8.jpg"),
        // imread("D:\\.test\\stitch2\\4-9.jpg"),
        // imread("D:\\.test\\stitch2\\4-10.jpg"),
        // imread("D:\\.test\\stitch2\\5-8.jpg"),
        // imread("D:\\.test\\stitch2\\5-9.jpg"),
        // imread("D:\\.test\\stitch2\\5-10.jpg"),
        // imread("C:\\Users\\simscop\\Desktop\\2.jpg"),
        // imread("C:\\Users\\simscop\\Desktop\\3.jpg"),
        //
    };

    auto count = images.size();
    auto conf = 1.0f;

    vector<ImageFeatures> features(count);
    auto finder = SIFT::create();
    for (int i = 0; i < count; ++i)
    {
        computeImageFeatures(finder, images[i], features[i]);
        features[i].img_idx = i;
    }

    vector<MatchesInfo> matches;
    auto matcher = makePtr<BestOf2NearestMatcher>(false, false, conf);
    (*matcher)(features, matches);
    (*matcher).collectGarbage();

    vector<CameraParams> cameras;
    auto estimator = makePtr<AffineBasedEstimator>();
    (*estimator)(features, matches, cameras);

    for (size_t i = 0; i < cameras.size(); ++i)
    {
        Mat R;
        cameras[i].R.convertTo(R, CV_32F);
        cameras[i].R = R;
    }

    auto adjuster = makePtr<NoBundleAdjuster>();
    adjuster->setConfThresh(conf);
    adjuster->setRefinementMask(Mat::ones(3, 3, CV_8U));
    (*adjuster)(features, matches, cameras);

    // print cameras
    for (auto &camera : cameras)
    {
        cout << "---------------------------------------" << endl;
        cout << camera.K() << endl;
        cout << camera.R << endl;
        cout << camera.t << endl;
    }

    vector<Point> corners(count);
    vector<UMat> masks_warped(count);
    vector<UMat> images_warped(count);
    vector<Size> sizes(count);
    vector<UMat> masks(count);

    for (int i = 0; i < count; ++i)
    {
        masks[i].create(images[i].size(), CV_8U);
        masks[i].setTo(Scalar::all(255));
    }

    auto warper = makePtr<cv::AffineWarper>()->create(1.0f);

    for (int i = 0; i < count; ++i)
    {
        Mat_<float> K;
        cameras[i].K().convertTo(K, CV_32F);
        float swa = (float)1.0;
        K(0, 0) *= swa;
        K(0, 2) *= swa;
        K(1, 1) *= swa;
        K(1, 2) *= swa;

        corners[i] = warper->warp(images[i], K, cameras[i].R, INTER_LINEAR, BORDER_REFLECT, images_warped[i]);
        cout << corners[i] << endl;

        sizes[i] = images_warped[i].size();
        warper->warp(masks[i], K, cameras[i].R, INTER_NEAREST, BORDER_CONSTANT, masks_warped[i]);
    }

    vector<UMat> images_warped_f(count);
    for (int i = 0; i < count; ++i)
        images_warped[i].convertTo(images_warped_f[i], CV_32F);

    auto compensator = ExposureCompensator::createDefault(ExposureCompensator::GAIN);
    auto gcompensator = dynamic_cast<GainCompensator *>(compensator.get());
    gcompensator->setNrFeeds(1);
    compensator->feed(corners, images_warped_f, masks_warped);

    // auto seamer = makePtr<GraphCutSeamFinder>(GraphCutSeamFinderBase::COST_COLOR);
    auto seamer = makePtr<detail::VoronoiSeamFinder>();
    seamer->find(images_warped_f, corners, masks_warped);
    images_warped_f.clear();

    auto blender = Blender::createDefault(Blender::MULTI_BAND, false);

    MultiBandBlender *mb = dynamic_cast<MultiBandBlender *>(blender.get());
    auto dst_sz = resultRoi(corners, sizes).size();
    float blend_width = sqrt(static_cast<float>(dst_sz.area())) * 5 / 100.f;
    mb->setNumBands(static_cast<int>(ceil(log(1000) / log(2.)) - 1.));

    blender->prepare(corners, sizes);

    for (int i = 0; i < count; i++)
    {
        Mat warped, dilate, seam;
        auto img = images_warped[i].getMat(ACCESS_RW).clone();

        compensator->apply(i, corners[i], images_warped[i], masks_warped[i]);

        if (img.channels() == 1)
            cvtColor(img, img, COLOR_GRAY2BGR);
        if (img.depth() == CV_16U)
            img.convertTo(warped, CV_16SC3, 1, -65535 / 2.0);
        else if (img.depth() == CV_8U)
            img.convertTo(warped, CV_16SC3, 256, -65535 / 2);
        else if (img.depth() == CV_16S)
            warped = img;
        else
            throw runtime_error("Unsupported image depth");

        cv::dilate(masks_warped[i], dilate, Mat());
        cv::resize(dilate, seam, masks_warped[i].size(), 0, 0, INTER_LINEAR_EXACT);

        blender->feed(warped, masks_warped[i], corners[i]);

        ResizeShow(&warped, "warped", 1000, false);
        ResizeShow(&masks_warped[i], "masks_warped", 1000, false);
        waitKey(0);
    }

    Mat result, mask;
    blender->blend(result, mask);

    ResizeShow(&result, "result");
    return 1;
}