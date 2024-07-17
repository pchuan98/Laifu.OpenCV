using System.Drawing;
using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace Laifu.OpenCv.Models;

/// <summary>
/// Width + Height
/// </summary>
/// <param name="width"></param>
/// <param name="height"></param>
[Serializable]
[StructLayout(LayoutKind.Sequential)]
public struct CvSize(int width, int height)
{
    /// <summary>
    /// 
    /// </summary>
    public int Width = width;

    /// <summary>
    /// 
    /// </summary>
    public int Height = height;

    /// <summary>
    /// 
    /// </summary>
    public Size ToSize => new(Width, Height);

    /// <inheritdoc />
    public override string ToString() => $"{Width},{Height}";
}

partial class CvModelExtensions
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="size"></param>
    /// <returns></returns>
    public static Size ToSize(this CvSize size) => new(size.Width, size.Height);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="size"></param>
    /// <returns></returns>
    public static CvSize FromSize(this Size size) => new(size.Width, size.Height);
}