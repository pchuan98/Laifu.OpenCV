using System.Runtime.InteropServices;

namespace Laifu.OpenCv.PInvoke;

/// <summary>
/// 
/// </summary>
public class StdString() : SafeHandle(IntPtr.Zero, true)
{

    /// <inheritdoc />
    public override bool IsInvalid => handle == IntPtr.Zero;

    /// <inheritdoc />
    protected override bool ReleaseHandle()
    {
        NativeMethods.Delete(handle);
        return true;
    }

    /// <inheritdoc />
    public override string ToString()
    {
        if (IsInvalid)
            throw new InvalidOperationException("Invalid handle");

        var ptr = NativeMethods.PtrString(this);
        if (ptr == IntPtr.Zero)
            throw new OpenCvException("Null string pointer.");

        return Marshal.PtrToStringUTF8(ptr)!;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static StdString Create() => NativeMethods.Empty();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static StdString Create(string str) => NativeMethods.String(str);
}