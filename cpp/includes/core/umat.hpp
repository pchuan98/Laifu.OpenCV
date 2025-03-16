/**
 * @file umat.hpp
 * @author pchuan98 (haeer98@outlook.com)
 * @brief
 * @version 0.1
 * @date 2024-08-30
 *
 * @copyright Copyright (c) 2024
 *
 */

#pragma once

#include "common.hpp"

// UMat(UMatUsageFlags usageFlags = USAGE_DEFAULT) CV_NOEXCEPT;
API(ExceptionStatus)
api_umat_new1(int usageFlags, cv::UMat **output)
{
    BEGIN_WRAP
    *output = new cv::UMat((cv::UMatUsageFlags)usageFlags);
    END_WRAP
}

// UMat(int rows, int cols, int type, UMatUsageFlags usageFlags = USAGE_DEFAULT);
API(ExceptionStatus)
api_umat_new2(int rows, int cols, int type, int usageFlags, cv::UMat **output)
{
    BEGIN_WRAP
    *output = new cv::UMat(rows, cols, type, (cv::UMatUsageFlags)usageFlags);
    END_WRAP
}

// UMat(Size size, int type, UMatUsageFlags usageFlags = USAGE_DEFAULT);
API(ExceptionStatus)
api_umat_new3(cv::Size size, int type, int usageFlags, cv::UMat **output)
{
    BEGIN_WRAP
    *output = new cv::UMat(size, type, (cv::UMatUsageFlags)usageFlags);
    END_WRAP
}

// UMat(int rows, int cols, int type, const Scalar& s, UMatUsageFlags usageFlags = USAGE_DEFAULT);
API(ExceptionStatus)
api_umat_new4(int rows, int cols, int type, cv::Scalar s, int usageFlags, cv::UMat **output)
{
    BEGIN_WRAP
    *output = new cv::UMat(rows, cols, type, s, (cv::UMatUsageFlags)usageFlags);
    END_WRAP
}

// UMat(Size size, int type, const Scalar& s, UMatUsageFlags usageFlags = USAGE_DEFAULT);
API(ExceptionStatus)
api_umat_new5(cv::Size size, int type, cv::Scalar s, int usageFlags, cv::UMat **output)
{
    BEGIN_WRAP
    *output = new cv::UMat(size, type, s, (cv::UMatUsageFlags)usageFlags);
    END_WRAP
}

// UMat(int ndims, const int* sizes, int type, UMatUsageFlags usageFlags = USAGE_DEFAULT);
API(ExceptionStatus)
api_umat_new6(int ndims, const int *sizes, int type, int usageFlags, cv::UMat **output)
{
    BEGIN_WRAP
    *output = new cv::UMat(ndims, sizes, type, (cv::UMatUsageFlags)usageFlags);
    END_WRAP
}

// UMat(int ndims, const int* sizes, int type, const Scalar& s, UMatUsageFlags usageFlags = USAGE_DEFAULT);
API(ExceptionStatus)
api_umat_new7(int ndims, const int *sizes, int type, cv::Scalar s, int usageFlags, cv::UMat **output)
{
    BEGIN_WRAP
    *output = new cv::UMat(ndims, sizes, type, s, (cv::UMatUsageFlags)usageFlags);
    END_WRAP
}

// UMat(const UMat& m);
API(ExceptionStatus)
api_umat_new8(cv::UMat *m, cv::UMat **output)
{
    BEGIN_WRAP
    *output = new cv::UMat(*m);
    END_WRAP
}

// UMat(const UMat& m, const Range& rowRange, const Range& colRange=Range::all());
API(ExceptionStatus)
api_umat_new9(cv::UMat *m, cv::Range rowRange, cv::Range colRange, cv::UMat **output)
{
    BEGIN_WRAP
    *output = new cv::UMat(*m, rowRange, colRange);
    END_WRAP
}

// UMat(const UMat& m, const Rect& roi);
API(ExceptionStatus)
api_umat_new10(cv::UMat *m, cv::Rect roi, cv::UMat **output)
{
    BEGIN_WRAP
    *output = new cv::UMat(*m, roi);
    END_WRAP
}

// UMat(const UMat& m, const Range* ranges);
API(ExceptionStatus)
api_umat_new11(cv::UMat *m, cv::Range ranges[], cv::UMat **output)
{
    BEGIN_WRAP
    *output = new cv::UMat(*m, *ranges);
    END_WRAP
}

// UMat(const UMat& m, const std::vector<Range>& ranges);
API(ExceptionStatus)
api_umat_new12(cv::UMat *m, std::vector<cv::Range> *ranges, cv::UMat **output)
{
    BEGIN_WRAP
    *output = new cv::UMat(*m, *ranges);
    END_WRAP
}

// UMat& operator = (const UMat& m);

// Mat getMat(AccessFlag flags) const;
API(ExceptionStatus)
api_umat_getMat(cv::UMat *umat, int flags, cv::Mat **output)
{
    BEGIN_WRAP
    *output = new cv::Mat(umat->getMat((cv::AccessFlag)flags));
    END_WRAP
}

// UMat row(int y) const;
API(ExceptionStatus)
api_umat_row(cv::UMat *umat, int y, cv::UMat **output)
{
    BEGIN_WRAP
    *output = new cv::UMat(umat->row(y));
    END_WRAP
}

// UMat col(int x) const;
API(ExceptionStatus)
api_umat_col(cv::UMat *umat, int x, cv::UMat **output)
{
    BEGIN_WRAP
    *output = new cv::UMat(umat->col(x));
    END_WRAP
}

// UMat rowRange(int startrow, int endrow) const;
API(ExceptionStatus)
api_umat_row_range1(cv::UMat *umat, int startrow, int endrow, cv::UMat **output)
{
    BEGIN_WRAP
    *output = new cv::UMat(umat->rowRange(startrow, endrow));
    END_WRAP
}

// UMat rowRange(const Range& r) const;
API(ExceptionStatus)
api_umat_row_range2(cv::UMat *umat, cv::Range r, cv::UMat **output)
{
    BEGIN_WRAP
    *output = new cv::UMat(umat->rowRange(r));
    END_WRAP
}

// UMat colRange(int startcol, int endcol) const;
API(ExceptionStatus)
api_umat_col_range1(cv::UMat *umat, int startcol, int endcol, cv::UMat **output)
{
    BEGIN_WRAP
    *output = new cv::UMat(umat->colRange(startcol, endcol));
    END_WRAP
}

// UMat colRange(const Range& r) const;
API(ExceptionStatus)
api_umat_col_range2(cv::UMat *umat, cv::Range r, cv::UMat **output)
{
    BEGIN_WRAP
    *output = new cv::UMat(umat->colRange(r));
    END_WRAP
}

// UMat diag(int d=0) const;
API(ExceptionStatus)
api_umat_diag(cv::UMat *umat, int d, cv::UMat **output)
{
    BEGIN_WRAP
    *output = new cv::UMat(umat->diag(d));
    END_WRAP
}

// CV_NODISCARD_STD static UMat diag(const UMat& d, UMatUsageFlags usageFlags     void* handle(AccessFlag accessFlags) const;
// void ndoffset(size_t* ofs) const;
// enum { MAGIC_VAL  = 0x42FF0000, AUTO_STEP = 0, CONTINUOUS_FLAG = CV_MAT_CONT_FLAG, SUBMATRIX_FLAG = CV_SUBMAT_FLAG };
// enum { MAGIC_MASK = 0xFFFF0000, TYPE_MASK = 0x00000FFF, DEPTH_MASK = 7 };

// int flags;
API(int)
api_umat_flags(const cv::UMat *umat)
{
    return umat->flags;
}

// int dims;
API(int)
api_umat_dims(const cv::UMat *umat)
{
    return umat->dims;
}

// int rows;
API(int)
api_umat_rows(const cv::UMat *umat)
{
    return umat->rows;
}

// int cols;
API(int)
api_umat_cols(const cv::UMat *umat)
{
    return umat->cols;
}

// MatAllocator* allocator;
// UMatUsageFlags usageFlags;
// static MatAllocator* getStdAllocator();

// void updateContinuityFlag();
API(ExceptionStatus)
api_umat_update_continuity_flag(cv::UMat *umat)
{
    BEGIN_WRAP
    umat->updateContinuityFlag();
    END_WRAP
}

// UMatData* u;
API(ExceptionStatus)
api_umat_u(cv::UMat *umat, cv::UMatData **output)
{
    BEGIN_WRAP
    *output = umat->u;
    END_WRAP
}

// size_t offset;
API(size_t)
api_umat_offset(const cv::UMat *umat)
{
    return umat->offset;
}

// MatSize size;
API(CvSize)
api_umat_size(const cv::UMat *umat)
{
    auto size = umat->size;
    return {size[0], size[1]};
}

// MatStep step;
API(ExceptionStatus)
api_umat_step(const cv::UMat *umat, size_t *output)
{
    BEGIN_WRAP
    *output = umat->step;
    END_WRAP
}