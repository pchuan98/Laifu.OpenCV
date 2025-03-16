using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laifu.OpenCv.Native;
using Laifu.Stitching.Core.Estimator;
using Laifu.Stitching.Core.Finder;
using Laifu.Stitching.Core.Matcher;

namespace Laifu.Stitching.Core.Services;

public interface IAdjusterService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="features"></param>
    /// <param name="matches"></param>
    /// <param name="cameras"></param>
    /// <returns></returns>
    public bool Estimate(
        ref ImageFeatures[] features,
        ref MatchesInfo[] matches,
        ref CameraParams[] cameras);
}