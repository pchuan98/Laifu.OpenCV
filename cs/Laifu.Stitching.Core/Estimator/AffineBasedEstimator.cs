using Laifu.Stitching.Core.Services;
using Laifu.Stitching.Core.Finder;
using Laifu.Stitching.Core.Matcher;

namespace Laifu.Stitching.Core.Estimator;

public class AffineBasedEstimator : IEstimatorService
{
    public bool Estimate(
        IEnumerable<ImageFeatures> features, 
        IEnumerable<MatchesInfo> matches, 
        out CameraParams[] cameras)
    {
        var featuresHandle = features.ToHandle();
        var matchesHandle = matches.ToHandle();

        var ret = EstimatorHelper.api_modules_estimator_affine(featuresHandle, matchesHandle, out var handle);

        cameras = handle.ToCameraParams();

        return ret;
    }
}