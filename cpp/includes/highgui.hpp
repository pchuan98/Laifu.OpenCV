/**
 * @file highgui.hpp
 * @author chuan (haeer98@outlook.com)
 * @brief Methods for showing images with GUI (controls and window)
 * @version 0.1
 * @date 2024-08-27
 *
 * @copyright Copyright (c) 2024
 *
 */

#pragma once

#include "common.hpp"

#include <opencv2/highgui.hpp>

API(ExceptionStatus)
api_namedWindow(const char *winname, int flags = cv::WINDOW_AUTOSIZE)
{
    BEGIN_WRAP
    cv::namedWindow(winname, flags);
    END_WRAP
}

API(ExceptionStatus)
api_destroyWindow(const char *winname)
{
    BEGIN_WRAP
    cv::destroyWindow(winname);
    END_WRAP
}

API(ExceptionStatus)
api_destroyAllWindows()
{
    BEGIN_WRAP
    cv::destroyAllWindows();
    END_WRAP
}

API(int)
api_startWindowThread()
{
    return cv::startWindowThread();
}

API(int)
api_waitKeyEx(int delay)
{
    return cv::waitKey(delay);
}

API(int)
api_waitKey(int delay)
{
    return cv::waitKey(delay);
}

API(int)
api_pollKey()
{
    return cv::pollKey();
}

API(ExceptionStatus)
api_imshow1(const char *winname, const cv::Mat *mat)
{
    BEGIN_WRAP
    cv::imshow(winname, *mat);
    END_WRAP
}

API(ExceptionStatus)
api_imshow2(const char *winname, const cv::UMat *umat)
{
    BEGIN_WRAP
    cv::imshow(winname, *umat);
    END_WRAP
}

// API(ExceptionStatus)
// imshow3(const char *winname, const cv::ogl::Texture2D *tex)
// {
//     BEGIN_WRAP
//     cv::imshow(winname, *tex);
//     END_WRAP
// }

API(ExceptionStatus)
api_resizeWindow1(const char *winname, int width, int height)
{
    BEGIN_WRAP
    cv::resizeWindow(winname, width, height);
    END_WRAP
}

API(ExceptionStatus)
api_resizeWindow2(const char *winname, const cv::Size size)
{
    BEGIN_WRAP
    cv::resizeWindow(winname, size);
    END_WRAP
}

API(ExceptionStatus)
api_moveWindow(const char *winname, int x, int y)
{
    BEGIN_WRAP
    cv::moveWindow(winname, x, y);
    END_WRAP
}

API(ExceptionStatus)
api_setWindowProperty(const char *winname, int prop_id, double prop_value)
{
    BEGIN_WRAP
    cv::setWindowProperty(winname, prop_id, prop_value);
    END_WRAP
}

API(ExceptionStatus)
api_setWindowTitle(const char *winname, const char *title)
{
    BEGIN_WRAP
    cv::setWindowTitle(winname, title);
    END_WRAP
}

API(double)
api_getWindowProperty(const char *winname, int prop_id)
{
    return cv::getWindowProperty(winname, prop_id);
}

API(ExceptionStatus)
api_getWindowImageRect(const char *winname, cv::Rect *rect)
{
    BEGIN_WRAP
    *rect = cv::getWindowImageRect(winname);
    END_WRAP
}

API(ExceptionStatus)
api_setMouseCallback(const char *winname, cv::MouseCallback onMouse, void *userdata)
{
    BEGIN_WRAP
    cv::setMouseCallback(winname, onMouse, userdata);
    END_WRAP
}

API(int)
api_getMouseWheelDelta(int flags)
{
    return cv::getMouseWheelDelta(flags);
}

API(ExceptionStatus)
api_selectROI1(const char *windowName,
               const cv::_InputArray *img,
               bool showCrosshair,
               bool fromCenter,
               bool printNotice,
               cv::Rect *roi)
{
    BEGIN_WRAP
    *roi = cv::selectROI(windowName, *img, showCrosshair, fromCenter, printNotice);
    END_WRAP
}

API(ExceptionStatus)
api_selectROI2(const cv::_InputArray *img,
               bool showCrosshair,
               bool fromCenter, bool printNotice,
               cv::Rect *roi)
{
    BEGIN_WRAP
    *roi = cv::selectROI(*img, showCrosshair, fromCenter, printNotice);
    END_WRAP
}

API(ExceptionStatus)
api_selectROIs(const char *windowName,
               const cv::Mat *img,
               std::vector<cv::Rect> *boundingBoxes,
               bool showCrosshair,
               bool fromCenter,
               bool printNotice)
{
    BEGIN_WRAP
    cv::selectROIs(windowName, *img, *boundingBoxes, showCrosshair, fromCenter, printNotice);
    END_WRAP
}

API(int)
api_createTrackbar(const char *trackbarname,
                   const char *winname,
                   int *value,
                   int count,
                   cv::TrackbarCallback onChange,
                   void *userdata)
{
    return cv::createTrackbar(trackbarname, winname, value, count, onChange, userdata);
}

API(int)
api_getTrackbarPos(const char *trackbarname, const char *winname)
{
    return cv::getTrackbarPos(trackbarname, winname);
}

API(ExceptionStatus)
api_setTrackbarPos(const char *trackbarname, const char *winname, int pos)
{
    BEGIN_WRAP
    cv::setTrackbarPos(trackbarname, winname, pos);
    END_WRAP
}

API(ExceptionStatus)
api_setTrackbarMax(const char *trackbarname, const char *winname, int maxval)
{
    BEGIN_WRAP
    cv::setTrackbarMax(trackbarname, winname, maxval);
    END_WRAP
}

API(ExceptionStatus)
api_setTrackbarMin(const char *trackbarname, const char *winname, int minval)
{
    BEGIN_WRAP
    cv::setTrackbarMin(trackbarname, winname, minval);
    END_WRAP
}

// API(ExceptionStatus)
// setOpenGlDrawCallback(const char *winname, OpenGlDrawCallback onOpenGlDraw, void *userdata)
// {
//     BEGIN_WRAP
//     cv::setOpenGlDrawCallback(winname, onOpenGlDraw, userdata);
//     END_WRAP
// }

// API(ExceptionStatus)
// setOpenGlContext(const char *winname)
// {
//     BEGIN_WRAP
//     cv::setOpenGlContext(winname);
//     END_WRAP
// }

API(ExceptionStatus)
api_updateWindow(const char *winname)
{
    BEGIN_WRAP
    cv::updateWindow(winname);
    END_WRAP
}
