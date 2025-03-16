// ReSharper disable InconsistentNaming

using Laifu.OpenCv.Cv2;
using Laifu.OpenCv.Native;

namespace Laifu.Stitching.Core.Estimator;

public static class CameraParamsHelper
{
    public static StdVectorHandle ToHandle(this IEnumerable<CameraParams> @params)
    {
        var array = @params
            .ToArray()
            .Select(item => item.Handle)
            .Select(handle => handle.DangerousGetHandle())
            .ToArray();

        EstimatorHelper.api_modules_camera_params_array2vector(array, array.Length, out var vector)
            .ThrowHandleException();

        return vector;
    }

    public static CameraParams[] ToCameraParams(this StdVectorHandle ptr)
    {
        var vector = new VectorOfCameraParams(ptr);
        return vector.ToArray();
    }
}

public class CameraParams(SafePtrHandle handle) : IDisposable
{
    public SafePtrHandle Handle { get; } = handle;

    public static CameraParams Create()
    {
        EstimatorHelper.api_modules_camera_params_create(out var cameraParams).ThrowHandleException();
        return new CameraParams(cameraParams);
    }

    public double Focal => EstimatorHelper.api_modules_camera_params_focal(Handle);

    public double Aspect => EstimatorHelper.api_modules_camera_params_aspect(Handle);

    public double PPX => EstimatorHelper.api_modules_camera_params_ppx(Handle);

    public double PPY => EstimatorHelper.api_modules_camera_params_ppy(Handle);

    public Mat R
    {
        get
        {
            EstimatorHelper.api_modules_camera_params_R(Handle, out var matHandle).ThrowHandleException();
            return new Mat(matHandle);
        }
    }

    public Mat T
    {
        get
        {
            EstimatorHelper.api_modules_camera_params_t(Handle, out var matHandle).ThrowHandleException();
            return new Mat(matHandle);
        }
    }

    public void Dispose()
    {
        Handle.Dispose();
    }

    public override string ToString()
    {
        var focal = Focal;
        var aspect = Aspect;

        var ppx = PPX;
        var ppy = PPY;

        var r = R;
        var t = T;

        return $"focal      {focal}\n" +
               $"aspect     {aspect}\n" +
               $"ppx        {ppx}\n" +
               $"ppy        {ppy}\n";
    }
}