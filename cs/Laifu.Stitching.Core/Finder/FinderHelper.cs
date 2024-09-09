using Laifu.OpenCv.Native;
using Laifu.OpenCv.Native.Constants;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CvSize = Laifu.Stitching.Core.Models.CvSize;

// ReSharper disable InconsistentNaming
namespace Laifu.Stitching.Core.Finder;

internal static partial class FinderHelper
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

// ImageFeatures
partial class FinderHelper
{
    [LibraryImport(Name)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus api_modules_features_create(out SafePtrHandle features);

    [LibraryImport(Name)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial int api_modules_features_index(SafePtrHandle features);

    [LibraryImport(Name)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial CvSize api_modules_features_size(SafePtrHandle features);

    [LibraryImport(Name)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus api_modules_features_keypoints(SafePtrHandle features, out StdVectorHandle keypoints);

    [LibraryImport(Name)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus api_modules_features_descriptors(SafePtrHandle features, out SafePtrHandle descriptors);

    [LibraryImport(Name)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus api_modules_features_array2vector(nint[] features, int size, out StdVectorHandle vector);
}

// orb
partial class FinderHelper
{
    [LibraryImport(Name)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus api_modules_finder_orb(
        MatHandle iamge,
        int nfeatures,
        float scaleFactor,
        int nlevels,
        int edgeThreshold,
        int firstLevel,
        int WTA_K,
        int scoreType,
        int patchSize,
        int fastThreshold,
        double scale,
        int index,
        SafePtrHandle features);

}

// akaze
partial class FinderHelper
{
    [LibraryImport(Name)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus api_modules_finder_akaze(
        MatHandle iamge,
        int descriptor_type,
        int descriptor_size,
        int descriptor_channels,
        float threshold,
        int nOctaves,
        int nOctaveLayers,
        int diffusivity,
        int max_points,
        double scale,
        int index,
        SafePtrHandle features);
}

// surf
partial class FinderHelper
{
    [LibraryImport(Name)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus api_modules_finder_surf(
        MatHandle iamge,
        double hessianThreshold,
        int nOctaves,
        int nOctaveLayers,
        [MarshalAs(UnmanagedType.I1)] bool extended,
        [MarshalAs(UnmanagedType.I1)] bool upright,
        double scale,
        int index,
        SafePtrHandle features);
}

// sift
partial class FinderHelper
{
    [LibraryImport(Name)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus api_modules_finder_sift(
        MatHandle iamge,
        int nfeatures,
        int nOctaveLayers,
        double contrastThreshold,
        double edgeThreshold,
        double sigma,
        [MarshalAs(UnmanagedType.I1)] bool enable_precise_upscale,
        double scale,
        int index,
        SafePtrHandle features);
}

