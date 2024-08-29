// ReSharper disable once CheckNamespace
namespace Laifu.OpenCv.Native.HighGui;

/// <summary>
/// Mouse Events for cv::AddMouseCallback.
/// </summary>
public enum MouseEventTypes
{
    /// <summary>
    /// Indicates that the mouse pointer has moved over the window.
    /// </summary>
    EVENT_MOUSEMOVE = 0,

    /// <summary>
    /// Indicates that the left mouse button is pressed.
    /// </summary>
    EVENT_LBUTTONDOWN = 1,

    /// <summary>
    /// Indicates that the right mouse button is pressed.
    /// </summary>
    EVENT_RBUTTONDOWN = 2,

    /// <summary>
    /// Indicates that the middle mouse button is pressed.
    /// </summary>
    EVENT_MBUTTONDOWN = 3,

    /// <summary>
    /// Indicates that the left mouse button is released.
    /// </summary>
    EVENT_LBUTTONUP = 4,

    /// <summary>
    /// Indicates that the right mouse button is released.
    /// </summary>
    EVENT_RBUTTONUP = 5,

    /// <summary>
    /// Indicates that the middle mouse button is released.
    /// </summary>
    EVENT_MBUTTONUP = 6,

    /// <summary>
    /// Indicates that the left mouse button is double clicked.
    /// </summary>
    EVENT_LBUTTONDBLCLK = 7,

    /// <summary>
    /// Indicates that the right mouse button is double clicked.
    /// </summary>
    EVENT_RBUTTONDBLCLK = 8,

    /// <summary>
    /// Indicates that the middle mouse button is double clicked.
    /// </summary>
    EVENT_MBUTTONDBLCLK = 9,

    /// <summary>
    /// Positive and negative values mean forward and backward scrolling, respectively.
    /// </summary>
    EVENT_MOUSEWHEEL = 10,

    /// <summary>
    /// Positive and negative values mean right and left scrolling, respectively.
    /// </summary>
    EVENT_MOUSEHWHEEL = 11
}