// ReSharper disable once CheckNamespace
namespace Laifu.OpenCv.Models;

/// <summary>
/// 
/// </summary>
/// <param name="Pt">x & y coordinates of the keypoint</param>
/// <param name="Size">keypoint diameter</param>
/// <param name="Angle">keypoint orientation</param>
/// <param name="Response">keypoint detector response on the keypoint (that is, strength of the keypoint)</param>
/// <param name="Octave">pyramid octave in which the keypoint has been detected</param>
/// <param name="ClassId">object id</param>
[Serializable]
[StructLayout(LayoutKind.Sequential)]
public readonly record struct KeyPoints(Point2F Pt, float Size, float Angle = -1, float Response = 0, int Octave = 0, int ClassId = -1);