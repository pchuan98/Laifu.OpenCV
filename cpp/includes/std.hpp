/**
 * @file std.hpp
 * @author chuan (haeer98@outlook.com)
 * @brief
 * @version 0.1
 * @date 2024-08-27
 *
 * @copyright Copyright (c) 2024
 *
 */

#pragma once

#include "common.hpp"

API(ExceptionStatus)
std_delete(void *obj)
{
	BEGIN_WRAP
	delete obj;
	END_WRAP
}