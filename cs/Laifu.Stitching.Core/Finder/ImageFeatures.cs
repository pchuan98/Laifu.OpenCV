using Laifu.OpenCv.Native.Stitching;
using Laifu.OpenCv.Native;
using System.Drawing;
using Laifu.OpenCv.Cv2.Core;
using Laifu.OpenCv.Native.Core;

namespace Laifu.Stitching.Core.Finder;

public static class ImageFeaturesHelper
{
    public static StdVectorHandle ToHandle(this IEnumerable<ImageFeatures> features)
    {
        var array = features
            .ToArray()
            .Select(item => item.Handle)
            .Select(handle => handle.DangerousGetHandle())
            .ToArray();

        FinderHelper.api_modules_features_array2vector(array, array.Length, out var vector)
            .ThrowHandleException();
        return vector;
    }

    public static ImageFeatures[] ToImageFeatures(this StdVectorHandle ptr)
    {
        var vector = new VectorOfImageFeatures(ptr);
        return vector.ToArray();
    }
}

public class ImageFeatures(SafePtrHandle features)
{
    public SafePtrHandle Handle { get; init; } = features;

    public static ImageFeatures Create()
    {
        FinderHelper.api_modules_features_create(out var features);
        return new ImageFeatures(features);
    }

    /// <summary>
    /// 
    /// </summary>
    public int Index => FinderHelper.api_modules_features_index(Handle);

    /// <summary>
    /// 
    /// </summary>
    public Size Size
    {
        get
        {
            var cvsize = FinderHelper.api_modules_features_size(Handle);
            return new Size(cvsize.width, cvsize.height);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public KeyPoint[]? Points
    {
        get
        {
            FinderHelper
                .api_modules_features_keypoints(Handle, out var ptr)
                .ThrowHandleException();

            var vector = new VectorOfKeyPoints(ptr);
            return vector.ToArray();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public UMat? Descriptor { get; private set; }
}