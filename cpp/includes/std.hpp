#pragma once

#include "common.hpp"

#include <string>

CVAPI_BASE_WRAPPER(api_std_delete(void *obj), delete obj;);

#pragma region VECTOR WRAPPER

#define CVAPI_STD_VECTOR_WRAPPER(type, name)                  \
    CVAPI(std::vector<type> *)                                \
    api_std_vector_create_##name##1()                         \
    {                                                         \
        return new std::vector<type>();                       \
    }                                                         \
    CVAPI(std::vector<type> *)                                \
    api_std_vector_create_##name##2(size_t size)              \
    {                                                         \
        return new std::vector<type>(size);                   \
    }                                                         \
    CVAPI(std::vector<type> *)                                \
    api_std_vector_create_##name##3(type * data, size_t size) \
    {                                                         \
        return new std::vector<type>(data, data + size);      \
    }                                                         \
    CVAPI(int)                                                \
    api_std_vector_size_##name(std::vector<type> *vec)        \
    {                                                         \
        if (vec == nullptr)                                   \
            return -1;                                        \
        return vec->size();                                   \
    }                                                         \
    CVAPI(type *)                                             \
    api_std_vector_data_##name(std::vector<type> *vec)        \
    {                                                         \
        if (vec == nullptr)                                   \
            return nullptr;                                   \
        return vec->data();                                   \
    }

CVAPI_STD_VECTOR_WRAPPER(cv::KeyPoint, keypoint);

#pragma endregion