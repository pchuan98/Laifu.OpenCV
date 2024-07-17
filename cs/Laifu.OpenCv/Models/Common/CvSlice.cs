using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace Laifu.OpenCv.Models;

/// <summary>
/// 
/// </summary>
/// <param name="Start"></param>
/// <param name="End"></param>
[Serializable]
[StructLayout(LayoutKind.Sequential)]
public readonly record struct CvSlice(int Start, int End);

/// <summary>
/// 
/// </summary>
partial class CvModelExtensions
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="tuple"></param>
    /// <returns></returns>
    public static CvSlice ToCvSlice(this (int start, int end) tuple) => new(tuple.start, tuple.end);

    // NOTE 如果直接再CvSlice之中写ToRange会触发错误，应该是序列化的原因

    /// <summary>
    /// 
    /// </summary>
    /// <param name="slice"></param>
    /// <returns></returns>
    public static Range ToRange(this CvSlice slice) => new(slice.Start, slice.End);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="range"></param>
    /// <returns></returns>
    public static CvSlice FromRange(this Range range) => new(range.Start.Value, range.End.Value);
}