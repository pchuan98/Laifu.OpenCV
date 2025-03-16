// ReSharper disable once CheckNamespace
namespace Laifu.OpenCv.Native.ImageCodecs;

/// <summary>
/// Imwrite HDR specific values for the IMWRITE_HDR_COMPRESSION parameter key.
/// Specifies the compression type for HDR images.
/// </summary>
// ReSharper disable once InconsistentNaming
public enum ImwriteHDRCompressionFlags
{
    /// <summary>
    /// No compression.
    /// </summary>
    IMWRITE_HDR_COMPRESSION_NONE = 0,

    /// <summary>
    /// Run length encoding compression.
    /// </summary>
    IMWRITE_HDR_COMPRESSION_RLE = 1
}
