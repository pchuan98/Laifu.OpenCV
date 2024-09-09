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

void main()
{
    auto img = imread("D:\\.test\\test.png");

    // orb
    auto orb = ORB::create();
    auto features = new ImageFeatures();
    computeImageFeatures(orb, img, *features);

    cout << features->img_idx << endl;
    cout << features->img_size << endl;
    cout << features->keypoints.size() << endl;

    // surf
    auto surf = xfeatures2d::SURF::create();
    computeImageFeatures(surf, img, *features);

    cout << features->img_idx << endl;
    cout << features->img_size << endl;
    cout << features->keypoints.size() << endl;

    // akaze
    auto akaze = AKAZE::create();
    computeImageFeatures(akaze, img, *features);

    cout << features->img_idx << endl;
    cout << features->img_size << endl;
    cout << features->keypoints.size() << endl;

    // sift
    auto sift = SIFT::create();
    computeImageFeatures(sift, img, *features);

    cout << features->img_idx << endl;
    cout << features->img_size << endl;
    cout << features->keypoints.size() << endl;
}