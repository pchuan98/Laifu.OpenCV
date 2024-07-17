#ifdef _DEBUG
#pragma comment(lib, "opencv_world4100d.lib")
#pragma comment(lib, "opencv_img_hash4100d.lib")
#else
#pragma comment(lib, "opencv_world4100.lib")
#pragma comment(lib, "opencv_img_hash4100.lib")
// Release 模式下的代码
#endif


#include "array.hpp"
#include "core.hpp"
#include "gui.hpp"
#include "imgcodecs.hpp"
#include "imgproc.hpp"
#include "mat_expr.hpp"
#include "mat.hpp"
#include "umat.hpp"