// ReSharper disable once CheckNamespace
namespace Laifu.OpenCv.Native.Core;

// new
partial class Method
{
    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_umat_new1")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus UMatNew(int usageFlags, out UMatHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_umat_new2")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus UMatNew(int rows, int cols, int type, int usageFlags, out UMatHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_umat_new3")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus UMatNew(Size2i size, int type, int usageFlags, out UMatHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_umat_new4")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus UMatNew(int rows, int cols, int type, Scalar s, int usageFlags, out UMatHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_umat_new5")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus UMatNew(Size2i size, int type, Scalar s, int usageFlags, out UMatHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_umat_new6")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus UMatNew(int ndims, int[] sizes, int type, int usageFlags, out UMatHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_umat_new7")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus UMatNew(int ndims, int[] sizes, int type, Scalar s, int usageFlags, out UMatHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_umat_new8")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus UMatNew(UMatHandle m, out UMatHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_umat_new9")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus UMatNew(UMatHandle m, Range rowRange, Range colRange, out UMatHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_umat_new10")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus UMatNew(UMatHandle m, Rect2i roi, out UMatHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_umat_new11")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus UMatNew(UMatHandle m, Range[] ranges, out UMatHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_umat_new12")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus UMatNew(UMatHandle m, VectorOfRangeHandle ranges, out UMatHandle output);
}

// methods
partial class Method
{
    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_umat_getMat")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus UMatGetMat(UMatHandle umat, int flags, out MatHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_umat_row")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus UMatRow(UMatHandle umat, int y, out UMatHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_umat_col")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus UMatCol(UMatHandle umat, int x, out UMatHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_umat_row_range1")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus UMatRowRange(UMatHandle umat, int startrow, int endrow, out UMatHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_umat_row_range2")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus UMatRowRange(UMatHandle umat, Range r, out UMatHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_umat_col_range1")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus UMatColRange(UMatHandle umat, int startcol, int endcol, out UMatHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_umat_col_range2")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus UMatColRange(UMatHandle umat, Range r, out UMatHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_umat_diag")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus UMatDiag(UMatHandle umat, int d, out UMatHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_umat_update_continuity_flag")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus UMatUpdateContinuityFlag(UMatHandle umat);
}

// props
partial class Method
{
    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_umat_flags")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial int UMatFlags(UMatHandle umat);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_umat_dims")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial int UMatDims(UMatHandle umat);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_umat_rows")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial int UMatRows(UMatHandle umat);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_umat_cols")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial int UMatCols(UMatHandle umat);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_umat_u")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus UMatU(UMatHandle umat, out nint output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_umat_offset")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial nint UMatOffset(UMatHandle umat);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_umat_size")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial CvSize UMatSize(UMatHandle umat);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_umat_step")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus UMatStep(UMatHandle umat, out nint output);
}
