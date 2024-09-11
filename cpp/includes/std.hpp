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
#include <iostream>

API(ExceptionStatus)
std_delete(void *obj)
{
	BEGIN_WRAP
	delete obj;
	END_WRAP
}

#pragma region Vector of KeyPoint

API(ExceptionStatus)
std_vec_kp_new1(std::vector<cv::KeyPoint> **out)
{
	BEGIN_WRAP
	*out = new std::vector<cv::KeyPoint>();
	END_WRAP
}

API(ExceptionStatus)
std_vec_kp_new2(int size, std::vector<cv::KeyPoint> **out)
{
	BEGIN_WRAP
	*out = new std::vector<cv::KeyPoint>(size);
	END_WRAP
}

API(ExceptionStatus)
std_vec_kp_new3(KeyPoint points[], int size, std::vector<cv::KeyPoint> **out)
{
	BEGIN_WRAP
	*out = new std::vector<cv::KeyPoint>(points, points + size);
	END_WRAP
}

API(ExceptionStatus)
std_vec_kp_new4(std::vector<cv::KeyPoint> *ptr, std::vector<cv::KeyPoint> **out)
{
	BEGIN_WRAP
	*out = new std::vector<cv::KeyPoint>(*ptr);
	END_WRAP
}

API(int)
std_vec_kp_size(std::vector<cv::KeyPoint> *vec)
{
	return vec->size();
}

API(void *)
std_vec_kp_pointer(std::vector<cv::KeyPoint> *vec)
{
	return vec->data();
}

API(void)
std_vec_kp_test1(std::vector<cv::KeyPoint> *keypoints)
{
	std::cout << keypoints->size() << std::endl;
	std::cout << keypoints->at(0).pt << "\t"
			  << keypoints->at(0).size << "\t"
			  << keypoints->at(0).angle << "\t"
			  << keypoints->at(0).response << "\t"
			  << keypoints->at(0).octave << "\t"
			  << keypoints->at(0).class_id << std::endl;
	std::cout << keypoints->at(keypoints->size() - 1).pt << "\t"
			  << keypoints->at(keypoints->size() - 1).size << "\t"
			  << keypoints->at(keypoints->size() - 1).angle << "\t"
			  << keypoints->at(keypoints->size() - 1).response << "\t"
			  << keypoints->at(keypoints->size() - 1).octave << "\t"
			  << keypoints->at(keypoints->size() - 1).class_id << std::endl;
}

API(void)
std_vec_kp_test2(std::vector<cv::KeyPoint> **output)
{
	auto vec = new std::vector<cv::KeyPoint>();
	vec->push_back(cv::KeyPoint(1, 2, 3, 4, 5, 6, 7));
	vec->push_back(cv::KeyPoint(8, 9, 10, 11, 12, 13, 14));
	*output = vec;
}

#pragma endregion

#pragma region Vector of DMatch

API(ExceptionStatus)
std_vec_dm_new1(std::vector<cv::DMatch> **out)
{
	BEGIN_WRAP
	*out = new std::vector<cv::DMatch>();
	END_WRAP
}

API(ExceptionStatus)
std_vec_dm_new2(int size, std::vector<cv::DMatch> **out)
{
	BEGIN_WRAP
	*out = new std::vector<cv::DMatch>(size);
	END_WRAP
}

API(ExceptionStatus)
std_vec_dm_new3(cv::DMatch matches[], int size, std::vector<cv::DMatch> **out)
{
	BEGIN_WRAP
	*out = new std::vector<cv::DMatch>(matches, matches + size);
	END_WRAP
}

API(ExceptionStatus)
std_vec_dm_new4(std::vector<cv::DMatch> *ptr, std::vector<cv::DMatch> **out)
{
	BEGIN_WRAP
	*out = new std::vector<cv::DMatch>(*ptr);
	END_WRAP
}

API(int)
std_vec_dm_size(std::vector<cv::DMatch> *vec)
{
	return vec->size();
}

API(void *)
std_vec_dm_pointer(std::vector<cv::DMatch> *vec)
{
	return vec->data();
}

#pragma endregion

#pragma region Vector of uchar

API(ExceptionStatus)
std_vec_uchar_new1(std::vector<uchar> **out)
{
	BEGIN_WRAP
	*out = new std::vector<uchar>();
	END_WRAP
}

API(ExceptionStatus)
std_vec_uchar_new2(int size, std::vector<uchar> **out)
{
	BEGIN_WRAP
	*out = new std::vector<uchar>(size);
	END_WRAP
}

API(ExceptionStatus)
std_vec_uchar_new3(uchar values[], int size, std::vector<uchar> **out)
{
	BEGIN_WRAP
	*out = new std::vector<uchar>(values, values + size);
	END_WRAP
}

API(ExceptionStatus)
std_vec_uchar_new4(std::vector<uchar> *ptr, std::vector<uchar> **out)
{
	BEGIN_WRAP
	*out = new std::vector<uchar>(*ptr);
	END_WRAP
}

API(int)
std_vec_uchar_size(std::vector<uchar> *vec)
{
	return vec->size();
}

API(void *)
std_vec_uchar_pointer(std::vector<uchar> *vec)
{
	return vec->data();
}

#pragma endregion

#pragma region Vector of int

API(ExceptionStatus)
std_vec_int_new1(std::vector<int> **out)
{
	BEGIN_WRAP
	*out = new std::vector<int>();
	END_WRAP
}

API(ExceptionStatus)
std_vec_int_new2(int size, std::vector<int> **out)
{
	BEGIN_WRAP
	*out = new std::vector<int>(size);
	END_WRAP
}

API(ExceptionStatus)
std_vec_int_new3(int values[], int size, std::vector<int> **out)
{
	BEGIN_WRAP
	*out = new std::vector<int>(values, values + size);
	END_WRAP
}

API(ExceptionStatus)
std_vec_int_new4(std::vector<int> *ptr, std::vector<int> **out)
{
	BEGIN_WRAP
	*out = new std::vector<int>(*ptr);
	END_WRAP
}

API(int)
std_vec_int_size(std::vector<int> *vec)
{
	return vec->size();
}

API(void *)
std_vec_int_pointer(std::vector<int> *vec)
{
	return vec->data();
}

#pragma endregion
