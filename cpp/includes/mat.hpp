#pragma once

#include "common.hpp"

#define CVAPI_MAT_WRAP(func, lambada, ...) CVAPI_BASE_WRAPPER(api_mat_##func(__VA_ARGS__), lambada);

#define CVAPI_MAT_WRAP_CREATE(func, lambada, ...) \
    CVAPI_BASE_WRAPPER(api_mat_##func(__VA_ARGS__, cv::Mat **ret), *ret = new cv::Mat lambada;)

#define CVAPI_MAT_WRAP_RET_EXPR(func, lambada, ...) \
    CVAPI_BASE_WRAPPER(api_mat_##func(__VA_ARGS__, cv::MatExpr **ret), *ret = new cv::MatExpr lambada;)

#define CVAPI_MAT_WRAP_FIELD(func, type, lambada, ...) \
    CVAPI(type)                                        \
    api_mat_##func(const cv::Mat *obj, __VA_ARGS__) { return lambada; }

#define CVAPI_MAT_WRAP_METHOD(func, lambada, ...) \
    CVAPI_BASE_WRAPPER(api_mat_##func(const cv::Mat *obj, __VA_ARGS__, cv::Mat **ret), *ret = lambada;)

CVAPI_MAT_WRAP(create1, *ret = new cv::Mat, cv::Mat **ret)

CVAPI_MAT_WRAP_CREATE(create2, (rows, cols, type), const int rows, const int cols, const int type)
CVAPI_MAT_WRAP_CREATE(create3, (rows, cols, type, scalar), const int rows, const int cols, const int type, const CvScalar scalar)
CVAPI_MAT_WRAP_CREATE(create4, (ndims, sizes, type), const int ndims, const int *sizes, const int type)
CVAPI_MAT_WRAP_CREATE(create5, (ndims, sizes, type, static_cast<cv::Scalar>(scalar)), const int ndims, const int *sizes, const int type, CvScalar scalar)
CVAPI_MAT_WRAP_CREATE(create6, (*mat), const cv::Mat *mat)
CVAPI_MAT_WRAP_CREATE(create7, (rows, cols, type, data, step), const int rows, const int cols, const int type, void *data, const size_t step)
CVAPI_MAT_WRAP_CREATE(create8, (ndims, sizes, type, data, steps), const int ndims, const int *sizes, const int type, void *data, const size_t *steps)
CVAPI_MAT_WRAP_CREATE(create9, (*mat, {rowRange.start_index, rowRange.end_index}, {colRange.start_index, colRange.end_index}), const cv::Mat *mat, const CvSlice rowRange, const CvSlice colRange)
CVAPI_MAT_WRAP_CREATE(create10, (*mat, static_cast<cv::Rect>(roi)), const cv::Mat *mat, const CvRect roi)
CVAPI_MAT_WRAP_CREATE(create11, (*mat, ranges), const cv::Mat *mat, const cv::Range *ranges)

CVAPI_MAT_WRAP(delete_mat, delete obj, cv::Mat *obj)

CVAPI_MAT_WRAP_FIELD(flags, int, obj->flags)
CVAPI_MAT_WRAP_FIELD(dims, int, obj->dims)
CVAPI_MAT_WRAP_FIELD(rows, int, obj->rows)
CVAPI_MAT_WRAP_FIELD(cols, int, obj->cols)
CVAPI_MAT_WRAP_FIELD(total, uchar *, obj->data)
CVAPI_MAT_WRAP_FIELD(size, CvSize, cvSize(obj->size()))
CVAPI_MAT_WRAP(size_at, *ret = obj->size[dims], const cv::Mat *obj, const int dims, int *ret)
CVAPI_MAT_WRAP_FIELD(step, size_t, obj->step)
CVAPI_MAT_WRAP(step_at, *ret = obj->step[dims], const cv::Mat *obj, const int dims, size_t *ret)

CVAPI_MAT_WRAP_METHOD(row, new cv::Mat(obj->row(y)), const int y)
CVAPI_MAT_WRAP_METHOD(col, new cv::Mat(obj->col(x)), const int x)
CVAPI_MAT_WRAP_METHOD(row_range1, new cv::Mat(obj->rowRange(start, end)), const int start, const int end)
CVAPI_MAT_WRAP_METHOD(row_range2, new cv::Mat(obj->rowRange(range)), const cv::Range range)
CVAPI_MAT_WRAP_METHOD(col_range1, new cv::Mat(obj->colRange(start, end)), const int start, const int end)
CVAPI_MAT_WRAP_METHOD(col_range2, new cv::Mat(obj->colRange(range)), const cv::Range range)
CVAPI_MAT_WRAP_METHOD(diag, new cv::Mat(obj->diag(d)), const int d)
CVAPI_MAT_WRAP(clone, *ret = new cv::Mat(obj->clone()), const cv::Mat *obj, cv::Mat **ret)

CVAPI_MAT_WRAP(copy_to1, obj->copyTo(*dst), const cv::Mat *obj, const cv::_OutputArray *dst)
CVAPI_MAT_WRAP(copy_to2, obj->copyTo(*dst, *mask), const cv::Mat *obj, cv::_OutputArray *dst, const cv::_InputArray *mask)

CVAPI_MAT_WRAP(converter_to, obj->convertTo(*mat, rtype, alpha, beta), const cv::Mat *obj, cv::_OutputArray *mat, int rtype, double alpha, double beta)
CVAPI_MAT_WRAP(assign_to, obj->assignTo(*mat, type), const cv::Mat *obj, cv::Mat *mat, int type)

CVAPI_MAT_WRAP(set_to1, obj->setTo(*value, ((mask != nullptr) ? *mask : static_cast<cv::_InputArray>(cv::noArray()))), cv::Mat *obj, const cv::_InputArray *value, cv::_InputArray *mask)
CVAPI_MAT_WRAP(set_to2, obj->setTo(static_cast<cv::Scalar>(value), ((mask != nullptr) ? *mask : static_cast<cv::_InputArray>(cv::noArray()))), cv::Mat *obj, const CvScalar value, cv::_InputArray *mask)