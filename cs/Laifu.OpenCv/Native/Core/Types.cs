// ReSharper disable InconsistentNaming
namespace Laifu.OpenCv.Native.Core;

[Serializable]
[StructLayout(LayoutKind.Sequential)]
public record struct Size2i(int Width, int Height);

[Serializable]
[StructLayout(LayoutKind.Sequential)]
public record struct Rect2i(int X, int Y, int Width, int Height);
