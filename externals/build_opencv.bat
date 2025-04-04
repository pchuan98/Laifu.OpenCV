@echo off

setlocal enabledelayedexpansion
chcp 65001

cd /d %~dp0

@REM add the proxy
set http_proxy=http://127.0.0.1:1080
set https_proxy=http://127.0.0.1:1080

@REM set the env variable
set opencvPath="%~dp0opencv"
set modulePath="%~dp0opencv_contrib\modules"
set build="./build"

@REM x64 or Win32
set msbuildPlatform=x64

@REM Set default Visual Studio path
set "vsCount=5"
set "vsPath[1]=C:\Program Files\Microsoft Visual Studio\2022\Preview\Common7\Tools\VsDevCmd.bat"
set "vsPath[2]=C:\Program Files\Microsoft Visual Studio\2022\Enterprise\Common7\Tools\VsDevCmd.bat"
set "vsPath[3]=C:\Program Files\Microsoft Visual Studio\2022\Professional\Common7\Tools\VsDevCmd.bat"
set "vsPath[4]=C:\Program Files\Microsoft Visual Studio\2022\Community\Common7\Tools\VsDevCmd.bat"
set "vsPath[5]=C:\Program Files\Microsoft Visual Studio\2022\Preview\Common7\Tools\VsDevCmd.bat"

set "vsName[1]=Visual Studio 2022 Preview"
set "vsName[2]=Visual Studio 2022 Enterprise"
set "vsName[3]=Visual Studio 2022 Professional"
set "vsName[4]=Visual Studio 2022 Community"
set "vsName[5]=User Config"

@REM Try to find Visual Studio 2022
set "vsFound=0"
for /L %%i in (1,1,%vsCount%) do (
    echo Checking: !vsName[%%i]!
    if exist "!vsPath[%%i]!" (
        echo Found: !vsName[%%i]!
        call "!vsPath[%%i]!"
        set "vsFound=1"
        goto vs_found
    )
)

:vs_not_found
if %vsFound% EQU 0 (
    echo ## Error: Not found Visual Studio 2022.Please ensure that Visual Studio 2022 is installed.
    echo ## If you have installed Visual Studio 2022, please modify the script to set the correct path.
    pause
    exit /b 1
)

:vs_found
cmake ^
    -A %msbuildPlatform% ^
    -B %build% ^
    -D BUILD_SHARED_LIBS=OFF ^
    -D ENABLE_CXX11=1 ^
    -D CMAKE_BUILD_TYPE=Release ^
    -D CMAKE_INSTALL_PREFIX=install ^
    -D INSTALL_C_EXAMPLES=OFF ^
    -D INSTALL_PYTHON_EXAMPLES=OFF ^
    -D BUILD_DOCS=OFF ^
    -D BUILD_WITH_DEBUG_INFO=OFF ^
    -D BUILD_EXAMPLES=OFF ^
    -D BUILD_TESTS=OFF ^
    -D BUILD_PERF_TESTS=OFF ^

    -D BUILD_JAVA=OFF ^
    -D BUILD_opencv_java_bindings_generator=OFF ^

    -D BUILD_opencv_js=OFF ^
    -D BUILD_opencv_js_bindings_generator=OFF ^

    -D BUILD_opencv_apps=OFF ^
    -D BUILD_opencv_datasets=OFF ^

    -D BUILD_opencv_objc_bindings_generator=OFF ^
    -D BUILD_opencv_python_bindings_generator=OFF ^
    -D BUILD_opencv_python_tests=OFF ^
    -D BUILD_opencv_ts=OFF ^

    -D BUILD_opencv_world=OFF ^

    -D WITH_QT=OFF ^
    -D WITH_FREETYPE=OFF ^
    -D OPENCV_ENABLE_NONFREE=ON ^

    -D OPENCV_EXTRA_MODULES_PATH=%modulePath% ^

    -G "Visual Studio 17 2022" ^
    -S %opencvPath%

msbuild %build%/INSTALL.vcxproj /t:build /p:configuration=Debug /p:platform=%msbuildPlatform% /maxcpucount
msbuild %build%/INSTALL.vcxproj /t:build /p:configuration=Release /p:platform=%msbuildPlatform% /maxcpucount

pause