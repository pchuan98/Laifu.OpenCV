// ReSharper disable once CheckNamespace
namespace Laifu.OpenCv.Native.HighGui;

/// <summary>
/// Delegate for the OpenGL draw callback function.
/// </summary>
/// <param name="userdata">Optional user-defined parameter.</param>
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void OpenGlDrawCallback(nint userdata);