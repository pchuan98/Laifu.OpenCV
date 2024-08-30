/**
 * @file test.hpp
 * @author pchuan98 (haeer98@outlook.com)
 * @brief Test for base value
 * @version 0.1
 * @date 2024-08-30
 *
 * @copyright Copyright (c) 2024
 *
 */

#pragma once

#include "common.hpp"

API(ExceptionStatus)
test_mat(cv::Mat *mat)
{
    BEGIN_WRAP
    // printf row col type dims
    printf("rows: %d\n", mat->rows);
    printf("cols: %d\n", mat->cols);
    printf("type: %d\n", mat->type());
    printf("dims: %d\n", mat->dims);
    END_WRAP
}

API(bool)
test_true()
{
    return true;
}

API(bool)
test_false()
{
    return false;
}

API(size_t)
test_sizet_negative()
{
    return -10;
}

API(size_t)
test_sizet_positive()
{
    return 10;
}

API(size_t)
test_sizet_large()
{
    // size_t is | - 1<<31 ~ 1<<30 -1 |
    size_t value = 2147483647;
    return value;
}