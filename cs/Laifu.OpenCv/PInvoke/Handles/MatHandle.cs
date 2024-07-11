using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Laifu.OpenCv.PInvoke.Handles;

public class MatHandle() : SafeHandle(IntPtr.Zero, true)
{
    protected override bool ReleaseHandle()
    {
        NativeMethods.Mat.Delete(handle);
        return true;
    }

    public override bool IsInvalid => handle == IntPtr.Zero;
}

