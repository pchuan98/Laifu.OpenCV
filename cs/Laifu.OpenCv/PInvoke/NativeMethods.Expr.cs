namespace Laifu.OpenCv.PInvoke;

partial class NativeMethods
{
    [LibraryImport(LibraryName, EntryPoint = "api_expr_create")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus Expr_Create(out MatExprHandle output);

    [LibraryImport(LibraryName, EntryPoint = "api_expr_create_by_mat")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus Expr_Create(MatHandle intput, out MatExprHandle output);

    [LibraryImport(LibraryName, EntryPoint = "api_expr_delete_expr")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus Expr_Delete(IntPtr ptr);

    [LibraryImport(LibraryName, EntryPoint = "api_expr_to_mat")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus Expr_ToMat(MatExprHandle obj, out MatHandle output);

    [LibraryImport(LibraryName, EntryPoint = "api_expr_size")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus Expr_Size(MatExprHandle obj, out CvSize output);

    [LibraryImport(LibraryName, EntryPoint = "api_expr_type")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus Expr_Type(MatExprHandle obj, out int output);

    [LibraryImport(LibraryName, EntryPoint = "api_expr_get_row")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus Expr_GetRow(MatExprHandle obj, int x, out MatExprHandle output);

    [LibraryImport(LibraryName, EntryPoint = "api_expr_get_col")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus Expr_GetCol(MatExprHandle obj, int y, out MatExprHandle output);

    [LibraryImport(LibraryName, EntryPoint = "api_expr_get_diag")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus Expr_GetDiag(MatExprHandle obj, int d, out MatExprHandle output);

    [LibraryImport(LibraryName, EntryPoint = "api_expr_crop_by_range")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus Expr_Crop(MatExprHandle obj, CvSlice rowRange, CvSlice colRange, out MatExprHandle output);

    [LibraryImport(LibraryName, EntryPoint = "api_expr_crop_by_rect")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus Expr_Crop(MatExprHandle obj, CvRect roi, out MatExprHandle output);

    [LibraryImport(LibraryName, EntryPoint = "api_expr_t")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus Expr_T(MatExprHandle obj, out MatExprHandle output);

    [LibraryImport(LibraryName, EntryPoint = "api_expr_inv")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus Expr_Inv(MatExprHandle obj, int method, out MatExprHandle output);

    [LibraryImport(LibraryName, EntryPoint = "api_expr_mul_with_expr")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus Expr_MulWithExpr(MatExprHandle obj, MatExprHandle expr, double scale, out MatExprHandle output);

    [LibraryImport(LibraryName, EntryPoint = "api_expr_mul_with_mat")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus Expr_MulWithMat(MatExprHandle obj, MatHandle mat, double scale, out MatExprHandle output);

    [LibraryImport(LibraryName, EntryPoint = "api_expr_cross")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus Expr_Cross(MatExprHandle obj, MatHandle mat, out MatExprHandle output);

    [LibraryImport(LibraryName, EntryPoint = "api_expr_dot")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus Expr_Dot(MatExprHandle obj, MatHandle mat, out double output);
}
