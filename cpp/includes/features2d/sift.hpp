/**
 * @file sift.hpp
 * @author pchuan98 (haeer98@outlook.com)
 * @brief
 * @version 0.1
 * @date 2024-09-02
 *
 * @copyright Copyright (c) 2024
 *
 */

#pragma once

#include "common.hpp"
#include "opencv2/features2d.hpp"

// CV_WRAP static Ptr<SIFT> create(int nfeatures, int nOctaveLayers,
//     double contrastThreshold, double edgeThreshold,
//     double sigma, int descriptorType, bool enable_precise_upscale = false);

API(ExceptionStatus)
api_sift_create(
    int nfeatures, int nOctaveLayers,
    double contrastThreshold, double edgeThreshold, double sigma,
    cv::Ptr<cv::SIFT> **output)
{
    BEGIN_WRAP
    const auto ptr = cv::SIFT::create(
        nfeatures, nOctaveLayers, contrastThreshold, edgeThreshold, sigma);
    *output = clone(ptr);
    END_WRAP
}

CVAPI(ExceptionStatus)
api_sift_ptr_get(cv::Ptr<cv::SIFT> *ptr, cv::SIFT **output)
{
    BEGIN_WRAP
    *output = ptr->get();
    END_WRAP
}

// CV_WRAP virtual String getDefaultName() const CV_OVERRIDE;

// CV_WRAP virtual void setNFeatures(int maxFeatures) = 0;
// CV_WRAP virtual int getNFeatures() const = 0;

// CV_WRAP virtual void setNOctaveLayers(int nOctaveLayers) = 0;
// CV_WRAP virtual int getNOctaveLayers() const = 0;

// CV_WRAP virtual void setContrastThreshold(double contrastThreshold) = 0;
// CV_WRAP virtual double getContrastThreshold() const = 0;

// CV_WRAP virtual void setEdgeThreshold(double edgeThreshold) = 0;
// CV_WRAP virtual double getEdgeThreshold() const = 0;

// CV_WRAP virtual void setSigma(double sigma) = 0;
// CV_WRAP virtual double getSigma() const = 0;
