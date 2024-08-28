/**
 * @file std.hpp
 * @author chuan (haeer98@outlook.com)
 * @brief
 * @version 0.1
 * @date 2024-08-27
 *
 * @copyright Copyright (c) 2024
 *
 */

#pragma once

#include "common.hpp"
#include <opencv2/core.hpp>
#include <opencv2/core/types_c.h>
#include <opencv2/aruco.hpp>
#include <opencv2/aruco/charuco.hpp>
#include <opencv2/bgsegm.hpp>
#include <opencv2/img_hash.hpp>
#include <opencv2/line_descriptor.hpp>
#include <opencv2/optflow.hpp>
#include <opencv2/quality.hpp>
#include <opencv2/tracking.hpp>
#include <opencv2/xfeatures2d.hpp>
#include <opencv2/ximgproc.hpp>
#include <opencv2/xphoto.hpp>

CVAPI(ExceptionStatus)
del(void *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

CVAPI(std::vector<cv::Mat> *)
mats()
{
    return new std::vector<cv::Mat>();
}

CVAPI(void)
index(std::vector<cv::Mat> *mats, int i, cv::Mat **mat)
{
    // *mat = new cv::Mat(mats->at(i));

    // mats->at(i).assignTo(**mat);
}