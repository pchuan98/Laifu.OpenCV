// ReSharper disable InconsistentNaming
using Laifu.OpenCv.Native.Core;

namespace Laifu.OpenCv.Native.HighGui;

/// <summary>
/// 
/// </summary>
internal static partial class Method
{
    /// <summary>
    /// The function namedWindow creates a window that can be used as a placeholder for images and
    /// trackbars. Created windows are referred to by their names.
    /// If a window with the same name already exists, the function does nothing.
    /// You can call cv::destroyWindow or cv::destroyAllWindows to close the window and de-allocate any associated
    /// memory usage. For a simple program, you do not really have to call these functions because all the
    /// resources and windows of the application are closed automatically by the operating system upon exit.
    /// </summary>
    /// <param name="winname">The name of the window.</param>
    /// <param name="flags">Window flags.</param>
    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_namedWindow", StringMarshallingCustomType = typeof(Utf8StringMarshaller))]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus NamedWindow(string winname, int flags = 0);

    /// <summary>
    /// Destroys a window.
    /// </summary>
    /// <param name="winname">The name of the window.</param>
    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_destroyWindow", StringMarshallingCustomType = typeof(Utf8StringMarshaller))]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus DestroyWindow(string winname);

    /// <summary>
    /// Destroys all windows.
    /// </summary>
    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_destroyAllWindows")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus DestroyAllWindows();

    /// <summary>
    /// Starts the window thread.
    /// </summary>
    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_startWindowThread")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial int StartWindowThread();

    /// <summary>
    /// Waits for a key event.
    /// </summary>
    /// <param name="delay">Delay in milliseconds.</param>
    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_waitKeyEx")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial int WaitKeyEx(int delay);

    /// <summary>
    /// Waits for a key event.
    /// </summary>
    /// <param name="delay">Delay in milliseconds.</param>
    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_waitKey")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial int WaitKey(int delay);

    /// <summary>
    /// Polls a key event.
    /// </summary>
    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_pollKey")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial int PollKey();

    /// <summary>
    /// Displays an image in a window.
    /// </summary>
    /// <param name="winname">The name of the window.</param>
    /// <param name="mat">The image to display.</param>
    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_imshow1", StringMarshallingCustomType = typeof(Utf8StringMarshaller))]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus Imshow(string winname, MatHandle mat);

    /// <summary>
    /// Displays an image in a window.
    /// </summary>
    /// <param name="winname">The name of the window.</param>
    /// <param name="umat">The UMat to display.</param>
    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_imshow2", StringMarshallingCustomType = typeof(Utf8StringMarshaller))]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus Imshow(string winname, UMatHandle umat);

    /// <summary>
    /// Resizes a window.
    /// </summary>
    /// <param name="winname">The name of the window.</param>
    /// <param name="width">The width of the window.</param>
    /// <param name="height">The height of the window.</param>
    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_resizeWindow1", StringMarshallingCustomType = typeof(Utf8StringMarshaller))]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ResizeWindow(string winname, int width, int height);

    /// <summary>
    /// Resizes a window.
    /// </summary>
    /// <param name="winname">The name of the window.</param>
    /// <param name="size">The size of the window.</param>
    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_resizeWindow2", StringMarshallingCustomType = typeof(Utf8StringMarshaller))]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ResizeWindow(string winname, Size2i size);

    /// <summary>
    /// Moves a window.
    /// </summary>
    /// <param name="winname">The name of the window.</param>
    /// <param name="x">The x-coordinate of the window's top-left corner.</param>
    /// <param name="y">The y-coordinate of the window's top-left corner.</param>
    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_moveWindow", StringMarshallingCustomType = typeof(Utf8StringMarshaller))]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus MoveWindow(string winname, int x, int y);

    /// <summary>
    /// Sets a property of a window.
    /// </summary>
    /// <param name="winname">The name of the window.</param>
    /// <param name="id">The property ID.</param>
    /// <param name="value">The property value.</param>
    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_setWindowProperty", StringMarshallingCustomType = typeof(Utf8StringMarshaller))]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus SetWindowProperty(string winname, int id, double value);

    /// <summary>
    /// Sets the title of a window.
    /// </summary>
    /// <param name="winname">The name of the window.</param>
    /// <param name="title">The title of the window.</param>
    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_setWindowTitle", StringMarshallingCustomType = typeof(Utf8StringMarshaller))]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus SetWindowTitle(string winname, string title);

    /// <summary>
    /// Gets a property of a window.
    /// </summary>
    /// <param name="winname">The name of the window.</param>
    /// <param name="id">The property ID.</param>
    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_getWindowProperty", StringMarshallingCustomType = typeof(Utf8StringMarshaller))]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial double GetWindowProperty(string winname, int id);

    /// <summary>
    /// Gets the image rectangle of a window.
    /// </summary>
    /// <param name="winname">The name of the window.</param>
    /// <param name="rect">The output rectangle.</param>
    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_getWindowImageRect", StringMarshallingCustomType = typeof(Utf8StringMarshaller))]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus GetWindowImageRect(string winname, out Rect2i rect);

    /// <summary>
    /// Sets a mouse callback for a window.
    /// </summary>
    /// <param name="winname">The name of the window.</param>
    /// <param name="onMouse">The mouse callback function.</param>
    /// <param name="userdata">User data to pass to the callback.</param>
    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_setMouseCallback", StringMarshallingCustomType = typeof(Utf8StringMarshaller))]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus SetMouseCallback(string winname, MouseCallback onMouse, IntPtr userdata);

    /// <summary>
    /// Gets the mouse wheel delta.
    /// </summary>
    /// <param name="flags">Flags for mouse wheel delta.</param>
    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_getMouseWheelDelta")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial int GetMouseWheelDelta(int flags);

    /// <summary>
    /// Selects a region of interest (ROI) from an image.
    /// </summary>
    /// <param name="windowName">The name of the window.</param>
    /// <param name="img">The input image.</param>
    /// <param name="showCrosshair">Whether to show a crosshair.</param>
    /// <param name="fromCenter">Whether to select ROI from the center.</param>
    /// <param name="printNotice">Whether to print notice.</param>
    /// <param name="roi">The selected ROI.</param>
    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_selectROI1", StringMarshallingCustomType = typeof(Utf8StringMarshaller))]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus SelectROI(string windowName, MatHandle img, [MarshalAs(UnmanagedType.I1)] bool showCrosshair, [MarshalAs(UnmanagedType.I1)] bool fromCenter, [MarshalAs(UnmanagedType.I1)] bool printNotice, out Rect2i roi);

    /// <summary>
    /// Selects a region of interest (ROI) from an image.
    /// </summary>
    /// <param name="img">The input image.</param>
    /// <param name="showCrosshair">Whether to show a crosshair.</param>
    /// <param name="fromCenter">Whether to select ROI from the center.</param>
    /// <param name="printNotice">Whether to print notice.</param>
    /// <param name="roi">The selected ROI.</param>
    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_selectROI2")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus SelectROI(MatHandle img, [MarshalAs(UnmanagedType.I1)] bool showCrosshair, [MarshalAs(UnmanagedType.I1)] bool fromCenter, [MarshalAs(UnmanagedType.I1)] bool printNotice, out Rect2i roi);

    /// <summary>
    /// Selects multiple regions of interest (ROIs) from an image.
    /// </summary>
    /// <param name="windowName">The name of the window.</param>
    /// <param name="img">The input image.</param>
    /// <param name="boundingBoxes">The output bounding boxes.</param>
    /// <param name="showCrosshair">Whether to show a crosshair.</param>
    /// <param name="fromCenter">Whether to select ROI from the center.</param>
    /// <param name="printNotice">Whether to print notice.</param>
    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_selectROIs", StringMarshallingCustomType = typeof(Utf8StringMarshaller))]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus SelectROIs(string windowName, MatHandle img, [MarshalAs(UnmanagedType.LPArray)] Rect2i[] boundingBoxes, [MarshalAs(UnmanagedType.I1)] bool showCrosshair, [MarshalAs(UnmanagedType.I1)] bool fromCenter, [MarshalAs(UnmanagedType.I1)]  bool printNotice);

    /// <summary>
    /// Creates a trackbar.
    /// </summary>
    /// <param name="trackbarname">The name of the trackbar.</param>
    /// <param name="winname">The name of the window.</param>
    /// <param name="value">The initial value of the trackbar.</param>
    /// <param name="count">The maximum value of the trackbar.</param>
    /// <param name="onChange">The callback function when the trackbar value changes.</param>
    /// <param name="userdata">User data to pass to the callback.</param>
    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_createTrackbar", StringMarshallingCustomType = typeof(Utf8StringMarshaller))]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial int CreateTrackbar(string trackbarname, string winname, ref int value, int count, TrackbarCallback onChange, IntPtr userdata);

    /// <summary>
    /// Gets the position of a trackbar.
    /// </summary>
    /// <param name="trackbarname">The name of the trackbar.</param>
    /// <param name="winname">The name of the window.</param>
    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_getTrackbarPos", StringMarshallingCustomType = typeof(Utf8StringMarshaller))]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial int GetTrackbarPos(string trackbarname, string winname);

    /// <summary>
    /// Sets the position of a trackbar.
    /// </summary>
    /// <param name="trackbarname">The name of the trackbar.</param>
    /// <param name="winname">The name of the window.</param>
    /// <param name="pos">The position to set.</param>
    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_setTrackbarPos", StringMarshallingCustomType = typeof(Utf8StringMarshaller))]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus SetTrackbarPos(string trackbarname, string winname, int pos);

    /// <summary>
    /// Sets the maximum value of a trackbar.
    /// </summary>
    /// <param name="trackbarname">The name of the trackbar.</param>
    /// <param name="winname">The name of the window.</param>
    /// <param name="maxval">The maximum value to set.</param>
    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_setTrackbarMax", StringMarshallingCustomType = typeof(Utf8StringMarshaller))]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus SetTrackbarMax(string trackbarname, string winname, int maxval);

    /// <summary>
    /// Sets the minimum value of a trackbar.
    /// </summary>
    /// <param name="trackbarname">The name of the trackbar.</param>
    /// <param name="winname">The name of the window.</param>
    /// <param name="minval">The minimum value to set.</param>
    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_setTrackbarMin", StringMarshallingCustomType = typeof(Utf8StringMarshaller))]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus SetTrackbarMin(string trackbarname, string winname, int minval);

    /// <summary>
    /// Updates a window.
    /// </summary>
    /// <param name="winname">The name of the window.</param>
    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_updateWindow", StringMarshallingCustomType = typeof(Utf8StringMarshaller))]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus UpdateWindow(string winname);
}