#include "stitching_detail/matchers.hpp"
#include "opencv2/imgproc.hpp"
#include "opencv2/imgcodecs.hpp"

using namespace std;
using namespace cv;

int main()
{
    auto img = "D:/.test/test.png";
    auto mat = imread(img);

    api_st_detail_computeImageFeatures(cv::SIFT::create(), &mat);
}