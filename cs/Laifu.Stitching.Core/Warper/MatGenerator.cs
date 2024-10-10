using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Laifu.OpenCv.Cv2;

namespace Laifu.Stitching.Core.Warper;

public static class MatGenerator
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="focal"></param>
    /// <param name="ppx"></param>
    /// <param name="ppy"></param>
    /// <param name="aspect"></param>
    /// <returns></returns>
    public static Mat K(double focal, double ppx, double ppy, double aspect)
    {
        //k(0, 0) = focal; k(0, 2) = ppx;
        //k(1, 1) = focal * aspect; k(1, 2) = ppy;

        WarperHelper.api_modules_warper_32Mat(
            (float)focal, 0, (float)ppx,
            0, (float)(focal * aspect), (float)ppy,
            0, 0, 1,
            out var handle).ThrowHandleException();

        return new Mat(handle);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="theta">顺时针旋转角度 单位<code>°</code></param>
    /// <param name="s">scale</param>
    /// <param name="tx">平移x</param>
    /// <param name="ty">平移y</param>
    /// <param name="hx">剪切参数x</param>
    /// <param name="hy">剪切参数y</param>
    /// <returns></returns>
    public static Mat R(
        double theta = 0,
        double s = 1,
        double tx = 0,
        double ty = 0,
        double hx = 0,
        double hy = 0)
    {
        var angle = -theta / 180.0 * Math.PI;
        var cos = Math.Cos(angle) * s;
        var sin = Math.Sin(angle) * s;

        return Mat32(
            cos, hx - sin, tx,
            hy + sin, cos, ty,
            0, 0, 1);
    }

    public static Mat Eye() => Mat32(
        1, 0, 0,
        0, 1, 0,
        0, 0, 1);

    public static Mat Mat32(
        double a11, double a12, double a13,
        double a21, double a22, double a23,
        double a31, double a32, double a33)
    {
        WarperHelper.api_modules_warper_32Mat(
            (float)a11, (float)a12, (float)a13,
            (float)a21, (float)a22, (float)a23,
            (float)a31, (float)a32, (float)a33,
            out var handle).ThrowHandleException();

        return new Mat(handle);
    }
}