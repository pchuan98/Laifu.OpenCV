// ReSharper disable InconsistentNaming

using System.Drawing;
using System.Runtime.InteropServices;

namespace Laifu.Stitching.Core.Models;

#region Core

[Serializable]
[StructLayout(LayoutKind.Sequential)]
public record struct CvPoint2i(int Width, int Height);

[Serializable]
[StructLayout(LayoutKind.Sequential)]
public record struct CvPoint2f(float Width, float Height);

[Serializable]
[StructLayout(LayoutKind.Sequential)]
public record struct CvSize2i(int Width, int Height);

[Serializable]
[StructLayout(LayoutKind.Sequential)]
public record struct CvRect2i(int X, int Y, int Width, int Height);

[Serializable]
[StructLayout(LayoutKind.Sequential)]
public record struct CvScalar(double V0, double V1, double V2, double V3);

[Serializable]
[StructLayout(LayoutKind.Sequential)]
public record struct CvRange(int Start, int End);

[StructLayout(LayoutKind.Sequential)]
public struct CvSize(int width, int height)
{
    public int width = width;
    public int height = height;

    public static implicit operator Size(CvSize size)
        => new(size.width, size.height);

    public override string ToString() => $"CvSize(width: {width}, height: {height})";
}

#endregion

[Serializable]
[StructLayout(LayoutKind.Sequential)]
public record struct DMatch(int QueryIndex, int TrainIndex, int ImageIndex, float Distance);