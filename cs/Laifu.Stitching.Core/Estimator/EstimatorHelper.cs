// ReSharper disable InconsistentNaming

using Laifu.OpenCv.Native;
using Laifu.OpenCv.Native.Constants;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Laifu.Stitching.Core.Models;

namespace Laifu.Stitching.Core.Estimator;

internal static partial class EstimatorHelper
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

// CameraParams
partial class EstimatorHelper
{
    [LibraryImport(Name)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus api_modules_camera_params_create(out SafePtrHandle cameraParams);

    [LibraryImport(Name)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial double api_modules_camera_params_focal(SafePtrHandle cameraParams);

    [LibraryImport(Name)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial double api_modules_camera_params_aspect(SafePtrHandle cameraParams);

    [LibraryImport(Name)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial double api_modules_camera_params_ppx(SafePtrHandle cameraParams);

    [LibraryImport(Name)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial double api_modules_camera_params_ppy(SafePtrHandle cameraParams);

    [LibraryImport(Name)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus api_modules_camera_params_R(SafePtrHandle cameraParams, out MatHandle R);

    [LibraryImport(Name)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus api_modules_camera_params_t(SafePtrHandle cameraParams, out MatHandle t);

    [LibraryImport(Name)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus api_modules_camera_params_array2vector(nint[] cameras, int size, out StdVectorHandle vector);
}

// Estimator
partial class EstimatorHelper
{
    [LibraryImport(Name)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus api_modules_estimator_leaveBiggestComponent(
        StdVectorHandle features,
        StdVectorHandle matches,
        double conf_thresh,
        out StdVectorHandle indices);

    [LibraryImport(Name)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    internal static partial bool api_modules_estimator_homography(
        [MarshalAs(UnmanagedType.Bool)] bool is_focals_estimated,
        StdVectorHandle features,
        StdVectorHandle matches,
        out StdVectorHandle cameras);

    [LibraryImport(Name)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    internal static partial bool api_modules_estimator_affine(
        StdVectorHandle features,
        StdVectorHandle matches,
        out StdVectorHandle cameras);
}

// BundleAdjusterBase
partial class EstimatorHelper
{
    [LibraryImport(Name)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    internal static partial bool api_modules_estimator_no_bundle_adjuster(
        [MarshalAs(UnmanagedType.I1)] bool is_focals,
        [MarshalAs(UnmanagedType.I1)] bool is_ppx,
        [MarshalAs(UnmanagedType.I1)] bool is_ppy,
        [MarshalAs(UnmanagedType.I1)] bool is_aspect,
        [MarshalAs(UnmanagedType.I1)] bool is_skew,
        [MarshalAs(UnmanagedType.I1)] bool is_wave_correct,
        double conf_thresh,
        StdVectorHandle features,
        StdVectorHandle pairwise_matches,
        StdVectorHandle cameras);

    [LibraryImport(Name)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    internal static partial bool api_modules_estimator_bundle_adjuster_ray(
        [MarshalAs(UnmanagedType.I1)] bool is_focals,
        [MarshalAs(UnmanagedType.I1)] bool is_ppx,
        [MarshalAs(UnmanagedType.I1)] bool is_ppy,
        [MarshalAs(UnmanagedType.I1)] bool is_aspect,
        [MarshalAs(UnmanagedType.I1)] bool is_skew,
        [MarshalAs(UnmanagedType.I1)] bool is_wave_correct,
        double conf_thresh,
        StdVectorHandle features,
        StdVectorHandle pairwise_matches,
        StdVectorHandle cameras);

    [LibraryImport(Name)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    internal static partial bool api_modules_estimator_bundle_adjuster_reproj(
        [MarshalAs(UnmanagedType.I1)] bool is_focals,
        [MarshalAs(UnmanagedType.I1)] bool is_ppx,
        [MarshalAs(UnmanagedType.I1)] bool is_ppy,
        [MarshalAs(UnmanagedType.I1)] bool is_aspect,
        [MarshalAs(UnmanagedType.I1)] bool is_skew,
        [MarshalAs(UnmanagedType.I1)] bool is_wave_correct,
        double conf_thresh,
        StdVectorHandle features,
        StdVectorHandle pairwise_matches,
        StdVectorHandle cameras);

    [LibraryImport(Name)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    internal static partial bool api_modules_estimator_bundle_adjuster_affine_partial(
        [MarshalAs(UnmanagedType.I1)] bool is_focals,
        [MarshalAs(UnmanagedType.I1)] bool is_ppx,
        [MarshalAs(UnmanagedType.I1)] bool is_ppy,
        [MarshalAs(UnmanagedType.I1)] bool is_aspect,
        [MarshalAs(UnmanagedType.I1)] bool is_skew,
        [MarshalAs(UnmanagedType.I1)] bool is_wave_correct,
        double conf_thresh,
        StdVectorHandle features,
        StdVectorHandle pairwise_matches,
        StdVectorHandle cameras);
}