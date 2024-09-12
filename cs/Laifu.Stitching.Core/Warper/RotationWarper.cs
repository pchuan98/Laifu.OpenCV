using Laifu.OpenCv.Cv2;
using Laifu.OpenCv.Native.Core;
using Laifu.Stitching.Core.Models;
using Laifu.Stitching.Core.Services;
using CvSize = Laifu.Stitching.Core.Models.CvSize;

namespace Laifu.Stitching.Core.Warper;

public class RotationWarper : IRotationWarperService
{
    public Mat K { get; }
    public Mat R { get; }
    public double Scale { get; set; }
    public CvPoint2f WrapPoint(CvPoint2f pt)
    {
        throw new NotImplementedException();
    }

    public CvPoint2f WrapPoint(CvPoint2f pt, Mat K, Mat R)
    {
        throw new NotImplementedException();
    }

    public CvPoint2f WarpPointBackward(CvPoint2f pt)
    {
        throw new NotImplementedException();
    }

    public CvRect2i WarpPointBackward(CvPoint2f pt, Mat K, Mat R)
    {
        throw new NotImplementedException();
    }

    public CvRect2i BuildMaps(CvSize srcSize, out Mat xmap, out Mat ymap)
    {
        throw new NotImplementedException();
    }

    public CvRect2i BuildMaps(CvSize srcSize, Mat K, Mat R, out Mat xmap, out Mat ymap)
    {
        throw new NotImplementedException();
    }

    public CvPoint2i Warp(Mat src, int interpMode, int borderMode, Mat dst)
    {
        throw new NotImplementedException();
    }

    public CvPoint2i Warp(Mat src, Mat K, Mat R, int interpMode, int borderMode, Mat dst)
    {
        throw new NotImplementedException();
    }

    public void WarpBackward(Mat src, int interpMode, int borderMode, CvSize dstSize, Mat dst)
    {
        throw new NotImplementedException();
    }

    public void WarpBackward(Mat src, Mat K, Mat R, int interpMode, int borderMode, CvSize dstSize, Mat dst)
    {
        throw new NotImplementedException();
    }

    public Rect2i WarpRoi(CvSize srcSize)
    {
        throw new NotImplementedException();
    }

    public Rect2i WarpRoi(CvSize srcSize, Mat K, Mat R)
    {
        throw new NotImplementedException();
    }
}