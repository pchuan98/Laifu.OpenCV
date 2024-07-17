using static Laifu.OpenCv.PInvoke.NativeMethods;

namespace Laifu.OpenCv.Models;

public partial class OutputArray
{
    private readonly OutputArrayHandle _handle;

    public OutputArrayHandle Handle => _handle;

    public bool IsDisposed => _handle.IsClosed || _handle.IsInvalid;

    public OutputArray(Mat mat)
    {
        ArgumentNullException.ThrowIfNull(mat);

        if (mat.IsDisposed)
            throw new ArgumentException("The Mat is disposed.", nameof(mat));

        Array_OutputCreate(mat.Handle, out _handle).ThrowHandleException();
        GC.KeepAlive(mat);
    }
}

partial class OutputArray
{
    public static implicit operator OutputArray(Mat mat) => new(mat);

}