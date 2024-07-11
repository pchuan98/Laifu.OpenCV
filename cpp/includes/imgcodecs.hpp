#pragma once

#include "common.hpp"
#include <opencv2/imgcodecs.hpp>
#include <iostream>

CVAPI(ExceptionStatus)
api_imgcodecs_imread(const char *filename, int flags, cv::Mat **output)
{
    BEGIN_WRAP;
    const auto ret = cv::imread(filename, flags);
    *output = new cv::Mat(ret);

    std::cout << &ret << std::endl;
    std::cout << *output << std::endl;
    std::cout << output << std::endl;

    END_WRAP;
}
