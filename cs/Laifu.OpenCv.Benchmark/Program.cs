using System.Diagnostics;
using Laifu.OpenCv.Cv2;
using Laifu.OpenCv.Constants;
using Laifu.OpenCv.Models;

//var cols = 40;
//var rows = 40;

//var root = @"D:\.test\test_human\0709\src";

//var paths = Enumerable.Range(0, rows * cols)
//    .Select(index =>
//    {
//        var row = index / cols;
//        var col = index % cols;

//        return Path.Join(root, $"{row + 1}_{col + 1}.tif");
//    }).ToList();


//var mat = Cv2.ImRead(paths[0]);
//mat.ImShow("test");

//new MatExpr(mat).Crop(new CvRect(0, 0, 400, 400)).ToMat().ImShow("test2");

//Cv2.WaitKey();


Laifu.OpenCv.Test.Run();