/**
 * @file imgcodecs.hpp
 * @author chuan (haeer98@outlook.com)
 * @brief Methods for reading and writing images
 * @version 0.1
 * @date 2024-08-27
 *
 * @copyright Copyright (c) 2024
 *
 */

#pragma once

#include "common.hpp"

#include <opencv2/imgcodecs.hpp>

CVAPI(ExceptionStatus)
imread(const char *filename, int flags, cv::Mat **output)
{
    BEGIN_WRAP;
    const auto ret = cv::imread(filename, flags);
    *output = new cv::Mat(ret);

    END_WRAP;
}

CVAPI(bool)
imreadmulti(
    const char *filename,
    int flags,
    std::vector<cv::Mat> *mats)
{
    return cv::imreadmulti(filename, *mats, flags);
}