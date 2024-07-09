#include <opencv2/core.hpp>
#include <opencv2/highgui.hpp>
#include <opencv2/imgproc.hpp>

#include <iostream>

using namespace std;
using namespace cv;

int main()
{
    auto img = Mat(100, 100, CV_8UC3, Scalar(0, 255, 0));

    imshow("Image", img);
    waitKey(0);
}