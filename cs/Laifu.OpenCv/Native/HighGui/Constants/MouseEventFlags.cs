// ReSharper disable once CheckNamespace
namespace Laifu.OpenCv.Native.HighGui;

/// <summary>
/// Mouse Event Flags for cv::AddMouseCallback.
/// </summary>
[Flags]
public enum MouseEventFlags
{
    /// <summary>
    /// Indicates that the left mouse button is down.
    /// </summary>
    EVENT_FLAG_LBUTTON = 1,

    /// <summary>
    /// Indicates that the right mouse button is down.
    /// </summary>
    EVENT_FLAG_RBUTTON = 2,

    /// <summary>
    /// Indicates that the middle mouse button is down.
    /// </summary>
    EVENT_FLAG_MBUTTON = 4,

    /// <summary>
    /// Indicates that the CTRL key is pressed.
    /// </summary>
    EVENT_FLAG_CTRLKEY = 8,

    /// <summary>
    /// Indicates that the SHIFT key is pressed.
    /// </summary>
    EVENT_FLAG_SHIFTKEY = 16,

    /// <summary>
    /// Indicates that the ALT key is pressed.
    /// </summary>
    EVENT_FLAG_ALTKEY = 32
}