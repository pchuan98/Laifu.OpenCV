#include <opencv2/core.hpp>
#include <opencv2/highgui.hpp>
#include <opencv2/imgproc.hpp>
#include <opencv2/core/types_c.h>
#include "opencv2/stitching/detail/matchers.hpp"
#include "opencv2/xfeatures2d.hpp"

#include <iostream>

#include <string>
#include <windows.h>

using namespace std;
using namespace cv;

void api_test_feature(cv::detail::ImageFeatures *feature)
{
    auto mat = cv::imread("D:\\.test\\test.png");
    auto finder = cv::ORB::create();
    cv::detail::computeImageFeatures(finder, mat, *feature);
    std::cout << feature->keypoints.size() << std::endl;
}

int main()
{
    locale::global(locale("zh_CN.UTF-8"));

    cout << typeid(int).name() << endl;
}