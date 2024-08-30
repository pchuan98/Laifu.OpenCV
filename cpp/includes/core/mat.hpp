/**
 * @file mat.hpp
 * @author pchuan98 (haeer98@outlook.com)
 * @brief
 * @version 0.1
 * @date 2024-08-29
 *
 * @copyright Copyright (c) 2024
 *
 */

#pragma once

#include "common.hpp"

#pragma region Create

API(ExceptionStatus)
api_mat_new1(cv::Mat **output)
{
    BEGIN_WRAP
    *output = new cv::Mat;
    END_WRAP
}

API(ExceptionStatus)
api_mat_new2(int rows, int cols, int type, cv::Mat **output)
{
    BEGIN_WRAP
    *output = new cv::Mat(rows, cols, type);
    END_WRAP
}

API(ExceptionStatus)
api_mat_new3(cv::Size size, int type, cv::Mat **output)
{
    BEGIN_WRAP
    *output = new cv::Mat(size, type);
    END_WRAP
}

API(ExceptionStatus)
api_mat_new4(int rows, int cols, int type, cv::Scalar s, cv::Mat **output)
{
    BEGIN_WRAP
    *output = new cv::Mat(rows, cols, type, s);
    END_WRAP
}

API(ExceptionStatus)
api_mat_new5(cv::Size size, int type, cv::Scalar s, cv::Mat **output)
{
    BEGIN_WRAP
    *output = new cv::Mat(size, type, s);
    END_WRAP
}

API(ExceptionStatus)
api_mat_new6(int ndims, const int *sizes, int type, cv::Mat **output)
{
    BEGIN_WRAP
    *output = new cv::Mat(ndims, sizes, type);
    END_WRAP
}

API(ExceptionStatus)
api_mat_new7(int ndims, const int *sizes, int type, cv::Scalar s, cv::Mat **output)
{
    BEGIN_WRAP
    *output = new cv::Mat(ndims, sizes, type, s);
    END_WRAP
}

API(ExceptionStatus)
api_mat_new8(const cv::Mat *m, cv::Mat **output)
{
    BEGIN_WRAP
    *output = new cv::Mat(*m);
    END_WRAP
}

API(ExceptionStatus)
api_mat_new9(int rows, int cols, int type, void *data, size_t step, cv::Mat **output)
{
    BEGIN_WRAP
    *output = new cv::Mat(rows, cols, type, data, step);
    END_WRAP
}

API(ExceptionStatus)
api_mat_new10(cv::Size size, int type, void *data, size_t step, cv::Mat **output)
{
    BEGIN_WRAP
    *output = new cv::Mat(size, type, data, step);
    END_WRAP
}

API(ExceptionStatus)
api_mat_new11(cv::Mat *m, cv::Range rowRange, cv::Range colRange, cv::Mat **output)
{
    BEGIN_WRAP
    *output = new cv::Mat(*m, rowRange, colRange);
    END_WRAP
}

API(ExceptionStatus)
api_mat_new12(cv::Mat *m, cv::Rect roi, cv::Mat **output)
{
    BEGIN_WRAP
    *output = new cv::Mat(*m, roi);
    END_WRAP
}

API(ExceptionStatus)
api_mat_new13(cv::Mat *m, cv::Range ranges[], cv::Mat **output)
{
    BEGIN_WRAP
    *output = new cv::Mat(*m, *ranges);
    END_WRAP
}

#pragma endregion

#pragma region Props

// 这部分代码从头文件的 _InputArray的属性中获得

API(int)
api_mat_flags(const cv::Mat *mat)
{
    return mat->flags;
}

API(int)
api_mat_dims(const cv::Mat *mat)
{
    return mat->dims;
}

API(int)
api_mat_rows(const cv::Mat *mat)
{
    return mat->rows;
}

API(int)
api_mat_cols(const cv::Mat *mat)
{
    return mat->cols;
}

API(uchar *)
api_mat_data(const cv::Mat *obj)
{
    return obj->data;
}

API(CvSize)
api_mat_size(const cv::Mat *mat)
{
    return cvSize(mat->size());
}

API(int)
api_mat_sizeat(const cv::Mat *mat, const int i)
{
    return mat->size[i];
}

API(size_t)
api_mat_step(const cv::Mat *mat)
{
    return mat->step;
}

API(size_t)
api_mat_stepat(const cv::Mat *mat, const int i)
{
    return mat->step[i];
}

#pragma endregion

#pragma region Methods

// todo getUMat

// Mat row(int y) const;
API(ExceptionStatus)
api_mat_row(const cv::Mat *mat, int y, cv::Mat **output)
{
    BEGIN_WRAP
    *output = new cv::Mat(mat->row(y));
    END_WRAP
}

// Mat col(int x) const;
API(ExceptionStatus)
api_mat_col(const cv::Mat *mat, int x, cv::Mat **output)
{
    BEGIN_WRAP
    *output = new cv::Mat(mat->col(x));
    END_WRAP
}

// Mat rowRange(int startrow, int endrow) const;
API(ExceptionStatus)
api_mat_row_range1(const cv::Mat *mat, int startrow, int endrow, cv::Mat **output)
{
    BEGIN_WRAP
    *output = new cv::Mat(mat->rowRange(startrow, endrow));
    END_WRAP
}

// Mat rowRange(const Range& r) const;
API(ExceptionStatus)
api_mat_row_range2(const cv::Mat *mat, cv::Range r, cv::Mat **output)
{
    BEGIN_WRAP
    *output = new cv::Mat(mat->rowRange(r));
    END_WRAP
}

// Mat colRange(int startcol, int endcol) const;
API(ExceptionStatus)
api_mat_col_range1(const cv::Mat *mat, int startcol, int endcol, cv::Mat **output)
{
    BEGIN_WRAP
    *output = new cv::Mat(mat->colRange(startcol, endcol));
    END_WRAP
}

// Mat colRange(const Range& r) const;
API(ExceptionStatus)
api_mat_col_range2(const cv::Mat *mat, cv::Range r, cv::Mat **output)
{
    BEGIN_WRAP
    *output = new cv::Mat(mat->colRange(r));
    END_WRAP
}

// CV_NODISCARD_STD static Mat diag(const Mat& d);
API(ExceptionStatus)
api_mat_diag(const cv::Mat *mat, int d, cv::Mat **output)
{
    BEGIN_WRAP
    *output = new cv::Mat(mat->diag(d));
    END_WRAP
}

// CV_NODISCARD_STD Mat clone() const;
API(ExceptionStatus)
api_mat_clone(const cv::Mat *mat, cv::Mat **output)
{
    BEGIN_WRAP
    *output = new cv::Mat(mat->clone());
    END_WRAP
}

// void copyTo( OutputArray m ) const;
API(ExceptionStatus)
api_mat_copy_to1(const cv::Mat *mat, cv::_OutputArray *m)
{
    BEGIN_WRAP
    mat->copyTo(*m);
    END_WRAP
}

// void copyTo( OutputArray m, InputArray mask ) const;
API(ExceptionStatus)
api_mat_copy_to2(const cv::Mat *mat, cv::_OutputArray *m, const cv::_InputArray *mask)
{
    BEGIN_WRAP
    mat->copyTo(*m, *mask);
    END_WRAP
}

// void convertTo( OutputArray m, int rtype, double alpha=1, double beta=0 ) const;
API(ExceptionStatus)
api_mat_convert_to(const cv::Mat *mat, cv::_OutputArray *m, int rtype, double alpha, double beta)
{
    BEGIN_WRAP
    mat->convertTo(*m, rtype, alpha, beta);
    END_WRAP
}

// void assignTo( Mat& m, int type=-1 ) const;
API(ExceptionStatus)
api_mat_assign_to(const cv::Mat *mat, cv::Mat *m, int type)
{
    BEGIN_WRAP
    mat->assignTo(*m, type);
    END_WRAP
}

// Mat& setTo(InputArray value, InputArray mask=noArray());
API(ExceptionStatus)
api_mat_set_to(cv::Mat *mat, cv::_InputArray *value, cv::_InputArray *mask)
{
    BEGIN_WRAP
    mat->setTo(*value, *mask);
    END_WRAP
}

// Mat reshape(int cn, int rows=0) const;
API(ExceptionStatus)
api_mat_reshape1(const cv::Mat *mat, int cn, int rows, cv::Mat **output)
{
    BEGIN_WRAP
    *output = new cv::Mat(mat->reshape(cn, rows));
    END_WRAP
}

// Mat reshape(int cn, int newndims, const int* newsz) const;
API(ExceptionStatus)
api_mat_reshape2(const cv::Mat *mat, int cn, int newndims, const int *newsz, cv::Mat **output)
{
    BEGIN_WRAP
    *output = new cv::Mat(mat->reshape(cn, newndims, newsz));
    END_WRAP
}

// Mat reshape(int cn, const std::vector<int>& newshape) const;
API(ExceptionStatus)
api_mat_reshape3(const cv::Mat *mat, int cn, int *newshape, int count, cv::Mat **output)
{
    BEGIN_WRAP
    std::vector<int> newshape_vec(newshape, newshape + count);
    *output = new cv::Mat(mat->reshape(cn, newshape_vec));
    END_WRAP
}

// MatExpr t() const;
API(ExceptionStatus)
api_mat_t(const cv::Mat *mat, cv::MatExpr **output)
{
    BEGIN_WRAP
    *output = new cv::MatExpr(mat->t());
    END_WRAP
}

// MatExpr inv(int method=DECOMP_LU) const;
API(ExceptionStatus)
api_mat_inv(const cv::Mat *mat, int method, cv::MatExpr **output)
{
    BEGIN_WRAP
    *output = new cv::MatExpr(mat->inv(method));
    END_WRAP
}

// MatExpr mul(InputArray m, double scale=1) const;
API(ExceptionStatus)
api_mat_mul(const cv::Mat *mat, cv::_InputArray *m, double scale, cv::MatExpr **output)
{
    BEGIN_WRAP
    *output = new cv::MatExpr(mat->mul(*m, scale));
    END_WRAP
}

// Mat cross(InputArray m) const;
API(ExceptionStatus)
api_mat_cross(const cv::Mat *mat, cv::_InputArray *m, cv::Mat **output)
{
    BEGIN_WRAP
    *output = new cv::Mat(mat->cross(*m));
    END_WRAP
}

// Mat dot(InputArray m) const;
API(double)
api_mat_dot(const cv::Mat *mat, cv::_InputArray *m)
{
    return mat->dot(*m);
}

// CV_NODISCARD_STD static MatExpr zeros(int rows, int cols, int type);
API(ExceptionStatus)
api_mat_zeros1(int rows, int cols, int type, cv::MatExpr **output)
{
    BEGIN_WRAP
    *output = new cv::MatExpr(cv::Mat::zeros(rows, cols, type));
    END_WRAP
}

// CV_NODISCARD_STD static MatExpr zeros(Size size, int type);
API(ExceptionStatus)
api_mat_zeros2(cv::Size size, int type, cv::MatExpr **output)
{
    BEGIN_WRAP
    *output = new cv::MatExpr(cv::Mat::zeros(size, type));
    END_WRAP
}

// CV_NODISCARD_STD static MatExpr zeros(int ndims, const int* sz, int type);
API(ExceptionStatus)
api_mat_zeros3(int ndims, const int *sz, int type, cv::MatExpr **output)
{
    BEGIN_WRAP
    *output = new cv::MatExpr(cv::Mat::zeros(ndims, sz, type));
    END_WRAP
}

// CV_NODISCARD_STD static MatExpr ones(int rows, int cols, int type);
API(ExceptionStatus)
api_mat_ones1(int rows, int cols, int type, cv::MatExpr **output)
{
    BEGIN_WRAP
    *output = new cv::MatExpr(cv::Mat::ones(rows, cols, type));
    END_WRAP
}

// CV_NODISCARD_STD static MatExpr ones(Size size, int type);
API(ExceptionStatus)
api_mat_ones2(cv::Size size, int type, cv::MatExpr **output)
{
    BEGIN_WRAP
    *output = new cv::MatExpr(cv::Mat::ones(size, type));
    END_WRAP
}

// CV_NODISCARD_STD static MatExpr ones(int ndims, const int* sz, int type);
API(ExceptionStatus)
api_mat_ones3(int ndims, const int *sz, int type, cv::MatExpr **output)
{
    BEGIN_WRAP
    *output = new cv::MatExpr(cv::Mat::ones(ndims, sz, type));
    END_WRAP
}

// CV_NODISCARD_STD static MatExpr eye(int rows, int cols, int type);
API(ExceptionStatus)
api_mat_eye1(int rows, int cols, int type, cv::MatExpr **output)
{
    BEGIN_WRAP
    *output = new cv::MatExpr(cv::Mat::eye(rows, cols, type));
    END_WRAP
}

// CV_NODISCARD_STD static MatExpr eye(Size size, int type);
API(ExceptionStatus)
api_mat_eye2(cv::Size size, int type, cv::MatExpr **output)
{
    BEGIN_WRAP
    *output = new cv::MatExpr(cv::Mat::eye(size, type));
    END_WRAP
}

// void create(int rows, int cols, int type);
API(ExceptionStatus)
api_mat_create1(cv::Mat *mat, int rows, int cols, int type)
{
    BEGIN_WRAP
    mat->create(rows, cols, type);
    END_WRAP
}

// void create(Size size, int type);
API(ExceptionStatus)
api_mat_create2(cv::Mat *mat, cv::Size size, int type)
{
    BEGIN_WRAP
    mat->create(size, type);
    END_WRAP
}
// void create(int ndims, const int* sizes, int type);
API(ExceptionStatus)
api_mat_create3(cv::Mat *mat, int ndims, const int *sizes, int type)
{
    BEGIN_WRAP
    mat->create(ndims, sizes, type);
    END_WRAP
}

// void create(const std::vector<int>& sizes, int type);
API(ExceptionStatus)
api_mat_create4(cv::Mat *mat, int *sizes, int count, int type)
{
    BEGIN_WRAP
    std::vector<int> sizes_vec(sizes, sizes + count);
    mat->create(sizes_vec, type);
    END_WRAP
}

// void addref();
API(ExceptionStatus)
api_mat_addref(cv::Mat *mat)
{
    BEGIN_WRAP
    mat->addref();
    END_WRAP
}

// void release();
API(ExceptionStatus)
api_mat_release(cv::Mat *mat)
{
    BEGIN_WRAP
    mat->release();
    END_WRAP
}

// void deallocate();
API(ExceptionStatus)
api_mat_deallocate(cv::Mat *mat)
{
    BEGIN_WRAP
    mat->deallocate();
    END_WRAP
}

// void copySize(const Mat& m);
API(ExceptionStatus)
api_mat_copy_size(cv::Mat *mat, const cv::Mat *m)
{
    BEGIN_WRAP
    mat->copySize(*m);
    END_WRAP
}

// void reserve(size_t sz);
API(ExceptionStatus)
api_mat_reserve(cv::Mat *mat, size_t sz)
{
    BEGIN_WRAP
    mat->reserve(sz);
    END_WRAP
}

// void reserveBuffer(size_t sz);
API(ExceptionStatus)
api_mat_reserve_buffer(cv::Mat *mat, size_t sz)
{
    BEGIN_WRAP
    mat->reserveBuffer(sz);
    END_WRAP
}

// void resize(size_t sz);
API(ExceptionStatus)
api_mat_resize(cv::Mat *mat, size_t sz)
{
    BEGIN_WRAP
    mat->resize(sz);
    END_WRAP
}

// void resize(size_t sz, const Scalar& s);
API(ExceptionStatus)
api_mat_resize_with_scalar(cv::Mat *mat, size_t sz, cv::Scalar s)
{
    BEGIN_WRAP
    mat->resize(sz, s);
    END_WRAP
}

// size_t step1(int i=0) const;
API(size_t)
api_mat_step1(const cv::Mat *mat, int i)
{
    return mat->step1(i);
}

// size_t total(int startDim, int endDim=INT_MAX) const;
API(size_t)
api_mat_total1(const cv::Mat *mat, int startDim, int endDim)
{
    return mat->total(startDim, endDim);
}

// int checkVector(int elemChannels, int depth=-1, bool requireContinuous=true) const;
API(int)
api_mat_check_vector(const cv::Mat *mat, int elemChannels, int depth, bool requireContinuous)
{
    return mat->checkVector(elemChannels, depth, requireContinuous);
}

// const uchar* ptr(int i0=0) const;
API(const uchar *)
api_mat_ptr1(const cv::Mat *mat, int i0)
{
    return mat->ptr(i0);
}

// const uchar* ptr(int row, int col) const;
API(const uchar *)
api_mat_ptr2(const cv::Mat *mat, int row, int col)
{
    return mat->ptr(row, col);
}

// const uchar* ptr(int i0, int i1, int i2) const;
API(const uchar *)
api_mat_ptr3(const cv::Mat *mat, int i0, int i1, int i2)
{
    return mat->ptr(i0, i1, i2);
}

// const uchar* ptr(const int* idx) const;
API(const uchar *)
api_mat_ptr4(const cv::Mat *mat, const int *idx)
{
    return mat->ptr(idx);
}

#pragma endregion

#pragma region Prop BUT Method

// bool isContinuous() const;
API(bool)
api_mat_is_continuous(const cv::Mat *mat)
{
    return mat->isContinuous();
}

// bool isSubmatrix() const;
API(bool)
api_mat_is_submatrix(const cv::Mat *mat)
{
    return mat->isSubmatrix();
}

// size_t elemSize() const;
API(size_t)
api_mat_elem_size(const cv::Mat *mat)
{
    return mat->elemSize();
}

// size_t elemSize1() const;
API(size_t)
api_mat_elem_size1(const cv::Mat *mat)
{
    return mat->elemSize1();
}

// int type() const;
API(int)
api_mat_type(const cv::Mat *mat)
{
    return mat->type();
}

// int depth() const;
API(int)
api_mat_depth(const cv::Mat *mat)
{
    return mat->depth();
}

// int channels() const;
API(int)
api_mat_channels(const cv::Mat *mat)
{
    return mat->channels();
}

// bool empty() const;
API(bool)
api_mat_empty(const cv::Mat *mat)
{
    return mat->empty();
}

// size_t total() const;
API(size_t)
api_mat_total(const cv::Mat *mat)
{
    return mat->total();
}

#pragma endregion