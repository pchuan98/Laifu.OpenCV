namespace Laifu.OpenCv.Native.ImageCodecs;

/// <summary>
/// Enumeration for TIFF compression flags used in image writing in OpenCV.
/// </summary>
public enum ImwriteTiffCompressionFlags
{
    /// <summary>
    /// No compression (dump mode).
    /// </summary>
    IMWRITE_TIFF_COMPRESSION_NONE = 1,

    /// <summary>
    /// CCITT modified Huffman RLE compression.
    /// </summary>
    IMWRITE_TIFF_COMPRESSION_CCITTRLE = 2,

    /// <summary>
    /// CCITT Group 3 fax encoding compression.
    /// </summary>
    IMWRITE_TIFF_COMPRESSION_CCITTFAX3 = 3,

    /// <summary>
    /// CCITT T.4 compression (TIFF 6 name).
    /// </summary>
    IMWRITE_TIFF_COMPRESSION_CCITT_T4 = 3,

    /// <summary>
    /// CCITT Group 4 fax encoding compression.
    /// </summary>
    IMWRITE_TIFF_COMPRESSION_CCITTFAX4 = 4,

    /// <summary>
    /// CCITT T.6 compression (TIFF 6 name).
    /// </summary>
    IMWRITE_TIFF_COMPRESSION_CCITT_T6 = 4,

    /// <summary>
    /// Lempel-Ziv & Welch compression.
    /// </summary>
    IMWRITE_TIFF_COMPRESSION_LZW = 5,

    /// <summary>
    /// Old-style JPEG compression (TIFF 6.0 JPEG).
    /// </summary>
    IMWRITE_TIFF_COMPRESSION_OJPEG = 6,

    /// <summary>
    /// JPEG DCT compression.
    /// </summary>
    IMWRITE_TIFF_COMPRESSION_JPEG = 7,

    /// <summary>
    /// Adobe Deflate compression.
    /// </summary>
    IMWRITE_TIFF_COMPRESSION_ADOBE_DEFLATE = 8,

    /// <summary>
    /// TIFF/FX T.85 JBIG compression.
    /// </summary>
    IMWRITE_TIFF_COMPRESSION_T85 = 9,

    /// <summary>
    /// TIFF/FX T.43 colour by layered JBIG compression.
    /// </summary>
    IMWRITE_TIFF_COMPRESSION_T43 = 10,

    /// <summary>
    /// NeXT 2-bit RLE compression.
    /// </summary>
    IMWRITE_TIFF_COMPRESSION_NEXT = 32766,

    /// <summary>
    /// CCITT RLE with word alignment compression.
    /// </summary>
    IMWRITE_TIFF_COMPRESSION_CCITTRLEW = 32771,

    /// <summary>
    /// Macintosh RLE compression.
    /// </summary>
    IMWRITE_TIFF_COMPRESSION_PACKBITS = 32773,

    /// <summary>
    /// ThunderScan RLE compression.
    /// </summary>
    IMWRITE_TIFF_COMPRESSION_THUNDERSCAN = 32809,

    /// <summary>
    /// IT8 CT with padding compression.
    /// </summary>
    IMWRITE_TIFF_COMPRESSION_IT8CTPAD = 32895,

    /// <summary>
    /// IT8 Linework RLE compression.
    /// </summary>
    IMWRITE_TIFF_COMPRESSION_IT8LW = 32896,

    /// <summary>
    /// IT8 Monochrome picture compression.
    /// </summary>
    IMWRITE_TIFF_COMPRESSION_IT8MP = 32897,

    /// <summary>
    /// IT8 Binary line art compression.
    /// </summary>
    IMWRITE_TIFF_COMPRESSION_IT8BL = 32898,

    /// <summary>
    /// Pixar companded 10-bit LZW compression.
    /// </summary>
    IMWRITE_TIFF_COMPRESSION_PIXARFILM = 32908,

    /// <summary>
    /// Pixar companded 11-bit ZIP compression.
    /// </summary>
    IMWRITE_TIFF_COMPRESSION_PIXARLOG = 32909,

    /// <summary>
    /// Deflate compression (legacy tag).
    /// </summary>
    IMWRITE_TIFF_COMPRESSION_DEFLATE = 32946,

    /// <summary>
    /// Kodak DCS encoding compression.
    /// </summary>
    IMWRITE_TIFF_COMPRESSION_DCS = 32947,

    /// <summary>
    /// ISO JBIG compression.
    /// </summary>
    IMWRITE_TIFF_COMPRESSION_JBIG = 34661,

    /// <summary>
    /// SGI Log Luminance RLE compression.
    /// </summary>
    IMWRITE_TIFF_COMPRESSION_SGILOG = 34676,

    /// <summary>
    /// SGI Log 24-bit packed compression.
    /// </summary>
    IMWRITE_TIFF_COMPRESSION_SGILOG24 = 34677,

    /// <summary>
    /// Leadtools JPEG2000 compression.
    /// </summary>
    IMWRITE_TIFF_COMPRESSION_JP2000 = 34712,

    /// <summary>
    /// ESRI Lerc codec compression.
    /// </summary>
    IMWRITE_TIFF_COMPRESSION_LERC = 34887,

    /// <summary>
    /// LZMA2 compression.
    /// </summary>
    IMWRITE_TIFF_COMPRESSION_LZMA = 34925,

    /// <summary>
    /// ZSTD compression (not registered in Adobe-maintained registry).
    /// </summary>
    IMWRITE_TIFF_COMPRESSION_ZSTD = 50000,

    /// <summary>
    /// WEBP compression (not registered in Adobe-maintained registry).
    /// </summary>
    IMWRITE_TIFF_COMPRESSION_WEBP = 50001,

    /// <summary>
    /// JPEGXL compression (not registered in Adobe-maintained registry).
    /// </summary>
    IMWRITE_TIFF_COMPRESSION_JXL = 50002
}
