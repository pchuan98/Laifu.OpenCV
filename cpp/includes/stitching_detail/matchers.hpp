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

#pragma pack(push, 1)
    struct api_MatchesInfo_DMatch
    {
        int queryIdx;
        int trainIdx;
        int imgIdx;
        float distance;
    };
#pragma pack(pop)

#pragma pack(push, 1)
    struct api_MatchesInfo
    {
        int src_img_idx;
        int dst_img_idx;
        std::vector<api_MatchesInfo_DMatch> *matches;
        std::vector<uchar> *inliers_mask;
        int num_inliers;
        cv::Mat *H;
        double confidence;
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

CVAPI(ExceptionStatus)
api_MatchesInfo_getMatches(api_MatchesInfo info, std::vector<api_MatchesInfo_DMatch> **output)
{
    BEGIN_WRAP
    *output = info.matches;
    END_WRAP
}

CVAPI(ExceptionStatus)
api_MatchesInfo_getInliers(api_MatchesInfo info, std::vector<uchar> **output)
{
    BEGIN_WRAP
    *output = info.inliers_mask;
    END_WRAP
}

// todo 把mask部分写了

// CV_EXPORTS_AS(computeImageFeatures2) void computeImageFeatures(
//     const Ptr<Feature2D> &featuresFinder,
//     InputArray image,
//     CV_OUT ImageFeatures &features,
//     InputArray mask = noArray());
CVAPI(api_ImageFeatures)
api_st_detail_computeImageFeatures(cv::Feature2D *finder, cv::_InputArray *image)
{
    // keep the pointer alive
    // https://github.com/shimat/opencvsharp/blob/ca1f60877aff090de5e3e456c06c7827f33f364d/src/OpenCvSharpExtern/stitching_detail_Matchers.h
    const cv::Ptr<cv::Feature2D> featuresFinderPtr(finder, [](cv::Feature2D *) {});

    cv::detail::ImageFeatures rawFeatures;

    cv::detail::computeImageFeatures(featuresFinderPtr, *image, rawFeatures);

    api_ImageFeatures features = {};

    features.img_idx = rawFeatures.img_idx;
    features.img_size = rawFeatures.img_size;
    features.keypoints = new std::vector<cv::KeyPoint>(rawFeatures.keypoints);

    // printf("img_idx: %d\n", features.img_idx);
    // printf("img_size: w %d h %d\n", features.img_size.width, features.img_size.height);

    // auto keypoints = features.keypoints;
    // std::cout << keypoints->size() << std::endl;
    // std::cout << keypoints->at(0).pt << "\t"
    //           << keypoints->at(0).size << "\t"
    //           << keypoints->at(0).angle << "\t"
    //           << keypoints->at(0).response << "\t"
    //           << keypoints->at(0).octave << "\t"
    //           << keypoints->at(0).class_id << std::endl;
    // std::cout << keypoints->at(keypoints->size() - 1).pt << "\t"
    //           << keypoints->at(keypoints->size() - 1).size << "\t"
    //           << keypoints->at(keypoints->size() - 1).angle << "\t"
    //           << keypoints->at(keypoints->size() - 1).response << "\t"
    //           << keypoints->at(keypoints->size() - 1).octave << "\t"
    //           << keypoints->at(keypoints->size() - 1).class_id << std::endl;

    // printf("--------------------------------\n");
    return features;
}

#pragma region BestOf2NearestMatcher

// CV_WRAP BestOf2NearestMatcher(bool try_use_gpu = false, float match_conf = 0.3f, int num_matches_thresh1 = 6,
//                         int num_matches_thresh2 = 6, double matches_confindece_thresh = 3.);

// CV_WRAP void collectGarbage() CV_OVERRIDE;
// CV_WRAP static Ptr<BestOf2NearestMatcher> create(bool try_use_gpu = false, float match_conf = 0.3f, int num_matches_thresh1 = 6,
//     int num_matches_thresh2 = 6, double matches_confindece_thresh = 3.);

API(ExceptionStatus)
api_st_detail_nearest_create(
    bool try_use_gpu,
    float match_conf,
    int num_matches_thresh1,
    int num_matches_thresh2,
    double matches_confindece_thresh,
    cv::Ptr<cv::detail::BestOf2NearestMatcher> **matcher)
{
    BEGIN_WRAP
    const auto ptr = cv::detail::BestOf2NearestMatcher::create(
        try_use_gpu,
        match_conf,
        num_matches_thresh1,
        num_matches_thresh2,
        matches_confindece_thresh);
    *matcher = clone(ptr);
    END_WRAP
}

API(ExceptionStatus)
api_st_detail_nearest_ptr_get(cv::Ptr<cv::detail::BestOf2NearestMatcher> *ptr, cv::detail::BestOf2NearestMatcher **output)
{
    BEGIN_WRAP
    *output = ptr->get();
    END_WRAP
}

// protected:

// void match(const ImageFeatures &features1, const ImageFeatures &features2, MatchesInfo &matches_info) CV_OVERRIDE;

API(api_MatchesInfo)
api_st_detail_nearest_match(
    cv::detail::BestOf2NearestMatcher *matcher,
    api_ImageFeatures features1,
    api_ImageFeatures features2)
{
    cv::detail::ImageFeatures rawFeatures1;
    rawFeatures1.img_idx = features1.img_idx;
    rawFeatures1.img_size = features1.img_size;
    rawFeatures1.keypoints = *features1.keypoints;
    rawFeatures1.descriptors = *features1.descriptors;

    cv::detail::ImageFeatures rawFeatures2;
    rawFeatures2.img_idx = features2.img_idx;
    rawFeatures2.img_size = features2.img_size;
    rawFeatures2.keypoints = *features2.keypoints;
    rawFeatures2.descriptors = *features2.descriptors;

    cv::detail::MatchesInfo rawMatchesInfo;

    (*matcher)(rawFeatures1, rawFeatures2, rawMatchesInfo);

    api_MatchesInfo matches_info = {};
    matches_info.src_img_idx = rawMatchesInfo.src_img_idx;
    matches_info.dst_img_idx = rawMatchesInfo.dst_img_idx;
    matches_info.matches = new std::vector<api_MatchesInfo_DMatch>();
    for (auto match : rawMatchesInfo.matches)
    {
        api_MatchesInfo_DMatch dmatch = {};
        dmatch.queryIdx = match.queryIdx;
        dmatch.trainIdx = match.trainIdx;
        dmatch.imgIdx = match.imgIdx;
        dmatch.distance = match.distance;
        matches_info.matches->push_back(dmatch);
    }
    matches_info.inliers_mask = new std::vector<uchar>(rawMatchesInfo.inliers_mask);
    matches_info.num_inliers = rawMatchesInfo.num_inliers;
    matches_info.H = new cv::Mat(rawMatchesInfo.H);
    matches_info.confidence = rawMatchesInfo.confidence;

    return matches_info;
}

// int num_matches_thresh1_;
// int num_matches_thresh2_;
// double matches_confindece_thresh_;
// Ptr<FeaturesMatcher> impl_;

#pragma endregion

#pragma region BestOf2NearestRangeMatcher

// CV_WRAP BestOf2NearestRangeMatcher(int range_width = 5, bool try_use_gpu = false, float match_conf = 0.3f,
//                         int num_matches_thresh1 = 6, int num_matches_thresh2 = 6);

API(ExceptionStatus)
api_st_detail_range_create(
    int range_width,
    bool try_use_gpu,
    float match_conf,
    int num_matches_thresh1,
    int num_matches_thresh2,
    cv::Ptr<cv::detail::BestOf2NearestRangeMatcher> **matcher)
{
    BEGIN_WRAP
    const auto ptr = cv::makePtr<cv::detail::BestOf2NearestRangeMatcher>(
        range_width,
        try_use_gpu,
        match_conf,
        num_matches_thresh1,
        num_matches_thresh2);
    *matcher = clone(ptr);
    END_WRAP
}

API(ExceptionStatus)
api_st_detail_range_ptr_get(
    cv::Ptr<cv::detail::BestOf2NearestRangeMatcher> *ptr,
    cv::detail::BestOf2NearestRangeMatcher **output)
{
    BEGIN_WRAP
    *output = ptr->get();
    END_WRAP
}

// void match(const std::vector<ImageFeatures> &features, std::vector<MatchesInfo> &pairwise_matches,
//             const cv::UMat &mask = cv::UMat()) CV_OVERRIDE;

#pragma endregion
