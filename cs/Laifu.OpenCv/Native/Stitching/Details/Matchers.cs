namespace Laifu.OpenCv.Native.Stitching.Details;

/// <summary>
/// 
/// </summary>
partial class Method
{
    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_st_detail_computeImageFeatures")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial CvImageFeatures ComputeImageFeatures(SafePtrHandle finder, MatHandle image);
}