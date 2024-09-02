/**
 * @file matchers.hpp
 * @author pchuan98 (haeer98@outlook.com)
 * @brief
 * @version 0.1
 * @date 2024-09-02
 *
 * @copyright Copyright (c) 2024
 *
 */

#include "common.hpp"
#include "opencv2/stitching/detail/matchers.hpp"
#include <opencv2/imgproc.hpp>
#include <iostream>
#include "opencv2/xfeatures2d.hpp"
#include "opencv2/xfeatures2d/nonfree.hpp"
#include "opencv2/imgcodecs.hpp"

extern "C"
{
#pragma pack(push, 1)
    struct api_ImageFeatures
    {
        int img_idx;
        cv::Size img_size;
        std::vector<cv::KeyPoint> *keypoints;
        cv::UMat *descriptors;
    };
#pragma pack(pop)
}

CVAPI(ExceptionStatus)
api_ImageFeatures_getKeypoints(api_ImageFeatures feature, std::vector<cv::KeyPoint> **output)
{
    BEGIN_WRAP
    *output = feature.keypoints;
    END_WRAP
}

CVAPI(ExceptionStatus)
api_ImageFeatures_getDescriptors(api_ImageFeatures feature, cv::UMat **output)
{
    BEGIN_WRAP
    *output = feature.descriptors;
    END_WRAP
}

CVAPI(api_ImageFeatures)
api_st_detail_computeImageFeatures(cv::Feature2D *finder, cv::Mat *image)
{
    // keep the pointer alive
    const cv::Ptr<cv::Feature2D> featuresFinderPtr(finder, [](cv::Feature2D *) {});

    // https://github.com/shimat/opencvsharp/blob/ca1f60877aff090de5e3e456c06c7827f33f364d/src/OpenCvSharpExtern/stitching_detail_Matchers.h
    cv::detail::ImageFeatures rawFeatures;

    cv::detail::computeImageFeatures(featuresFinderPtr, *image, rawFeatures);

    api_ImageFeatures features = {};

    features.img_idx = rawFeatures.img_idx;
    features.img_size = rawFeatures.img_size;
    features.keypoints = new std::vector<cv::KeyPoint>(rawFeatures.keypoints);

    printf("img_idx: %d\n", features.img_idx);
    printf("img_size: w %d h %d\n", features.img_size.width, features.img_size.height);

    auto keypoints = features.keypoints;
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

    printf("--------------------------------\n");

    return features;
}