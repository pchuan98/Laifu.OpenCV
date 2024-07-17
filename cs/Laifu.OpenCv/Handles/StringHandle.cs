using System.Runtime.InteropServices;
using Laifu.OpenCv.PInvoke;

namespace Laifu.OpenCv.Handles;

/// <summary>
/// C++ type is <b>std::string*</b> .
/// </summary>
internal class StringHandle() : SafeHandle(nint.Zero, true)
{
    /// <inheritdoc />
    public override bool IsInvalid => handle == nint.Zero;

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
        if (ptr == nint.Zero)
            throw new OpenCvException("Null string pointer.");

        return Marshal.PtrToStringUTF8(ptr)!;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static StringHandle Create() => NativeMethods.Empty();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static StringHandle Create(string str) => NativeMethods.String(str);
}