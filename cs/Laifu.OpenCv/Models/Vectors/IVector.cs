// ReSharper disable once CheckNamespace
namespace Laifu.OpenCv.Models.Vectors;

internal interface IVector<out T> : IDisposable
{
    /// <summary>
    /// the same as Array
    /// </summary>
    int Length { set; }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    T[] ToArray();
}