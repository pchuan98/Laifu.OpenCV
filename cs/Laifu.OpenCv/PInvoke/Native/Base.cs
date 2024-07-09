using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace Laifu.OpenCv.PInvoke;

internal static partial class NativeMethods
{
    private const string LibraryName = "OpenCvSharpExtern";


    static NativeMethods()
    {
        if (!IsWindows()) 
            throw new OpenCvException("This lib only support the windows system.");
    }

    /// <summary>
    /// Returns whether the OS is *nix or not
    /// </summary>
    /// <returns></returns>
    private static bool IsWindows() =>
        RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
}