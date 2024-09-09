using System.Text;
using Laifu.OpenCv.Cv2;
using Laifu.OpenCv.Native;
using Laifu.Stitching.Core.Models;

namespace Laifu.Stitching.Core.Matcher;

public static class MatchesInfoHelper
{
    public static MatchesInfo[] ToMatchInfos(this StdVectorHandle ptr)
    {
        var vector = new VectorOfMatchInfo(ptr);

        return vector.ToArray();
    }
}

public class MatchesInfo(SafePtrHandle handle) : IDisposable
{
    public SafePtrHandle Handle { get; } = handle;

    public static MatchesInfo Create()
    {
        MatcherHelper.api_modules_matches_info_create(out var matchesInfo).ThrowHandleException();
        return new MatchesInfo(matchesInfo);
    }

    public int SrcIndex => MatcherHelper.api_modules_matches_info_src_img_idx(Handle);

    public int DstIndex => MatcherHelper.api_modules_matches_info_dst_img_idx(Handle);

    public int NumberOfInliers => MatcherHelper.api_modules_matches_info_num_inliers(Handle);

    public DMatch[]? Matches
    {
        get
        {
            MatcherHelper
                .api_modules_matches_info_matches(Handle, out var ptr)
                .ThrowHandleException();

            var vector = new VectorOfDMatch(ptr);
            return vector.ToArray();
        }
    }

    public byte[]? InliersMask
    {
        get
        {
            MatcherHelper
                .api_modules_matches_info_inliers_mask(Handle, out var ptr)
                .ThrowHandleException();

            var vector = new VectorOfUChar(ptr);
            return vector.ToArray();
        }
    }

    public Mat? H
    {
        get
        {
            MatcherHelper
                .api_modules_matches_info_H(Handle, out var matHandle)
                .ThrowHandleException();

            return new Mat(matHandle);
        }
    }

    public double Confidence => MatcherHelper.api_modules_matches_info_confidence(Handle);

    public void Dispose()
    {
        Handle.Dispose();
    }

    public override string ToString()
    {
        var src = SrcIndex;
        var dst = DstIndex;

        var count = Matches?.Length ?? 0;
        var first = count >= 1 ? Matches![0].ToString()! : "NULL";
        var last = count > 1 ? Matches![^1].ToString()! : "NULL";

        var h = H!;
        var cols = h.Cols;
        var rows = h.Rows;

        var confidence = Confidence;

        return $"src:       {src}\n" +
               $"dst:       {dst}\n" +
               $"conf:      {confidence}\n" +
               $"match:     {count}\n" +
               $"[0]        {first}\n" +
               $"[^1]       {last}";
    }
}