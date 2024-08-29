// ReSharper disable once CheckNamespace
namespace Laifu.OpenCv.Native.HighGui;

/// <summary>
/// Delegate to be called every time the slider changes the position.
/// </summary>
/// <param name="pos"></param>
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void TrackbarCallback(int pos);

/// <summary>
/// 
/// </summary>
/// <param name="pos"></param>
/// <param name="userData"></param>
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void TrackbarCallbackNative(int pos, SafePtrHandle userData);