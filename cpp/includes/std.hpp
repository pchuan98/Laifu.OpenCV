#pragma once

#include <string>
#include "common.hpp"

CVAPI(std::string *)
api_string_empty();

CVAPI(std::string *)
api_string(const char *str);

CVAPI(void)
api_string_delete(const std::string *obj);

CVAPI(const char *)
api_string_c_str(std::string *obj);