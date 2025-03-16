// ReSharper disable once CheckNamespace
namespace Laifu.OpenCv.Native.ImageCodecs;

/// <summary>
/// Enumeration for EXR compression flags used in image writing in OpenCV.
/// Specifies the compression type for EXR format.
/// </summary>
// ReSharper disable once InconsistentNaming
public enum ImwriteEXRCompressionFlags
{
    /// <summary>
    /// No compression.
    /// </summary>
    IMWRITE_EXR_COMPRESSION_NO = 0,

    /// <summary>
    /// Run length encoding.
    /// </summary>
    IMWRITE_EXR_COMPRESSION_RLE = 1,

    /// <summary>
    /// Zlib compression, one scan line at a time.
    /// </summary>
    IMWRITE_EXR_COMPRESSION_ZIPS = 2,

    /// <summary>
    /// Zlib compression, in blocks of 16 scan lines.
    /// </summary>
    IMWRITE_EXR_COMPRESSION_ZIP = 3,

    /// <summary>
    /// Piz-based wavelet compression.
    /// </summary>
    IMWRITE_EXR_COMPRESSION_PIZ = 4,

    /// <summary>
    /// Lossy 24-bit float compression.
    /// </summary>
    IMWRITE_EXR_COMPRESSION_PXR24 = 5,

    /// <summary>
    /// Lossy 4-by-4 pixel block compression, fixed compression rate.
    /// </summary>
    IMWRITE_EXR_COMPRESSION_B44 = 6,

    /// <summary>
    /// Lossy 4-by-4 pixel block compression, flat fields are compressed more.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    IMWRITE_EXR_COMPRESSION_B44A = 7,

    /// <summary>
    /// Lossy DCT-based compression, in blocks of 32 scanlines. More efficient for partial buffer access. Supported since OpenEXR 2.2.0.
    /// </summary>
    IMWRITE_EXR_COMPRESSION_DWAA = 8,

    /// <summary>
    /// Lossy DCT-based compression, in blocks of 256 scanlines. More efficient space-wise and faster to decode full frames than DWAA_COMPRESSION. Supported since OpenEXR 2.2.0.
    /// </summary>
    IMWRITE_EXR_COMPRESSION_DWAB = 9
}
