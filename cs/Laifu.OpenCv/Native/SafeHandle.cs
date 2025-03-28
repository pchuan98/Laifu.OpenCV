﻿namespace Laifu.OpenCv.Native;

/// <summary>
/// The default ptr handle.
/// </summary>
public class SafePtrHandle()
    : SafeHandle(IntPtr.Zero, true)
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
public class MatExprHandle : SafePtrHandle;

/// <summary>
/// 
/// </summary>
public class UMatHandle : SafePtrHandle;

/// <summary>
/// 
/// </summary>
public class UMatDataHandle : SafePtrHandle;

/// <summary>
/// 
/// </summary>
public class InputArrayHandle : SafePtrHandle;

/// <summary>
/// 
/// </summary>
public class OutputArrayHandle : SafePtrHandle;

/// <summary>
/// 
/// </summary>
public class InputOutputArrayHandle : SafePtrHandle;

/// <summary>
/// 
/// </summary>
public class StdVectorHandle : SafePtrHandle;
public class VectorOfMatHandle : SafePtrHandle;
public class VectorOfUMatHandle : SafePtrHandle;
public class VectorOfRangeHandle : SafePtrHandle;