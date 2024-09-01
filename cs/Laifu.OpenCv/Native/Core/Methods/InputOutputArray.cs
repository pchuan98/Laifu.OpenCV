// ReSharper disable once CheckNamespace
namespace Laifu.OpenCv.Native.Core;

// new
partial class Method
{
    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_inputoutputarray_new1")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus InputOutputArrayNew(out InputOutputArrayHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_inputoutputarray_new2")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus InputOutputArrayNew(int flags, IntPtr obj, out InputOutputArrayHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_inputoutputarray_new3")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus InputOutputArrayNew(MatHandle m, out InputOutputArrayHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_inputoutputarray_new4")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus InputOutputArrayNew(VectorOfMatHandle vec, out InputOutputArrayHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_inputoutputarray_new8")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus InputOutputArrayNew(UMatHandle m, out InputOutputArrayHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_inputoutputarray_new9")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus InputOutputArrayNew(VectorOfUMatHandle vec, out InputOutputArrayHandle output);
}
