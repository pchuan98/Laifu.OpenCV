using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Laifu.OpenCv.PInvoke.NativeMethods;

namespace Laifu.OpenCv;

public static class Demo
{
    public static void Test()
    {
        ImageCodecs_Imread(@"D:\.test\test.png", 1, out var img);

        Gui_NamedWindow("test", 0);
    }
}