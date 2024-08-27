namespace Laifu.OpenCv.PInvoke;

internal static partial class NativeMethods
{
    [LibraryImport(LibraryName, EntryPoint = "api_fd_create_orb")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus Fd_Create_Orb(
        int nfeatures, float scaleFactor, int nlevels,
        int edgeThreshold, int firstLevel, int wtaK,
        int scoreType, int patchSize, int fastThreshold, out Feature2dHandle orb);

    [LibraryImport(LibraryName, EntryPoint = "api_fd_create_akaze")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus Fd_Create_Akaze(
        int descriptorType, int descriptorSize, int descriptorChannels,
        float threshold, int nOctaves, int nOctaveLayers, int diffusivity,
        int maxPoints, out Feature2dHandle akaze);

    [LibraryImport(LibraryName, EntryPoint = "api_fd_create_sift")
     , UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus Fd_Create_Sift(
        int nfeatures, int nOctaveLayers, double contrastThreshold,
        double edgeThreshold, double sigma, [MarshalAs(UnmanagedType.Bool)] bool enablePreciseUpscale, out Feature2dHandle sift);
}