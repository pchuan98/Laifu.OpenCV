// ReSharper disable once CheckNamespace
namespace Laifu.OpenCv.Constants;

/// <summary>
/// Specifies the modes for reading images using the imread function.
///
/// Imread flags
/// </summary>
[Flags]
public enum ImreadModes
{
    /// <summary>
    /// If set, return the loaded image as is (with alpha channel, otherwise it gets cropped). Ignore EXIF orientation.
    /// </summary>
    UNCHANGED = -1,

    /// <summary>
    /// If set, always convert image to the single channel grayscale image (codec internal conversion).
    /// </summary>
    GRAYSCALE = 0,

    /// <summary>
    /// If set, always convert image to the 3 channel BGR color image.
    /// </summary>
    COLOR_BGR = 1,

    /// <summary>
    /// Same as IMREAD_COLOR_BGR.
    /// </summary>
    COLOR = 1,

    /// <summary>
    /// If set, return 16-bit/32-bit image when the input has the corresponding depth, otherwise convert it to 8-bit.
    /// </summary>
    ANYDEPTH = 2,

    /// <summary>
    /// If set, the image is read in any possible color format.
    /// </summary>
    ANYCOLOR = 4,

    /// <summary>
    /// If set, use the gdal driver for loading the image.
    /// </summary>
    LOAD_GDAL = 8,

    /// <summary>
    /// If set, always convert image to the single channel grayscale image and the image size reduced 1/2.
    /// </summary>
    REDUCED_GRAYSCALE_2 = 16,

    /// <summary>
    /// If set, always convert image to the 3 channel BGR color image and the image size reduced 1/2.
    /// </summary>
    REDUCED_COLOR_2 = 17,

    /// <summary>
    /// If set, always convert image to the single channel grayscale image and the image size reduced 1/4.
    /// </summary>
    REDUCED_GRAYSCALE_4 = 32,

    /// <summary>
    /// If set, always convert image to the 3 channel BGR color image and the image size reduced 1/4.
    /// </summary>
    REDUCED_COLOR_4 = 33,

    /// <summary>
    /// If set, always convert image to the single channel grayscale image and the image size reduced 1/8.
    /// </summary>
    REDUCED_GRAYSCALE_8 = 64,

    /// <summary>
    /// If set, always convert image to the 3 channel BGR color image and the image size reduced 1/8.
    /// </summary>
    REDUCED_COLOR_8 = 65,

    /// <summary>
    /// If set, do not rotate the image according to EXIF's orientation flag.
    /// </summary>
    IGNORE_ORIENTATION = 128,

    /// <summary>
    /// If set, always convert image to the 3 channel RGB color image.
    /// </summary>
    COLOR_RGB = 256
}
