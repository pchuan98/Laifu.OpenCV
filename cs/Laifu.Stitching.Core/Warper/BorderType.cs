// ReSharper disable CheckNamespace

namespace Laifu.Stitching.Core.Warper;

/// <summary>
/// Enum representing different border types for image processing.
/// </summary>
[Flags]
public enum BorderTypes
{
    /// <summary>
    /// iiiiii|abcdefgh|iiiiiii with some specified i
    /// </summary>
    BORDER_CONSTANT = 0,

    /// <summary>
    /// aaaaaa|abcdefgh|hhhhhhh
    /// </summary>
    BORDER_REPLICATE = 1,

    /// <summary>
    /// fedcba|abcdefgh|hgfedcb
    /// </summary>
    BORDER_REFLECT = 2,

    /// <summary>
    /// cdefgh|abcdefgh|abcdefg
    /// </summary>
    BORDER_WRAP = 3,

    /// <summary>
    /// gfedcb|abcdefgh|gfedcba
    /// </summary>
    BORDER_REFLECT_101 = 4,

    /// <summary>
    /// uvwxyz|abcdefgh|ijklmno - Treats outliers as transparent.
    /// </summary>
    BORDER_TRANSPARENT = 5,

    /// <summary>
    /// Same as BORDER_REFLECT_101
    /// </summary>
    BORDER_REFLECT101 = BORDER_REFLECT_101,

    /// <summary>
    /// Same as BORDER_REFLECT_101
    /// </summary>
    BORDER_DEFAULT = BORDER_REFLECT_101,

    /// <summary>
    /// Interpolation restricted within the ROI boundaries.
    /// </summary>
    BORDER_ISOLATED = 16
}