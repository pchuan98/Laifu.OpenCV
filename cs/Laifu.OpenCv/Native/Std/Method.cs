namespace Laifu.OpenCv.Native.Std;

/// <summary>
/// 
/// </summary>
internal static partial class Method
{
    [LibraryImport(Helper.DLLNAME, EntryPoint = "std_delete")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus Delete(nint obj);
}