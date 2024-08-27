namespace Laifu.OpenCv.PInvoke;

internal static partial class NativeMethods
{
    [LibraryImport(LibraryName, EntryPoint = "api_xfd_create_surf")
     , UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus XFd_Create_Surf(
        int nfeatures, int nOctaveLayers, double contrastThreshold,
        double edgeThreshold, double sigma, [MarshalAs(UnmanagedType.Bool)] bool enablePreciseUpscale, out Feature2dHandle sift);
}