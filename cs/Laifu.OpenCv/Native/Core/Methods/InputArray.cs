// ReSharper disable once CheckNamespace
namespace Laifu.OpenCv.Native.Core;

// new
partial class Method
{
    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_inputarray_new1")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus InputArrayNew(out InputArrayHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_inputarray_new2")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus InputArrayNew(int flags, IntPtr obj, out InputArrayHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_inputarray_new3")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus InputArrayNew(MatHandle m, out InputArrayHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_inputarray_new4")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus InputArrayNew(MatExprHandle expr, out InputArrayHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_inputarray_new5")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus InputArrayNew(VectorOfMatHandle vec, out InputArrayHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_inputarray_new6")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus InputArrayNew(double val, out InputArrayHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_inputarray_new11")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus InputArrayNew(UMatHandle um, out InputArrayHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_inputarray_new12")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus InputArrayNew(VectorOfUMatHandle umv, out InputArrayHandle output);
}

// methods
partial class Method
{
    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_inputarray_getMat")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus InputArrayGetMat(InputArrayHandle input, int idx, out MatHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_inputarray_getUMat")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus InputArrayGetUMat(InputArrayHandle input, int idx, out UMatHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_inputarray_getMatVector")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus InputArrayGetMatVector(InputArrayHandle input, IntPtr mv);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_inputarray_getUMatVector")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus InputArrayGetUMatVector(InputArrayHandle input, IntPtr umv);
}
