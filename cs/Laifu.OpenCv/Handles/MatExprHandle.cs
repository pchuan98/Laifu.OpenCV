using System.Runtime.InteropServices;
using Laifu.OpenCv.PInvoke;

namespace Laifu.OpenCv.Handles;

/// <summary>
/// 
/// </summary>
public class MatExprHandle() : SafeHandle(IntPtr.Zero, true)
{
    protected override bool ReleaseHandle() 
        => NativeMethods.HandleException(NativeMethods.Expr_Delete(handle));

    public override bool IsInvalid => handle == IntPtr.Zero;
}

