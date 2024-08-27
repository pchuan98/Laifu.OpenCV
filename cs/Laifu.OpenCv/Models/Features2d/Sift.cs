using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laifu.OpenCv.Models.Features2d;

public class Sift : DisposableObject
{
    private readonly Feature2dHandle _handle;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="nfeatures"></param>
    /// <param name="nOctaveLayers"></param>
    /// <param name="contrastThreshold"></param>
    /// <param name="edgeThreshold"></param>
    /// <param name="sigma"></param>
    /// <param name="enablePreciseUpscale"></param>
    public Sift(
        int nfeatures = 0,
        int nOctaveLayers = 3,
        double contrastThreshold = 0.04,
        double edgeThreshold = 10,
        double sigma = 1.6,
        bool enablePreciseUpscale = false) => Fd_Create_Sift(nfeatures, nOctaveLayers, contrastThreshold,
        edgeThreshold, sigma, enablePreciseUpscale, out _handle);
}

