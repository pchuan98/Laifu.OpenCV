using Laifu.OpenCv.Cv2;
using Laifu.OpenCv.Native.HighGui;
using Laifu.OpenCv.Native.ImageCodecs;
using Laifu.Stitching.Core.Estimator;
using Laifu.Stitching.Core.Finder;
using Laifu.Stitching.Core.Matcher;
using Laifu.Stitching.Core.Warper;

namespace Laifu.Stitching.Wpf;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow
{
    public MainWindow()
    {
        InitializeComponent();

        var mat = Cv2.ImRead(@"D:\.test\test.png");

        var orb = new Orb();
        orb.ComputeImageFeatures(Cv2.ImRead(@"D:\.test\stitch2\3-4.jpg"), out var f1);
        orb.ComputeImageFeatures(Cv2.ImRead(@"D:\.test\stitch2\3-4.jpg"), out var f2);

        var features = new[] { f1, f2 };

        new AffineBestOf2NearestMatcher().Match(features, out var matches, 0.1);

        var camera = new AffineBasedEstimator();
        Console.WriteLine(camera.Estimate(features, matches, out var cameras));

        Console.WriteLine(features.Length);
        Console.WriteLine(matches.Length);

        EstimatorExtension.LeaveBiggestComponent(ref features, ref matches, out var indices, 1);

        Console.WriteLine(features.Length);
        Console.WriteLine(matches.Length);

        Console.WriteLine(new NoBundleAdjuster().Estimate(ref features, ref matches, ref cameras));

        var warper = RotationWarper.Generator(WarpType.Plane);
        warper.K = MatGenerator.K(1, 0, 0, 1);
        warper.R = MatGenerator.R();

        var src = Cv2.ImRead(@"D:\.test\stitch2\3-4.jpg", ImreadModes.IMREAD_UNCHANGED);
        var dst = new Mat();

        Console.WriteLine(warper.Warp(src, InterpolationFlags.INTER_LINEAR, BorderTypes.BORDER_REFLECT, dst));

        var srcw = new Window("src", flags: WindowFlags.WINDOW_NORMAL);
        srcw.ShowLimitWidth(src);

        var dstw = new Window("dst", flags: WindowFlags.WINDOW_NORMAL);
        dstw.ShowLimitWidth(dst);

        Console.WriteLine(src.Size);
        Console.WriteLine(dst.Size);

        Window.WaitKey(0);

        App.Current.Shutdown();
    }
}