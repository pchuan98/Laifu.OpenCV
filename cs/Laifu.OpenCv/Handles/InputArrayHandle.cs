using System.Runtime.InteropServices;
using Laifu.OpenCv.PInvoke;

namespace Laifu.OpenCv.Handles;

public class InputArrayHandle() : SafeHandle(IntPtr.Zero, true)
{
    protected override bool ReleaseHandle()
        => NativeMethods.Array_InputDelete(handle).ThrowHandleException();

    public override bool IsInvalid => handle == IntPtr.Zero;
}
