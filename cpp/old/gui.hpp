#pragma once

#include "common.hpp"
#include <opencv2/highgui.hpp>

#define CVAPI_GUI_FUNC_WRAP(func) CVAPI_BASE_WRAPPER(api_gui_##func(), cv::func())
#define CVAPI_GUI_FUNC_WRAP_PLUS(func, lambada, ...) CVAPI_BASE_WRAPPER(api_gui_##func(__VA_ARGS__), lambada;)

CVAPI_GUI_FUNC_WRAP_PLUS(namedWindow, cv::namedWindow(winname, flags), const char *winname, int flags)
CVAPI_GUI_FUNC_WRAP(destroyAllWindows)
CVAPI_GUI_FUNC_WRAP_PLUS(destroyWindow, cv::destroyWindow(winname), const char *winname)
CVAPI_GUI_FUNC_WRAP_PLUS(startWindowThread, *ret = cv::startWindowThread(), int *ret)
CVAPI_GUI_FUNC_WRAP_PLUS(waitKeyEx, *ret = cv::waitKeyEx(delay), int delay, int *ret)
CVAPI_GUI_FUNC_WRAP_PLUS(waitKey, *ret = cv::waitKey(delay), int delay, int *ret)
CVAPI_GUI_FUNC_WRAP_PLUS(imshow, cv::imshow(winname, *mat), const char *winname, cv::Mat *mat)
CVAPI_GUI_FUNC_WRAP_PLUS(imshow_umat, cv::imshow(winname, *mat), const char *winname, cv::UMat *mat)
CVAPI_GUI_FUNC_WRAP_PLUS(resizeWindow, cv::resizeWindow(winname, width, height), const char *winname, int width, int height)
CVAPI_GUI_FUNC_WRAP_PLUS(moveWindow, cv::moveWindow(winname, x, y), const char *winname, int x, int y)
CVAPI_GUI_FUNC_WRAP_PLUS(setWindowProperty, cv::setWindowProperty(winname, prop_id, prop_value), const char *winname, int prop_id, double prop_value)
CVAPI_GUI_FUNC_WRAP_PLUS(setWindowTitle, cv::setWindowTitle(winname, title), const char *winname, const char *title)
CVAPI_GUI_FUNC_WRAP_PLUS(getWindowProperty, *ret = cv::getWindowProperty(winname, prop_id), const char *winname, int prop_id, double *ret)
CVAPI_GUI_FUNC_WRAP_PLUS(setMouseCallback, cv::setMouseCallback(winname, onMouse, userdata), const char *winname, cv::MouseCallback onMouse, void *userdata)
CVAPI_GUI_FUNC_WRAP_PLUS(getMouseWheelDelta, *ret = cv::getMouseWheelDelta(flags), int flags, int *ret)
CVAPI_GUI_FUNC_WRAP_PLUS(createTrackbar, *ret = cv::createTrackbar(trackbarName, winName, value, count, onChange, userData), const char *trackbarName, const char *winName, int *value, int count, cv::TrackbarCallback onChange, void *userData, int *ret)
CVAPI_GUI_FUNC_WRAP_PLUS(getTrackbarPos, *ret = cv::getTrackbarPos(trackbarname, winname), const char *trackbarname, const char *winname, int *ret)
CVAPI_GUI_FUNC_WRAP_PLUS(setTrackbarPos, cv::setTrackbarPos(trackbarname, winname, pos), const char *trackbarname, const char *winname, int pos)
CVAPI_GUI_FUNC_WRAP_PLUS(setTrackbarMax, cv::setTrackbarMax(trackbarname, winname, maxval), const char *trackbarname, const char *winname, int maxval)
CVAPI_GUI_FUNC_WRAP_PLUS(setTrackbarMin, cv::setTrackbarMin(trackbarname, winname, minval), const char *trackbarname, const char *winname, int minval)
