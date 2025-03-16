@echo off

call "C:\Program Files\Microsoft Visual Studio\2022\Enterprise\Common7\Tools\VsDevCmd.bat"

cd /d %~dp0
cd ..
cd build
cd release

dumpbin /exports OpenCvSharpExtern.dll
pause