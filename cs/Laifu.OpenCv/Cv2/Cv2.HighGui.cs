using Laifu.OpenCv.Interfaces;
using static Laifu.OpenCv.PInvoke.NativeMethods;

namespace Laifu.OpenCv.Cv2;

public static partial class Cv2
{
    public static void ImShow(string winname, Mat mat)
    {
        ArgumentNullException.ThrowIfNull(mat);

        Gui_ImShow(winname, mat.Handle);
    }

    public static void ImShow(this Mat mat, string winname) => ImShow(winname, mat);

    public static int WaitKey(int delay = 0)
        => Gui_WaitKey(delay, out var ret).ThrowHandleException() ? ret : 0;
}