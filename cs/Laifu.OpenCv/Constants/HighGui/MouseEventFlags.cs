// ReSharper disable once CheckNamespace
namespace Laifu.OpenCv.Constants;

/// <summary>
/// Mouse Event Flags.
/// </summary>
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
    /// Indicates that CTRL Key is pressed.
    /// </summary>
    EVENT_FLAG_CTRLKEY = 8,

    /// <summary>
    /// Indicates that SHIFT Key is pressed.
    /// </summary>
    EVENT_FLAG_SHIFTKEY = 16,

    /// <summary>
    /// Indicates that ALT Key is pressed.
    /// </summary>
    EVENT_FLAG_ALTKEY = 32
}