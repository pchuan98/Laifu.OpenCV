#include <opencv2/core.hpp>
#include <opencv2/highgui.hpp>
#include <opencv2/imgproc.hpp>

#include <iostream>

using namespace std;
using namespace cv;

void onMouse(int event, int x, int y, int flags, void *userdata)
{
    if (event == cv::EVENT_LBUTTONDOWN)
    {
        std::cout << "Left button clicked at (" << x << ", " << y << ")" << std::endl;
    }
}

int main()
{
    auto img = Mat(1000, 1000, CV_8UC3, Scalar(0, 255, 0));

    namedWindow("image", WINDOW_NORMAL);
    setMouseCallback("image", onMouse, nullptr);
    imshow("image", img);
    waitKey(0);
}