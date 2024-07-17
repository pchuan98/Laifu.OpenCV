#include <opencv2/core.hpp>
#include <opencv2/highgui.hpp>
#include <opencv2/imgproc.hpp>
#include <opencv2/core/types_c.h>

#include <iostream>

#include <string>
#include <windows.h>

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
    locale::global(locale("zh_CN.UTF-8"));

    auto img = Mat(1000, 1000, CV_8UC3, Scalar(0, 255, 0));
    imshow("中文测试", img);

    waitKey(0);
    destroyAllWindows();
    cout << "ok\n";
}