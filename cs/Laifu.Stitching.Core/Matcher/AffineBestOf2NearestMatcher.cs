// ReSharper disable InconsistentNaming

using Laifu.Stitching.Core.Finder;
using Laifu.Stitching.Core.Services;

namespace Laifu.Stitching.Core.Matcher;

public class AffineBestOf2NearestMatcher(
    bool full_affine = false,
    bool try_use_gpu = false,
    double match_conf = 0.3,
    int num_matches_thresh1 = 6) : IMatcherService
{
    public void Match(ImageFeatures[] features, out MatchesInfo[] infos, double conf = 1)
    {

        MatcherHelper.api_modules_matcher_affine(
            full_affine,
            try_use_gpu,
            (float)conf,
            num_matches_thresh1,
            features.ToHandle(),
            out var vector).ThrowHandleException();

        infos = vector.ToMatchInfos();
    }
}