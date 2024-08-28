using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using Laifu.OpenCv.Native.Constants;
using Laifu.OpenCv.Native.ImageCodecs;


var mats = Method.Mats();
Method.Imreadmulti(@"D:\.test\profiling001.tif", (int)ImreadModes.IMREAD_UNCHANGED, mats, out var recall);

Method.Index(mats, 80, out var mat);
Method.ImShow("show", mat);
Method.WaitKey(0, out _);

/// <summary>
/// The default ptr handle.
/// </summary>
public class SafePtrHandle() : SafeHandle(IntPtr.Zero, true)
{
    /// <inheritdoc />
    protected override bool ReleaseHandle()
        => Method.Del(handle).ThrowHandleException();

    /// <inheritdoc />
    public override bool IsInvalid => handle == nint.Zero;
}

public static partial class Method
{
    const string LibraryName = "OpenCvSharpExtern";

    public static bool ThrowHandleException(this ExceptionStatus status)
        => HandleException(status);

    internal static bool HandleException(ExceptionStatus status)
    {
        if (status == ExceptionStatus.OCCURRED)
            throw new Exception(); // todo 添加内部错误捕获

        return true;
    }

    [LibraryImport(LibraryName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus Del(nint ptr);

    [LibraryImport(LibraryName, EntryPoint = "imread", StringMarshallingCustomType = typeof(Utf8StringMarshaller))]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus Imread(string filename, int flags, out SafePtrHandle ret);

    [LibraryImport(LibraryName, EntryPoint = "imshow", StringMarshallingCustomType = typeof(Utf8StringMarshaller))]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ImShow(string winname, SafePtrHandle mat);

    [LibraryImport(LibraryName, EntryPoint = "imreadmulti", StringMarshallingCustomType = typeof(Utf8StringMarshaller))]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus Imreadmulti(string filename, int flags, SafePtrHandle ret, [MarshalAs(UnmanagedType.Bool)] out bool recall);

    [LibraryImport(LibraryName, EntryPoint = "waitkey")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus WaitKey(int delay, out int ret);

    [LibraryImport(LibraryName, EntryPoint = "mats")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial SafePtrHandle Mats();

    [LibraryImport(LibraryName, EntryPoint = "index")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void Index(SafePtrHandle mats, int i, out SafePtrHandle mat);
}



