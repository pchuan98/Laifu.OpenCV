namespace Laifu.OpenCv.PInvoke;

partial class NativeMethods
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="filename"></param>
    /// <param name="flags"></param>
    /// <param name="ret"></param>
    /// <returns></returns>
    [LibraryImport(LibraryName, EntryPoint = "api_imgcodecs_imread",
        StringMarshallingCustomType = typeof(Utf8StringMarshaller))]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ImageCodecs_Imread(string filename, int flags, out MatHandle ret);
}