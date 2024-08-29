// ReSharper disable once CheckNamespace
namespace Laifu.OpenCv.Native.HighGui;

/// <summary>
/// Flags for cv::setWindowProperty / cv::getWindowProperty.
/// </summary>
public enum WindowPropertyFlags
{
    /// <summary>
    /// Fullscreen property (can be WINDOW_NORMAL or WINDOW_FULLSCREEN).
    /// </summary>
    WND_PROP_FULLSCREEN = 0,

    /// <summary>
    /// Autosize property (can be WINDOW_NORMAL or WINDOW_AUTOSIZE).
    /// </summary>
    WND_PROP_AUTOSIZE = 1,

    /// <summary>
    /// Window's aspect ratio (can be set to WINDOW_FREERATIO or WINDOW_KEEPRATIO).
    /// </summary>
    WND_PROP_ASPECT_RATIO = 2,

    /// <summary>
    /// OpenGL support.
    /// </summary>
    WND_PROP_OPENGL = 3,

    /// <summary>
    /// Checks whether the window exists and is visible.
    /// </summary>
    WND_PROP_VISIBLE = 4,

    /// <summary>
    /// Property to toggle normal window being topmost or not.
    /// </summary>
    WND_PROP_TOPMOST = 5,

    /// <summary>
    /// Enable or disable V-SYNC (in OpenGL mode).
    /// </summary>
    WND_PROP_VSYNC = 6
}
