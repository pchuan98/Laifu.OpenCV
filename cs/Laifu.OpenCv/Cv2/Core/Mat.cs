using System.Drawing;
using Laifu.OpenCv.Constants;
using Laifu.OpenCv.Native;
using Laifu.OpenCv.Native.Core;

// ReSharper disable once CheckNamespace
namespace Laifu.OpenCv.Cv2;

/// <summary>
/// 
/// </summary>
public partial class Mat
{
    private readonly MatHandle _handle;
}


// create
partial class Mat
{
    public Mat() => CoreMethod.MatNew(out _handle).ThrowHandleException();

    public Mat(MatHandle mat) => _handle = mat;

    public Mat(int rows, int cols, MatType type)
        => CoreMethod.MatNew(rows, cols, type, out _handle).ThrowHandleException();

    public Mat(Size2i size, MatType type)
        => CoreMethod.MatNew(size, type, out _handle).ThrowHandleException();

    public Mat(int rows, int cols, MatType type, Scalar s)
        => CoreMethod.MatNew(rows, cols, type, s, out _handle).ThrowHandleException();

    public Mat(Size2i size, MatType type, Scalar s)
        => CoreMethod.MatNew(size, type, s, out _handle).ThrowHandleException();

    public Mat(IEnumerable<int> sizes, MatType type)
    {
        ArgumentNullException.ThrowIfNull(sizes, nameof(sizes));

        var array = sizes.ToArray();
        CoreMethod.MatNew(array.Length, array, type, out _handle).ThrowHandleException();
    }

    // todo
}

// props
partial class Mat
{
    public int Flags => CoreMethod.MatFlags(_handle);

    public int Dims => CoreMethod.MatDims(_handle);

    public int Rows => CoreMethod.MatRows(_handle);

    public int Cols => CoreMethod.MatCols(_handle);

    public nint Data => CoreMethod.MatData(_handle);

    public unsafe byte* DataPointer => (byte*)Data;

    public Size Size => CoreMethod.MatSize(_handle);

    public int SizeAt(int i)
        => CoreMethod.MatSizeAt(_handle, i);

    public int MatStep => CoreMethod.MatStep(_handle);

    public int StepAt(int i)
        => CoreMethod.MatStepAt(_handle, i);
}

// todo
partial class Mat
{
    public Mat Row(int y)
    {
        CoreMethod.MatRow(_handle, y, out var row);

        return new Mat(row);
    }
}

partial class Mat
{
    public bool IsContinuous => CoreMethod.MatIsContinuous(_handle);

    public bool IsSubmatrix => CoreMethod.MatIsSubmatrix(_handle);

    public int ElemSize => CoreMethod.MatElemSize(_handle);

    public int ElemSize1 => CoreMethod.MatElemSize1(_handle);

    public MatType Type => CoreMethod.MatType(_handle);

    public int Depth => CoreMethod.MatDepth(_handle);

    public int Channels => CoreMethod.MatChannels(_handle);

    public bool IsEmpty => CoreMethod.MatEmpty(_handle) != 0;

    public nint Total => (nint)CoreMethod.MatTotal(_handle);
}