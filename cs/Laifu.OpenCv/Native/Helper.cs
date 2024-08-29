namespace Laifu.OpenCv.Native;

internal static class Helper
{
    /// <summary>
    /// Dll名称
    /// </summary>
    internal const string DLLNAME = "OpenCvSharpExtern";

    /// <summary>
    /// 
    /// </summary>
    /// <param name="status"></param>
    /// <returns></returns>
    internal static bool ThrowHandleException(this ExceptionStatus status)
        => HandleException(status);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="status"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    internal static bool HandleException(ExceptionStatus status)
    {
        if (status == ExceptionStatus.OCCURRED)
            throw new Exception(); // todo 添加内部错误捕获

        return true;
    }
}