using System.Runtime.InteropServices;
using Laifu.OpenCv.PInvoke;

namespace Laifu.OpenCv.Handles;

internal class InputOutputArrayHandle() : SafeHandle(IntPtr.Zero, true)
{
    protected override bool ReleaseHandle()
        => NativeMethods.HandleException(NativeMethods.Array_InputOutputDelete(handle));

    public override bool IsInvalid => handle == IntPtr.Zero;
}

