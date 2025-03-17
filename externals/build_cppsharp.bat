@echo off

setlocal enabledelayedexpansion
chcp 65001

cd /d %~dp0

cd cppsharp
cd build

@REM detect 7z https://7-zip.org/a/7z2409-x64.exe
@REM must install the default folder
if not exist "C:\Program Files\7-Zip\7z.exe" (
    echo "7z not found, please install 7z and add it to PATH"
    pause
    exit /b 1
)

set http_proxy=http://127.0.0.1:1080
set https_proxy=http://127.0.0.1:1080
set all_proxy=http://127.0.0.1:1080

set SHEXE="C:\Users\simscop\Downloads\cmder\vendor\git-for-windows\bin\sh.exe"

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
@REM %SHEXE% build.sh generate -configuration Release -platform x64
@REM %SHEXE% build.sh -configuration Release -platform x64
%SHEXE% build.sh prepack -configuration Release -platform x64
%SHEXE% build.sh pack -configuration Release -platform x64
@REM %SHEXE% build.sh test -configuration Release -platform x64
pause