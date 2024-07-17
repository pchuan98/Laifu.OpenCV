#pragma once

#include <string>
#include "common.hpp"
#include "matchers.hpp"

CVAPI(std::string *)
api_string_empty()
{
    return new std::string;
}

CVAPI(std::string *)
api_string(const char *str)
{
    return new std::string(str);
}

CVAPI(void)
api_string_delete(const std::string *obj)
{
    delete obj;
}

CVAPI(const char *)
api_string_c_str(std::string *obj)
{
    return obj->c_str();
}

struct CV_EXPORTS_W_SIMPLE Laifu_ImageFeatures
{
    int img_idx;
    CvSize img_size;
    std::vector<cv::KeyPoint> *keypoints;
    cv::UMat *descriptors;
};

CVAPI(ExceptionStatus)
api_stitching_computer_image_feature(
    cv::_InputArray *image,
    Laifu_ImageFeatures *features)
{
    BEGIN_WRAP

    // Do not free Feature2D
    // const cv::Ptr<cv::Feature2D> featuresFinderPtr(finder, [](cv::Feature2D *) {});
    auto finder = cv::xfeatures2d::SURF::create();

    cv::detail::ImageFeatures rawFeature;
    cv::detail::computeImageFeatures(finder, *image, rawFeature);

    features->img_idx = rawFeature.img_idx;
    features->img_size = {rawFeature.img_size.width, rawFeature.img_size.height};
    std::copy(rawFeature.keypoints.begin(), rawFeature.keypoints.end(), std::back_inserter(*features->keypoints));
    rawFeature.descriptors.copyTo(*features->descriptors);

    END_WRAP
}