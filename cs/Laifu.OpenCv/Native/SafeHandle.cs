namespace Laifu.OpenCv.Native;

/// <summary>
/// The default ptr handle.
/// </summary>
public class SafePtrHandle() : SafeHandle(IntPtr.Zero, true)
{
    /// <inheritdoc />
    protected override bool ReleaseHandle()
        => StdMethod.Delete(handle).ThrowHandleException();

    /// <inheritdoc />
    public override bool IsInvalid => handle == nint.Zero;
}

/// <summary>
/// 
/// </summary>
public class MatHandle : SafePtrHandle;

/// <summary>
/// 
/// </summary>
public class UMatHandle : SafePtrHandle;

/// <summary>
/// 
/// </summary>
public class VectorHandle : SafePtrHandle;