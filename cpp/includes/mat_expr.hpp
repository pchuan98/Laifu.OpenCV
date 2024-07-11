#pragma once

#include "common.hpp"

#define CVAPI_MATEXPR_FUNC_WRAP(func, lambada, ...) CVAPI_BASE_WRAPPER(api_expr_##func(__VA_ARGS__), lambada;)
#define CVAPI_MATEXPR_FUNC_WRAP_SPE(func, lambada, ...) \
    CVAPI_BASE_WRAPPER(api_expr_##func(const cv::MatExpr *obj, __VA_ARGS__), lambada;)

CVAPI_MATEXPR_FUNC_WRAP(create_by_expr, *ret = new cv::MatExpr(), cv::MatExpr **ret)
CVAPI_MATEXPR_FUNC_WRAP(create_by_mat, *ret = new cv::MatExpr(*mat), cv::Mat *mat, cv::MatExpr **ret)
CVAPI_MATEXPR_FUNC_WRAP(delete_expr, delete obj, cv::MatExpr *obj)
CVAPI_MATEXPR_FUNC_WRAP_SPE(to_mat, *ret = new cv::Mat(*obj), cv::Mat **ret)
CVAPI_MATEXPR_FUNC_WRAP_SPE(size, *ret = cvSize(obj->size()), CvSize *ret)
CVAPI_MATEXPR_FUNC_WRAP_SPE(type, *ret = obj->type(), int *ret)
CVAPI_MATEXPR_FUNC_WRAP_SPE(getRow, *ret = new cv::MatExpr(obj->row(x)), const int x, cv::MatExpr **ret)
CVAPI_MATEXPR_FUNC_WRAP_SPE(getCol, *ret = new cv::MatExpr(obj->col(y)), const int y, cv::MatExpr **ret)
CVAPI_MATEXPR_FUNC_WRAP_SPE(getDiag, *ret = new cv::MatExpr(obj->col(d)), const int d, cv::MatExpr **ret)
CVAPI_MATEXPR_FUNC_WRAP_SPE(crop_by_range, *ret = new cv::MatExpr((*obj)({rowRange.start_index, rowRange.end_index}, {colRange.start_index, colRange.end_index})), const CvSlice rowRange, const CvSlice colRange, cv::MatExpr **ret)
CVAPI_MATEXPR_FUNC_WRAP_SPE(crop_by_rect, *ret = new cv::MatExpr((*obj)(roi)), const CvRect roi, cv::MatExpr **ret)
CVAPI_MATEXPR_FUNC_WRAP_SPE(t, *ret = new cv::MatExpr(obj->t()), cv::MatExpr **ret)
CVAPI_MATEXPR_FUNC_WRAP_SPE(inv, *ret = new cv::MatExpr(obj->inv(method)), const int method, cv::MatExpr **ret)
CVAPI_MATEXPR_FUNC_WRAP_SPE(mul_with_expr, *ret = new cv::MatExpr(obj->mul(*expr, scale)), const cv::MatExpr *expr, const double scale, cv::MatExpr **ret)
CVAPI_MATEXPR_FUNC_WRAP_SPE(mul_with_mat, *ret = new cv::MatExpr(obj->mul(*expr, scale)), const cv::Mat *expr, const double scale, cv::MatExpr **ret)
CVAPI_MATEXPR_FUNC_WRAP_SPE(cross, *ret = new cv::MatExpr(obj->cross(*mat)), const cv::Mat *mat, cv::MatExpr **ret)
CVAPI_MATEXPR_FUNC_WRAP_SPE(dot, *ret = obj->dot(*mat), const cv::Mat *mat, double *ret)
