namespace Laifu.OpenCv.PInvoke;

partial class NativeMethods
{
    [LibraryImport(LibraryName, EntryPoint = "api_string_empty")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial StringHandle Empty();

    [LibraryImport(LibraryName,
        StringMarshallingCustomType = typeof(Utf8StringMarshaller),
        EntryPoint = "api_string")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial StringHandle @String(string str);

    [LibraryImport(LibraryName, EntryPoint = "api_string_delete")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial void Delete(IntPtr ptr);

    [LibraryImport(LibraryName, EntryPoint = "api_string_c_str")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial IntPtr PtrString(StringHandle obj);

    //[LibraryImport(LibraryName, EntryPoint = "api_stitching_computer_image_feature"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    //internal static partial ExceptionStatus XXXX(InputArrayHandle input, ImageFeatures* feature);
}
