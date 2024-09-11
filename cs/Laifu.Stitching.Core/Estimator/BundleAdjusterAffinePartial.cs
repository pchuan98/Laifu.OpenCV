// ReSharper disable InconsistentNaming

using Laifu.Stitching.Core.Services;
using Laifu.Stitching.Core.Finder;
using Laifu.Stitching.Core.Matcher;

namespace Laifu.Stitching.Core.Estimator;

public class BundleAdjusterAffinePartial(
    double conf_thresh = 1.0,
    bool is_focals = true,
    bool is_ppx = true,
    bool is_ppy = true,
    bool is_aspect = true,
    bool is_skew = true,
    bool is_wave_correct = false)
    : IAdjusterService
{
    public bool Estimate(ref ImageFeatures[] features, ref MatchesInfo[] matches, ref CameraParams[] cameras)
    {
        var featuresHandle = features.ToHandle();
        var matchesHandle = matches.ToHandle();
        var camerasHandle = cameras.ToHandle();

        var rec = EstimatorHelper.api_modules_estimator_bundle_adjuster_affine_partial(
            is_focals,
            is_ppx,
            is_ppy,
            is_aspect,
            is_skew,
            is_wave_correct,
            conf_thresh,
            featuresHandle,
            matchesHandle,
            camerasHandle);

        if (!rec) return rec;

        features = featuresHandle.ToImageFeatures();
        matches = matchesHandle.ToMatchInfos();
        cameras = camerasHandle.ToCameraParams();

        return rec;
    }
}