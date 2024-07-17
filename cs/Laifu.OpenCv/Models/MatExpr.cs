using System.Drawing;
using System.Reflection.Metadata;
using Laifu.OpenCv.PInvoke;
using static Laifu.OpenCv.PInvoke.NativeMethods;

namespace Laifu.OpenCv.Models;

public partial class MatExpr : IDisposable
{
    private readonly MatExprHandle _handle;

    public MatExprHandle Handle => _handle;

    /// <summary>
    /// 
    /// </summary>
    public MatExpr() => Expr_Create(out _handle).ThrowHandleException();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="handle"></param>
    public MatExpr(MatExprHandle handle) => _handle = handle;

    /// <summary>
    /// Determine whether to dispose signal.
    ///
    /// 0 - not disposed, 1 - disposing or disposed.
    /// </summary>
    private volatile int _signal;

    public bool IsDisposed => _handle.IsClosed || _handle.IsInvalid;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="mat"></param>
    public MatExpr(Mat mat)
    {
        ArgumentNullException.ThrowIfNull(mat);

        if (mat.IsDisposed)
            throw new ArgumentException("The Mat is disposed.", nameof(mat));

        Expr_Create(mat.Handle, out _handle).ThrowHandleException();
        GC.KeepAlive(mat);
    }

    public void Dispose()
    {
        // http://stackoverflow.com/questions/425132/a-reference-to-a-volatile-field-will-not-be-treated-as-volatile-implications
        if (Interlocked.Exchange(ref _signal, 1) != 0)
            return;

        _handle.Dispose();
        GC.SuppressFinalize(this);
    }

    ~MatExpr() { }
}

// operator and converter
partial class MatExpr
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="mat"></param>
    public static explicit operator MatExpr(Mat mat) => new(mat);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="matExpr"></param>
    public static explicit operator Mat(MatExpr matExpr) => matExpr.ToMat();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="rowRange"></param>
    /// <param name="colRange"></param>
    /// <returns></returns>
    public MatExpr this[CvSlice rowRange, CvSlice colRange] => Crop(rowRange, colRange);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="rowRange"></param>
    /// <param name="colRange"></param>
    /// <returns></returns>
    public MatExpr this[Range rowRange, Range colRange]
        => Crop(rowRange.FromRange(), colRange.FromRange());

    /// <summary>
    /// 
    /// </summary>
    /// <param name="roi"></param>
    /// <returns></returns>
    public MatExpr this[CvRect roi] => Crop(roi);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="roi"></param>
    /// <returns></returns>
    public MatExpr this[Rectangle roi] => Crop(roi.ToCvRect());
}

// warpper
partial class MatExpr
{
    /// <summary>
    /// a simple pinvoke warper
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <param name="func"></param>
    /// <param name="arg"></param>
    /// <returns></returns>
    /// <exception cref="ObjectDisposedException"></exception>
    T1 SPinvoke<T1>(Func<T1> func)
    {
        if (_signal != 0)
            throw new ObjectDisposedException(GetType().Name);

        var ret = func.Invoke();

        GC.KeepAlive(this);

        return ret;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public Mat ToMat() => new(SPinvoke(() =>
    {
        Expr_ToMat(_handle, out var mat)
            .ThrowHandleException();
        return mat;
    }));

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public CvSize Size() => SPinvoke(() =>
    {
        Expr_Size(_handle, out var size)
            .ThrowHandleException();
        return size;
    });

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public MatType Type() => SPinvoke(() =>
    {
        Expr_Type(_handle, out var tp)
            .ThrowHandleException();
        return tp;
    });

    /// <summary>
    /// 
    /// </summary>
    /// <param name="y"></param>
    /// <returns></returns>
    public MatExpr Row(int y) => SPinvoke(() =>
    {
        Expr_GetRow(_handle, y, out var output)
            .ThrowHandleException();
        return new MatExpr(output);
    });

    /// <summary>
    /// 
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    public MatExpr Col(int x) => SPinvoke(() =>
    {
        Expr_GetCol(_handle, x, out var output)
            .ThrowHandleException();
        return new MatExpr(output);
    });

    /// <summary>
    /// 
    /// </summary>
    /// <param name="d"></param>
    /// <returns></returns>
    public MatExpr Diag(int d = 0) => SPinvoke(() =>
    {
        Expr_GetDiag(_handle, d, out var output)
            .ThrowHandleException();
        return new MatExpr(output);
    });

    /// <summary>
    /// 
    /// </summary>
    /// <param name="rowRange"></param>
    /// <param name="colRange"></param>
    /// <returns></returns>
    public MatExpr Crop(CvSlice rowRange, CvSlice colRange) => SPinvoke(() =>
    {
        Expr_Crop(_handle, rowRange, colRange, out var output)
            .ThrowHandleException();
        return new MatExpr(output);
    });

    /// <summary>
    /// 
    /// </summary>
    /// <param name="roi"></param>
    /// <returns></returns>
    public MatExpr Crop(CvRect roi) => SPinvoke(() =>
    {
        Expr_Crop(_handle, roi, out var output)
            .ThrowHandleException();
        return new MatExpr(output);
    });
}