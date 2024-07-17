using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace Laifu.OpenCv.Models;

/// <summary>
/// 
/// </summary>
[Serializable]
[StructLayout(LayoutKind.Sequential)]
public record struct CvScalar(double V0, double V1, double V2, double V3)
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="v0"></param>
    public CvScalar(double v0) : this(v0, 0, 0, 0) { }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="v0"></param>
    /// <param name="v1"></param>
    public CvScalar(double v0, double v1) : this(v0, v1, 0, 0) { }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="v0"></param>
    /// <param name="v1"></param>
    /// <param name="v2"></param>
    public CvScalar(double v0, double v1, double v2) : this(v0, v1, v2, 0) { }
}

partial class CvModelExtensions
{
    
}