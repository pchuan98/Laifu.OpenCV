using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Laifu.OpenCv.Native;
using Laifu.OpenCv.Native.Constants;

// ReSharper disable InconsistentNaming
namespace Laifu.Stitching.Core.Matcher;

// base
internal static partial class MatcherHelper
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

// MatchesInfo
partial class MatcherHelper
{
    [LibraryImport(Name)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus api_modules_matches_info_create(out SafePtrHandle matchesInfo);

    [LibraryImport(Name)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial int api_modules_matches_info_src_img_idx(SafePtrHandle matchesInfo);

    [LibraryImport(Name)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial int api_modules_matches_info_dst_img_idx(SafePtrHandle matchesInfo);

    [LibraryImport(Name)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial int api_modules_matches_info_num_inliers(SafePtrHandle matchesInfo);

    [LibraryImport(Name)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus api_modules_matches_info_matches(SafePtrHandle matchesInfo, out StdVectorHandle matches);

    [LibraryImport(Name)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus api_modules_matches_info_inliers_mask(SafePtrHandle matchesInfo, out StdVectorHandle inliersMask);

    [LibraryImport(Name)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus api_modules_matches_info_H(SafePtrHandle matchesInfo, out MatHandle H);

    [LibraryImport(Name)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial double api_modules_matches_info_confidence(SafePtrHandle matchesInfo);
}

// AffineBestOf2NearestMatcher
partial class MatcherHelper
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="full_affine"></param>
    /// <param name="try_use_gpu"></param>
    /// <param name="match_conf"></param>
    /// <param name="num_matches_thresh1"></param>
    /// <param name="features"></param>
    /// <param name="matches"></param>
    /// <returns></returns>
    [LibraryImport(Name)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus api_modules_matcher_affine(
       [MarshalAs(UnmanagedType.I1)] bool full_affine,
       [MarshalAs(UnmanagedType.I1)] bool try_use_gpu,
        float match_conf,
        int num_matches_thresh1,
        StdVectorHandle features,
        out StdVectorHandle matches);
}

// BestOf2NearestMatcher
partial class MatcherHelper
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="try_use_gpu"></param>
    /// <param name="match_conf"></param>
    /// <param name="num_matches_thresh1"></param>
    /// <param name="num_matches_thresh2"></param>
    /// <param name="matches_confindece_thresh"></param>
    /// <param name="features"></param>
    /// <param name="matches"></param>
    /// <returns></returns>
    [LibraryImport(Name)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus api_modules_matcher_bestof2nearest(
        [MarshalAs(UnmanagedType.I1)] bool try_use_gpu,
        float match_conf,
        int num_matches_thresh1,
        int num_matches_thresh2,
        double matches_confindece_thresh,
        StdVectorHandle features,
        out StdVectorHandle matches);
}

// BestOf2NearestRangeMatcher
partial class MatcherHelper
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="range_width"></param>
    /// <param name="try_use_gpu"></param>
    /// <param name="match_conf"></param>
    /// <param name="num_matches_thresh1"></param>
    /// <param name="num_matches_thresh2"></param>
    /// <param name="features"></param>
    /// <param name="matches"></param>
    /// <returns></returns>
    [LibraryImport(Name)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus api_modules_matcher_bestof2range(
        int range_width,
        [MarshalAs(UnmanagedType.I1)] bool try_use_gpu,
        float match_conf,
        int num_matches_thresh1,
        int num_matches_thresh2,
        StdVectorHandle features,
        out StdVectorHandle matches);
}