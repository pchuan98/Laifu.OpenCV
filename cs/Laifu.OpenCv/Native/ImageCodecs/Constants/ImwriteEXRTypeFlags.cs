// ReSharper disable once CheckNamespace
namespace Laifu.OpenCv.Native.ImageCodecs;

/// <summary>
/// Enumeration for EXR type flags used in image writing in OpenCV.
/// Specifies the pixel storage type for EXR format.
/// </summary>
// ReSharper disable once InconsistentNaming
public enum ImwriteEXRTypeFlags
{
    /// <summary>
    /// Store as HALF (FP16).
    /// </summary>
    IMWRITE_EXR_TYPE_HALF = 1,

    /// <summary>
    /// Store as FP32 (default).
    /// </summary>
    IMWRITE_EXR_TYPE_FLOAT = 2
}
