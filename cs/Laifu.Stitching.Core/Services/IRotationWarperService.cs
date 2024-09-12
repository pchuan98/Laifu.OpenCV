// ReSharper disable InconsistentNaming

using Laifu.OpenCv.Cv2;
using Laifu.OpenCv.Native.Core;
using Laifu.Stitching.Core.Models;
using CvSize = Laifu.Stitching.Core.Models.CvSize;

namespace Laifu.Stitching.Core.Services;

public interface IRotationWarperService

{
    /// <summary>
    /// 
    /// </summary>
    public Mat K { get; }

    /// <summary>
    /// 
    /// </summary>
    public Mat R { get; }

    /// <summary>
    /// 
    /// </summary>
    public double Scale { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="pt"></param>
    /// <returns></returns>
    CvPoint2f WrapPoint(CvPoint2f pt);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="pt"></param>
    /// <param name="K"></param>
    /// <param name="R"></param>
    /// <returns></returns>
    CvPoint2f WrapPoint(CvPoint2f pt, Mat K, Mat R);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="pt"></param>
    /// <returns></returns>
    CvPoint2f WarpPointBackward(CvPoint2f pt);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="pt"></param>
    /// <param name="K"></param>
    /// <param name="R"></param>
    /// <returns></returns>
    CvRect2i WarpPointBackward(CvPoint2f pt, Mat K, Mat R);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="srcSize"></param>
    /// <param name="K"></param>
    /// <param name="R"></param>
    /// <param name="xmap"></param>
    /// <param name="ymap"></param>
    /// <returns></returns>
    CvRect2i BuildMaps(CvSize srcSize, out Mat xmap, out Mat ymap);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="srcSize"></param>
    /// <param name="K"></param>
    /// <param name="R"></param>
    /// <param name="xmap"></param>
    /// <param name="ymap"></param>
    /// <returns></returns>
    CvRect2i BuildMaps(CvSize srcSize, Mat K, Mat R, out Mat xmap, out Mat ymap);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="src"></param>
    /// <param name="interpMode"></param>
    /// <param name="borderMode"></param>
    /// <param name="dst"></param>
    /// <returns></returns>
    CvPoint2i Warp(Mat src, int interpMode, int borderMode, Mat dst);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="src"></param>
    /// <param name="K"></param>
    /// <param name="R"></param>
    /// <param name="interpMode"></param>
    /// <param name="borderMode"></param>
    /// <param name="dst"></param>
    /// <returns></returns>
    CvPoint2i Warp(Mat src, Mat K, Mat R, int interpMode, int borderMode, Mat dst);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="src"></param>
    /// <param name="interpMode"></param>
    /// <param name="borderMode"></param>
    /// <param name="dstSize"></param>
    /// <param name="dst"></param>
    void WarpBackward(Mat src, int interpMode, int borderMode, CvSize dstSize, Mat dst);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="src"></param>
    /// <param name="K"></param>
    /// <param name="R"></param>
    /// <param name="interpMode"></param>
    /// <param name="borderMode"></param>
    /// <param name="dstSize"></param>
    /// <param name="dst"></param>
    void WarpBackward(Mat src, Mat K, Mat R, int interpMode, int borderMode, CvSize dstSize, Mat dst);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="srcSize"></param>
    /// <returns></returns>
    Rect2i WarpRoi(CvSize srcSize);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="srcSize"></param>
    /// <param name="K"></param>
    /// <param name="R"></param>
    /// <returns></returns>
    Rect2i WarpRoi(CvSize srcSize, Mat K, Mat R);
}