// ReSharper disable once CheckNamespace
namespace Laifu.OpenCv.Native.ImageCodecs;

/** These flags will be modify the way of PNG image compression and will be passed to the underlying zlib processing stage.

-   The effect of IMWRITE_PNG_STRATEGY_FILTERED is to force more Huffman coding and less string matching; it is somewhat intermediate between IMWRITE_PNG_STRATEGY_DEFAULT and IMWRITE_PNG_STRATEGY_HUFFMAN_ONLY.
-   IMWRITE_PNG_STRATEGY_RLE is designed to be almost as fast as IMWRITE_PNG_STRATEGY_HUFFMAN_ONLY, but give better compression for PNG image data.
-   The strategy parameter only affects the compression ratio but not the correctness of the compressed output even if it is not set appropriately.
-   IMWRITE_PNG_STRATEGY_FIXED prevents the use of dynamic Huffman codes, allowing for a simpler decoder for special applications.
*/

/// <summary>
/// Imwrite PNG specific flags used to tune the compression algorithm in OpenCV.
/// These flags modify the way PNG image compression is handled and are passed to the underlying zlib processing stage.
/// </summary>
// ReSharper disable once InconsistentNaming
public enum ImwritePNGFlags
{
    /// <summary>
    /// Use this value for normal data.
    /// </summary>
    IMWRITE_PNG_STRATEGY_DEFAULT = 0,

    /// <summary>
    /// Use this value for data produced by a filter (or predictor).
    /// Filtered data consists mostly of small values with a somewhat random distribution.
    /// In this case, the compression algorithm is tuned to compress them better.
    /// </summary>
    IMWRITE_PNG_STRATEGY_FILTERED = 1,

    /// <summary>
    /// Use this value to force Huffman encoding only (no string match).
    /// </summary>
    IMWRITE_PNG_STRATEGY_HUFFMAN_ONLY = 2,

    /// <summary>
    /// Use this value to limit match distances to one (run-length encoding).
    /// </summary>
    IMWRITE_PNG_STRATEGY_RLE = 3,

    /// <summary>
    /// Using this value prevents the use of dynamic Huffman codes, allowing for a simpler decoder for special applications.
    /// </summary>
    IMWRITE_PNG_STRATEGY_FIXED = 4
}
