/**
 * @file microscope_stitching.hpp
 * @author pchuan98 (haeer98@outlook.com)
 * @brief
 * @version 0.1
 * @date 2024-09-03
 *
 * @copyright Copyright (c) 2024
 *
 */

#pragma once

#include "common.hpp"

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

#include "opencv2/xfeatures2d.hpp"
#include "opencv2/xfeatures2d/nonfree.hpp"

// NOTE： 这里的包装只是临时包装，为了之后的使用

#pragma region ImageFeatures

API(ExceptionStatus)
api_modules_features_create(cv::detail::ImageFeatures **features)
{
    BEGIN_WRAP
    *features = new cv::detail::ImageFeatures();
    END_WRAP
}

API(int)
api_modules_features_index(cv::detail::ImageFeatures *features)
{
    return features->img_idx;
}

API(CvSize)
api_modules_features_size(cv::detail::ImageFeatures *features)
{
    auto size = features->img_size;
    cout << size.width << endl;
    cout << size.height << endl;
    return {size.width, size.height};
}

API(ExceptionStatus)
api_modules_features_keypoints(cv::detail::ImageFeatures *features, std::vector<cv::KeyPoint> **keypoints)
{
    BEGIN_WRAP
    *keypoints = &features->keypoints;
    END_WRAP
}

API(ExceptionStatus)
api_modules_features_descriptors(cv::detail::ImageFeatures *features, cv::UMat **descriptors)
{
    BEGIN_WRAP
    *descriptors = &features->descriptors;
    END_WRAP
}

API(ExceptionStatus)
api_modules_features_array2vector(cv::detail::ImageFeatures *features[], int size, std::vector<cv::detail::ImageFeatures> **out)
{
    BEGIN_WRAP
    if (*out == nullptr)
        *out = new std::vector<cv::detail::ImageFeatures>();

    (*out)->clear();
    (*out)->reserve(size);
    for (int i = 0; i < size; i++)
    {
        if (features[i] != nullptr)
        {
            (*out)->push_back(*features[i]);
        }
    }
    END_WRAP
}

#pragma region Vector of ImageFeatures

#pragma endregion

#pragma endregion

#pragma region Finder

// CV_WRAP static Ptr<ORB> create(int nfeatures=500, float scaleFactor=1.2f, int nlevels=8, int edgeThreshold=31,
//     int firstLevel=0, int WTA_K=2, ORB::ScoreType scoreType=ORB::HARRIS_SCORE, int patchSize=31, int fastThreshold=20);
API(ExceptionStatus)
api_modules_finder_orb(
    cv::Mat *iamge,
    int nfeatures,
    float scaleFactor,
    int nlevels,
    int edgeThreshold,
    int firstLevel,
    int WTA_K,
    int scoreType,
    int patchSize,
    int fastThreshold,
    double scale,
    int index,
    cv::detail::ImageFeatures *features)
{
    BEGIN_WRAP

    cv::Mat full_img, img;
    full_img = *iamge;
    img = full_img;

    auto ptr = cv::ORB::create(
        nfeatures,
        scaleFactor,
        nlevels,
        edgeThreshold,
        firstLevel,
        WTA_K,
        (cv::ORB::ScoreType)scoreType,
        patchSize,
        fastThreshold);

    if (abs(scale - 1.0) >= 1e-6)
        cv::resize(full_img, img, cv::Size(), scale, scale, cv::INTER_LINEAR_EXACT);

    cv::detail::computeImageFeatures(ptr, img, *features);
    features->img_idx = index;

    full_img.release();
    img.release();

    END_WRAP
}

// CV_WRAP static Ptr<AKAZE> create(AKAZE::DescriptorType descriptor_type = AKAZE::DESCRIPTOR_MLDB,
//                                     int descriptor_size = 0, int descriptor_channels = 3,
//                                     float threshold = 0.001f, int nOctaves = 4,
//                                     int nOctaveLayers = 4, KAZE::DiffusivityType diffusivity = KAZE::DIFF_PM_G2,
//                                     int max_points = -1);
API(ExceptionStatus)
api_modules_finder_akaze(
    cv::Mat *iamge,
    int descriptor_type,
    int descriptor_size,
    int descriptor_channels,
    float threshold,
    int nOctaves,
    int nOctaveLayers,
    int diffusivity,
    int max_points,
    double scale,
    int index,
    cv::detail::ImageFeatures *features)
{
    BEGIN_WRAP

    cv::Mat full_img, img;
    full_img = *iamge;
    img = full_img;

    auto ptr = cv::AKAZE::create(
        (AKAZE::DescriptorType)descriptor_type,
        descriptor_size,
        descriptor_channels,
        threshold,
        nOctaves,
        nOctaveLayers,
        (KAZE::DiffusivityType)diffusivity,
        max_points);

    if (abs(scale - 1.0) >= 1e-6)
        cv::resize(full_img, img, cv::Size(), scale, scale, cv::INTER_LINEAR_EXACT);

    cv::detail::computeImageFeatures(ptr, img, *features);
    features->img_idx = index;

    full_img.release();
    img.release();

    END_WRAP
}

// CV_WRAP static Ptr<SURF> create(double hessianThreshold=100,
//                 int nOctaves = 4, int nOctaveLayers = 3,
//                 bool extended = false, bool upright = false);
API(ExceptionStatus)
api_modules_finder_surf(
    cv::Mat *iamge,
    double hessianThreshold,
    int nOctaves,
    int nOctaveLayers,
    bool extended,
    bool upright,
    double scale,
    int index,
    cv::detail::ImageFeatures *features)
{
    BEGIN_WRAP

    cv::Mat full_img, img;
    full_img = *iamge;
    img = full_img;

    auto ptr = cv::xfeatures2d::SURF::create(
        hessianThreshold,
        nOctaves,
        nOctaveLayers,
        extended,
        upright);

    if (abs(scale - 1.0) >= 1e-6)
        cv::resize(full_img, img, cv::Size(), scale, scale, cv::INTER_LINEAR_EXACT);

    cv::detail::computeImageFeatures(ptr, img, *features);
    features->img_idx = index;

    full_img.release();
    img.release();

    END_WRAP
}

// CV_WRAP static Ptr<SIFT> create(int nfeatures = 0, int nOctaveLayers = 3,
//     double contrastThreshold = 0.04, double edgeThreshold = 10,
//     double sigma = 1.6, bool enable_precise_upscale = false);
API(ExceptionStatus)
api_modules_finder_sift(
    cv::Mat *iamge,
    int nfeatures,
    int nOctaveLayers,
    double contrastThreshold,
    double edgeThreshold,
    double sigma,
    bool enable_precise_upscale,
    double scale,
    int index,
    cv::detail::ImageFeatures *features)
{
    BEGIN_WRAP

    cv::Mat full_img, img;
    full_img = *iamge;
    img = full_img;

    auto ptr = cv::SIFT::create(
        nfeatures,
        nOctaveLayers,
        contrastThreshold,
        edgeThreshold,
        sigma,
        enable_precise_upscale);

    if (abs(scale - 1.0) >= 1e-6)
        cv::resize(full_img, img, cv::Size(), scale, scale, cv::INTER_LINEAR_EXACT);

    cv::detail::computeImageFeatures(ptr, img, *features);
    features->img_idx = index;

    full_img.release();
    img.release();

    END_WRAP
}
#pragma endregion

#pragma region MatchesInfo

API(ExceptionStatus)
api_modules_matches_info_create(cv::detail::MatchesInfo **matches_info)
{
    BEGIN_WRAP
    *matches_info = new cv::detail::MatchesInfo();
    END_WRAP
}

API(int)
api_modules_matches_info_src_img_idx(cv::detail::MatchesInfo *matches_info)
{
    return matches_info->src_img_idx;
}

API(int)
api_modules_matches_info_dst_img_idx(cv::detail::MatchesInfo *matches_info)
{
    return matches_info->dst_img_idx;
}

API(int)
api_modules_matches_info_num_inliers(cv::detail::MatchesInfo *matches_info)
{
    return matches_info->num_inliers;
}

API(ExceptionStatus)
api_modules_matches_info_matches(cv::detail::MatchesInfo *matches_info, std::vector<cv::DMatch> **matches)
{
    BEGIN_WRAP
    *matches = &matches_info->matches;
    END_WRAP
}

API(ExceptionStatus)
api_modules_matches_info_inliers_mask(cv::detail::MatchesInfo *matches_info, std::vector<uchar> **inliers_mask)
{
    BEGIN_WRAP
    *inliers_mask = &matches_info->inliers_mask;
    END_WRAP
}

API(ExceptionStatus)
api_modules_matches_info_H(cv::detail::MatchesInfo *matches_info, cv::Mat **H)
{
    BEGIN_WRAP
    *H = &matches_info->H;
    END_WRAP
}

API(double)
api_modules_matches_info_confidence(cv::detail::MatchesInfo *matches_info)
{
    return matches_info->confidence;
}

API(int)
api_modules_matches_vec_size(vector<cv::detail::MatchesInfo> *vector)
{
    return vector->size();
}

API(ExceptionStatus)
api_modules_matches_vec_at(vector<cv::detail::MatchesInfo> *vector, int index, cv::detail::MatchesInfo **matches_info)
{
    BEGIN_WRAP

    if (*matches_info == nullptr)
        *matches_info = new cv::detail::MatchesInfo();

    **matches_info = (*vector)[index];
    END_WRAP
}

#pragma endregion

#pragma region Matcher

// void AffineBestOf2NearestMatcher::match(const ImageFeatures &features1, const ImageFeatures &features2,
//                                         MatchesInfo &matches_info)
API(ExceptionStatus)
api_modules_matcher_affine(
    bool full_affine,
    bool try_use_gpu,
    float match_conf,
    int num_matches_thresh1,
    vector<cv::detail::ImageFeatures> *features,
    vector<cv::detail::MatchesInfo> **matches)
{
    BEGIN_WRAP
    auto matcher = cv::makePtr<cv::detail::AffineBestOf2NearestMatcher>(
        full_affine,
        false,
        match_conf,
        num_matches_thresh1);

    if (*matches == nullptr)
        *matches = new vector<cv::detail::MatchesInfo>();

    (*matcher)(*features, **matches);
    matcher->collectGarbage();

    END_WRAP
}

// CV_WRAP BestOf2NearestMatcher(bool try_use_gpu = false, float match_conf = 0.3f, int num_matches_thresh1 = 6,
//                         int num_matches_thresh2 = 6, double matches_confindece_thresh = 3.);
API(ExceptionStatus)
api_modules_matcher_bestof2nearest(
    bool try_use_gpu,
    float match_conf,
    int num_matches_thresh1,
    int num_matches_thresh2,
    double matches_confindece_thresh,
    vector<cv::detail::ImageFeatures> *features,
    vector<cv::detail::MatchesInfo> **matches)
{
    BEGIN_WRAP
    auto matcher = cv::makePtr<cv::detail::BestOf2NearestMatcher>(
        false,
        match_conf,
        num_matches_thresh1,
        num_matches_thresh2,
        matches_confindece_thresh);

    if (*matches == nullptr)
        *matches = new vector<cv::detail::MatchesInfo>();

    (*matcher)(*features, **matches);
    matcher->collectGarbage();

    END_WRAP
}

// CV_WRAP BestOf2NearestRangeMatcher(int range_width = 5, bool try_use_gpu = false, float match_conf = 0.3f,
//                         int num_matches_thresh1 = 6, int num_matches_thresh2 = 6);

API(ExceptionStatus)
api_modules_matcher_bestof2range(
    int range_width,
    bool try_use_gpu,
    float match_conf,
    int num_matches_thresh1,
    int num_matches_thresh2,
    vector<cv::detail::ImageFeatures> *features,
    vector<cv::detail::MatchesInfo> **matches)
{
    BEGIN_WRAP
    auto matcher = cv::makePtr<cv::detail::BestOf2NearestRangeMatcher>(
        range_width,
        false,
        match_conf,
        num_matches_thresh1,
        num_matches_thresh2);

    if (*matches == nullptr)
        *matches = new vector<cv::detail::MatchesInfo>();

    (*matcher)(*features, **matches);
    matcher->collectGarbage();

    END_WRAP
}

#pragma endregion