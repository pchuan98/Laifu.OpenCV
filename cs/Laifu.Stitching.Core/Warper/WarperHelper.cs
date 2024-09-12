// ReSharper disable InconsistentNaming

using Laifu.OpenCv.Native;
using Laifu.OpenCv.Native.Constants;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Laifu.Stitching.Core.Models;

namespace Laifu.Stitching.Core.Warper;

// base
internal static partial class WarperHelper
{
    private const string Name = "OpenCvSharpExtern";

    internal static bool ThrowHandleException(this ExceptionStatus status)
        => HandleException(status);

    internal static bool HandleException(ExceptionStatus status)
    {
        if (status == ExceptionStatus.OCCURRED)
            throw new Exception("Unhandled error, from HandleException. Go to https://github.com/pchuan98/laifu.opencv/issues");

        return true;
    }
}

// rotation warper
partial class WarperHelper
{
    [LibraryImport(Name)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus api_modules_warper_create(
        int type,
        float scale,
        out SafePtrHandle warper);

    [LibraryImport(Name)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial CvPoint2f api_modules_warper_warp_point(
        CvPoint2f pt,
        SafePtrHandle K,
        SafePtrHandle R,
        SafePtrHandle warper);

    [LibraryImport(Name)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial CvPoint2f api_modules_warper_warp_point_backward(
        CvPoint2f pt,
        SafePtrHandle K,
        SafePtrHandle R,
        SafePtrHandle warper);

    [LibraryImport(Name)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial CvRect2i api_modules_warper_build_maps(
        CvSize src_size,
        SafePtrHandle K,
        SafePtrHandle R,
        SafePtrHandle xmap,
        SafePtrHandle ymap,
        SafePtrHandle warper);

    [LibraryImport(Name)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial CvPoint2i api_modules_warper_warp(
        SafePtrHandle src,
        SafePtrHandle K,
        SafePtrHandle R,
        int interp_mode,
        int border_mode,
        SafePtrHandle dst,
        SafePtrHandle warper);

    [LibraryImport(Name)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus api_modules_warper_warp_backward(
        SafePtrHandle src,
        SafePtrHandle K,
        SafePtrHandle R,
        int interp_mode,
        int border_mode,
        CvSize dst_size,
        SafePtrHandle dst,
        SafePtrHandle warper);

    [LibraryImport(Name)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial CvRect2i api_modules_warper_warp_roi(
        CvSize src_size,
        SafePtrHandle K,
        SafePtrHandle R,
        SafePtrHandle warper);

    [LibraryImport(Name)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial float api_modules_warper_get_scale(SafePtrHandle warper);

    [LibraryImport(Name)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus api_modules_warper_set_scale(
        float scale,
        SafePtrHandle warper);
}