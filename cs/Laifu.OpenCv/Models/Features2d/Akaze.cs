using Laifu.OpenCv.Constants.Features2d.Akaze;

// ReSharper disable once CheckNamespace
namespace Laifu.OpenCv.Models;

public class Akaze : DisposableObject
{
    private readonly Feature2dHandle _handle;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="descriptorType"></param>
    /// <param name="descriptorSize"></param>
    /// <param name="descriptorChannels"></param>
    /// <param name="threshold"></param>
    /// <param name="nOctaves"></param>
    /// <param name="nOctaveLayers"></param>
    /// <param name="diffusivity"></param>
    /// <param name="maxPoints"></param>
    public Akaze(
        DescriptorType descriptorType = DescriptorType.DESCRIPTOR_MLDB,
        int descriptorSize = 0,
        int descriptorChannels = 3,
        float threshold = 0.001f,
        int nOctaves = 4,
        int nOctaveLayers = 4,
        DiffusivityType diffusivity = DiffusivityType.DIFF_PM_G2,
        int maxPoints = -1) => Fd_Create_Akaze((int)descriptorType, descriptorSize, descriptorChannels,
            threshold, nOctaves, nOctaveLayers, (int)diffusivity, maxPoints, out _handle).ThrowHandleException();

}