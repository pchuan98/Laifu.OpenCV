using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Laifu.OpenCv.Constants;
using Laifu.OpenCv.Native;
using Laifu.OpenCv.Native.Core;
using Laifu.OpenCv.Native.Core.Constants;
using Range = Laifu.OpenCv.Native.Core.Range;

// ReSharper disable once CheckNamespace
namespace Laifu.OpenCv.Cv2;

/// <summary>
/// OpenCV UMat class
/// </summary>
public partial class UMat
{
    private readonly UMatHandle _handle;

    public UMatHandle Handle => _handle;
}

// create
partial class UMat
{
    public UMat(UMatUsageFlags usageFlags = UMatUsageFlags.USAGE_DEFAULT)
        => CoreMethod.UMatNew((int)usageFlags, out _handle).ThrowHandleException();

    public UMat(UMatHandle umat) => _handle = umat;

    public UMat(int rows, int cols, MatType type, UMatUsageFlags usageFlags = UMatUsageFlags.USAGE_DEFAULT)
        => CoreMethod.UMatNew(rows, cols, type, (int)usageFlags, out _handle).ThrowHandleException();

    public UMat(Size2i size, MatType type, UMatUsageFlags usageFlags = UMatUsageFlags.USAGE_DEFAULT)
        => CoreMethod.UMatNew(size, type, (int)usageFlags, out _handle).ThrowHandleException();

    public UMat(int rows, int cols, MatType type, Scalar s, UMatUsageFlags usageFlags = UMatUsageFlags.USAGE_DEFAULT)
        => CoreMethod.UMatNew(rows, cols, type, s, (int)usageFlags, out _handle).ThrowHandleException();

    public UMat(Size2i size, MatType type, Scalar s, UMatUsageFlags usageFlags = UMatUsageFlags.USAGE_DEFAULT)
        => CoreMethod.UMatNew(size, type, s, (int)usageFlags, out _handle).ThrowHandleException();

    public UMat(IEnumerable<int> sizes, MatType type, UMatUsageFlags usageFlags = UMatUsageFlags.USAGE_DEFAULT)
    {
        ArgumentNullException.ThrowIfNull(sizes, nameof(sizes));

        var array = sizes.ToArray();
        CoreMethod.UMatNew(array.Length, array, type, (int)usageFlags, out _handle).ThrowHandleException();
    }

    public UMat(IEnumerable<int> sizes, MatType type, Scalar s, UMatUsageFlags usageFlags = UMatUsageFlags.USAGE_DEFAULT)
    {
        ArgumentNullException.ThrowIfNull(sizes, nameof(sizes));

        var array = sizes.ToArray();
        CoreMethod.UMatNew(array.Length, array, type, s, (int)usageFlags, out _handle).ThrowHandleException();
    }

    public UMat(UMat m)
        => CoreMethod.UMatNew(m.Handle, out _handle).ThrowHandleException();

    public UMat(UMat m, Range rowRange, Range colRange)
        => CoreMethod.UMatNew(m.Handle, rowRange, colRange, out _handle).ThrowHandleException();

    public UMat(UMat m, Rect2i roi)
        => CoreMethod.UMatNew(m.Handle, roi, out _handle).ThrowHandleException();

    public UMat(UMat m, Range[] ranges)
        => CoreMethod.UMatNew(m.Handle, ranges, out _handle).ThrowHandleException();
}

// props
partial class UMat
{
    public int Flags => CoreMethod.UMatFlags(_handle);

    public int Dims => CoreMethod.UMatDims(_handle);

    public int Rows => CoreMethod.UMatRows(_handle);

    public int Cols => CoreMethod.UMatCols(_handle);

    public nint U
    {
        get
        {
            CoreMethod.UMatU(_handle, out var output).ThrowHandleException();
            return output;
        }
    }

    public nint Offset => CoreMethod.UMatOffset(_handle);

    public Size Size => CoreMethod.UMatSize(_handle);

    public nint Step
    {
        get
        {
            CoreMethod.UMatStep(_handle, out var output).ThrowHandleException();
            return output;
        }
    }
}

// methods
partial class UMat
{
    public Mat GetMat(int flags)
    {
        CoreMethod.UMatGetMat(_handle, flags, out var output).ThrowHandleException();
        return new Mat(output);
    }

    public UMat Row(int y)
    {
        CoreMethod.UMatRow(_handle, y, out var output).ThrowHandleException();
        return new UMat(output);
    }

    public UMat Col(int x)
    {
        CoreMethod.UMatCol(_handle, x, out var output).ThrowHandleException();
        return new UMat(output);
    }

    public UMat RowRange(int startrow, int endrow)
    {
        CoreMethod.UMatRowRange(_handle, startrow, endrow, out var output).ThrowHandleException();
        return new UMat(output);
    }

    public UMat RowRange(Range r)
    {
        CoreMethod.UMatRowRange(_handle, r, out var output).ThrowHandleException();
        return new UMat(output);
    }

    public UMat ColRange(int startcol, int endcol)
    {
        CoreMethod.UMatColRange(_handle, startcol, endcol, out var output).ThrowHandleException();
        return new UMat(output);
    }

    public UMat ColRange(Range r)
    {
        CoreMethod.UMatColRange(_handle, r, out var output).ThrowHandleException();
        return new UMat(output);
    }

    public UMat Diag(int d = 0)
    {
        CoreMethod.UMatDiag(_handle, d, out var output).ThrowHandleException();
        return new UMat(output);
    }

    public void UpdateContinuityFlag()
    {
        CoreMethod.UMatUpdateContinuityFlag(_handle).ThrowHandleException();
    }
}