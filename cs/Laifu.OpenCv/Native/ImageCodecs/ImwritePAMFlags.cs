namespace Laifu.OpenCv.Native.ImageCodecs;

/// <summary>
/// Imwrite PAM specific tupletype flags used to define the 'TUPLETYPE' field of a PAM file.
/// Specifies the format of the PAM image data.
/// </summary>
// ReSharper disable once InconsistentNaming
public enum ImwritePAMFlags
{
    /// <summary>
    /// Null format, no image data.
    /// </summary>
    IMWRITE_PAM_FORMAT_NULL = 0,

    /// <summary>
    /// Black and white format.
    /// </summary>
    IMWRITE_PAM_FORMAT_BLACKANDWHITE = 1,

    /// <summary>
    /// Grayscale format.
    /// </summary>
    IMWRITE_PAM_FORMAT_GRAYSCALE = 2,

    /// <summary>
    /// Grayscale format with alpha channel.
    /// </summary>
    IMWRITE_PAM_FORMAT_GRAYSCALE_ALPHA = 3,

    /// <summary>
    /// RGB format.
    /// </summary>
    IMWRITE_PAM_FORMAT_RGB = 4,

    /// <summary>
    /// RGB format with alpha channel.
    /// </summary>
    IMWRITE_PAM_FORMAT_RGB_ALPHA = 5
}
