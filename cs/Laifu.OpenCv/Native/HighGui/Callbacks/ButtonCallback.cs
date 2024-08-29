// ReSharper disable once CheckNamespace
namespace Laifu.OpenCv.Native.HighGui;

/// <summary>
/// Delegate for the button callback function created by cv::createButton.
/// </summary>
/// <param name="state">Current state of the button. It could be -1 for a push button, 0 or 1 for a check/radio box button.</param>
/// <param name="userdata">Optional user-defined parameter.</param>
public delegate void ButtonCallback(int state, nint userdata);