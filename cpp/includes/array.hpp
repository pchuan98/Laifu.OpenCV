#pragma once

#include "common.hpp"

#define CVAPI_ARRAY_FUNC_WRAP(func, lambada, ...) CVAPI_BASE_WRAPPER(api_array_##func(__VA_ARGS__), lambada;)

CVAPI_ARRAY_FUNC_WRAP(input_create_by_mat, *ret = new cv::_InputArray(*mat), cv::Mat *mat, cv::_InputArray **ret)
CVAPI_ARRAY_FUNC_WRAP(input_create_by_matexpr, *ret = new cv::_InputArray(*matExpr), cv::MatExpr *matExpr, cv::_InputArray **ret)
CVAPI_ARRAY_FUNC_WRAP(input_delete, delete obj, cv::_InputArray *obj)
CVAPI_ARRAY_FUNC_WRAP(input_get_mat, *ret = new cv::Mat(obj->getMat(idx)), cv::_InputArray *obj, int idx, cv::Mat **ret)

CVAPI_ARRAY_FUNC_WRAP(output_create_by_mat, *ret = new cv::_OutputArray(*mat), cv::Mat *mat, cv::_OutputArray **ret)
CVAPI_ARRAY_FUNC_WRAP(output_delete, delete obj, cv::_OutputArray *obj)

CVAPI_ARRAY_FUNC_WRAP(inputoutput_create_by_mat, *ret = new cv::_InputOutputArray(*mat), cv::Mat *mat, cv::_InputOutputArray **ret)
CVAPI_ARRAY_FUNC_WRAP(inputoutput_delete, delete obj, cv::_InputOutputArray *obj)
