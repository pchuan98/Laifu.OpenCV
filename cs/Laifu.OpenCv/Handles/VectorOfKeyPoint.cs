using Laifu.OpenCv.PInvoke;

namespace Laifu.OpenCv.Handles;

public class VectorOfKeyPoint() : SafeHandle(IntPtr.Zero, true)
{
    protected override bool ReleaseHandle()
        => NativeMethods.Mat_Delete(handle).ThrowHandleException();

    public override bool IsInvalid => handle == IntPtr.Zero;
}

