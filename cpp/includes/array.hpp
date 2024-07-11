#pragma once

#include "common.hpp"

#define CVAPI_ARRAY_FUNC_WRAP(func, lambada, ...) CVAPI_BASE_WRAPPER(api_array_##func(__VA_ARGS__), lambada;)

CVAPI_ARRAY_FUNC_WRAP(create_input_by_mat, *ret = new cv::_InputArray(*mat), cv::Mat *mat, cv::_InputArray **ret)
CVAPI_ARRAY_FUNC_WRAP(create_input_by_matexpr, *ret = new cv::_InputArray(*matExpr), cv::MatExpr *matExpr, cv::_InputArray **ret)
CVAPI_ARRAY_FUNC_WRAP(delete_input, delete obj, cv::_InputArray *obj)

CVAPI_ARRAY_FUNC_WRAP(create_output_by_mat, *ret = new cv::_OutputArray(*mat), cv::Mat *mat, cv::_OutputArray **ret)
CVAPI_ARRAY_FUNC_WRAP(delete_output, delete obj, cv::_OutputArray *obj)

CVAPI_ARRAY_FUNC_WRAP(create_inputoutput_by_mat, *ret = new cv::_InputOutputArray(*mat), cv::Mat *mat, cv::_InputOutputArray **ret)
CVAPI_ARRAY_FUNC_WRAP(delete_inputoutput, delete obj, cv::_InputOutputArray *obj)
