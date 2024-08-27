#pragma once

#include "common.hpp"

#define CVAPI_UMAT_WRAP(func, lambada, ...) CVAPI_BASE_WRAPPER(api_umat_##func(__VA_ARGS__), lambada);
#define CVAPI_UMAT_WRAP_CREATE(index, lambada, ...) \
    CVAPI_BASE_WRAPPER(api_umat_create##index(__VA_ARGS__, cv::UMat **ret), *ret = new cv::UMat lambada;);

CVAPI_UMAT_WRAP_CREATE(1, (flags), const cv::UMatUsageFlags flags)
CVAPI_UMAT_WRAP_CREATE(2, (rows, cols, type, flags), const int rows, const int cols, const int type, const cv::UMatUsageFlags flags)
CVAPI_UMAT_WRAP_CREATE(3, (size, type, scalar, flags), CvSize size, const int type, CvScalar scalar, const cv::UMatUsageFlags flags)

// todo add some others func

CVAPI_UMAT_WRAP_CREATE(6, (*umat), cv::UMat *umat)

CVAPI_UMAT_WRAP(delete_umat, delete obj, cv::UMat *obj)

CVAPI_UMAT_WRAP(get_mat, *ret = new cv::Mat(obj->getMat(flag)), const cv::UMat *obj, cv::AccessFlag flag, cv::Mat **ret)