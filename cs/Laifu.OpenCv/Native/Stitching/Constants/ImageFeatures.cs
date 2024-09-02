using System.Drawing;
using Laifu.OpenCv.Cv2;
using Laifu.OpenCv.Cv2.Core;
using Laifu.OpenCv.Native.Core;

// ReSharper disable once CheckNamespace
namespace Laifu.OpenCv.Native.Stitching;

internal static partial class ImageFeatureHelper
{
    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_ImageFeatures_getKeypoints")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus GetKeyPoints(CvImageFeatures feature, out StdVectorHandle handle);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_ImageFeatures_getDescriptors")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus GetDescriptors(CvImageFeatures feature, out UMatHandle handle);

}

public class ImageFeature
{
    /// <summary>
    /// 
    /// </summary>
    public int Index { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public Size Size { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public VectorOfKeyPoints Points { get; private set; }


    public ImageFeature(CvImageFeatures features)
    {
        Index = features.ImgIdx;

        var s = features.ImgSize;
        Size = new Size(s.Width, s.Height);

        ImageFeatureHelper.GetKeyPoints(features, out var vector)
            .ThrowHandleException();
       
        Points = new VectorOfKeyPoints(vector);
    }
}

[Serializable]
[StructLayout(LayoutKind.Sequential)]

public struct CvImageFeatures
{
    /// <summary>
    /// 
    /// </summary>
    public int ImgIdx;

    /// <summary>
    /// 
    /// </summary>
    public Size2i ImgSize;

    /// <summary>
    /// 
    /// </summary>
    public nint Keypoints;

    /// <summary>
    /// 
    /// </summary>
    public nint Descriptors;
}