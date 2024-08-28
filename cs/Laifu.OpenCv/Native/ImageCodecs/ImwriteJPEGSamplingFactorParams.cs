namespace Laifu.OpenCv.Native.ImageCodecs;

/// <summary>
/// Enumeration for JPEG sampling factors used in image writing in OpenCV.
/// </summary>
// ReSharper disable once InconsistentNaming
public enum ImwriteJPEGSamplingFactorParams
{
    /// <summary>
    /// 4x1,1x1,1x1 sampling factor.
    /// </summary>
    IMWRITE_JPEG_SAMPLING_FACTOR_411 = 0x411111,

    /// <summary>
    /// 2x2,1x1,1x1 sampling factor (Default).
    /// </summary>
    IMWRITE_JPEG_SAMPLING_FACTOR_420 = 0x221111,

    /// <summary>
    /// 2x1,1x1,1x1 sampling factor.
    /// </summary>
    IMWRITE_JPEG_SAMPLING_FACTOR_422 = 0x211111,

    /// <summary>
    /// 1x2,1x1,1x1 sampling factor.
    /// </summary>
    IMWRITE_JPEG_SAMPLING_FACTOR_440 = 0x121111,

    /// <summary>
    /// 1x1,1x1,1x1 sampling factor (No subsampling).
    /// </summary>
    IMWRITE_JPEG_SAMPLING_FACTOR_444 = 0x111111
}
