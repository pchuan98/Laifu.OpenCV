using Laifu.OpenCv.Interfaces;
using Laifu.OpenCv.PInvoke;
using static Laifu.OpenCv.PInvoke.NativeMethods;

namespace Laifu.OpenCv.Models;

public partial class Mat : DisposableObject, IInputArray
{
    private readonly MatHandle _handle;

    public MatHandle Handle => _handle;

    public new bool IsDisposed => _handle.IsClosed || _handle.IsInvalid;

    public InputArrayHandle GetInputArrayHandle() => ((InputArray)this).GetInputArrayHandle();

    public Mat() => Mat_Create(out _handle).ThrowHandleException();

    public Mat(int row, int col, MatType type)
        => Mat_Create(row, col, type, out _handle);

    public Mat(int row, int col, MatType type, CvScalar scalar)
        => Mat_Create(row, col, type, scalar, out _handle);

    public Mat(CvSize size, MatType type)
        => Mat_Create(size.Height, size.Width, type, out _handle);

    public Mat(IEnumerable<int> sizes, MatType type)
    {
        ArgumentNullException.ThrowIfNull(sizes);

        var arrgy = sizes as int[] ?? sizes.ToArray();
        Mat_Create(arrgy.Length, arrgy, type, out _handle)
            .ThrowHandleException();
    }

    public Mat(IEnumerable<int> sizes, MatType type, CvScalar scalar)
    {
        ArgumentNullException.ThrowIfNull(sizes);

        var arrgy = sizes as int[] ?? sizes.ToArray();
        Mat_Create(arrgy.Length, arrgy, type, scalar, out _handle)
            .ThrowHandleException();

    }

    internal Mat(MatHandle expr) => _handle = expr;

    public Mat(Mat mat)
    {
        ArgumentNullException.ThrowIfNull(mat);

        if (mat.IsDisposed)
            throw new ArgumentException("The Mat is disposed.", nameof(mat));

        Mat_Create(mat.Handle, out _handle)
            .ThrowHandleException();
        GC.KeepAlive(mat);
    }

    public Mat(int row, int col, MatType type, IntPtr data, nint step = 0)
        => Mat_Create(row, col, type, data, step, out _handle);

    public Mat(int row, int col, MatType type, Array data, nint step = 0)
    {
        DataHandle = GCHandle.Alloc(data, GCHandleType.Pinned);
        Mat_Create(row, col, type, DataHandle.AddrOfPinnedObject(), step, out _handle)
            .ThrowHandleException();
    }
    public Mat(CvSize size, MatType type, IntPtr data, nint step = 0)
        => Mat_Create(size.Height, size.Width, type, data, step, out _handle);

    public Mat(IEnumerable<int> sizes, MatType type, IntPtr data, IEnumerable<nint>? steps = null)
    {
        ArgumentNullException.ThrowIfNull(sizes);
        ArgumentNullException.ThrowIfNull(data);

        var array = sizes as int[] ?? sizes.ToArray();
        var stepsArray = steps?.ToArray();

        Mat_Create(array.Length, array, type, data, stepsArray, out _handle)
            .ThrowHandleException();
    }

    public Mat(IEnumerable<int> sizes, MatType type, Array data, IEnumerable<nint>? steps = null)
    {
        ArgumentNullException.ThrowIfNull(sizes);
        ArgumentNullException.ThrowIfNull(data);

        DataHandle = GCHandle.Alloc(data, GCHandleType.Pinned);

        var array = sizes as int[] ?? sizes.ToArray();
        var stepsArray = steps?.ToArray();

        Mat_Create(array.Length, array, type, DataHandle.AddrOfPinnedObject(), stepsArray, out _handle)
            .ThrowHandleException();
    }

    public Mat(Mat mat, CvSlice rowRange, CvSlice colRange)
    {
        ArgumentNullException.ThrowIfNull(mat);

        if (mat.IsDisposed)
            throw new ArgumentException("The Mat is disposed.", nameof(mat));

        Mat_Create(mat.Handle, rowRange, colRange, out _handle)
            .ThrowHandleException();
    }

    public Mat(Mat mat, CvRect roi)
    {
        ArgumentNullException.ThrowIfNull(mat);

        if (mat.IsDisposed)
            throw new ArgumentException("The Mat is disposed.", nameof(mat));

        Mat_Create(mat.Handle, roi, out _handle)
            .ThrowHandleException();
    }

    public Mat(Mat mat, IEnumerable<CvSlice> ranges)
    {
        ArgumentNullException.ThrowIfNull(mat);
        ArgumentNullException.ThrowIfNull(ranges);

        if (mat.IsDisposed)
            throw new ArgumentException("The Mat is disposed.", nameof(mat));

        var array = ranges.ToArray();
        Mat_Create(mat.Handle, array, out _handle)
            .ThrowHandleException();
    }

    // todo converter with span

    public Mat(string filename, ImreadModes flag)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(filename);

        ImageCodecs_Imread(filename, (int)flag, out _handle)
            .ThrowHandleException();
    }
}


// fields
partial class Mat
{
    /// <summary>
    /// includes several bit-fields:
    /// - the magic signature
    /// - continuity flag
    /// - depth
    /// - number of channels
    /// </summary>
    public int Flags => Mat_Flags(_handle);

    /// <summary>
    /// the matrix dimensionality, >= 2
    /// </summary>
    public int Dims => Mat_Dims(_handle);

    /// <summary>
    /// the number of rows or -1 when the matrix has more than 2 dimensions
    /// </summary>
    public int Rows => Mat_Rows(_handle);

    /// <summary>
    /// the number of columns or -1 when the matrix has more than 2 dimensions
    /// </summary>
    public int Cols => Mat_Cols(_handle);

    /// <summary>
    /// pointer to the data
    /// </summary>
    public nint Data => Mat_Data(_handle);

    /// <summary>
    /// unsafe pointer to the data
    /// </summary>
    public unsafe byte* DataPointer => (byte*)Data;

    /// <summary>
    /// Returns a matrix size.
    /// </summary>
    public CvSize Size() => Mat_Size(_handle);
}