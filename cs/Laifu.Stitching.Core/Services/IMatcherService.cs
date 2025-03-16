using Laifu.Stitching.Core.Finder;
using Laifu.Stitching.Core.Matcher;

namespace Laifu.Stitching.Core.Services;

public interface IMatcherService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="features"></param>
    /// <param name="infos"></param>
    /// <param name="conf"></param>
    public void Match(ImageFeatures[] features, out MatchesInfo[] infos, double conf = 1.0);
}