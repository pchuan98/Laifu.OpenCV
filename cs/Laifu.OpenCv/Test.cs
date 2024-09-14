using Laifu.OpenCv.Constants;
using Laifu.OpenCv.Cv2;
using Laifu.OpenCv.Native.Core;
using Laifu.OpenCv.Native.HighGui;
using Laifu.OpenCv.Native.ImageCodecs;
using Laifu.OpenCv.Native.Stitching;
using CvRange = Laifu.OpenCv.Native.Core.Range;

namespace Laifu.OpenCv;

public static class Test
{
    public static void ValueTest()
    {
        TestMethod.Test();
    }

    public static void TestMatCreate()
    {
        CoreMethod.MatNew(out var m1);
        TestMethod.TestMat(m1);
        Console.WriteLine(new String('-', 50));

        CoreMethod.MatNew(980, 430, MatType.CV_8UC3, new Scalar(255, 20, 0, 255), out var m2);
        TestMethod.TestMat(m2);
        m2.ShowWindow();
        Console.WriteLine(new String('-', 50));

        CoreMethod.MatNew(new Size2i(980, 430), MatType.CV_8UC3, new Scalar(0, 20, 0, 0), out var m3);
        TestMethod.TestMat(m3);
        m3.ShowWindow();
        Console.WriteLine(new String('-', 50));

        CoreMethod.MatNew(111, 333, MatType.CV_8UC3, new Scalar(255, 1, 1, 55), out var m4);
        TestMethod.TestMat(m4);
        m4.ShowWindow();
        Console.WriteLine(new String('-', 50));

        CoreMethod.MatNew(new Size2i(443, 245), MatType.CV_8UC3, new Scalar(255, 0, 0, 255), out var m5);
        TestMethod.TestMat(m5);
        m5.ShowWindow();
        Console.WriteLine(new String('-', 50));

        CoreMethod.MatNew(2, [100, 200], MatType.CV_8UC3, out var m6);
        TestMethod.TestMat(m6);
        m6.ShowWindow();
        Console.WriteLine(new String('-', 50));

        CoreMethod.MatNew(2, [100, 200], MatType.CV_8UC3, new Scalar(255, 0, 0, 0), out var m7);
        TestMethod.TestMat(m7);
        m7.ShowWindow();
        Console.WriteLine(new String('-', 50));

        CoreMethod.MatNew(m2, out var m8);
        TestMethod.TestMat(m8);
        m8.ShowWindow();
        Console.WriteLine(new String('-', 50));
    }

    public static void TestMatProp()
    {
        CoreMethod.MatNew(980, 430, MatType.CV_8UC3, new Scalar(255, 20, 0, 255), out var img);

        var flags = CoreMethod.MatFlags(img);
        var dims = CoreMethod.MatDims(img);
        var rows = CoreMethod.MatRows(img);
        var cols = CoreMethod.MatCols(img);
        var ptr = CoreMethod.MatData(img);
        var size = CoreMethod.MatSize(img);
        var sizeat1 = CoreMethod.MatSizeAt(img, 1);
        var step = CoreMethod.MatStep(img);
        var stepat1 = CoreMethod.MatStepAt(img, 0);

        Console.WriteLine($"flags: \t{flags}\n" +
                          $"dims: \t{dims}\n" +
                          $"rows: \t{rows}\n" +
                          $"cols: \t{cols}\n" +
                          $"ptr: \t{ptr}\n" +
                          $"size: \t{size}\n" +
                          $"sizeat1: \t{sizeat1}\n" +
                          $"step: \t\t{step}\n" +
                          $"stepat1: \t{stepat1}\n");

        CoreMethod.MatNew(rows, cols, MatType.CV_8UC3, ptr, 0, out var mats);
    }

    public static void TestMatMethod()
    {
        CoreMethod.MatNew(980, 430, MatType.CV_8UC3, new Scalar(255, 20, 0, 255), out var mat);
        Console.WriteLine($"{CoreMethod.MatDims(mat)}");

        CoreMethod.MatRow(mat, 0, out var dst);
        Console.WriteLine($"{CoreMethod.MatRows(dst)} {CoreMethod.MatCols(dst)}");

        CoreMethod.MatCol(mat, 0, out dst);
        Console.WriteLine($"{CoreMethod.MatRows(dst)} {CoreMethod.MatCols(dst)}");

        CoreMethod.MatRowRange(mat, 0, 20, out dst);
        Console.WriteLine($"{CoreMethod.MatRows(dst)} {CoreMethod.MatCols(dst)}");

        CoreMethod.MatRowRange(mat, new CvRange(10, 40), out dst);
        Console.WriteLine($"{CoreMethod.MatRows(dst)} {CoreMethod.MatCols(dst)}");

        CoreMethod.MatColRange(mat, 0, 20, out dst);
        Console.WriteLine($"{CoreMethod.MatRows(dst)} {CoreMethod.MatCols(dst)}");

        CoreMethod.MatColRange(mat, new CvRange(10, 40), out dst);
        Console.WriteLine($"{CoreMethod.MatRows(dst)} {CoreMethod.MatCols(dst)}");

        CoreMethod.MatDiag(mat, 1, out dst);
        Console.WriteLine($"{CoreMethod.MatRows(dst)} {CoreMethod.MatCols(dst)}");

        CoreMethod.MatClone(mat, out dst);
        Console.WriteLine($"{CoreMethod.MatRows(dst)} {CoreMethod.MatCols(dst)}");

        CoreMethod.MatReshape(mat, 0, 0, out dst);
        Console.WriteLine($"{CoreMethod.MatRows(dst)} {CoreMethod.MatCols(dst)}");
        Console.WriteLine($"{CoreMethod.MatDims(dst)}");

        // prop but method
        Console.WriteLine(new string('-', 50));
        Console.WriteLine(CoreMethod.MatIsContinuous(mat));
        Console.WriteLine(CoreMethod.MatIsSubmatrix(mat));
        Console.WriteLine(CoreMethod.MatElemSize(mat));
        Console.WriteLine(CoreMethod.MatElemSize1(mat));
        Console.WriteLine(CoreMethod.MatType(mat));
        Console.WriteLine(CoreMethod.MatDepth(mat));
        Console.WriteLine(CoreMethod.MatChannels(mat));
        Console.WriteLine(CoreMethod.MatEmpty(mat));

        CoreMethod.MatNew(out var matnew);
        Console.WriteLine(CoreMethod.MatEmpty(matnew));
        Console.WriteLine(CoreMethod.MatTotal(mat));

    }

    public static void TestGui()
    {
        ImageCodecsMethod.Imread(@"D:\.test\test.png", (int)ImreadModes.IMREAD_UNCHANGED, out var img);

        var window = new Window(flags: WindowFlags.WINDOW_KEEPRATIO | WindowFlags.WINDOW_GUI_EXPANDED);

        window.Resize(new Size2i(500, 500));
        window.Move(0, 0);
        window.Show(new Mat(img));

        Console.WriteLine(window.ThreadId);

        foreach (var name in Enum.GetNames<WindowPropertyFlags>())
        {
            try
            {
                Console.WriteLine($"{name} -> {window.GetProperty(Enum.Parse<WindowPropertyFlags>(name))}");
            }
            catch (Exception e) { }
        }

        window.SetProperty(WindowPropertyFlags.WND_PROP_TOPMOST, 1);
        window.AddMouseCallback(((@event, x, y, flags, _) =>
        {
            Console.WriteLine($"{@event} - {flags} - {x},{y}");
        }));


        var bar = window.Trackbars[window.AddTrackbar()];
        bar.OnTrackChanged += Console.WriteLine;

        Window.WaitKey();
    }

    public static void Temp()
    {
        ImageCodecsMethod.Imread(@"D:\.test\test.png", -1, out var img);

        //var orb = Native.Stitching.Details.Method.ORB();

        Native.Features2d.Method.OrbNew(
            500,
            1.2f,
            8,
            31,
            0,
            2,
            0,
            31,
            20,
            out var orb_cvptr);
        Native.Features2d.Method.OrbGetPtr(orb_cvptr, out var orbptr);

        Native.Features2d.Method.SiftNew(
            0, 3, 0.04, 10, 1.6,
            out var sift_cvptr);
        Native.Features2d.Method.SiftGetPtr(sift_cvptr, out var siftptr);


        var feature = new ImageFeature(Native.Stitching.Details.Method.ComputeImageFeatures(siftptr, img));

        Console.WriteLine(feature.Index);
        Console.WriteLine(feature.Size);
        Console.WriteLine(feature.Points.Size);

        var array = feature.Points.ToArray();
        Console.WriteLine(array[0]);
        Console.WriteLine(array[^1]);
    }
}