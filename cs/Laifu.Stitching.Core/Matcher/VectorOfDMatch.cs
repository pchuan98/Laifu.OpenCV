using Laifu.OpenCv.Native.Constants;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Laifu.OpenCv;
using Laifu.OpenCv.Native;
using Laifu.Stitching.Core.Models;

namespace Laifu.Stitching.Core.Matcher;

internal static partial class VectorOfDMatchHelper
{
    private const string Name = "OpenCvSharpExtern";

    [LibraryImport(Name, EntryPoint = "std_vec_dm_new1")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus New(out StdVectorHandle output);

    [LibraryImport(Name, EntryPoint = "std_vec_dm_new2")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus New(int size, out StdVectorHandle output);

    [LibraryImport(Name, EntryPoint = "std_vec_dm_new3")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus New([In] DMatch[] matches, int size, out StdVectorHandle output);

    [LibraryImport(Name, EntryPoint = "std_vec_dm_new4")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]    
    internal static partial ExceptionStatus New(nint matches, out StdVectorHandle output);

    [LibraryImport(Name, EntryPoint = "std_vec_dm_size")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial int Size(StdVectorHandle vector);

    [LibraryImport(Name, EntryPoint = "std_vec_dm_pointer")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial nint Data(StdVectorHandle output);
}

public class VectorOfDMatch : DisposableObject
{
    private readonly StdVectorHandle _handle;

    public StdVectorHandle Handle => _handle;

    public VectorOfDMatch()
        => VectorOfDMatchHelper.New(out _handle)
            .ThrowHandleException();

    public VectorOfDMatch(StdVectorHandle ptr) => _handle = ptr;

    public VectorOfDMatch(nint ptr)
        => VectorOfDMatchHelper.New(ptr, out _handle)
            .ThrowHandleException();

    public VectorOfDMatch(int size)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(size, 0, nameof(size));
        VectorOfDMatchHelper.New(size, out _handle).ThrowHandleException();
    }

    public VectorOfDMatch(IEnumerable<DMatch> matches)
    {
        ArgumentNullException.ThrowIfNull(matches, nameof(matches));

        var array = matches.ToArray();
        VectorOfDMatchHelper.New(array, array.Length, out _handle).ThrowHandleException();
    }

    public int Size => VectorOfDMatchHelper.Size(_handle);

    public DMatch[] ToArray()
    {
        var size = Size;

        var array = new DMatch[size];
        var length = Marshal.SizeOf<DMatch>() * size;

        DataHandle = GCHandle.Alloc(array, GCHandleType.Pinned);

        unsafe
        {
            var ptr = VectorOfDMatchHelper.Data(_handle);
            Buffer.MemoryCopy(ptr.ToPointer(),
                DataHandle.AddrOfPinnedObject().ToPointer(),
                length, length);
        }

        GC.KeepAlive(this);
        return array;
    }
}