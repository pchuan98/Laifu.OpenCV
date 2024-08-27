#pragma once

#include "common.hpp"
#include "opencv2/features2d.hpp"

// orb,akaze,sift

CVAPI(ExceptionStatus)
api_fd_create_orb(int nfeatures, float scaleFactor, int nlevels,
                  int edgeThreshold, int firstLevel, int WTA_K,
                  int scoreType, int patchSize, int fastThreshold,
                  cv::Ptr<cv::ORB> **orb)
{
    BEGIN_WRAP
    const auto ptr = cv::ORB::create(nfeatures, scaleFactor, nlevels,
                                     edgeThreshold, firstLevel, WTA_K,
                                     static_cast<cv::ORB::ScoreType>(scoreType), patchSize, fastThreshold);
    *orb = new cv::Ptr<cv::ORB>(ptr);
    END_WRAP
} // todo others function

CVAPI(ExceptionStatus)
api_fd_create_akaze(int descriptor_type, int descriptor_size, int descriptor_channels,
                    float threshold, int nOctaves, int nOctaveLayers, int diffusivity,
                    int max_points, cv::Ptr<cv::AKAZE> **akaze)
{
    BEGIN_WRAP
    const auto ptr = cv::AKAZE::create(static_cast<cv::AKAZE::DescriptorType>(descriptor_type), descriptor_size, descriptor_channels,
                                       threshold, nOctaves, nOctaveLayers, static_cast<cv::KAZE::DiffusivityType>(diffusivity), max_points);
    *akaze = new cv::Ptr<cv::AKAZE>(ptr);
    END_WRAP
} // todo others function

CVAPI(ExceptionStatus)
api_fd_create_sift(int nfeatures, int nOctaveLayers, double contrastThreshold,
                   double edgeThreshold, double sigma, bool enable_precise_upscale, cv::Ptr<cv::SIFT> **sift)
{
    BEGIN_WRAP
    const auto ptr = cv::SIFT::create(nfeatures, nOctaveLayers, contrastThreshold,
                                      edgeThreshold, sigma, enable_precise_upscale);
    *sift = new cv::Ptr<cv::SIFT>(ptr);
    END_WRAP
} // todo others function