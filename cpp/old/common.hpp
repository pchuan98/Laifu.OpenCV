#pragma once

#if defined WIN32 || defined _WIN32
#pragma warning(push)
#include <codeanalysis/warnings.h>
#pragma warning(disable : ALL_CODE_ANALYSIS_WARNINGS)
#endif

#include <opencv2/core.hpp>
#include <opencv2/core/types_c.h>
#include <opencv2/aruco.hpp>
#include <opencv2/aruco/charuco.hpp>
#include <opencv2/bgsegm.hpp>
#include <opencv2/img_hash.hpp>
#include <opencv2/line_descriptor.hpp>
#include <opencv2/optflow.hpp>
#include <opencv2/quality.hpp>
#include <opencv2/tracking.hpp>
#include <opencv2/xfeatures2d.hpp>
#include <opencv2/ximgproc.hpp>
#include <opencv2/xphoto.hpp>

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

#define CVAPI_BASE_WRAPPER(header, body) \
    CVAPI(ExceptionStatus)               \
    header                               \
    {                                    \
        BEGIN_WRAP                       \
        body;                            \
        END_WRAP                         \
    }
