// ReSharper disable once CheckNamespace
namespace Laifu.OpenCv.Native.Core;

// new
partial class Method
{
    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_outputarray_new1")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus OutputArrayNew(out OutputArrayHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_outputarray_new2")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus OutputArrayNew(int flags, IntPtr obj, out OutputArrayHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_outputarray_new3")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus OutputArrayNew(MatHandle m, out OutputArrayHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_outputarray_new4")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus OutputArrayNew(VectorOfMatHandle vec, out OutputArrayHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_outputarray_new9")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus OutputArrayNew(UMatHandle m, out OutputArrayHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_outputarray_new10")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus OutputArrayNew(VectorOfUMatHandle vec, out OutputArrayHandle output);
}

// methods
partial class Method
{
    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_outputarray_getMatRef")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus OutputArrayGetMatRef(OutputArrayHandle output, int i, out MatHandle mat);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_outputarray_getUMatRef")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus OutputArrayGetUMatRef(OutputArrayHandle output, int i, out UMatHandle umat);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_outputarray_release")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus OutputArrayRelease(OutputArrayHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_outputarray_move1")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus OutputArrayMove(OutputArrayHandle output, UMatHandle u);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_outputarray_move2")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus OutputArrayMove(OutputArrayHandle output, MatHandle m);
}