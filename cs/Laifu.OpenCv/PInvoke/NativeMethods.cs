namespace Laifu.OpenCv.PInvoke;

internal static partial class NativeMethods
{
    private const string LibraryName = "OpenCvSharpExtern";

    static NativeMethods()
    {
        if (!IsWindows())
            throw new OpenCvException("This lib only support the windows system.");
    }

    /// <summary>
    /// Returns whether the OS is *nix or not
    /// </summary>
    /// <returns></returns>
    private static bool IsWindows() =>
        RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

    internal static bool HandleException(ExceptionStatus status)
    {
        if (status == ExceptionStatus.OCCURRED)
            throw new Exception(); // todo 添加内部错误捕获

        return true;
    }

    public static bool ThrowHandleException(this ExceptionStatus status)
        => HandleException(status);
}