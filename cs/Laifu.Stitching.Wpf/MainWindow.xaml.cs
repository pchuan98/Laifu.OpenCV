using Laifu.OpenCv.Cv2;
using Laifu.Stitching.Core.Finder;
using Laifu.Stitching.Core.Matcher;

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
        orb.ComputeImageFeatures(Cv2.ImRead(@"D:\.test\stitch2\3-5.jpg"), out var f2);

        var fs = new[] { f1, f2 };
        var handle = fs.ToHandle();

        var matcher = new AffineBestOf2NearestMatcher();
        matcher.Match(fs, out var infos, 0.1);

        foreach (var t in infos)
        {
            if (t.SrcIndex == -1) continue;

            Console.WriteLine(t);
            Console.WriteLine("====================================================");

        }

        Console.Read();
    }
}