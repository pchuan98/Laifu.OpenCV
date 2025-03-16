using Laifu.OpenCv.Native;

// ReSharper disable once CheckNamespace
namespace Laifu.OpenCv.Cv2;

public class Trackbar
{
    /// <summary>
    /// 宿主窗口名
    /// </summary>
    public string WinName { private get; set; }

    /// <summary>
    /// Trackbar名
    /// </summary>
    public string Name { private get; init; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="winname"></param>
    /// <param name="name"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <param name="value"></param>
    /// <param name="userdate"></param>
    public Trackbar(
        string winname,
        string name,
        int min = 0,
        int max = 100,
        int value = 0,
        nint? userdate = null)
    {
        WinName = winname;
        Name = name;

        HighGuiMethod.CreateTrackbar(
            name,
            winname,
            ref value,
            max,
            (pos => OnTrackChanged?.Invoke(pos)),
            userdate ?? IntPtr.Zero);

        Min = min;
        Max = max;
    }

    public int Value
    {
        get => HighGuiMethod.GetTrackbarPos(Name, WinName);
        set => HighGuiMethod
            .SetTrackbarPos(Name, WinName, value)
            .ThrowHandleException();
    }

    public int Min
    {
        set => HighGuiMethod
            .SetTrackbarMin(Name, WinName, value)
            .ThrowHandleException();
    }

    public int Max
    {
        set => HighGuiMethod
            .SetTrackbarMax(Name, WinName, value)
            .ThrowHandleException();
    }

    public event Action<int>? OnTrackChanged;
}