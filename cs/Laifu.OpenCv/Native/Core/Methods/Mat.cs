// ReSharper disable once CheckNamespace
namespace Laifu.OpenCv.Native.Core;

// new
partial class Method
{
    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_mat_new1")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatNew(out MatHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_mat_new2")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatNew(int rows, int cols, int type, out MatHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_mat_new3")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatNew(Size2i size, int type, out MatHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_mat_new4")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatNew(int rows, int cols, int type, Scalar s, out MatHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_mat_new5")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatNew(Size2i size, int type, Scalar s, out MatHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_mat_new6")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatNew(int ndims, int[] sizes, int type, out MatHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_mat_new7")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatNew(int ndims, int[] sizes, int type, Scalar s, out MatHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_mat_new8")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatNew(MatHandle m, out MatHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_mat_new9")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatNew(int rows, int cols, int type, nint data, int step, out MatHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_mat_new10")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatNew(Size2i size, int type, uint data, nint step, out MatHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_mat_new11")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatNew(MatHandle mat, Range rowRange, Range colRange, out MatHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_mat_new12")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatNew(MatHandle mat, Rect2i roi, out MatHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_mat_new13")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatNew(MatHandle mat, Range[] ranges, out MatHandle output);
}

// props
partial class Method
{
    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_mat_flags")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial int MatFlags(MatHandle mat);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_mat_dims")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial int MatDims(MatHandle mat);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_mat_rows")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial int MatRows(MatHandle mat);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_mat_cols")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial int MatCols(MatHandle mat);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_mat_data")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial IntPtr MatData(MatHandle mat);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_mat_size")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial CvSize MatSize(MatHandle mat);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_mat_sizeat")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial int MatSizeAt(MatHandle mat, int i);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_mat_step")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial int MatStep(MatHandle mat);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_mat_stepat")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial int MatStepAt(MatHandle mat, int i);
}

// func
partial class Method
{
    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_mat_row")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatRow(MatHandle mat, int y, out MatHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_mat_col")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatCol(MatHandle mat, int x, out MatHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_mat_row_range1")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatRowRange(MatHandle mat, int startRow, int endRow, out MatHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_mat_row_range2")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatRowRange(MatHandle mat, Range range, out MatHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_mat_col_range1")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatColRange(MatHandle mat, int startCol, int endCol, out MatHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_mat_col_range2")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatColRange(MatHandle mat, Range range, out MatHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_mat_diag")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatDiag(MatHandle mat, int d, out MatHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_mat_clone")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatClone(MatHandle mat, out MatHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_mat_copy_to1")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatCopyTo(MatHandle mat, OutputArrayHandle outputArray);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_mat_copy_to2")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatCopyTo(MatHandle mat, OutputArrayHandle outputArray, InputArrayHandle mask);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_mat_convert_to")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatConvertTo(MatHandle mat, OutputArrayHandle outputArray, int rtype, double alpha, double beta);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_mat_assign_to")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatAssignTo(MatHandle mat, MatHandle output, int type);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_mat_set_to")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatSetTo(MatHandle mat, InputArrayHandle value, InputArrayHandle mask);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_mat_reshape1")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatReshape(MatHandle mat, int cn, int rows, out MatHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_mat_reshape2")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatReshape(MatHandle mat, int cn, int newDims, int[] newSize, out MatHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_mat_reshape3")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatReshape(MatHandle mat, int cn, int[] newShape, int count, out MatHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_mat_t")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatT(MatHandle mat, out MatHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_mat_inv")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatInv(MatHandle mat, int method, out MatHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_mat_mul")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatMul(MatHandle mat, InputArrayHandle m, double scale, out MatHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_mat_cross")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatCross(MatHandle mat, InputArrayHandle m, out MatHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_mat_dot")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial double MatDot(MatHandle mat, InputArrayHandle m);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_mat_zeros1")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatZeros(int rows, int cols, int type, out MatHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_mat_zeros2")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatZeros(Size2i size, int type, out MatHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_mat_zeros3")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatZeros(int ndims, int[] sizes, int type, out MatHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_mat_ones1")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatOnes(int rows, int cols, int type, out MatHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_mat_ones2")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatOnes(Size2i size, int type, out MatHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_mat_ones3")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatOnes(int ndims, int[] sizes, int type, out MatHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_mat_eye1")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatEye(int rows, int cols, int type, out MatHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_mat_eye2")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatEye(Size2i size, int type, out MatHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_mat_create1")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatCreate(MatHandle mat, int rows, int cols, int type);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_mat_create2")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatCreate(MatHandle mat, Size2i size, int type);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_mat_create3")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatCreate(MatHandle mat, int ndims, int[] sizes, int type);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_mat_create4")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatCreate(MatHandle mat, int[] sizes, int count, int type);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_mat_addref")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatAddRef(MatHandle mat);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_mat_release")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatRelease(MatHandle mat);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_mat_deallocate")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatDeallocate(MatHandle mat);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_mat_copy_size")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatCopySize(MatHandle mat, MatHandle m);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_mat_reserve")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatReserve(MatHandle mat, nint sz);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_mat_reserve_buffer")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatReserveBuffer(MatHandle mat, nint sz);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_mat_resize")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatResize(MatHandle mat, nint sz);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_mat_resize_with_scalar")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatResizeWithScalar(MatHandle mat, nint sz, Scalar s);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_mat_step1")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial nint MatStep1(MatHandle mat, int i);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_mat_total1")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial nint MatTotal(MatHandle mat, int startDim, int endDim);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_mat_check_vector")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial int MatCheckVector(MatHandle mat, int elemChannels, int depth, [MarshalAs(UnmanagedType.I1)] bool requireContinuous);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_mat_ptr1")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial nint MatPtr(MatHandle mat, int i0);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_mat_ptr2")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial nint MatPtr(MatHandle mat, int row, int col);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_mat_ptr3")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial nint MatPtr(MatHandle mat, int i0, int i1, int i2);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_mat_ptr4")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial nint MatPtr(MatHandle mat, int[] idx);
}

// prop but func
partial class Method
{
    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_mat_is_continuous")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    internal static partial bool MatIsContinuous(MatHandle mat);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_mat_is_submatrix")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    internal static partial bool MatIsSubmatrix(MatHandle mat);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_mat_elem_size")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial int MatElemSize(MatHandle mat);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_mat_elem_size1")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial int MatElemSize1(MatHandle mat);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_mat_type")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial int MatType(MatHandle mat);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_mat_depth")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial int MatDepth(MatHandle mat);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_mat_channels")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial int MatChannels(MatHandle mat);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_mat_empty")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial int MatEmpty(MatHandle mat);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_mat_total")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial UIntPtr MatTotal(MatHandle mat);
}