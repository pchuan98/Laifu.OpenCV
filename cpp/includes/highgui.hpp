/**
 * @file highgui.hpp
 * @author chuan (haeer98@outlook.com)
 * @brief Methods for showing images with GUI (controls and window)
 * @version 0.1
 * @date 2024-08-27
 *
 * @copyright Copyright (c) 2024
 *
 */

#pragma once

#include "common.hpp"

#include <opencv2/highgui.hpp>

CVAPI(ExceptionStatus)
waitkey(int delay, int *ret)
{
    BEGIN_WRAP
    *ret = cv::waitKey(delay);
    END_WRAP
}

CVAPI(ExceptionStatus)
imshow(const char *winname, cv::Mat *mat)
{
    BEGIN_WRAP
    cv::imshow(winname, *mat);
    END_WRAP
}