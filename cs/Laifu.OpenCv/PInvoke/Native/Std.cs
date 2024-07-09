using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace Laifu.OpenCv.PInvoke;

partial class NativeMethods
{
    [LibraryImport(LibraryName, EntryPoint = "api_string_empty")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial StdString Empty();

    [LibraryImport(LibraryName,
        StringMarshallingCustomType = typeof(Utf8StringMarshaller),
        EntryPoint = "api_string")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial StdString @String(string str);

    [LibraryImport(LibraryName, EntryPoint = "api_string_delete")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial void Delete(IntPtr ptr);

    [LibraryImport(LibraryName, EntryPoint = "api_string_c_str")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial IntPtr PtrString(StdString obj);
}
