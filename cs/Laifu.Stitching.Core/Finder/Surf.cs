using Laifu.OpenCv.Cv2;
using Laifu.Stitching.Core.Services;

namespace Laifu.Stitching.Core.Finder;

/// <summary>
/// 
/// </summary>
/// <param name="index"></param>
/// <param name="scale"></param>
/// <param name="hessianThreshold"></param>
/// <param name="nOctaves"></param>
/// <param name="nOctaveLayers"></param>
/// <param name="extended"></param>
/// <param name="upright"></param>
public partial class Surf(
    int index = 0,
    double scale = 1.0, 
    double hessianThreshold = 100,
    int nOctaves = 4,
    int nOctaveLayers = 3,
    bool extended = false,
    bool upright = false) : IFinderService
{
    public void ComputeImageFeatures(Mat image, out ImageFeatures feature)
    {
        feature = ImageFeatures.Create();

        FinderHelper.api_modules_finder_surf(
            image.Handle,
            hessianThreshold,
            nOctaves,
            nOctaveLayers,
            extended,
            upright,
            scale,
            index,
            feature.Handle).ThrowHandleException();
    }
}