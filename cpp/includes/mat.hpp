#pragma once

#include "common.hpp"

#define CVAPI_MAT_FUNC_WRAP(func, lambada, ...) CVAPI_BASE_WRAPPER(api_mat_##func(__VA_ARGS__), lambada);

#define CVAPI_MAT_CREATE_WRAP(func, lambada, ...) \
    CVAPI_BASE_WRAPPER(api_mat_##func(__VA_ARGS__, cv::Mat **ret), *ret = new cv::Mat lambada;)

#define CVAPI_MAT_WRAP_RET_EXPR(func, lambada, ...) \
    CVAPI_BASE_WRAPPER(api_mat_##func(__VA_ARGS__, cv::MatExpr **ret), *ret = new cv::MatExpr lambada;)

#define CVAPI_MAT_FIELD_WRAP(func, type, lambada, ...) \
    CVAPI(type)                                        \
    api_mat_##func(const cv::Mat *obj, __VA_ARGS__) { return lambada; }

#define CVAPI_MAT_METHOD_WRAP(func, lambada, ...) \
    CVAPI_BASE_WRAPPER(api_mat_##func(const cv::Mat *obj, __VA_ARGS__, cv::Mat **ret), *ret = lambada;)

CVAPI_MAT_FUNC_WRAP(create1, *ret = new cv::Mat, cv::Mat **ret)

CVAPI_MAT_CREATE_WRAP(create2, (rows, cols, type), const int rows, const int cols, const int type)
CVAPI_MAT_CREATE_WRAP(create3, (rows, cols, type, scalar), const int rows, const int cols, const int type, const CvScalar scalar)
CVAPI_MAT_CREATE_WRAP(create4, (ndims, sizes, type), const int ndims, const int *sizes, const int type)
CVAPI_MAT_CREATE_WRAP(create5, (ndims, sizes, type, static_cast<cv::Scalar>(scalar)), const int ndims, const int *sizes, const int type, CvScalar scalar)
CVAPI_MAT_CREATE_WRAP(create6, (*mat), const cv::Mat *mat)
CVAPI_MAT_CREATE_WRAP(create7, (rows, cols, type, data, step), const int rows, const int cols, const int type, void *data, const size_t step)
CVAPI_MAT_CREATE_WRAP(create8, (ndims, sizes, type, data, steps), const int ndims, const int *sizes, const int type, void *data, const size_t *steps)
CVAPI_MAT_CREATE_WRAP(create9, (*mat, {rowRange.start_index, rowRange.end_index}, {colRange.start_index, colRange.end_index}), const cv::Mat *mat, const CvSlice rowRange, const CvSlice colRange)
CVAPI_MAT_CREATE_WRAP(create10, (*mat, static_cast<cv::Rect>(roi)), const cv::Mat *mat, const CvRect roi)
CVAPI_MAT_CREATE_WRAP(create11, (*mat, ranges), const cv::Mat *mat, const cv::Range *ranges)

CVAPI_MAT_FUNC_WRAP(delete, delete obj, cv::Mat *obj)

CVAPI_MAT_FIELD_WRAP(flags, int, obj->flags)
CVAPI_MAT_FIELD_WRAP(dims, int, obj->dims)
CVAPI_MAT_FIELD_WRAP(rows, int, obj->rows)
CVAPI_MAT_FIELD_WRAP(cols, int, obj->cols)
CVAPI_MAT_FIELD_WRAP(total, uchar *, obj->data)
CVAPI_MAT_FIELD_WRAP(size, CvSize, cvSize(obj->size()))
CVAPI_MAT_FUNC_WRAP(size_at, *ret = obj->size[dims], const cv::Mat *obj, const int dims, int *ret)
CVAPI_MAT_FIELD_WRAP(step, size_t, obj->step)
CVAPI_MAT_FUNC_WRAP(step_at, *ret = obj->step[dims], const cv::Mat *obj, const int dims, size_t *ret)

CVAPI_MAT_METHOD_WRAP(row, new cv::Mat(obj->row(y)), const int y)
CVAPI_MAT_METHOD_WRAP(col, new cv::Mat(obj->col(x)), const int x)
CVAPI_MAT_METHOD_WRAP(row_range1, new cv::Mat(obj->rowRange(start, end)), const int start, const int end)
CVAPI_MAT_METHOD_WRAP(row_range2, new cv::Mat(obj->rowRange(range)), const cv::Range range)
CVAPI_MAT_METHOD_WRAP(col_range1, new cv::Mat(obj->colRange(start, end)), const int start, const int end)
CVAPI_MAT_METHOD_WRAP(col_range2, new cv::Mat(obj->colRange(range)), const cv::Range range)
CVAPI_MAT_METHOD_WRAP(diag, new cv::Mat(obj->diag(d)), const int d)
CVAPI_MAT_FUNC_WRAP(clone, *ret = new cv::Mat(obj->clone()), const cv::Mat *obj, cv::Mat **ret)

CVAPI_MAT_FUNC_WRAP(copy_to1, obj->copyTo(*dst), const cv::Mat *obj, const cv::_OutputArray *dst)
CVAPI_MAT_FUNC_WRAP(copy_to2, obj->copyTo(*dst, *mask), const cv::Mat *obj, cv::_OutputArray *dst, const cv::_InputArray *mask)

CVAPI_MAT_FUNC_WRAP(converter_to, obj->convertTo(*mat, rtype, alpha, beta), const cv::Mat *obj, cv::_OutputArray *mat, int rtype, double alpha, double beta)
CVAPI_MAT_FUNC_WRAP(assign_to, obj->assignTo(*mat, type), const cv::Mat *obj, cv::Mat *mat, int type)

CVAPI_MAT_FUNC_WRAP(set_to1, obj->setTo(*value, ((mask != nullptr) ? *mask : static_cast<cv::_InputArray>(cv::noArray()))), cv::Mat *obj, const cv::_InputArray *value, cv::_InputArray *mask)
CVAPI_MAT_FUNC_WRAP(set_to2, obj->setTo(static_cast<cv::Scalar>(value), ((mask != nullptr) ? *mask : static_cast<cv::_InputArray>(cv::noArray()))), cv::Mat *obj, const CvScalar value, cv::_InputArray *mask)
