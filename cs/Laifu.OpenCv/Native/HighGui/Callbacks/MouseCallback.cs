// ReSharper disable once CheckNamespace
namespace Laifu.OpenCv.Native.HighGui;

/// <summary>
/// Delegate to be called every time mouse event occurs in the specified window.
/// </summary>
/// <param name="event">one of MouseEventTypes</param>
/// <param name="x">x-coordinates of mouse pointer in image coordinates</param>
/// <param name="y">y-coordinates of mouse pointer in image coordinates</param>
/// <param name="flags">a combination of MouseEventFlags</param>
/// <param name="userData"></param>
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void MouseCallback(
    MouseEventTypes @event,
    int x,
    int y,
    MouseEventFlags flags,
    nint userData);