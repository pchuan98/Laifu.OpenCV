using System.Net.Mime;
using Laifu.OpenCv.Cv2;
using Laifu.OpenCv.Native.Core;
using Laifu.OpenCv.Native.HighGui;
using Laifu.OpenCv.Native.ImageCodecs;

namespace Laifu.OpenCv;

public static class Test
{
    public static void TestGui()
    {
        ImageCodecsMethod.Imread(@"D:\.test\test.png", (int)ImreadModes.IMREAD_UNCHANGED, out var img);

        var window = new Window(flags: WindowFlags.WINDOW_KEEPRATIO | WindowFlags.WINDOW_GUI_EXPANDED);

        window.Resize(new Size2i(500, 500));
        window.Move(0, 0);
        window.Show(img);

        Console.WriteLine(window.ThreadId);

        foreach (var name in Enum.GetNames<WindowPropertyFlags>())
        {
            try
            {
                Console.WriteLine($"{name} -> {window.GetProperty(Enum.Parse<WindowPropertyFlags>(name))}");
            }
            catch (Exception e) { }
        }

        window.SetProperty(WindowPropertyFlags.WND_PROP_TOPMOST, 1);
        window.AddMouseCallback(((@event, x, y, flags, _) =>
        {
            Console.WriteLine($"{@event} - {flags} - {x},{y}");
        }));


        var bar = window.Trackbars[window.AddTrackbar()];
        bar.OnTrackChanged += Console.WriteLine;

        Window.WaitKey();
    }
}