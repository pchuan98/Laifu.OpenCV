#pragma once

#if defined WIN32 || defined _WIN32
#pragma warning(push)
#include <codeanalysis/warnings.h>
#pragma warning(disable : ALL_CODE_ANALYSIS_WARNINGS)
#pragma warning(pop)
#endif

#include <opencv2/core.hpp>
#include <opencv2/core/types_c.h>

#if defined WIN32 || defined _WIN32
#pragma warning(pop)
#endif

enum class ExceptionStatus : int
{
    NOT_OCCURRED = 0,
    OCCURRED = 1
};

#define BEGIN_WRAP ;
#define END_WRAP return ExceptionStatus::NOT_OCCURRED;

#ifdef _WINDOWS
#define API(ret) extern "C" __declspec(dllexport) ret __cdecl
#else
#define API(ret) CVAPI(ret)
#endif