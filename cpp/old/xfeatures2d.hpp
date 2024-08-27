#pragma once

#include "common.hpp"
#include "opencv2/features2d.hpp"

// surf
CVAPI(ExceptionStatus)
api_xfd_create_surf(int hessianThreshold, int nOctaves, int nOctaveLayers,
                    bool extended, bool upright, cv::Ptr<cv::xfeatures2d::SURF> **surf)
{
    BEGIN_WRAP
    const auto ptr = cv::xfeatures2d::SURF::create(hessianThreshold, nOctaves, nOctaveLayers, extended, upright);
    *surf = new cv::Ptr<cv::xfeatures2d::SURF>(ptr);
    END_WRAP
}