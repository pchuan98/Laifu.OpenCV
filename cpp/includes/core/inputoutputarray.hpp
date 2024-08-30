/**
 * @file inputoutputarray.hpp
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

// _InputOutputArray();
API(ExceptionStatus)
api_inputoutputarray_new1(cv::_InputOutputArray **output)
{
    BEGIN_WRAP
    *output = new cv::_InputOutputArray();
    END_WRAP
}

// _InputOutputArray(int _flags, void* _obj);
API(ExceptionStatus)
api_inputoutputarray_new2(int _flags, void *_obj, cv::_InputOutputArray **output)
{
    BEGIN_WRAP
    *output = new cv::_InputOutputArray(_flags, _obj);
    END_WRAP
}

// _InputOutputArray(Mat& m);
API(ExceptionStatus)
api_inputoutputarray_new3(cv::Mat *m, cv::_InputOutputArray **output)
{
    BEGIN_WRAP
    *output = new cv::_InputOutputArray(*m);
    END_WRAP
}

// _InputOutputArray(std::vector<Mat>& vec);
API(ExceptionStatus)
api_inputoutputarray_new4(std::vector<cv::Mat> *vec, cv::_InputOutputArray **output)
{
    BEGIN_WRAP
    *output = new cv::_InputOutputArray(*vec);
    END_WRAP
}

// _InputOutputArray(cuda::GpuMat& d_mat);
API(ExceptionStatus)
api_inputoutputarray_new5();

// _InputOutputArray(ogl::Buffer& buf);
API(ExceptionStatus)
api_inputoutputarray_new6();

// _InputOutputArray(cuda::HostMem& cuda_mem);
API(ExceptionStatus)
api_inputoutputarray_new7();

// _InputOutputArray(UMat& m);
API(ExceptionStatus)
api_inputoutputarray_new8(cv::UMat *m, cv::_InputOutputArray **output)
{
    BEGIN_WRAP
    *output = new cv::_InputOutputArray(*m);
    END_WRAP
}

// _InputOutputArray(std::vector<UMat>& vec);
API(ExceptionStatus)
api_inputoutputarray_new9(const std::vector<cv::UMat> *vec, cv::_InputOutputArray **output)
{
    BEGIN_WRAP
    *output = new cv::_InputOutputArray(*vec);
    END_WRAP
}

// _InputOutputArray(const Mat& m);
// _InputOutputArray(const std::vector<Mat>& vec);
// _InputOutputArray(const cuda::GpuMat& d_mat);
// _InputOutputArray(const std::vector<cuda::GpuMat>& d_mat);
// _InputOutputArray(const ogl::Buffer& buf);
// _InputOutputArray(const cuda::HostMem& cuda_mem);
// _InputOutputArray(const UMat& m);
// _InputOutputArray(const std::vector<UMat>& vec);