// ReSharper disable InconsistentNaming

using Laifu.Stitching.Core.Finder;
using Laifu.Stitching.Core.Services;

namespace Laifu.Stitching.Core.Matcher;

public class BestOf2NearestRangeMatcher(
    int range_width = 5,
    bool try_use_gpu = false,
    float match_conf = 0.3f,
    int num_matches_thresh1 = 6,
    int num_matches_thresh2 = 6) : IMatcherService
{
    public void Match(ImageFeatures[] features, out MatchesInfo[] infos, double conf = 1)
    {
        MatcherHelper.api_modules_matcher_bestof2range(
            range_width,
            try_use_gpu,
            match_conf,
            num_matches_thresh1,
            num_matches_thresh2,
            features.ToHandle(),
            out var vector).ThrowHandleException();

        infos = vector.ToMatchInfos();
    }
}
