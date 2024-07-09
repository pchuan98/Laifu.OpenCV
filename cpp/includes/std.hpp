#pragma once

#include "common.hpp"

#include <string>

CVAPI(std::string *)
api_string_empty()
{
    return new std::string;
}

CVAPI(std::string *)
api_string(const char *str)
{
    return new std::string(str);
}

CVAPI(void)
api_string_delete(const std::string *obj)
{
    delete obj;
}

CVAPI(const char *)
api_string_c_str(std::string *obj)
{
    return obj->c_str();
}
