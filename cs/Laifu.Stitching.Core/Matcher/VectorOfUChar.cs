using Laifu.OpenCv.Native.Constants;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Laifu.OpenCv;
using Laifu.OpenCv.Native;

namespace Laifu.Stitching.Core.Matcher;

internal static partial class VectorOfUCharHelper
{
    private const string Name = "OpenCvSharpExtern";

    [LibraryImport(Name, EntryPoint = "std_vec_uchar_new1")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus New(out StdVectorHandle output);

    [LibraryImport(Name, EntryPoint = "std_vec_uchar_new2")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus New(int size, out StdVectorHandle output);

    [LibraryImport(Name, EntryPoint = "std_vec_uchar_new3")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus New([In] byte[] values, int size, out StdVectorHandle output);

    [LibraryImport(Name, EntryPoint = "std_vec_uchar_new4")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus New(nint values, out StdVectorHandle output);

    [LibraryImport(Name, EntryPoint = "std_vec_uchar_size")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial int Size(StdVectorHandle vector);

    [LibraryImport(Name, EntryPoint = "std_vec_uchar_pointer")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial nint Data(StdVectorHandle output);
}

public class VectorOfUChar : DisposableObject
{
    private readonly StdVectorHandle _handle;

    public StdVectorHandle Handle => _handle;

    public VectorOfUChar()
        => VectorOfUCharHelper.New(out _handle)
            .ThrowHandleException();

    public VectorOfUChar(StdVectorHandle ptr) => _handle = ptr;

    public VectorOfUChar(nint ptr)
        => VectorOfUCharHelper.New(ptr, out _handle)
            .ThrowHandleException();

    public VectorOfUChar(int size)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(size, 0, nameof(size));
        VectorOfUCharHelper.New(size, out _handle).ThrowHandleException();
    }

    public VectorOfUChar(IEnumerable<byte> values)
    {
        ArgumentNullException.ThrowIfNull(values, nameof(values));

        var array = values.ToArray();
        VectorOfUCharHelper.New(array, array.Length, out _handle).ThrowHandleException();
    }

    public int Size => VectorOfUCharHelper.Size(_handle);

    public byte[] ToArray()
    {
        var size = Size;

        var array = new byte[size];
        var length = size; // 因为byte是1字节，所以长度就是size

        DataHandle = GCHandle.Alloc(array, GCHandleType.Pinned);

        unsafe
        {
            var ptr = VectorOfUCharHelper.Data(_handle);
            Buffer.MemoryCopy(ptr.ToPointer(),
                DataHandle.AddrOfPinnedObject().ToPointer(),
                length, length);
        }

        GC.KeepAlive(this);
        return array;
    }
}