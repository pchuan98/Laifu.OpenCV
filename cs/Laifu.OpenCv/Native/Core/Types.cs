// ReSharper disable InconsistentNaming
namespace Laifu.OpenCv.Native.Core;

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

    public override string ToString() => $"CvSize(width: {width}, height: {height})";
}