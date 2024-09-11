// ReSharper disable InconsistentNaming

using Laifu.Stitching.Core.Finder;
using Laifu.Stitching.Core.Matcher;
using Laifu.Stitching.Core.Services;

namespace Laifu.Stitching.Core.Estimator;

public class HomographyBasedEstimator(
    bool is_focals_estimated = false) : IEstimatorService
{
    public bool Estimate(IEnumerable<ImageFeatures> features, IEnumerable<MatchesInfo> matches, out CameraParams[] cameras)
    {
        var featuresHandle = features.ToHandle();
        var matchesHandle = matches.ToHandle();

        var ret = EstimatorHelper.api_modules_estimator_homography(is_focals_estimated, featuresHandle, matchesHandle,
            out var handle);

        cameras = handle.ToCameraParams();

        return ret;
    }
}