using Laifu.OpenCv.Native.Core;

namespace Laifu.OpenCv.Native.Stitching;

internal static partial class VectorOfKeyPointsHelper
{
    [LibraryImport(Helper.DLLNAME, EntryPoint = "std_vec_kp_new1")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus New(out StdVectorHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "std_vec_kp_new2")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus New(int size, out StdVectorHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "std_vec_kp_new3")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus New([In] KeyPoint[] points, int size, out StdVectorHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "std_vec_kp_new4")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus New(nint points, out StdVectorHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "std_vec_kp_size")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial int Size(StdVectorHandle vector);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "std_vec_kp_size")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial int Size(nint vector);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "std_vec_kp_pointer")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial nint Data(StdVectorHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "std_vec_kp_test1")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial void Test(StdVectorHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "std_vec_kp_test2")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial void Test(out StdVectorHandle output);
}

/// <summary>
/// 
/// </summary>
public class VectorOfKeyPoints : DisposableObject
{
    /// <summary>
    /// 
    /// </summary>
    private readonly StdVectorHandle _handle;

    /// <summary>
    /// 
    /// </summary>
    public StdVectorHandle Handle => _handle;

    /// <summary>
    /// 
    /// </summary>
    public VectorOfKeyPoints()
        => VectorOfKeyPointsHelper.New(out _handle)
            .ThrowHandleException();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="ptr"></param>
    public VectorOfKeyPoints(StdVectorHandle ptr) => _handle = ptr;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="ptr"></param>
    public VectorOfKeyPoints(nint ptr)
        => VectorOfKeyPointsHelper.New(ptr, out _handle)
            .ThrowHandleException();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="size"></param>
    public VectorOfKeyPoints(int size)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(size, 0, nameof(size));
        VectorOfKeyPointsHelper.New(size, out _handle).ThrowHandleException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="points"></param>
    public VectorOfKeyPoints(IEnumerable<KeyPoint> points)
    {
        ArgumentNullException.ThrowIfNull(points, nameof(points));

        var array = points.ToArray();
        VectorOfKeyPointsHelper.New(array, array.Length, out _handle).ThrowHandleException();
    }

    /// <summary>
    /// 
    /// </summary>
    public int Size => VectorOfKeyPointsHelper.Size(_handle);

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public KeyPoint[] ToArray()
    {
        var size = Size;

        var array = new KeyPoint[size];
        var length = Marshal.SizeOf<KeyPoint>() * size;

        DataHandle = GCHandle.Alloc(array, GCHandleType.Pinned);

        unsafe
        {
            var ptr = VectorOfKeyPointsHelper.Data(_handle);
            Buffer.MemoryCopy(ptr.ToPointer(),
                DataHandle.AddrOfPinnedObject().ToPointer(),
                length, length);
        }

        GC.KeepAlive(this);
        return array;
    }
}