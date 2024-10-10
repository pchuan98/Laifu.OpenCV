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

API(int)
api_modules_features_vec_size(vector<cv::detail::ImageFeatures> *vector)
{
    return vector->size();
}

API(ExceptionStatus)
api_modules_features_vec_at(vector<cv::detail::ImageFeatures> *vector, int index, cv::detail::ImageFeatures **features)
{
    BEGIN_WRAP

    if (*features == nullptr)
        *features = new cv::detail::ImageFeatures();

    **features = (*vector)[index];
    END_WRAP
}

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
api_modules_matches_info_H_at(cv::Mat *h, int index)
{
    if (h->type() != 6)
        return 0;
    return h->at<double>(index);
}

API(double)
api_modules_matches_info_confidence(cv::detail::MatchesInfo *matches_info)
{
    return matches_info->confidence;
}

API(ExceptionStatus)
api_modules_matches_info_array2vector(
    cv::detail::MatchesInfo *matches_info[],
    int size,
    std::vector<cv::detail::MatchesInfo> **out)
{
    BEGIN_WRAP
    if (*out == nullptr)
        *out = new std::vector<cv::detail::MatchesInfo>();

    (*out)->clear();
    (*out)->reserve(size);
    for (int i = 0; i < size; i++)
    {
        if (matches_info[i] != nullptr)
        {
            (*out)->push_back(*matches_info[i]);
        }
    }
    END_WRAP
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

#pragma region CameraParams

API(ExceptionStatus)
api_modules_camera_params_create(cv::detail::CameraParams **camera_params)
{
    BEGIN_WRAP
    *camera_params = new cv::detail::CameraParams();
    END_WRAP
}

API(double)
api_modules_camera_params_focal(cv::detail::CameraParams *camera_params)
{
    return camera_params->focal;
}

API(double)
api_modules_camera_params_aspect(cv::detail::CameraParams *camera_params)
{
    return camera_params->aspect;
}

API(double)
api_modules_camera_params_ppx(cv::detail::CameraParams *camera_params)
{
    return camera_params->ppx;
}

API(double)
api_modules_camera_params_ppy(cv::detail::CameraParams *camera_params)
{
    return camera_params->ppy;
}

API(ExceptionStatus)
api_modules_camera_params_R(
    cv::detail::CameraParams *camera_params,
    cv::Mat **R)
{
    BEGIN_WRAP
    *R = &camera_params->R;
    END_WRAP
}

API(ExceptionStatus)
api_modules_camera_params_t(
    cv::detail::CameraParams *camera_params,
    cv::Mat **t)
{
    BEGIN_WRAP
    *t = &camera_params->t;
    END_WRAP
}

API(ExceptionStatus)
api_modules_camera_params_array2vector(
    cv::detail::CameraParams *camera_params[],
    int size,
    std::vector<cv::detail::CameraParams> **out)
{
    BEGIN_WRAP
    if (*out == nullptr)
        *out = new std::vector<cv::detail::CameraParams>();

    (*out)->clear();
    (*out)->reserve(size);
    for (int i = 0; i < size; i++)
    {
        if (camera_params[i] != nullptr)
        {
            (*out)->push_back(*camera_params[i]);
        }
    }
    END_WRAP
}

API(int)
api_modules_camera_params_vec_size(vector<cv::detail::CameraParams> *vector)
{
    return vector->size();
}

API(ExceptionStatus)
api_modules_camera_params_vec_at(
    vector<cv::detail::CameraParams> *vector,
    int index,
    cv::detail::CameraParams **camera_params)
{
    BEGIN_WRAP
    if (*camera_params == nullptr)
        *camera_params = new cv::detail::CameraParams();

    **camera_params = (*vector)[index];
    END_WRAP
}

#pragma endregion

#pragma region Estimator

API(ExceptionStatus)
api_modules_estimator_leaveBiggestComponent(
    vector<cv::detail::ImageFeatures> *features,
    vector<cv::detail::MatchesInfo> *matches,
    double conf_thresh,
    vector<int> **indices)
{
    BEGIN_WRAP
    auto incs = cv::detail::leaveBiggestComponent(*features, *matches, conf_thresh);
    *indices = new vector<int>(incs.begin(), incs.end());
    END_WRAP
}

// CV_WRAP HomographyBasedEstimator(bool is_focals_estimated = false)
API(bool)
api_modules_estimator_homography(
    bool is_focals_estimated,
    vector<cv::detail::ImageFeatures> *features,
    vector<cv::detail::MatchesInfo> *pairwise_matches,
    vector<cv::detail::CameraParams> **cameras)
{
    auto estimator = cv::makePtr<cv::detail::HomographyBasedEstimator>(is_focals_estimated);
    *cameras = new vector<cv::detail::CameraParams>();

    return (*estimator)(*features, *pairwise_matches, **cameras);
}

// CV_WRAP AffineBasedEstimator(){}
API(bool)
api_modules_estimator_affine(
    vector<cv::detail::ImageFeatures> *features,
    vector<cv::detail::MatchesInfo> *pairwise_matches,
    vector<cv::detail::CameraParams> **cameras)
{
    auto estimator = cv::makePtr<cv::detail::AffineBasedEstimator>();
    *cameras = new vector<cv::detail::CameraParams>();

    return (*estimator)(*features, *pairwise_matches, **cameras);
}

// CV_WRAP NoBundleAdjuster() : BundleAdjusterBase(0, 0) {}
API(bool)
api_modules_estimator_no_bundle_adjuster(
    bool is_focals,
    bool is_ppx,
    bool is_ppy,
    bool is_aspect,
    bool is_skew,
    bool is_wave_correct,
    double conf_thresh,
    vector<cv::detail::ImageFeatures> *features,
    vector<cv::detail::MatchesInfo> *pairwise_matches,
    vector<cv::detail::CameraParams> *cameras)
{
    // <fx><skew><ppx><aspect><ppy>
    Mat_<uchar> refine_mask = Mat::zeros(3, 3, CV_8U);
    if (is_focals)
        refine_mask(0, 0) = 1;
    if (is_skew)
        refine_mask(0, 1) = 1;
    if (is_ppx)
        refine_mask(0, 2) = 1;
    if (is_aspect)
        refine_mask(1, 1) = 1;
    if (is_ppy)
        refine_mask(1, 2) = 1;

    // converter camera.R to 32F
    for (size_t i = 0; i < cameras->size(); ++i)
    {
        Mat R;
        (*cameras)[i].R.convertTo(R, CV_32F);
        (*cameras)[i].R = R;
    }

    auto adjuster = cv::makePtr<cv::detail::NoBundleAdjuster>();
    adjuster->setConfThresh(conf_thresh);
    adjuster->setRefinementMask(refine_mask);

    return (*adjuster)(*features, *pairwise_matches, *cameras);
}

//  CV_WRAP BundleAdjusterRay() : BundleAdjusterBase(4, 3) {}
API(bool)
api_modules_estimator_bundle_adjuster_ray(
    bool is_focals,
    bool is_ppx,
    bool is_ppy,
    bool is_aspect,
    bool is_skew,
    bool is_wave_correct,
    double conf_thresh,
    vector<cv::detail::ImageFeatures> *features,
    vector<cv::detail::MatchesInfo> *pairwise_matches,
    vector<cv::detail::CameraParams> *cameras)
{
    // <fx><skew><ppx><aspect><ppy><wave_correct>
    Mat_<uchar> refine_mask = Mat::zeros(3, 3, CV_8U);
    if (is_focals)
        refine_mask(0, 0) = 1;
    if (is_skew)
        refine_mask(0, 1) = 1;
    if (is_ppx)
        refine_mask(0, 2) = 1;
    if (is_aspect)
        refine_mask(1, 1) = 1;
    if (is_ppy)
        refine_mask(1, 2) = 1;
    if (is_wave_correct)
        refine_mask(2, 2) = 1;

    // converter camera.R to 32F
    for (size_t i = 0; i < cameras->size(); ++i)
    {
        Mat R;
        (*cameras)[i].R.convertTo(R, CV_32F);
        (*cameras)[i].R = R;
    }

    auto adjuster = cv::makePtr<cv::detail::BundleAdjusterRay>();
    adjuster->setConfThresh(conf_thresh);
    adjuster->setRefinementMask(refine_mask);

    return (*adjuster)(*features, *pairwise_matches, *cameras);
}

// CV_WRAP BundleAdjusterReproj() : BundleAdjusterBase(7, 2) {}
API(bool)
api_modules_estimator_bundle_adjuster_reproj(
    bool is_focals,
    bool is_ppx,
    bool is_ppy,
    bool is_aspect,
    bool is_skew,
    bool is_wave_correct,
    double conf_thresh,
    vector<cv::detail::ImageFeatures> *features,
    vector<cv::detail::MatchesInfo> *pairwise_matches,
    vector<cv::detail::CameraParams> *cameras)
{
    // <fx><skew><ppx><aspect><ppy><wave_correct>
    Mat_<uchar> refine_mask = Mat::zeros(3, 3, CV_8U);
    if (is_focals)
        refine_mask(0, 0) = 1;
    if (is_skew)
        refine_mask(0, 1) = 1;
    if (is_ppx)
        refine_mask(0, 2) = 1;
    if (is_aspect)
        refine_mask(1, 1) = 1;
    if (is_ppy)
        refine_mask(1, 2) = 1;
    if (is_wave_correct)
        refine_mask(2, 2) = 1;

    // converter camera.R to 32F
    for (size_t i = 0; i < cameras->size(); ++i)
    {
        Mat R;
        (*cameras)[i].R.convertTo(R, CV_32F);
        (*cameras)[i].R = R;
    }

    auto adjuster = cv::makePtr<cv::detail::BundleAdjusterReproj>();
    adjuster->setConfThresh(conf_thresh);
    adjuster->setRefinementMask(refine_mask);

    return (*adjuster)(*features, *pairwise_matches, *cameras);
}

// CV_WRAP BundleAdjusterAffinePartial() : BundleAdjusterBase(4, 2) {}
API(bool)
api_modules_estimator_bundle_adjuster_affine_partial(
    bool is_focals,
    bool is_ppx,
    bool is_ppy,
    bool is_aspect,
    bool is_skew,
    bool is_wave_correct,
    double conf_thresh,
    vector<cv::detail::ImageFeatures> *features,
    vector<cv::detail::MatchesInfo> *pairwise_matches,
    vector<cv::detail::CameraParams> *cameras)
{
    // <fx><skew><ppx><aspect><ppy><wave_correct>
    Mat_<uchar> refine_mask = Mat::zeros(3, 3, CV_8U);
    if (is_focals)
        refine_mask(0, 0) = 1;
    if (is_skew)
        refine_mask(0, 1) = 1;
    if (is_ppx)
        refine_mask(0, 2) = 1;
    if (is_aspect)
        refine_mask(1, 1) = 1;
    if (is_ppy)
        refine_mask(1, 2) = 1;
    if (is_wave_correct)
        refine_mask(2, 2) = 1;

    // converter camera.R to 32F
    for (size_t i = 0; i < cameras->size(); ++i)
    {
        Mat R;
        (*cameras)[i].R.convertTo(R, CV_32F);
        (*cameras)[i].R = R;
    }

    auto adjuster = cv::makePtr<cv::detail::BundleAdjusterAffinePartial>();
    adjuster->setConfThresh(conf_thresh);
    adjuster->setRefinementMask(refine_mask);

    return (*adjuster)(*features, *pairwise_matches, *cameras);
}

#pragma endregion

#pragma region Warper

API(ExceptionStatus)
api_modules_warper_create(
    int type,
    float scale,
    cv::Ptr<cv::detail::RotationWarper> **warper)
{
    BEGIN_WRAP

    cv::Ptr<cv::WarperCreator> warper_creator;

    switch (type)
    {
    case 0:
        warper_creator = cv::makePtr<cv::PlaneWarper>();
        break;
    case 1:
        warper_creator = cv::makePtr<cv::AffineWarper>();
        break;
    case 2:
        warper_creator = cv::makePtr<cv::CylindricalWarper>();
        break;
    case 3:
        warper_creator = cv::makePtr<cv::SphericalWarper>();
        break;
    case 4:
        warper_creator = cv::makePtr<cv::FisheyeWarper>();
        break;
    case 5:
        warper_creator = cv::makePtr<cv::StereographicWarper>();
        break;
    case 6:
        warper_creator = cv::makePtr<cv::CompressedRectilinearWarper>(2.0f, 1.0f);
        break;
    case 7:
        warper_creator = cv::makePtr<cv::CompressedRectilinearWarper>(1.5f, 1.0f);
        break;
    case 8:
        warper_creator = cv::makePtr<cv::CompressedRectilinearPortraitWarper>(2.0f, 1.0f);
        break;
    case 9:
        warper_creator = cv::makePtr<cv::CompressedRectilinearPortraitWarper>(1.5f, 1.0f);
        break;
    case 10:
        warper_creator = cv::makePtr<cv::PaniniWarper>(2.0f, 1.0f);
        break;
    case 11:
        warper_creator = cv::makePtr<cv::PaniniWarper>(1.5f, 1.0f);
        break;
    case 12:
        warper_creator = cv::makePtr<cv::PaniniPortraitWarper>(2.0f, 1.0f);
        break;
    case 13:
        warper_creator = cv::makePtr<cv::PaniniPortraitWarper>(1.5f, 1.0f);
        break;
    case 14:
        warper_creator = cv::makePtr<cv::MercatorWarper>();
        break;
    case 15:
        warper_creator = cv::makePtr<cv::TransverseMercatorWarper>();
        break;
    default:
        break;
    }

    if (warper_creator.get() != nullptr)
    {
        auto ptr = warper_creator->create(scale);
        *warper = new cv::Ptr<cv::detail::RotationWarper>(ptr);
    }

    END_WRAP
}

API(ExceptionStatus)
api_modules_warper_get(
    cv::Ptr<cv::detail::RotationWarper> *warperPtr,
    cv::detail::RotationWarper **warper)
{
    BEGIN_WRAP
    *warper = warperPtr->get();
    END_WRAP
}

API(ExceptionStatus)
api_modules_warper_32Mat(
    float a11, float a12, float a13,
    float a21, float a22, float a23,
    float a31, float a32, float a33,
    cv::Mat **mat)
{
    BEGIN_WRAP
    if (*mat == nullptr)
        *mat = new cv::Mat(3, 3, CV_32FC1);

    (*mat)->at<float>(0, 0) = a11;
    (*mat)->at<float>(0, 1) = a12;
    (*mat)->at<float>(0, 2) = a13;
    (*mat)->at<float>(1, 0) = a21;
    (*mat)->at<float>(1, 1) = a22;
    (*mat)->at<float>(1, 2) = a23;
    (*mat)->at<float>(2, 0) = a31;
    (*mat)->at<float>(2, 1) = a32;
    (*mat)->at<float>(2, 2) = a33;
    END_WRAP
}

// virtual Point2f warpPoint(const Point2f &pt, InputArray K, InputArray R) = 0;
API(CvPoint2D32f)
api_modules_warper_warp_point(
    cv::Point2f pt,
    cv::Mat *K,
    cv::Mat *R,
    cv::detail::RotationWarper *warper)
{
    auto point = warper->warpPoint(pt, *K, *R);
    return {point.x, point.y};
}

// virtual Point2f warpPointBackward(const Point2f& pt, InputArray K, InputArray R)
API(CvPoint2D32f)
api_modules_warper_warp_point_backward(
    cv::Point2f pt,
    cv::Mat *K,
    cv::Mat *R,
    cv::detail::RotationWarper *warper)
{
    auto point = warper->warpPointBackward(pt, *K, *R);
    return {point.x, point.y};
}

// virtual Rect buildMaps(Size src_size, InputArray K, InputArray R, OutputArray xmap, OutputArray ymap) = 0;
API(CvRect)
api_modules_warper_build_maps(
    cv::Size src_size,
    cv::_InputArray *K,
    cv::Mat *R,
    cv::Mat *xmap,
    cv::Mat *ymap,
    cv::detail::RotationWarper *warper)
{
    auto rect = warper->buildMaps(src_size, *K, *R, *xmap, *ymap);
    return {rect.x, rect.y, rect.width, rect.height};
}

// virtual Point warp(InputArray src, InputArray K, InputArray R, int interp_mode, int border_mode,
//                    CV_OUT OutputArray dst) = 0;
API(CvPoint)
api_modules_warper_warp(
    cv::Mat *src,
    cv::Mat *K,
    cv::Mat *R,
    int interp_mode,
    int border_mode,
    cv::Mat *dst,
    cv::detail::RotationWarper *warper)
{
    auto point = warper->warp(*src, *K, *R, interp_mode, border_mode, *dst);
    return {point.x, point.y};
}

// virtual void warpBackward(InputArray src, InputArray K, InputArray R, int interp_mode, int border_mode,
//                             Size dst_size, CV_OUT OutputArray dst) = 0;
API(ExceptionStatus)
api_modules_warper_warp_backward(
    cv::Mat *src,
    cv::Mat *K,
    cv::Mat *R,
    int interp_mode,
    int border_mode,
    cv::Size dst_size,
    cv::Mat *dst,
    cv::detail::RotationWarper *warper)
{
    BEGIN_WRAP;
    warper->warpBackward(*src, *K, *R, interp_mode, border_mode, dst_size, *dst);
    END_WRAP
}

// virtual Rect warpRoi(Size src_size, InputArray K, InputArray R) = 0;
API(CvRect)
api_modules_warper_warp_roi(
    cv::Size src_size,
    cv::Mat *K,
    cv::Mat *R,
    cv::detail::RotationWarper *warper)
{
    auto rect = warper->warpRoi(src_size, *K, *R);
    return {rect.x, rect.y, rect.width, rect.height};
}

// virtual float getScale() const { return 1.f; }
API(float)
api_modules_warper_get_scale(cv::detail::RotationWarper *warper)
{
    return warper->getScale();
}

// virtual void setScale(float) {}
API(ExceptionStatus)
api_modules_warper_set_scale(float scale, cv::detail::RotationWarper *warper)
{
    BEGIN_WRAP
    warper->setScale(scale);
    END_WRAP
}

#pragma endregion

#pragma region ExposureCompensator

API(ExceptionStatus)
api_modules_exposure_compensator_create(
    int type,
    cv::Ptr<cv::detail::ExposureCompensator> **compensator)
{
    BEGIN_WRAP
    *compensator = new cv::Ptr<cv::detail::ExposureCompensator>(cv::detail::ExposureCompensator::createDefault(type));
    END_WRAP
}

API(ExceptionStatus)
api_modules_exposure_compensator_get(
    cv::Ptr<cv::detail::ExposureCompensator> *compensatorPtr,
    cv::detail::ExposureCompensator **compensator)
{
    BEGIN_WRAP
    *compensator = compensatorPtr->get();
    END_WRAP
}



#pragma endregion
