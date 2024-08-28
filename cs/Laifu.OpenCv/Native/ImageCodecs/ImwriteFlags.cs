namespace Laifu.OpenCv.Native.ImageCodecs;

/// <summary>
/// Enumeration for flags to specify image writing parameters in OpenCV.
/// </summary>
public enum ImwriteFlags
{
    /// <summary>
    /// For JPEG, it can be a quality from 0 to 100 (the higher is the better). Default value is 95.
    /// </summary>
    IMWRITE_JPEG_QUALITY = 1,

    /// <summary>
    /// Enable JPEG features, 0 or 1, default is False.
    /// </summary>
    IMWRITE_JPEG_PROGRESSIVE = 2,

    /// <summary>
    /// Enable JPEG features, 0 or 1, default is False.
    /// </summary>
    IMWRITE_JPEG_OPTIMIZE = 3,

    /// <summary>
    /// JPEG restart interval, 0 - 65535, default is 0 - no restart.
    /// </summary>
    IMWRITE_JPEG_RST_INTERVAL = 4,

    /// <summary>
    /// Separate luma quality level, 0 - 100, default is -1 - don't use. If JPEG_LIB_VERSION &lt; 70, Not supported.
    /// </summary>
    IMWRITE_JPEG_LUMA_QUALITY = 5,

    /// <summary>
    /// Separate chroma quality level, 0 - 100, default is -1 - don't use. If JPEG_LIB_VERSION &lt; 70, Not supported.
    /// </summary>
    IMWRITE_JPEG_CHROMA_QUALITY = 6,

    /// <summary>
    /// For JPEG, set sampling factor. See cv::ImwriteJPEGSamplingFactorParams.
    /// </summary>
    IMWRITE_JPEG_SAMPLING_FACTOR = 7,

    /// <summary>
    /// For PNG, it can be the compression level from 0 to 9. A higher value means a smaller size and longer compression time.
    /// If specified, strategy is changed to IMWRITE_PNG_STRATEGY_DEFAULT (Z_DEFAULT_STRATEGY). Default value is 1 (best speed setting).
    /// </summary>
    IMWRITE_PNG_COMPRESSION = 16,

    /// <summary>
    /// One of cv::ImwritePNGFlags, default is IMWRITE_PNG_STRATEGY_RLE.
    /// </summary>
    IMWRITE_PNG_STRATEGY = 17,

    /// <summary>
    /// Binary level PNG, 0 or 1, default is 0.
    /// </summary>
    IMWRITE_PNG_BILEVEL = 18,

    /// <summary>
    /// For PPM, PGM, or PBM, it can be a binary format flag, 0 or 1. Default value is 1.
    /// </summary>
    IMWRITE_PXM_BINARY = 32,

    /// <summary>
    /// Override EXR storage type (FLOAT (FP32) is default).
    /// </summary>
    IMWRITE_EXR_TYPE = (3 << 4) + 0, // 48

    /// <summary>
    /// Override EXR compression type (ZIP_COMPRESSION = 3 is default).
    /// </summary>
    IMWRITE_EXR_COMPRESSION = (3 << 4) + 1, // 49

    /// <summary>
    /// Override EXR DWA compression level (45 is default).
    /// </summary>
    IMWRITE_EXR_DWA_COMPRESSION_LEVEL = (3 << 4) + 2, // 50

    /// <summary>
    /// For WEBP, it can be a quality from 1 to 100 (the higher is the better). By default (without any parameter) and for quality above 100 the lossless compression is used.
    /// </summary>
    IMWRITE_WEBP_QUALITY = 64,

    /// <summary>
    /// Specify HDR compression.
    /// </summary>
    IMWRITE_HDR_COMPRESSION = (5 << 4) + 0, // 80

    /// <summary>
    /// For PAM, sets the TUPLETYPE field to the corresponding string value that is defined for the format.
    /// </summary>
    IMWRITE_PAM_TUPLETYPE = 128,

    /// <summary>
    /// For TIFF, use to specify which DPI resolution unit to set; see libtiff documentation for valid values.
    /// </summary>
    IMWRITE_TIFF_RESUNIT = 256,

    /// <summary>
    /// For TIFF, use to specify the X direction DPI.
    /// </summary>
    IMWRITE_TIFF_XDPI = 257,

    /// <summary>
    /// For TIFF, use to specify the Y direction DPI.
    /// </summary>
    IMWRITE_TIFF_YDPI = 258,

    /// <summary>
    /// For TIFF, use to specify the image compression scheme. See cv::ImwriteTiffCompressionFlags.
    /// Note, for images whose depth is CV_32F, only libtiff's SGILOG compression scheme is used.
    /// For other supported depths, the compression scheme can be specified by this flag; LZW compression is the default.
    /// </summary>
    IMWRITE_TIFF_COMPRESSION = 259,

    /// <summary>
    /// For TIFF, use to specify the number of rows per strip.
    /// </summary>
    IMWRITE_TIFF_ROWSPERSTRIP = 278,

    /// <summary>
    /// For TIFF, use to specify predictor. See cv::ImwriteTiffPredictorFlags.
    /// </summary>
    IMWRITE_TIFF_PREDICTOR = 317,

    /// <summary>
    /// For JPEG2000, use to specify the target compression rate (multiplied by 1000). The value can be from 0 to 1000. Default is 1000.
    /// </summary>
    IMWRITE_JPEG2000_COMPRESSION_X1000 = 272,

    /// <summary>
    /// For AVIF, it can be a quality between 0 and 100 (the higher the better). Default is 95.
    /// </summary>
    IMWRITE_AVIF_QUALITY = 512,

    /// <summary>
    /// For AVIF, it can be 8, 10 or 12. If >8, it is stored/read as CV_32F. Default is 8.
    /// </summary>
    IMWRITE_AVIF_DEPTH = 513,

    /// <summary>
    /// For AVIF, it is between 0 (slowest) and (fastest). Default is 9.
    /// </summary>
    IMWRITE_AVIF_SPEED = 514
}
