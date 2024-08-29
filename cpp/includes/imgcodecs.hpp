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

API(ExceptionStatus)
api_imread(const char *filename, int flags, cv::Mat **output)
{
	BEGIN_WRAP
	const auto ret = cv::imread(filename, flags);
	*output = new cv::Mat(ret);
	END_WRAP
}

API(bool)
api_imreadmulti1(
	const char *filename,
	std::vector<cv::Mat> *mats,
	int flags)
{
	return cv::imreadmulti(filename, *mats, flags);
}

API(bool)
api_imreadmulti2(
	const char *filename,
	std::vector<cv::Mat> *mats,
	int start,
	int count,
	int flags)
{
	return cv::imreadmulti(filename, *mats, start, count, flags);
}

API(size_t)
api_imcount(const char *filename, int flags)
{
	return cv::imcount(filename);
}

API(bool)
api_imwrite(const char *filename, cv::Mat *img, const int *params, int length)
{
	std::vector<int> paramsVec;
	paramsVec.assign(params, params + length);
	return cv::imwrite(filename, *img, paramsVec);
}

API(bool)
api_imwritemulti(const char *filename, std::vector<cv::Mat> *mats, const int *params, int length)
{
	std::vector<int> paramsVec;
	paramsVec.assign(params, params + length);
	return cv::imwritemulti(filename, *mats, paramsVec);
}

API(ExceptionStatus)
api_imdecode1(const cv::Mat *buf, int flags, cv::Mat **output)
{
	BEGIN_WRAP
	const auto ret = cv::imdecode(*buf, flags);
	*output = new cv::Mat(ret);
	END_WRAP
}

API(ExceptionStatus)
api_imdecode2(const cv::_InputArray *buf, int flags, cv::Mat **output)
{
	BEGIN_WRAP
	const auto ret = cv::imdecode(*buf, flags);
	*output = new cv::Mat(ret);
	END_WRAP
}

API(ExceptionStatus)
api_imdecode3(uchar *buf, size_t length, int flags, cv::Mat **output)
{
	BEGIN_WRAP
	const auto ret = cv::imdecode(cv::Mat(1, length, CV_8UC1, buf, cv::Mat::AUTO_STEP), flags);
	*output = new cv::Mat(ret);
	END_WRAP
}

API(bool)
api_imdecodemulti1(const cv::_InputArray *buf, int flags, std::vector<cv::Mat> mats)
{
	return cv::imdecodemulti(*buf, flags, mats);
}

API(bool)
api_imdecodemulti2(uchar *buf, size_t length, int flags, std::vector<cv::Mat> mats)
{
	return cv::imdecodemulti(cv::Mat(1, length, CV_8UC1, buf, cv::Mat::AUTO_STEP), flags, mats);
}

API(bool)
api_imencode(const char *ext, cv::_InputArray *img, std::vector<uchar> *buf, const int *params, int length)
{
	std::vector<int> paramsVec;
	if (params != nullptr)
		paramsVec = std::vector<int>(params, params + length);
	return cv::imencode(ext, *img, *buf, paramsVec);
}

API(bool)
api_haveImageReader(const char *filename)
{
	return cv::haveImageReader(filename);
}

API(bool)
api_haveImageWriter(const char *filename)
{
	return cv::haveImageWriter(filename);
}