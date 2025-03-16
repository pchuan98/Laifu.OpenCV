/**
 * @file inputarray.hpp
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

// _InputArray();
API(ExceptionStatus)
api_inputarray_new1(cv::_InputArray **output)
{
    BEGIN_WRAP
    *output = new cv::_InputArray();
    END_WRAP
}

// _InputArray(int _flags, void* _obj);
API(ExceptionStatus)
api_inputarray_new2(int _flags, void *_obj, cv::_InputArray **output)
{
    BEGIN_WRAP
    *output = new cv::_InputArray(_flags, _obj);
    END_WRAP
}

// _InputArray(const Mat& m);
API(ExceptionStatus)
api_inputarray_new3(cv::Mat *m, cv::_InputArray **output)
{
    BEGIN_WRAP
    *output = new cv::_InputArray(*m);
    END_WRAP
}

// _InputArray(const MatExpr& expr);
API(ExceptionStatus)
api_inputarray_new4(cv::MatExpr *expr, cv::_InputArray **output)
{
    BEGIN_WRAP
    *output = new cv::_InputArray(*expr);
    END_WRAP
}

// _InputArray(const std::vector<Mat>& vec);
API(ExceptionStatus)
api_inputarray_new5(const std::vector<cv::Mat> *vec, cv::_InputArray **output)
{
    BEGIN_WRAP
    *output = new cv::_InputArray(*vec);
    END_WRAP
}

// _InputArray(const double& val);
API(ExceptionStatus)
api_inputarray_new6(double val, cv::_InputArray **output)
{
    BEGIN_WRAP
    *output = new cv::_InputArray(val);
    END_WRAP
}

// _InputArray(const cuda::GpuMat& d_mat);
API(ExceptionStatus)
api_inputarray_new7();

// _InputArray(const std::vector<cuda::GpuMat>& d_mat_array);
API(ExceptionStatus)
api_inputarray_new8();

// _InputArray(const ogl::Buffer& buf);
API(ExceptionStatus)
api_inputarray_new9();

// _InputArray(const cuda::HostMem& cuda_mem);
API(ExceptionStatus)
api_inputarray_new10();

// _InputArray(const UMat& um);
API(ExceptionStatus)
api_inputarray_new11(cv::UMat *um, cv::_InputArray **output)
{
    BEGIN_WRAP
    *output = new cv::_InputArray(*um);
    END_WRAP
}

// _InputArray(const std::vector<UMat>& umv);
API(ExceptionStatus)
api_inputarray_new12(const std::vector<cv::UMat> *umv, cv::_InputArray **output)
{
    BEGIN_WRAP
    *output = new cv::_InputArray(*umv);
    END_WRAP
}

// Mat getMat(int idx=-1) const;
API(ExceptionStatus)
api_inputarray_getMat(cv::_InputArray *input, int idx, cv::Mat **output)
{
    BEGIN_WRAP
    *output = new cv::Mat(input->getMat(idx));
    auto mat = new cv::UMat();
    END_WRAP
}

// UMat getUMat(int idx=-1) const;
API(ExceptionStatus)
api_inputarray_getUMat(cv::_InputArray *input, int idx, cv::UMat **output)
{
    BEGIN_WRAP
    *output = new cv::UMat(input->getUMat(idx));
    END_WRAP
}

// void getMatVector(std::vector<Mat>& mv) const;
API(ExceptionStatus)
api_inputarray_getMatVector(cv::_InputArray *input, std::vector<cv::Mat> *mv)
{
    BEGIN_WRAP
    input->getMatVector(*mv);
    END_WRAP
}
// void getUMatVector(std::vector<UMat>& umv) const;
API(ExceptionStatus)
api_inputarray_getUMatVector(cv::_InputArray *input, std::vector<cv::UMat> *umv)
{
    BEGIN_WRAP
    input->getUMatVector(*umv);
    END_WRAP
}

// todo 下面部分常规用不到 不写了

// void getGpuMatVector(std::vector<cuda::GpuMat>& gpumv) const;
// cuda::GpuMat getGpuMat() const;
// ogl::Buffer getOGlBuffer() const;
// int getFlags() const;
// void* getObj() const;
// Size getSz() const;
// _InputArray::KindFlag kind() const;
// int dims(int i=-1) const;
// int cols(int i=-1) const;
// int rows(int i=-1) const;
// Size size(int i=-1) const;
// int sizend(int* sz, int i=-1) const;
// bool sameSize(const _InputArray& arr) const;
// size_t total(int i=-1) const;
// int type(int i=-1) const;
// int depth(int i=-1) const;
// int channels(int i=-1) const;
// bool isContinuous(int i=-1) const;
// bool isSubmatrix(int i=-1) const;
// bool empty() const;
// void copyTo(const _OutputArray& arr) const;
// void copyTo(const _OutputArray& arr, const _InputArray & mask) const;
// size_t offset(int i=-1) const;
// size_t step(int i=-1) const;
// bool isMat() const;
// bool isUMat() const;
// bool isMatVector() const;
// bool isUMatVector() const;
// bool isMatx() const;
// bool isVector() const;
// bool isGpuMat() const;
// bool isGpuMatVector() const;