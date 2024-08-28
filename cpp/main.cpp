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

int main()
{
    locale::global(locale("zh_CN.UTF-8"));

    cout << typeid(int).name() << endl;
}