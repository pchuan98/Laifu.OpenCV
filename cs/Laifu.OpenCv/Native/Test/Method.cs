namespace Laifu.OpenCv.Native.Test;

/// <summary>
/// 
/// </summary>
internal static partial class Method
{
    [LibraryImport(Helper.DLLNAME, EntryPoint = "test_mat")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus TestMat(MatHandle mat);

    [LibraryImport(Helper.DLLNAME, EntryPoint = "test_true")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    internal static partial bool TestTrue();

    [LibraryImport(Helper.DLLNAME, EntryPoint = "test_false")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.I1)]
    internal static partial bool TestFlase();

    [LibraryImport(Helper.DLLNAME, EntryPoint = "test_sizet_negative")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial int TestSizetNegative();

    [LibraryImport(Helper.DLLNAME, EntryPoint = "test_sizet_positive")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial int TestSizetPositive();

    [LibraryImport(Helper.DLLNAME, EntryPoint = "test_sizet_large")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial int TestSizetLarge();

    public static void Test()
    {
        Console.WriteLine($"true        -> {TestTrue()}");
        Console.WriteLine($"false       -> {TestFlase()}");
        Console.WriteLine($"sizet(-)    -> {TestSizetNegative()}");
        Console.WriteLine($"sizet(+)    -> {TestSizetPositive()}");
        Console.WriteLine($"sizet(∞)    -> {TestSizetLarge()}");
    }
}