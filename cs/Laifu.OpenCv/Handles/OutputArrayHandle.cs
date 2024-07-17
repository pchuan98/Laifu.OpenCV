using System.Runtime.InteropServices;
using Laifu.OpenCv.PInvoke;

namespace Laifu.OpenCv.Handles;

public class OutputArrayHandle() : SafeHandle(IntPtr.Zero, true)
{
    protected override bool ReleaseHandle()
        => NativeMethods.HandleException(NativeMethods.Array_OutputDelete(handle));

    public override bool IsInvalid => handle == IntPtr.Zero;
}

