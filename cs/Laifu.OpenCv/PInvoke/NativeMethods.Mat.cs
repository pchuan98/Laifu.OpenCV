namespace Laifu.OpenCv.PInvoke;

partial class NativeMethods
{
    [LibraryImport(LibraryName, EntryPoint = "api_mat_create1")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus Mat_Create(out MatHandle output);

    [LibraryImport(LibraryName, EntryPoint = "api_mat_create2")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus Mat_Create(int rows, int cols, int type, out MatHandle output);

    [LibraryImport(LibraryName, EntryPoint = "api_mat_create3")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus Mat_Create(int rows, int cols, int type, CvScalar scalar, out MatHandle output);

    [LibraryImport(LibraryName, EntryPoint = "api_mat_create4")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus Mat_Create(int ndims, int[] sizes, int type, out MatHandle output);

    [LibraryImport(LibraryName, EntryPoint = "api_mat_create5")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus Mat_Create(int ndims, int[] sizes, int type, CvScalar scalar, out MatHandle output);

    [LibraryImport(LibraryName, EntryPoint = "api_mat_create6")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus Mat_Create(MatHandle mat, out MatHandle output);

    [LibraryImport(LibraryName, EntryPoint = "api_mat_create7")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus Mat_Create(int rows, int cols, int type, IntPtr data, IntPtr step, out MatHandle output);

    [LibraryImport(LibraryName, EntryPoint = "api_mat_create8")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus Mat_Create(int ndims, int[] sizes, int type, IntPtr data, nint[]? steps, out MatHandle output);

    [LibraryImport(LibraryName, EntryPoint = "api_mat_create9")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus Mat_Create(MatHandle mat, CvSlice rowRange, CvSlice colRange, out MatHandle output);

    [LibraryImport(LibraryName, EntryPoint = "api_mat_create10")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus Mat_Create(MatHandle mat, CvRect roi, out MatHandle output);

    [LibraryImport(LibraryName, EntryPoint = "api_mat_create11")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus Mat_Create(MatHandle mat, CvSlice[] ranges, out MatHandle output);

    [LibraryImport(LibraryName, EntryPoint = "api_mat_delete_mat")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus Mat_Delete(IntPtr ptr);

    [LibraryImport(LibraryName, EntryPoint = "api_mat_flags")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial int Mat_Flags(MatHandle mat);

    [LibraryImport(LibraryName, EntryPoint = "api_mat_dims")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial int Mat_Dims(MatHandle mat);

    [LibraryImport(LibraryName, EntryPoint = "api_mat_rows")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial int Mat_Rows(MatHandle mat);

    [LibraryImport(LibraryName, EntryPoint = "api_mat_cols")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial int Mat_Cols(MatHandle mat);

    [LibraryImport(LibraryName, EntryPoint = "api_mat_total")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial IntPtr Mat_Data(MatHandle mat);

    [LibraryImport(LibraryName, EntryPoint = "api_mat_size")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial CvSize Mat_Size(MatHandle mat);

    [LibraryImport(LibraryName, EntryPoint = "api_mat_size_at")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial void Mat_SizeAt(MatHandle mat, int dims, out int ret);

    [LibraryImport(LibraryName, EntryPoint = "api_mat_step")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial IntPtr Mat_Step(MatHandle mat);

    [LibraryImport(LibraryName, EntryPoint = "api_mat_step_at")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial void Mat_StepAt(MatHandle mat, int dims, out nint ret);

    [LibraryImport(LibraryName, EntryPoint = "api_mat_row")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial void Mat_Row(MatHandle mat, int row, out MatHandle ret);

    [LibraryImport(LibraryName, EntryPoint = "api_mat_col")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial void Mat_Col(MatHandle mat, int col, out MatHandle ret);

    [LibraryImport(LibraryName, EntryPoint = "api_mat_row_range1")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial void Mat_RowRange1(MatHandle mat, int start, int end, out MatHandle ret);

    [LibraryImport(LibraryName, EntryPoint = "api_mat_row_range2")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus Mat_RowRange2(MatHandle mat, CvSlice range, out MatHandle output);

    [LibraryImport(LibraryName, EntryPoint = "api_mat_col_range1")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial void Mat_ColRange1(MatHandle mat, int start, int end, out MatHandle ret);

    [LibraryImport(LibraryName, EntryPoint = "api_mat_col_range2")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus Mat_ColRange2(MatHandle mat, CvSlice range, out MatHandle output);

    [LibraryImport(LibraryName, EntryPoint = "api_mat_diag")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus Mat_Diag(MatHandle mat, int d, out MatHandle output);

    [LibraryImport(LibraryName, EntryPoint = "api_mat_clone")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus Mat_Clone(MatHandle mat, out MatHandle output);

    [LibraryImport(LibraryName, EntryPoint = "api_mat_copy_to1")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus Mat_CopyTo1(MatHandle mat, MatHandle dst);

    [LibraryImport(LibraryName, EntryPoint = "api_mat_copy_to2")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus Mat_CopyTo2(MatHandle mat, MatHandle dst, MatHandle mask);

    [LibraryImport(LibraryName, EntryPoint = "api_mat_converter_to")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus Mat_ConvertTo(MatHandle mat, MatHandle dst, int rtype, double alpha, double beta);

    [LibraryImport(LibraryName, EntryPoint = "api_mat_assign_to")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus Mat_AssignTo(MatHandle mat, MatHandle dst, int type);

    [LibraryImport(LibraryName, EntryPoint = "api_mat_set_to1")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus Mat_SetTo1(MatHandle mat, MatHandle value, MatHandle mask);

    [LibraryImport(LibraryName, EntryPoint = "api_mat_set_to2")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus Mat_SetTo2(MatHandle mat, CvScalar value, MatHandle mask);
}
