using Laifu.OpenCv.PInvoke.Handles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace Laifu.OpenCv.PInvoke;

partial class NativeMethods
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="filename"></param>
    /// <param name="flags"></param>
    /// <param name="rec"></param>
    /// <returns></returns>
    [LibraryImport(LibraryName, EntryPoint = "api_imgcodecs_imread",
        StringMarshallingCustomType = typeof(Utf8StringMarshaller))]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ImageCodecs_Imread(string filename, int flags, out MatHandle rec);
}