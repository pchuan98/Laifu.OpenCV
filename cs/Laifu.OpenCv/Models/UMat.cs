using static Laifu.OpenCv.PInvoke.NativeMethods;

namespace Laifu.OpenCv.Models;

public class UMat
{
    private readonly UMatHandle _handle;

    public UMatHandle Handle => _handle;

    public bool IsDisposed => _handle.IsClosed || _handle.IsInvalid;

    public UMat(UMatUsageFlags flags = UMatUsageFlags.DEFAULT)
        => UMat_Create(flags, out _handle);


    public Mat GetMat(AccessFlag flag)
    {
        UMat_GetMat(_handle, flag, out var matHandle)
            .ThrowHandleException();

        return new Mat(matHandle);
    }













}