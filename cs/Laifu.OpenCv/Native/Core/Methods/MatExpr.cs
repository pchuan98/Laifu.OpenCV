// ReSharper disable once CheckNamespace
namespace Laifu.OpenCv.Native.Core;

// new
partial class Method
{
    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_matexpr_new1")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatExprNew(out MatExprHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_matexpr_new2")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatExprNew(MatHandle mat, out MatExprHandle output);
}

// func
partial class Method
{

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_matexpr_size")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial CvSize MatExprSize(MatExprHandle expr);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_matexpr_type")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial int MatExprType(MatExprHandle expr);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_matexpr_row")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatExprRow(MatExprHandle expr, int y, out MatExprHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_matexpr_col")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatExprCol(MatExprHandle expr, int x, out MatExprHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_matexpr_diag")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatExprDiag(MatExprHandle expr, int d, out MatExprHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_matexpr_t")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatExprT(MatExprHandle expr, out MatExprHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_matexpr_inv")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatExprInv(MatExprHandle expr, int method, out MatExprHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_matexpr_mul1")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatExprMul(MatExprHandle expr, MatHandle e, double scale, out MatExprHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_matexpr_mul2")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatExprMul(MatHandle mat, MatHandle m, double scale, out MatExprHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_matexpr_cross")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatExprCross(MatExprHandle expr, MatHandle m, out MatHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_matexpr_dot")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial double MatExprDot(MatExprHandle expr, MatHandle m);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_matexpr_swap")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatExprSwap(MatExprHandle expr, MatExprHandle b);
}

// bracket
partial class Method
{
    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_matexpr_operator_bracket")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatExprOperatorBracket(MatExprHandle expr, Range rowRange, Range colRange, out MatExprHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_matexpr_operator_bracket2")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatExprOperatorBracket(MatExprHandle expr, Rect2i roi, out MatExprHandle output);
}

// plus
partial class Method
{
    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_matexpr_operator_plus1")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatExprOperatorPlus(MatHandle a, MatHandle b, out MatExprHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_matexpr_operator_plus2")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatExprOperatorPlus(MatHandle a, Scalar s, out MatExprHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_matexpr_operator_plus3")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatExprOperatorPlus(MatExprHandle e, MatHandle m, out MatExprHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_matexpr_operator_plus4")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatExprOperatorPlus(MatExprHandle e, Scalar s, out MatExprHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_matexpr_operator_plus5")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatExprOperatorPlus(MatExprHandle e1, MatExprHandle e2, out MatExprHandle output);
}

// minus
partial class Method
{
    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_matexpr_operator_minus1")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatExprOperatorMinus(MatHandle a, MatHandle b, out MatExprHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_matexpr_operator_minus2")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatExprOperatorMinus(MatHandle a, Scalar s, out MatExprHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_matexpr_operator_minus3")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatExprOperatorMinus(MatExprHandle e, MatHandle m, out MatExprHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_matexpr_operator_minus4")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatExprOperatorMinus(MatExprHandle e, Scalar s, out MatExprHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_matexpr_operator_minus5")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatExprOperatorMinus(MatExprHandle e1, MatExprHandle e2, out MatExprHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_matexpr_operator_minus6")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatExprOperatorMinus(MatHandle m, out MatExprHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_matexpr_operator_minus7")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatExprOperatorMinus(MatExprHandle e, out MatExprHandle output);

}

// mul
partial class Method
{
    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_matexpr_operator_mul1")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatExprOperatorMul(MatHandle a, MatHandle b, out MatExprHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_matexpr_operator_mul2")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatExprOperatorMul(MatHandle a, double s, out MatExprHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_matexpr_operator_mul3")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatExprOperatorMul(MatExprHandle e, MatHandle m, out MatExprHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_matexpr_operator_mul4")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatExprOperatorMul(MatExprHandle e, double s, out MatExprHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_matexpr_operator_mul5")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatExprOperatorMul(MatExprHandle e1, MatExprHandle e2, out MatExprHandle output);
}

// div
partial class Method
{
    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_matexpr_operator_div1")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatExprOperatorDiv(MatHandle a, MatHandle b, out MatExprHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_matexpr_operator_div2")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatExprOperatorDiv(MatHandle a, double s, out MatExprHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_matexpr_operator_div3")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatExprOperatorDiv(double s, MatHandle a, out MatExprHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_matexpr_operator_div4")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatExprOperatorDiv(MatExprHandle e, MatHandle m, out MatExprHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_matexpr_operator_div5")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatExprOperatorDiv(MatHandle m, MatExprHandle e, out MatExprHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_matexpr_operator_div6")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatExprOperatorDiv(MatExprHandle e, double s, out MatExprHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_matexpr_operator_div7")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatExprOperatorDiv(double s, MatExprHandle e, out MatExprHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_matexpr_operator_div8")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatExprOperatorDiv(MatExprHandle e1, MatExprHandle e2, out MatExprHandle output);
}

// logic1 < <= == != >= >
partial class Method
{
    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_matexpr_operator_less1")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatExprOperatorLess(MatHandle a, MatHandle b, out MatExprHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_matexpr_operator_less2")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatExprOperatorLess(MatHandle a, double s, out MatExprHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_matexpr_operator_less_equal1")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatExprOperatorLessEqual(MatHandle a, MatHandle b, out MatExprHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_matexpr_operator_less_equal2")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatExprOperatorLessEqual(MatHandle a, double s, out MatExprHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_matexpr_operator_less_equal3")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatExprOperatorLessEqual(double s, MatHandle a, out MatExprHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_matexpr_operator_equal1")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatExprOperatorEqual(MatHandle a, MatHandle b, out MatExprHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_matexpr_operator_equal2")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatExprOperatorEqual(MatHandle a, double s, out MatExprHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_matexpr_operator_not_equal1")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatExprOperatorNotEqual(MatHandle a, MatHandle b, out MatExprHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_matexpr_operator_not_equal2")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatExprOperatorNotEqual(MatHandle a, double s, out MatExprHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_matexpr_operator_greater_equal1")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatExprOperatorGreaterEqual(MatHandle a, MatHandle b, out MatExprHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_matexpr_operator_greater_equal2")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatExprOperatorGreaterEqual(MatHandle a, double s, out MatExprHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_matexpr_operator_greater1")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatExprOperatorGreater(MatHandle a, MatHandle b, out MatExprHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_matexpr_operator_greater2")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatExprOperatorGreater(MatHandle a, double s, out MatExprHandle output);
}

// logic2 & | ^ ~
partial class Method
{
    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_matexpr_operator_and1")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatExprOperatorAnd(MatHandle a, MatHandle b, out MatExprHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_matexpr_operator_and2")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatExprOperatorAnd(MatHandle a, Scalar s, out MatExprHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_matexpr_operator_and3")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatExprOperatorAnd(Scalar s, MatHandle a, out MatExprHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_matexpr_operator_or1")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatExprOperatorOr(MatHandle a, MatHandle b, out MatExprHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_matexpr_operator_or2")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatExprOperatorOr(MatHandle a, Scalar s, out MatExprHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_matexpr_operator_or3")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatExprOperatorOr(Scalar s, MatHandle a, out MatExprHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_matexpr_operator_xor1")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatExprOperatorXor(MatHandle a, MatHandle b, out MatExprHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_matexpr_operator_xor2")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatExprOperatorXor(MatHandle a, Scalar s, out MatExprHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_matexpr_operator_xor3")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatExprOperatorXor(Scalar s, MatHandle a, out MatExprHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_matexpr_operator_not")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatExprOperatorNot(MatHandle m, out MatExprHandle output);
}

// min max abs
partial class Method
{
    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_matexpr_min1")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatExprMin(MatHandle a, MatHandle b, out MatExprHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_matexpr_min2")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatExprMin(MatHandle a, double s, out MatExprHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_matexpr_min3")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatExprMin(double s, MatHandle a, out MatExprHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_matexpr_max1")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatExprMax(MatHandle a, MatHandle b, out MatExprHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_matexpr_max2")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatExprMax(MatHandle a, double s, out MatExprHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_matexpr_max3")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatExprMax(double s, MatHandle a, out MatExprHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_matexpr_abs1")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatExprAbs(MatHandle m, out MatExprHandle output);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_matexpr_abs2")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MatExprAbs(MatExprHandle e, out MatExprHandle output);
}