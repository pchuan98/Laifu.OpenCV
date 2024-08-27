// ReSharper disable once CheckNamespace
namespace Laifu.OpenCv.Models;

public class Surf : DisposableObject
{
    private readonly Feature2dHandle _handle;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="hessianThreshold"></param>
    /// <param name="nOctaves"></param>
    /// <param name="nOctaveLayers"></param>
    /// <param name="extended"></param>
    /// <param name="upright"></param>
    public Surf(
        double hessianThreshold = 100,
        int nOctaves = 4,
        int nOctaveLayers = 3,
        bool extended = false,
        bool upright = false) => XFd_Create_Surf(hessianThreshold, nOctaves, nOctaveLayers, extended, upright, out _handle);
}
