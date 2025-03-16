using Laifu.Stitching.Core.Finder;
using Laifu.Stitching.Core.Matcher;
using Laifu.Stitching.Core.Others;

namespace Laifu.Stitching.Core.Estimator;

public static class EstimatorExtension
{
    public static void LeaveBiggestComponent(
        ref ImageFeatures[] features,
        ref MatchesInfo[] matches,
        out int[] indices,
        double conf)
    {
        var featuresHandle = features.ToHandle();
        var matchesHandle = matches.ToHandle();

        EstimatorHelper.api_modules_estimator_leaveBiggestComponent(
            featuresHandle,
            matchesHandle,
            conf,
            out var handle).ThrowHandleException();

        var vector = new VectorOfInt(handle);
        indices = vector.ToArray();

        features = featuresHandle.ToImageFeatures();
        matches = matchesHandle.ToMatchInfos();
    }
}
