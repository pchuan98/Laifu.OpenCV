using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace Laifu.OpenCv.PInvoke;

internal static partial class NativeMethods
{
    [LibraryImport(LibraryName, EntryPoint = "api_string_empty")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial StdString Empty();

    [LibraryImport(LibraryName, EntryPoint = "api_string")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial StdString @String();



        
}