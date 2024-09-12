// ReSharper disable ParameterHidesPrimaryConstructorParameter

using Laifu.OpenCv.Cv2;
using Laifu.OpenCv.Native;
using Laifu.OpenCv.Native.Core;
using Laifu.Stitching.Core.Models;
using Laifu.Stitching.Core.Services;
using CvSize = Laifu.Stitching.Core.Models.CvSize;

namespace Laifu.Stitching.Core.Warper;

public class RotationWarper(SafePtrHandle handle)
    : IRotationWarperService
{
    public static RotationWarper Generator(WarpType type, double scale = 1, Mat? k = null, Mat? r = null)
    {
        WarperHelper
            .api_modules_warper_create((int)type, (float)scale, out var handle)
            .ThrowHandleException();


        WarperHelper.api_modules_warper_get(handle, out var warper)
            .ThrowHandleException();

        return new RotationWarper(warper)
        {
            K = k,
            R = r,
        };

        GC.KeepAlive(handle);
    }

    public Mat? K { get; set; }

    public Mat? R { get; set; }

    public double Scale
    {
        get => WarperHelper.api_modules_warper_get_scale(handle);
        set => WarperHelper.api_modules_warper_set_scale((float)value, handle);
    }

    public SafePtrHandle Handle => handle;

    public CvPoint2f WrapPoint(CvPoint2f pt)
        => (K is null || R is null)
            ? throw new ArgumentException("K or R is null")
            : WrapPoint(pt, K, R);

    public CvPoint2f WrapPoint(CvPoint2f pt, Mat k, Mat r)
        => WarperHelper.api_modules_warper_warp_point(pt, k.Handle, r.Handle, Handle);

    public CvPoint2f WarpPointBackward(CvPoint2f pt)
        => (K is null || R is null)
            ? throw new ArgumentException("K or R is null")
            : WarpPointBackward(pt, K, R);

    public CvPoint2f WarpPointBackward(CvPoint2f pt, Mat k, Mat r)
        => WarperHelper.api_modules_warper_warp_point_backward(pt, k.Handle, r.Handle, Handle);

    public CvRect2i BuildMaps(CvSize srcSize, out Mat xmap, out Mat ymap)
        => (K is null || R is null)
            ? throw new ArgumentException("K or R is null")
            : BuildMaps(srcSize, K, R, out xmap, out ymap);

    public CvRect2i BuildMaps(CvSize srcSize, Mat k, Mat r, out Mat xmap, out Mat ymap)
    {
        xmap = new Mat();
        ymap = new Mat();
        return WarperHelper.api_modules_warper_build_maps(srcSize, k.Handle, r.Handle, xmap.Handle, ymap.Handle, Handle);
    }

    public CvPoint2i Warp(Mat src, InterpolationFlags interpMode, BorderTypes borderMode, Mat dst)
        => (K is null || R is null)
            ? throw new ArgumentException("K or R is null")
            : Warp(src, K, R, interpMode, borderMode, dst);

    public CvPoint2i Warp(Mat src, Mat k, Mat r, InterpolationFlags interpMode, BorderTypes borderMode, Mat dst)
    {
        if (interpMode is
            InterpolationFlags.INTER_AREA or
            InterpolationFlags.INTER_LINEAR_EXACT or
            InterpolationFlags.INTER_NEAREST_EXACT)
            throw new NotSupportedException();

        return WarperHelper.api_modules_warper_warp(src.Handle, k.Handle, r.Handle, (int)interpMode, (int)borderMode, dst.Handle, Handle);
    }


    public void WarpBackward(Mat src, InterpolationFlags interpMode, BorderTypes borderMode, CvSize dstSize, Mat dst)
    {
        if (K is null || R is null)
            throw new ArgumentException("K or R is null");

        WarpBackward(src, K, R, interpMode, borderMode, dstSize, dst);
    }

    public void WarpBackward(Mat src, Mat k, Mat r, InterpolationFlags interpMode, BorderTypes borderMode,
        CvSize dstSize, Mat dst)
    {
        if (interpMode is
            InterpolationFlags.INTER_AREA or
            InterpolationFlags.INTER_LINEAR_EXACT or
            InterpolationFlags.INTER_NEAREST_EXACT)
            throw new NotSupportedException();

        WarperHelper.api_modules_warper_warp_backward(src.Handle, k.Handle, r.Handle, (int)interpMode, (int)borderMode, dstSize, dst.Handle, Handle);
    }

    public CvRect2i WarpRoi(CvSize srcSize)
        => (K is null || R is null)
            ? throw new ArgumentException("K or R is null")
            : WarpRoi(srcSize, K, R);

    public CvRect2i WarpRoi(CvSize srcSize, Mat k, Mat r)
        => WarperHelper.api_modules_warper_warp_roi(srcSize, k.Handle, r.Handle, Handle);
}