using Laifu.OpenCv.Native.Constants;
using Laifu.OpenCv.Native;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Laifu.OpenCv;

namespace Laifu.Stitching.Core.Matcher;


internal static partial class VectorOfMatchInfoHelper
{
    private const string Name = "OpenCvSharpExtern";

    [LibraryImport(Name, EntryPoint = "api_modules_matches_vec_size")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial int Size(StdVectorHandle vector);

    [LibraryImport(Name, EntryPoint = "api_modules_matches_vec_at")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus At(StdVectorHandle vector, int index, out SafePtrHandle matchesInfo);
}

public class VectorOfMatchInfo(StdVectorHandle handle) : DisposableObject
{
    public StdVectorHandle Handle => handle;

    public int Size => VectorOfMatchInfoHelper.Size(handle);

    public MatchesInfo At(int index)
    {
        VectorOfMatchInfoHelper.At(handle, index, out var ptr)
            .ThrowHandleException();
        return new MatchesInfo(ptr);
    }

    public MatchesInfo[] ToArray()
    {
        var size = Size;
 
        var array = new MatchesInfo[size];

        for (var i = 0; i < size; i++)
        {
            array[i] = At(i);
        }

        return array;
    }
}   