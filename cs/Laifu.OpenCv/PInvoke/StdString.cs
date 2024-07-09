using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Laifu.OpenCv.PInvoke;

internal class StdString(IntPtr? invalidHandleValue = null, bool ownsHandle = true)
    : SafeHandle(invalidHandleValue ?? IntPtr.Zero, ownsHandle)
{
    protected override bool ReleaseHandle()
    {
        throw new NotImplementedException();
    }

    public override bool IsInvalid => handle == IntPtr.Zero;
}