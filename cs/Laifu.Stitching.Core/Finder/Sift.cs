using Laifu.OpenCv.Cv2;
using Laifu.Stitching.Core.Services;

// ReSharper disable InconsistentNaming
namespace Laifu.Stitching.Core.Finder;

/// <summary>
/// 
/// </summary>
/// <param name="index"></param>
/// <param name="scale"></param>
/// <param name="nfeatures"></param>
/// <param name="nOctaveLayers"></param>
/// <param name="contrastThreshold"></param>
/// <param name="edgeThreshold"></param>
/// <param name="sigma"></param>
/// <param name="enable_precise_upscale"></param>
public partial class Sift(
    int index = 0,
    double scale = 1.0,
    int nfeatures = 0,
    int nOctaveLayers = 3,
    double contrastThreshold = 0.04,
    double edgeThreshold = 10,
    double sigma = 1.6,
    bool enable_precise_upscale = false) : IFinderService
{
    public void ComputeImageFeatures(Mat image, out ImageFeatures feature)
    {
        feature = ImageFeatures.Create();

        FinderHelper.api_modules_finder_sift(
            image.Handle,
            nfeatures,
            nOctaveLayers,
            contrastThreshold,
            edgeThreshold,
            sigma,
            enable_precise_upscale,
            scale,
            index,
            feature.Handle);
    }
}