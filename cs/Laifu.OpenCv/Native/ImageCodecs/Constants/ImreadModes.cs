// ReSharper disable once CheckNamespace
namespace Laifu.OpenCv.Native.ImageCodecs;

/// <summary>
/// Enumeration for flags to specify image reading modes in OpenCV.
/// </summary>
[Flags]
public enum ImreadModes
{
    /// <summary>
    /// If set, return the loaded image as is (with alpha channel, otherwise it gets cropped). Ignore EXIF orientation.
    /// </summary>
    IMREAD_UNCHANGED = -1,

    /// <summary>
    /// If set, always convert image to the single channel grayscale image (codec internal conversion).
    /// </summary>
    IMREAD_GRAYSCALE = 0,

    /// <summary>
    /// If set, always convert image to the 3 channel BGR color image.
    /// </summary>
    IMREAD_COLOR_BGR = 1,

    /// <summary>
    /// Same as IMREAD_COLOR_BGR.
    /// </summary>
    IMREAD_COLOR = 1,

    /// <summary>
    /// If set, return 16-bit/32-bit image when the input has the corresponding depth, otherwise convert it to 8-bit.
    /// </summary>
    IMREAD_ANYDEPTH = 2,

    /// <summary>
    /// If set, the image is read in any possible color format.
    /// </summary>
    IMREAD_ANYCOLOR = 4,

    /// <summary>
    /// If set, use the GDAL driver for loading the image.
    /// </summary>
    IMREAD_LOAD_GDAL = 8,

    /// <summary>
    /// If set, always convert image to the single channel grayscale image and the image size reduced to 1/2.
    /// </summary>
    IMREAD_REDUCED_GRAYSCALE_2 = 16,

    /// <summary>
    /// If set, always convert image to the 3 channel BGR color image and the image size reduced to 1/2.
    /// </summary>
    IMREAD_REDUCED_COLOR_2 = 17,

    /// <summary>
    /// If set, always convert image to the single channel grayscale image and the image size reduced to 1/4.
    /// </summary>
    IMREAD_REDUCED_GRAYSCALE_4 = 32,

    /// <summary>
    /// If set, always convert image to the 3 channel BGR color image and the image size reduced to 1/4.
    /// </summary>
    IMREAD_REDUCED_COLOR_4 = 33,

    /// <summary>
    /// If set, always convert image to the single channel grayscale image and the image size reduced to 1/8.
    /// </summary>
    IMREAD_REDUCED_GRAYSCALE_8 = 64,

    /// <summary>
    /// If set, always convert image to the 3 channel BGR color image and the image size reduced to 1/8.
    /// </summary>
    IMREAD_REDUCED_COLOR_8 = 65,

    /// <summary>
    /// If set, do not rotate the image according to EXIF's orientation flag.
    /// </summary>
    IMREAD_IGNORE_ORIENTATION = 128,

    /// <summary>
    /// If set, always convert image to the 3 channel RGB color image.
    /// </summary>
    IMREAD_COLOR_RGB = 256
}
