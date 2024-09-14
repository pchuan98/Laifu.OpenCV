using Laifu.OpenCv.Native;
using Laifu.OpenCv.Native.Core;
using Laifu.OpenCv.Native.HighGui;

// ReSharper disable once CheckNamespace
namespace Laifu.OpenCv.Cv2;

/// <summary>
/// todo 等Mat写完之后再完善显示效果
/// </summary>
public class Window
{
    public string WinName { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public List<Trackbar> Trackbars { get; } = [];

    public string Title
    {
        init => HighGuiMethod
            .SetWindowTitle(WinName, value)
            .ThrowHandleException();
    }

    public Rect2i Rect
    {
        get
        {
            HighGuiMethod.GetWindowImageRect(WinName, out var rect)
                .ThrowHandleException();
            return rect;
        }
    }

    /// <summary>
    /// <inheritdoc cref="MouseEventFlags.EVENT_FLAG_LBUTTON"/>
    /// </summary>
    public int LButtonDelta => HighGuiMethod.GetMouseWheelDelta((int)MouseEventFlags.EVENT_FLAG_LBUTTON);

    /// <summary>
    /// <inheritdoc cref="MouseEventFlags.EVENT_FLAG_RBUTTON"/>
    /// </summary>
    public int RButtonDelta => HighGuiMethod.GetMouseWheelDelta((int)MouseEventFlags.EVENT_FLAG_RBUTTON);

    /// <summary>
    /// <inheritdoc cref="MouseEventFlags.EVENT_FLAG_MBUTTON"/>
    /// </summary>
    public int MButtonDelta => HighGuiMethod.GetMouseWheelDelta((int)MouseEventFlags.EVENT_FLAG_MBUTTON);

    /// <summary>
    /// <inheritdoc cref="MouseEventFlags.EVENT_FLAG_CTRLKEY"/>
    /// </summary>
    public int CtrlDelta => HighGuiMethod.GetMouseWheelDelta((int)MouseEventFlags.EVENT_FLAG_CTRLKEY);

    /// <summary>
    /// <inheritdoc cref="MouseEventFlags.EVENT_FLAG_SHIFTKEY"/>
    /// </summary>
    public int ShiftDelta => HighGuiMethod.GetMouseWheelDelta((int)MouseEventFlags.EVENT_FLAG_SHIFTKEY);

    /// <summary>
    /// <inheritdoc cref="MouseEventFlags.EVENT_FLAG_ALTKEY"/>
    /// </summary>
    public int AltDelta => HighGuiMethod.GetMouseWheelDelta((int)MouseEventFlags.EVENT_FLAG_ALTKEY);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="flags"></param>
    public Window(string name = "window", WindowFlags flags = WindowFlags.WINDOW_AUTOSIZE)
    {
        WinName = name;

        HighGuiMethod.NamedWindow(name, (int)flags);
    }

    /// <summary>
    /// 
    /// </summary>
    public void Destroy()
        => HighGuiMethod.DestroyWindow(WinName).ThrowHandleException();

    /// <summary>
    /// 
    /// </summary>
    public static void DestroyAll()
        => HighGuiMethod.DestroyAllWindows().ThrowHandleException();

    /// <summary>
    /// 
    /// </summary>
    public int ThreadId => HighGuiMethod.StartWindowThread();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="delay"></param>
    /// <returns></returns>
    public static int WaitKeyEx(int delay = 0)
        => HighGuiMethod.WaitKeyEx(delay);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="delay"></param>
    /// <returns></returns>
    public static int WaitKey(int delay = 0)
        => HighGuiMethod.WaitKey(delay);

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public int Pollkey()
        => HighGuiMethod.PollKey();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="mat"></param>
    /// <returns></returns>
    public void Show(Mat mat)
        => HighGuiMethod.Imshow(WinName, mat.Handle).ThrowHandleException();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="mat"></param>
    /// <param name="width"></param>
    public void ShowLimitWidth(Mat mat, int width = 1000)
    {
        var size = mat.Size;

        var scale = 1.0 * width / size.Width;

        Resize(new Size2i((int)(size.Width * scale), (int)(size.Height * scale)));
        Show(mat);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="umat"></param>
    /// <returns></returns>
    public void Show(UMatHandle umat)
        => HighGuiMethod.Imshow(WinName, umat).ThrowHandleException();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="width"></param>
    /// <param name="height"></param>
    public void Resize(int width, int height)
        => HighGuiMethod.ResizeWindow(WinName, width, height).ThrowHandleException();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="size"></param>
    public void Resize(Size2i size)
        => HighGuiMethod.ResizeWindow(WinName, size).ThrowHandleException();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    public void Move(int x, int y)
        => HighGuiMethod.MoveWindow(WinName, x, y).ThrowHandleException();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="propId"></param>
    /// <returns></returns>
    public double GetProperty(WindowPropertyFlags propId)
        => HighGuiMethod.GetWindowProperty(WinName, (int)propId);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="propId"></param>
    /// <param name="propValue"></param>
    public void SetProperty(WindowPropertyFlags propId, double propValue)
        => HighGuiMethod.SetWindowProperty(WinName, (int)propId, propValue).ThrowHandleException();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="mouse"></param>
    /// <param name="userdata"></param>
    public void AddMouseCallback(MouseCallback mouse, IntPtr? userdata = null)
    {
        var ud = userdata ?? IntPtr.Zero;

        HighGuiMethod
            .SetMouseCallback(WinName, mouse, ud)
            .ThrowHandleException();
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <param name="value"></param>
    /// <param name="userdate"></param>
    public int AddTrackbar(
        string name = "track",
        int min = 0,
        int max = 100,
        int value = 0,
        nint? userdate = null)
    {
        Trackbars.Add(new Trackbar(WinName, name, min, max, value, userdate));
        return Trackbars.Count - 1;
    }

    public void Update()
        => HighGuiMethod.UpdateWindow(WinName).ThrowHandleException();
}

