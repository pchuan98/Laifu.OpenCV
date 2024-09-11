using Laifu.Stitching.Core.Estimator;
using Laifu.Stitching.Core.Finder;
using Laifu.Stitching.Core.Matcher;

namespace Laifu.Stitching.Core.Services;

public interface IEstimatorService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="features"></param>
    /// <param name="matches"></param>
    /// <param name="cameras"></param>
    /// <returns></returns>
    public bool Estimate(
        IEnumerable<ImageFeatures> features,
        IEnumerable<MatchesInfo> matches,
        out CameraParams[] cameras);
}