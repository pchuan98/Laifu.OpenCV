using Laifu.OpenCv.Interfaces;
using static Laifu.OpenCv.PInvoke.NativeMethods;

namespace Laifu.OpenCv.Models;

public partial class InputArray : IInputArray
{
    private readonly InputArrayHandle _handle;

    public InputArrayHandle Handle => _handle;

    public bool IsDisposed => _handle.IsClosed || _handle.IsInvalid;

    public InputArrayHandle GetInputArrayHandle() => _handle;

    public InputArray(Mat mat)
    {
        ArgumentNullException.ThrowIfNull(mat);

        if (mat.IsDisposed)
            throw new ArgumentException("The Mat is disposed.", nameof(mat));

        Array_InputCreate(mat.Handle, out _handle).ThrowHandleException();
        GC.KeepAlive(mat);
    }

    public InputArray(MatExpr expr)
    {
        ArgumentNullException.ThrowIfNull(expr);

        if (expr.IsDisposed)
            throw new ArgumentException("The MatExpr is disposed.", nameof(expr));

        Array_InputCreate(expr.Handle, out _handle).ThrowHandleException();
        GC.KeepAlive(expr);
    }
}

// converter
partial class InputArray
{
    public static implicit operator InputArray(Mat mat) => new(mat);

    public static implicit operator InputArray(MatExpr expr) => new(expr);
}