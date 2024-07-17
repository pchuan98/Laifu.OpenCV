using static Laifu.OpenCv.PInvoke.NativeMethods;

namespace Laifu.OpenCv.Handles;

public class UMatHandle() : SafeHandle(IntPtr.Zero, true)
{
    protected override bool ReleaseHandle()
        => UMat_Delete(handle).ThrowHandleException();

    public override bool IsInvalid => handle == IntPtr.Zero;
}