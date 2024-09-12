// ReSharper disable InconsistentNaming

using Laifu.Stitching.Core.Finder;
using Laifu.Stitching.Core.Services;

namespace Laifu.Stitching.Core.Matcher;

public class BestOf2NearestMatcher(
    bool try_use_gpu = false,
    float match_conf = 0.3f,
    int num_matches_thresh1 = 6,
    int num_matches_thresh2 = 6,
    double matches_confidence_thresh = 3.0) : IMatcherService
{
    public void Match(ImageFeatures[] features, out MatchesInfo[] infos, double conf = 1)
    {
        MatcherHelper.api_modules_matcher_bestof2nearest(
            try_use_gpu,
            match_conf,
            num_matches_thresh1,
            num_matches_thresh2,
            matches_confidence_thresh,
            features.ToHandle(),
            out var vector).ThrowHandleException();

        infos = vector.ToMatchInfos();
    }
}
