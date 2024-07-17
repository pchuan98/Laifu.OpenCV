#pragma once

#include "common.hpp"
#include <opencv2/imgproc.hpp>

CVAPI(ExceptionStatus)
api_imgproc_resize(
    cv::_InputArray *src,
    cv::_OutputArray *dst,
    CvSize dsize,
    double fx,
    double fy,
    int interpolation)
{
    BEGIN_WRAP;
    cv::resize(*src, *dst, {dsize.width, dsize.height}, fx, fy, interpolation);
    END_WRAP;
}