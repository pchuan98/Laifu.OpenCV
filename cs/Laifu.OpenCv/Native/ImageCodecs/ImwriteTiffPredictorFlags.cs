namespace Laifu.OpenCv.Native.ImageCodecs;

/// <summary>
/// Enumeration for TIFF predictor flags used in image writing in OpenCV.
/// </summary>
public enum ImwriteTiffPredictorFlags
{
    /// <summary>
    /// No prediction scheme used.
    /// </summary>
    IMWRITE_TIFF_PREDICTOR_NONE = 1,

    /// <summary>
    /// Horizontal differencing predictor.
    /// </summary>
    IMWRITE_TIFF_PREDICTOR_HORIZONTAL = 2,

    /// <summary>
    /// Floating point predictor.
    /// </summary>
    IMWRITE_TIFF_PREDICTOR_FLOATINGPOINT = 3
}
