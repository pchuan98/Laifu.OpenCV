using Laifu.OpenCv.Native.Constants;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Laifu.OpenCv;
using Laifu.OpenCv.Native;
using Laifu.Stitching.Core.Finder;

namespace Laifu.Stitching.Core.Others;

internal static partial class VectorOfIntHelper
{
    private const string Name = "OpenCvSharpExtern";

    [LibraryImport(Name, EntryPoint = "std_vec_int_new1")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus New(out StdVectorHandle output);

    [LibraryImport(Name, EntryPoint = "std_vec_int_new2")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus New(int size, out StdVectorHandle output);

    [LibraryImport(Name, EntryPoint = "std_vec_int_new3")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus New([In] int[] values, int size, out StdVectorHandle output);

    [LibraryImport(Name, EntryPoint = "std_vec_int_new4")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus New(nint values, out StdVectorHandle output);

    [LibraryImport(Name, EntryPoint = "std_vec_int_size")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial int Size(StdVectorHandle vector);

    [LibraryImport(Name, EntryPoint = "std_vec_int_pointer")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial nint Data(StdVectorHandle output);
}

public class VectorOfInt : DisposableObject
{
    private readonly StdVectorHandle _handle;

    public StdVectorHandle Handle => _handle;

    public VectorOfInt()
        => VectorOfIntHelper.New(out _handle)
            .ThrowHandleException();

    public VectorOfInt(StdVectorHandle ptr) => _handle = ptr;

    public VectorOfInt(nint ptr)
        => VectorOfIntHelper.New(ptr, out _handle)
            .ThrowHandleException();

    public VectorOfInt(int size)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(size, 0, nameof(size));
        VectorOfIntHelper.New(size, out _handle).ThrowHandleException();
    }

    public VectorOfInt(IEnumerable<int> values)
    {
        ArgumentNullException.ThrowIfNull(values, nameof(values));

        var array = values.ToArray();
        VectorOfIntHelper.New(array, array.Length, out _handle).ThrowHandleException();
    }

    public int Size => VectorOfIntHelper.Size(_handle);

    public int[] ToArray()
    {
        var size = Size;

        var array = new int[size];
        var length = size * sizeof(int);

        DataHandle = GCHandle.Alloc(array, GCHandleType.Pinned);

        unsafe
        {
            var ptr = VectorOfIntHelper.Data(_handle);
            Buffer.MemoryCopy(ptr.ToPointer(),
                DataHandle.AddrOfPinnedObject().ToPointer(),
                length, length);
        }

        GC.KeepAlive(this);
        return array;
    }
}