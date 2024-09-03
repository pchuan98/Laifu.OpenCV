@echo off

setlocal

cd /d %~dp0

@REM add the proxy
set http_proxy=http://127.0.0.1:10809
set https_proxy=http://127.0.0.1:10809

@REM set the env variable
set opencvPath="%~dp0opencv"
set modulePath="%~dp0opencv_contrib\modules"
set build="./build"

@REM x64 or Win32
set msbuildPlatform=x64

@REM build
call "D:\.software\VisualStudio\Common7\Tools\VsDevCmd.bat"

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