#pragma once

#include "common.hpp"

CVAPI(cv::ErrorCallback)
core_redirectError(cv::ErrorCallback errCallback, void *userData, void **prevUserData)
{
    return cv::redirectError(errCallback, userData, prevUserData);
}

CVAPI(ExceptionStatus)
core_getTickCount(int64 *result)
{
    BEGIN_WRAP;
    *result = cv::getTickCount();
    END_WRAP;
}

CVAPI(ExceptionStatus)
core_getBuildInformation(std::string *buffer)
{
    BEGIN_WRAP;
    buffer->assign(cv::getBuildInformation());
    END_WRAP;
}

CVAPI(ExceptionStatus)
core_getVersionString(std::string *buffer)
{
    BEGIN_WRAP;
    buffer->assign(cv::getVersionString());
    END_WRAP;
}

CVAPI(ExceptionStatus)
core_format(
    const cv::_InputArray *mtx, int fmt, std::string *buffer)
{
    BEGIN_WRAP;
    const auto formatted = cv::format(*mtx, static_cast<cv::Formatter::FormatType>(fmt));

    std::stringstream s;
    s << formatted;
    buffer->assign(s.str());
    END_WRAP;
}

CVAPI(ExceptionStatus)
core_compare(
    const cv::_InputArray *src1, const cv::_InputArray *src2, const cv::_OutputArray *dst, const int cmpop)
{
    BEGIN_WRAP;
    cv::compare(*src1, *src2, *dst, cmpop);
    END_WRAP;
}

CVAPI(ExceptionStatus)
core_countNonZero(const cv::_InputArray *src, int *result)
{
    BEGIN_WRAP;
    *result = cv::countNonZero(*src);
    END_WRAP;
}

CVAPI(ExceptionStatus)
core_split(
    const cv::Mat *src, std::vector<cv::Mat> *mv)
{
    BEGIN_WRAP;
    cv::split(*src, *mv);
    END_WRAP;
}