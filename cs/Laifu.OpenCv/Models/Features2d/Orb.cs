using Laifu.OpenCv.Constants.Features2d.Orb;

// ReSharper disable once CheckNamespace
namespace Laifu.OpenCv.Models;

public class Orb : DisposableObject
{
    private readonly Feature2dHandle _handle;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="nfeatures"></param>
    /// <param name="scaleFactor"></param>
    /// <param name="nlevels"></param>
    /// <param name="edgeThreshold"></param>
    /// <param name="firstLevel"></param>
    /// <param name="wtaK"></param>
    /// <param name="scoreType"></param>
    /// <param name="patchSize"></param>
    /// <param name="fastThreshold"></param>
    public Orb(int nfeatures = 500, float scaleFactor = 1.2f, int nlevels = 8,
        int edgeThreshold = 31, int firstLevel = 0, int wtaK = 2,
        ScoreType scoreType = ScoreType.HARRIS_SCORE, int patchSize = 31, int fastThreshold = 20)
    {
        Fd_Create_Orb(nfeatures, scaleFactor, nlevels,
            edgeThreshold, firstLevel, wtaK,
            (int)scoreType, patchSize, fastThreshold, out _handle).ThrowHandleException();
    }
}