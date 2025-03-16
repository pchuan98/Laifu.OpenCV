/**
 * @file context.hpp
 * @author pchuan98 (haeer98@outlook.com)
 * @brief
 * @version 0.1
 * @date 2024-10-10
 *
 * @copyright Copyright (c) 2024
 *
 */

#pragma once

#include "common.hpp"

/**
 * 原始图像
 * 各种mask
 * 曝光增益系数
 * depth
 * channels
 */

/**
 * @brief Represents the context for image stitching in panorama generation.
 *
 * This object encapsulates all the necessary data required for processing images
 * during the panorama creation process, including image metadata, alignment parameters,
 * and any additional information relevant to the stitching algorithm.
 */
class ImageContext
{
protected:
    cv::Mat src;
    double x, y;
};



