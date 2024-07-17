using System.Diagnostics.CodeAnalysis;

// ReSharper disable once CheckNamespace
namespace Laifu.OpenCv.Constants;

/// <summary>
/// Flags for cv::namedWindow
/// </summary>
[Flags]
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public enum WindowFlags
{
    /// <summary>
    /// The user can resize the window (no constraint) / also use to switch a fullscreen window to a normal size.
    /// </summary>
    WINDOW_NORMAL = 0x00000000,

    /// <summary>
    /// The user cannot resize the window, the size is constrained by the image displayed.
    /// </summary>
    WINDOW_AUTOSIZE = 0x00000001,

    /// <summary>
    /// Window with OpenGL support.
    /// </summary>
    WINDOW_OPENGL = 0x00001000,

    /// <summary>
    /// Change the window to fullscreen.
    /// </summary>
    WINDOW_FULLSCREEN = 1,

    /// <summary>
    /// The image expands as much as it can (no ratio constraint).
    /// </summary>
    WINDOW_FREERATIO = 0x00000100,

    /// <summary>
    /// The ratio of the image is respected.
    /// </summary>
    WINDOW_KEEPRATIO = 0x00000000,

    /// <summary>
    /// Status bar and toolbar.
    /// </summary>
    WINDOW_GUI_EXPANDED = 0x00000000,

    /// <summary>
    /// Old fashious way.
    /// </summary>
    WINDOW_GUI_NORMAL = 0x00000010,
}