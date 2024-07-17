using System.Drawing;

// ReSharper disable once CheckNamespace
namespace Laifu.OpenCv.Models;

[Serializable]
[StructLayout(LayoutKind.Sequential)]
public readonly record struct CvRect(int X, int Y, int Width, int Height);

partial class CvModelExtensions
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="rect"></param>
    /// <returns></returns>
    public static Rectangle ToRectangle(this CvRect rect)
        => new(rect.X, rect.Y, rect.Width, rect.Height);

    public static CvRect ToCvRect(this Rectangle rect)
        => new(rect.X, rect.Y, rect.Width, rect.Height);
}