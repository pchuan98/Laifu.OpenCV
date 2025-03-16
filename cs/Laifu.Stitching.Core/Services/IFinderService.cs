using Laifu.OpenCv.Cv2;
using Laifu.Stitching.Core.Finder;

namespace Laifu.Stitching.Core.Services;

public interface IFinderService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="image"></param>
    /// <param name="feature"></param>
    public void ComputeImageFeatures(
        Mat image,
        out ImageFeatures feature);
}