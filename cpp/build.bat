@echo off

cd /d %~dp0
cd ..

call "C:\Program Files\Microsoft Visual Studio\2022\Enterprise\Common7\Tools\VsDevCmd.bat"

cmake ^
    -DCMAKE_EXPORT_COMPILE_COMMANDS:BOOL=TRUE ^
    --no-warn-unused-cli ^
    -S ./cpp ^
    -B ./build ^
    -G "Visual Studio 17 2022" ^
    -T host=x64 ^
    -A x64

cmake ^
    --build ./build ^
    --config Release ^
    --target ALL_BUILD ^
    -j 34 --
