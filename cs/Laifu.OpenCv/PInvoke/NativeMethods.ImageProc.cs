namespace Laifu.OpenCv.PInvoke;

partial class NativeMethods
{
    [LibraryImport(LibraryName, EntryPoint = "api_imgproc_resize")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ImageProc_Resize(
        InputArrayHandle input,
        OutputArrayHandle output,
        CvSize size,
        double fx,
        double fy,
        int interpolation);
}