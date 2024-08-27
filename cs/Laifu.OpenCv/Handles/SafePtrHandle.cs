using Laifu.OpenCv.PInvoke;

namespace Laifu.OpenCv.Handles;

/// <summary>
/// The default ptr handle.
/// </summary>
public class SafePtrHandle() : SafeHandle(IntPtr.Zero, true)
{
    /// <inheritdoc />
    protected override bool ReleaseHandle()
        => NativeMethods.Std_Delete(handle).ThrowHandleException();

    /// <inheritdoc />
    public override bool IsInvalid => handle == nint.Zero;
}