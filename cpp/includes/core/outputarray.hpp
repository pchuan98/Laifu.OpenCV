/**
 * @file outputarray.hpp
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

// _OutputArray();
API(ExceptionStatus)
api_outputarray_new1(cv::_OutputArray **output)
{
    BEGIN_WRAP
    *output = new cv::_OutputArray();
    END_WRAP
}

// _OutputArray(int _flags, void* _obj);
API(ExceptionStatus)
api_outputarray_new2(int _flags, void *_obj, cv::_OutputArray **output)
{
    BEGIN_WRAP
    *output = new cv::_OutputArray(_flags, _obj);
    END_WRAP
}

// _OutputArray(Mat& m);
API(ExceptionStatus)
api_outputarray_new3(cv::Mat *m, cv::_OutputArray **output)
{
    BEGIN_WRAP
    *output = new cv::_OutputArray(*m);
    END_WRAP
}

// _OutputArray(std::vector<Mat>& vec);
API(ExceptionStatus)
api_outputarray_new4(std::vector<cv::Mat> *vec, cv::_OutputArray **output)
{
    BEGIN_WRAP
    *output = new cv::_OutputArray(*vec);
    END_WRAP
}

// _OutputArray(cuda::GpuMat& d_mat);
API(ExceptionStatus)
api_outputarray_new5();

// _OutputArray(std::vector<cuda::GpuMat>& d_mat);
API(ExceptionStatus)
api_outputarray_new6();

// _OutputArray(ogl::Buffer& buf);
API(ExceptionStatus)
api_outputarray_new7();

// _OutputArray(cuda::HostMem& cuda_mem);
API(ExceptionStatus)
api_outputarray_new8();

// _OutputArray(UMat& m);
API(ExceptionStatus)
api_outputarray_new9(cv::UMat *m, cv::_OutputArray **output)
{
    BEGIN_WRAP
    *output = new cv::_OutputArray(*m);
    END_WRAP
}

// _OutputArray(std::vector<UMat>& vec);
API(ExceptionStatus)
api_outputarray_new10(const std::vector<cv::UMat> *vec, cv::_OutputArray **output)
{
    BEGIN_WRAP
    *output = new cv::_OutputArray(*vec);
    END_WRAP
}

// bool fixedSize() const;
// bool fixedType() const;
// bool needed() const;
// Mat& getMatRef(int i=-1) const;
API(ExceptionStatus)
api_outputarray_getMatRef(cv::_OutputArray *output, int i, cv::Mat **mat)
{
    BEGIN_WRAP
    *mat = new cv::Mat(output->getMatRef(i));
    END_WRAP
}

// UMat& getUMatRef(int i=-1) const;
API(ExceptionStatus)
api_outputarray_getUMatRef(cv::_OutputArray *output, int i, cv::UMat **umat)
{
    BEGIN_WRAP
    *umat = new cv::UMat(output->getUMatRef(i));
    END_WRAP
}

// cuda::GpuMat& getGpuMatRef() const;
// std::vector<cuda::GpuMat>& getGpuMatVecRef() const;
// ogl::Buffer& getOGlBufferRef() const;
// cuda::HostMem& getHostMemRef() const;
// void create(Size sz, int type, int i=-1, bool allowTransposed=false, _OutputArray::DepthMask fixedDepthMask=static_cast<_OutputArray::DepthMask>(0)) const;
// void create(int rows, int cols, int type, int i=-1, bool allowTransposed=false, _OutputArray::DepthMask fixedDepthMask=static_cast<_OutputArray::DepthMask>(0)) const;
// void create(int dims, const int* size, int type, int i=-1, bool allowTransposed=false, _OutputArray::DepthMask fixedDepthMask=static_cast<_OutputArray::DepthMask>(0)) const;
// void createSameSize(const _InputArray& arr, int mtype) const;
// void release() const;
API(ExceptionStatus)
api_outputarray_release(cv::_OutputArray *output)
{
    BEGIN_WRAP
    output->release();
    END_WRAP
}

// void clear() const;
// void setTo(const _InputArray& value, const _InputArray & mask = _InputArray()) const;
// void assign(const UMat& u) const;
// void assign(const Mat& m) const;
// void assign(const std::vector<UMat>& v) const;
// void assign(const std::vector<Mat>& v) const;
// void move(UMat& u) const;
API(ExceptionStatus)
api_outputarray_move1(cv::_OutputArray *output, cv::UMat *u)
{
    BEGIN_WRAP
    output->move(*u);
    END_WRAP
}

// void move(Mat& m) const;
API(ExceptionStatus)
api_outputarray_move2(cv::_OutputArray *output, cv::Mat *m)
{
    BEGIN_WRAP
    output->move(*m);
    END_WRAP
}