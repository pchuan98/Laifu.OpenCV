using Laifu.OpenCv.Native;

// ReSharper disable once CheckNamespace
namespace Laifu.OpenCv.Cv2;

public static class WindowExtension
{
    public static void ShowWindow(this MatHandle mat)
    {
        var name = new string(Enumerable.Range(0, 8).Select(_ => "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"[new Random().Next(52)]).ToArray());

        var window = new Window(name);
        window.Show(new Mat(mat));

        Window.WaitKey(0);
    }
}