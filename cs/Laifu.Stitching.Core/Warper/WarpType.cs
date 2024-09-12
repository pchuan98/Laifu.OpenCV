// ReSharper disable InconsistentNaming
namespace Laifu.Stitching.Core.Warper;

[Flags]
public enum WarpType
{
    Plane = 0,
    Affine = 1,
    Cylindrical = 2,
    Spherical = 3,
    Fisheye = 4,
    Stereographic = 5,
    CompressedRectilinear2_1 = 6,
    CompressedRectilinear1_5_1 = 7,
    CompressedRectilinearPortrait2_1 = 8,
    CompressedRectilinearPortrait1_5_1 = 9,
    Panini2_1 = 10,
    Panini1_5_1 = 11,
    PaniniPortrait2_1 = 12,
    PaniniPortrait1_5_1 = 13,
    Mercator = 14,
    TransverseMercator = 15
}