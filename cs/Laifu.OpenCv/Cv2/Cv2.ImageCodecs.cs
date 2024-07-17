using static Laifu.OpenCv.PInvoke.NativeMethods;

namespace Laifu.OpenCv.Cv2;

public static partial class Cv2
{
    public static Mat ImRead(string fileName, ImreadModes flags = ImreadModes.COLOR)
        => new(fileName, flags);
}