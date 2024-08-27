#include "common.hpp"
#include "opencv2/stitching/detail/matchers.hpp"
#include "opencv2/xfeatures2d.hpp"

#include <string>

#include <iostream>

CVAPI(void)
api_create_feature(cv::detail::ImageFeatures **feature)
{
    *feature = new cv::detail::ImageFeatures();
}

CVAPI(std::vector<cv::KeyPoint> *)
api_feature_keypoints(cv::detail::ImageFeatures *feature)
{
    return &feature->keypoints;
}

CVAPI(void)
api_feature_keypoints_print(std::vector<cv::KeyPoint> *keypoints)
{
    // print size ,the first one and the last one
    std::cout << keypoints->size() << std::endl;
    std::cout << keypoints->at(0).pt << "\t"
              << keypoints->at(0).size << "\t"
              << keypoints->at(0).angle << "\t"
              << keypoints->at(0).response << "\t"
              << keypoints->at(0).octave << "\t"
              << keypoints->at(0).class_id << std::endl;
    std::cout << keypoints->at(keypoints->size() - 1).pt << "\t"
              << keypoints->at(keypoints->size() - 1).size << "\t"
              << keypoints->at(keypoints->size() - 1).angle << "\t"
              << keypoints->at(keypoints->size() - 1).response << "\t"
              << keypoints->at(keypoints->size() - 1).octave << "\t"
              << keypoints->at(keypoints->size() - 1).class_id << std::endl;
}

CVAPI(void)
api_test_feature(cv::detail::ImageFeatures *feature)
{
    auto mat = cv::imread("D:\\.test\\test.png");
    auto finder = cv::ORB::create();
    cv::detail::computeImageFeatures(finder, mat, *feature);
}
