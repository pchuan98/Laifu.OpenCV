using Laifu.OpenCv.Cv2;
using Laifu.Stitching.Core.Services;

// ReSharper disable InconsistentNaming
namespace Laifu.Stitching.Core.Finder;

/// <summary>
/// 
/// </summary>
public enum OrbScoreType
{
    /// <summary>
    /// 
    /// </summary>
    HARRIS_SCORE = 0,

    /// <summary>
    /// 
    /// </summary>
    FAST_SCORE = 1
};

/// <summary>
/// Represents the ORB (Oriented FAST and Rotated BRIEF) feature detector and descriptor extractor.
/// </summary>
/// <param name="nfeatures">The maximum number of features to retain.</param>
/// <param name="scaleFactor">
/// Pyramid decimation ratio, greater than 1. scaleFactor==2 means the classical pyramid, 
/// where each next level has 4x less pixels than the previous. A large scale factor will 
/// degrade feature matching scores dramatically. However, a scale factor too close to 1 
/// will require more pyramid levels to cover a certain scale range, affecting speed.
/// </param>
/// <param name="nlevels">
/// The number of pyramid levels. The smallest level will have linear size equal to 
/// input_image_linear_size/pow(scaleFactor, nlevels - firstLevel).
/// </param>
/// <param name="edgeThreshold">
/// Size of the border where features are not detected. Should roughly match the patchSize parameter.
/// </param>
/// <param name="firstLevel">
/// The level of pyramid to put source image to. Previous layers are filled with upscaled source image.
/// </param>
/// <param name="WTA_K">
/// The number of points that produce each element of the oriented BRIEF descriptor. 
/// Default is 2, other possible values are 3 and 4. Higher values use more points 
/// to compute each bin, resulting in a different bit representation.
/// </param>
/// <param name="scoreType">
/// The algorithm used to rank features. HARRIS_SCORE (default) uses the Harris algorithm, 
/// while FAST_SCORE is slightly faster but produces less stable keypoints.
/// </param>
/// <param name="patchSize">
/// Size of the patch used by the oriented BRIEF descriptor. On smaller pyramid layers, 
/// the perceived image area covered by a feature will be larger.
/// </param>
/// <param name="fastThreshold">The fast threshold used in the FAST detector stage.</param>
public partial class Orb(
    int index = 0,
    double scale = 1.0,
    int nfeatures = 500,
    float scaleFactor = 1.2f,
    int nlevels = 8,
    int edgeThreshold = 31,
    int firstLevel = 0,
    int WTA_K = 2,
    OrbScoreType scoreType = OrbScoreType.HARRIS_SCORE,
    int patchSize = 31,
    int fastThreshold = 20) : IFinderService
{
    public void ComputeImageFeatures(Mat image, out ImageFeatures feature)
    {
        feature = ImageFeatures.Create();

        FinderHelper.api_modules_finder_orb(
            image.Handle,
            nfeatures,
            scaleFactor,
            nlevels,
            edgeThreshold,
            firstLevel,
            WTA_K,
            (int)scoreType,
            patchSize,
            fastThreshold,
            scale,
            index,
            feature.Handle);
    }
}