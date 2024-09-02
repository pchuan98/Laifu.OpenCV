using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// ReSharper disable once CheckNamespace
namespace Laifu.OpenCv.Native.Features2d;

partial class Method
{
    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_sift_create")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus SiftNew(
        int nfeatures, 
        int nOctaveLayers,
        double contrastThreshold,
        double edgeThreshold, 
        double sigma,
        out SafePtrHandle cvptr);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_sift_ptr_get")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus SiftGetPtr(SafePtrHandle cvptr, out SafePtrHandle orbptr);
}