using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace Laifu.OpenCv.Native.Features2d;

partial class Method
{
    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_orb_create")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus OrbNew(
        int nFeatures,
        float scaleFactor,
        int nlevels,
        int edgeThreshold,
        int firstLevel,
        int wtaK,
        int scoreType,
        int patchSize,
        int fastThreshold,
        out SafePtrHandle cvptr);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "api_orb_ptr_get")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus OrbGetPtr(SafePtrHandle cvptr, out SafePtrHandle orbptr);
}