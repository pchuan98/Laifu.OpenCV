using Laifu.OpenCv.Interfaces;
using static Laifu.OpenCv.PInvoke.NativeMethods;

namespace Laifu.OpenCv.Cv2;

partial class Cv2
{
	/// <summary>
	/// 
	/// </summary>
	/// <param name="src"></param>
	/// <param name="dst"></param>
	/// <param name="size"></param>
	/// <param name="fx"></param>
	/// <param name="fy"></param>
	/// <param name="interpolation"></param>
	public static void Resize(IInputArray src, OutputArray dst, CvSize size, double fx = 0, double fy = 0,
		InterpolationFlags interpolation = InterpolationFlags.INTER_LINEAR)
	{
		ArgumentNullException.ThrowIfNull(src);
		ArgumentNullException.ThrowIfNull(dst);

		if (src.IsDisposed)
			throw new ArgumentNullException(nameof(src));

		ImageProc_Resize(src.GetInputArrayHandle(), dst.Handle, size, fx, fy,
			(int)interpolation).ThrowHandleException();

		GC.KeepAlive(src);
		GC.KeepAlive(dst);
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="src"></param>
	/// <param name="size"></param>
	/// <param name="fx"></param>
	/// <param name="fy"></param>
	/// <param name="interpolation"></param>
	/// <returns></returns>
	public static Mat Resize(this IInputArray src, CvSize size, double fx = 0, double fy = 0,
		InterpolationFlags interpolation = InterpolationFlags.INTER_LINEAR)
	{
		ArgumentNullException.ThrowIfNull(src);

		var dst = new Mat();
		Resize(src, dst, size, fx, fy, interpolation);

		GC.KeepAlive(src);
        GC.KeepAlive(dst);

		return dst;
	}
}