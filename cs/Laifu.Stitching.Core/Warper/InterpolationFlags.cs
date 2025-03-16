namespace Laifu.Stitching.Core.Warper;

/// <summary>
/// Interpolation algorithm flags.
/// </summary>
[Flags]
public enum InterpolationFlags
{
    /// <summary>
    /// Nearest neighbor interpolation.
    /// </summary>
    INTER_NEAREST = 0,
    /// <summary>
    /// Bilinear interpolation.
    /// </summary>
    INTER_LINEAR = 1,
    /// <summary>
    /// Bicubic interpolation.
    /// </summary>
    INTER_CUBIC = 2,
    /// <summary>
    /// Resampling using pixel area relation. It may be a preferred method for image decimation, as
    /// it gives moire'-free results. But when the image is zoomed, it is similar to the INTER_NEAREST
    /// method.
    /// </summary>
    INTER_AREA = 3,
    /// <summary>
    /// Lanczos interpolation over 8x8 neighborhood.
    /// </summary>
    INTER_LANCZOS4 = 4,
    /// <summary>
    /// Bit exact bilinear interpolation.
    /// </summary>
    INTER_LINEAR_EXACT = 5,
    /// <summary>
    /// Bit exact nearest neighbor interpolation. This will produce same results as
    /// the nearest neighbor method in PIL, scikit-image or Matlab.
    /// </summary>
    INTER_NEAREST_EXACT = 6,
    /// <summary>
    /// Mask for interpolation codes.
    /// </summary>
    INTER_MAX = 7,
    /// <summary>
    /// Flag, fills all of the destination image pixels. If some of them correspond to outliers in the
    /// source image, they are set to zero.
    /// </summary>
    WARP_FILL_OUTLIERS = 8,
    /// <summary>
    /// Flag, inverse transformation.
    /// 
    /// For example, linearPolar or logPolar transforms:
    /// - Flag is not set: dst(ρ, φ) = src(x,y)
    /// - Flag is set: dst(x,y) = src(ρ, φ)
    /// </summary>
    WARP_INVERSE_MAP = 16,
    /// <summary>
    /// Flag, relative transformation.
    /// </summary>
    WARP_RELATIVE_MAP = 32
};
