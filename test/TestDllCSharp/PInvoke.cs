using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace TestDllCSharp;

[Serializable, StructLayout(LayoutKind.Sequential)]
public record struct Pointf(float X, float Y);

[Serializable, StructLayout(LayoutKind.Sequential)]
public readonly record struct KeyPoints(Pointf Pt, float Size, float Angle = -1, float Response = 0, int Octave = 0, int ClassId = -1);

[Serializable, StructLayout(LayoutKind.Sequential)]
public readonly record struct Feature(int Index, Pointf Point, Array Points, KeyPoints Key);

public class VectorHandle() : SafeHandle(IntPtr.Zero, true)
{
    protected override bool ReleaseHandle()
    {
        PInvoke.Delete(handle);
        return true;
    }

    public override bool IsInvalid => handle == IntPtr.Zero;
}

public class KeypointsVector
{
    public VectorHandle Handle { get; set; }

    public KeypointsVector(IEnumerable<KeyPoints> kps)
    {
        var array = kps.ToArray();

        Handle = PInvoke.CreatePtr(array, array.Length);
    }

    public KeyPoints[] ToArray()
    {
        var size = PInvoke.GetSize(Handle);
        var ptr = PInvoke.GetPtr(Handle);

        var array = Enumerable.Range(0, size).Select(_ => new KeyPoints()).ToArray();

        var dstPtr = new nint[size];
        for (int i = 0; i < size; i++)
        {
            dstPtr[i] = Marshal.ReadIntPtr(ptr, i * IntPtr.Size);
        }

        return array;
    }
}

public static partial class PInvoke
{
    [LibraryImport("TestDll.dll", EntryPoint = "test"),
     UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial void Test(KeyPoints point);

    [LibraryImport("TestDll.dll", EntryPoint = "to_delete"),
     UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial void Delete(IntPtr ptr);

    [LibraryImport("TestDll.dll", EntryPoint = "test2"),
     UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial void Test2(SafeHandle feature);



    [LibraryImport("TestDll.dll", EntryPoint = "create_ptr"),
     UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial VectorHandle CreatePtr(KeyPoints[] points, int length);

    [LibraryImport("TestDll.dll", EntryPoint = "get_ptr"),
     UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial nint GetPtr(VectorHandle feature);

    [LibraryImport("TestDll.dll", EntryPoint = "get_size"),
     UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial int GetSize(VectorHandle feature);
}