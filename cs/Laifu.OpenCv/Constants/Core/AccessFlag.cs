// ReSharper disable once CheckNamespace
namespace Laifu.OpenCv.Constants;

/// <summary>
/// 
/// </summary>
public enum AccessFlag
{
    /// <summary>
    /// 
    /// </summary>
    READ = 1 << 24,

    /// <summary>
    /// 
    /// </summary>
    WRITE = 1 << 25,

    /// <summary>
    /// 
    /// </summary>
    RW = 3 << 24,

    /// <summary>
    /// 
    /// </summary>
    MASK = RW,

    /// <summary>
    /// 
    /// </summary>
    FAST = 1 << 26
}
