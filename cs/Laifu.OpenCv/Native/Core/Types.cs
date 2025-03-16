// ReSharper disable InconsistentNaming

using System.Drawing;

namespace Laifu.OpenCv.Native.Core;

[Serializable]
[StructLayout(LayoutKind.Sequential)]
public record struct Point2f(float Width, float Height);

[Serializable]
[StructLayout(LayoutKind.Sequential)]
public record struct Size2i(int Width, int Height);

[Serializable]
[StructLayout(LayoutKind.Sequential)]
public record struct Rect2i(int X, int Y, int Width, int Height);

[Serializable]
[StructLayout(LayoutKind.Sequential)]
public record struct Scalar(double V0, double V1, double V2, double V3);

[Serializable]
[StructLayout(LayoutKind.Sequential)]
public record struct Range(int Start, int End);

[StructLayout(LayoutKind.Sequential)]
public struct CvSize(int width, int height)
{
    public int width = width;
    public int height = height;

    public static implicit operator Size(CvSize size)
        => new(size.width, size.height);

    public override string ToString() => $"CvSize(width: {width}, height: {height})";
}

[Serializable]
[StructLayout(LayoutKind.Sequential)]
public record struct KeyPoint(
    Point2f Pt,
    float Size,
    float Angle = -1,
    float Response = 0,
    int Octave = 0,
    int ClassId = -1)
{
    /// <summary>
    /// Complete constructor
    /// </summary>
    /// <param name="x">X-coordinate of the point</param>
    /// <param name="y">Y-coordinate of the point</param>
    /// <param name="size">Feature size</param>
    /// <param name="angle">Feature orientation in degrees (has negative value if the orientation is not defined/not computed)</param>
    /// <param name="response">Feature strength (can be used to select only the most prominent key points)</param>
    /// <param name="octave">Scale-space octave in which the feature has been found; may correlate with the size</param>
    /// <param name="classId">Point class (can be used by feature classifiers or object detectors)</param>
    public KeyPoint(
        float x, float y, float size, float angle = -1, float response = 0, int octave = 0, int classId = -1)
        : this(new Point2f(x, y), size, angle, response, octave, classId) { }

    public override string ToString()
        => $"{Pt}\t{Size}\t{Angle}\t{Response}\t{Octave}\t{ClassId}";
}