namespace Laifu.OpenCv.PInvoke;

partial class NativeMethods
{
    [LibraryImport(LibraryName, EntryPoint = "api_umat_create1"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus UMat_Create(UMatUsageFlags flags, out UMatHandle output);

    [LibraryImport(LibraryName, EntryPoint = "api_umat_create2"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus UMat_Create(int rows, int cols, int type, UMatUsageFlags flags, out UMatHandle output);

    [LibraryImport(LibraryName, EntryPoint = "api_umat_delete_umat"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus UMat_Delete(IntPtr ptr);

    [LibraryImport(LibraryName, EntryPoint = "api_umat_get_mat"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus UMat_GetMat(UMatHandle umat, AccessFlag flag, out MatHandle output);

}