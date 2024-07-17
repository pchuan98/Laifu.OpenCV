// ReSharper disable once CheckNamespace
namespace Laifu.OpenCv.Models;

// todo add the others type point strcut

[Serializable]
[StructLayout(LayoutKind.Sequential)]
public readonly record struct Point2F(float X, float Y);