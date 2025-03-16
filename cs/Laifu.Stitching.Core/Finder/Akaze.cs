using Laifu.OpenCv.Cv2;
using Laifu.Stitching.Core.Services;

// ReSharper disable InvalidXmlDocComment
// ReSharper disable InconsistentNaming
namespace Laifu.Stitching.Core.Finder;

public enum AkazeDescriptorType
{
    DESCRIPTOR_KAZE_UPRIGHT = 2, ///< Upright descriptors, not invariant to rotation
    DESCRIPTOR_KAZE = 3,
    DESCRIPTOR_MLDB_UPRIGHT = 4, ///< Upright descriptors, not invariant to rotation
    DESCRIPTOR_MLDB = 5
}

public enum AkazeDiffusivityType
{
    DIFF_PM_G1 = 0,
    DIFF_PM_G2 = 1,
    DIFF_WEICKERT = 2,
    DIFF_CHARBONNIER = 3
};

/// <summary>
/// 
/// </summary>
/// <param name="index"></param>
/// <param name="scale"></param>
/// <param name="descriptor_type"></param>
/// <param name="descriptor_size"></param>
/// <param name="descriptor_channels"></param>
/// <param name="threshold"></param>
/// <param name="nOctaves"></param>
/// <param name="nOctaveLayers"></param>
/// <param name="diffusivity"></param>
/// <param name="max_points"></param>
public partial class Akaze(
    int index = 0,
    double scale = 1.0,
    AkazeDescriptorType descriptor_type = AkazeDescriptorType.DESCRIPTOR_MLDB,
    int descriptor_size = 0,
    int descriptor_channels = 3,
    float threshold = 0.001f,
    int nOctaves = 4,
    int nOctaveLayers = 4,
    AkazeDiffusivityType diffusivity = AkazeDiffusivityType.DIFF_PM_G2,
    int max_points = -1
    ) : IFinderService
{
    public void ComputeImageFeatures(Mat image, out ImageFeatures feature)
    {
        feature = ImageFeatures.Create();

        FinderHelper.api_modules_finder_akaze(
            image.Handle,
            (int)descriptor_type,
            descriptor_size,
            descriptor_channels,
            threshold,
            nOctaves,
            nOctaveLayers,
            (int)diffusivity,
            max_points,
            scale,
            index,
            feature.Handle).ThrowHandleException();
    }
}