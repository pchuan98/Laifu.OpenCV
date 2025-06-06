cmake_minimum_required(VERSION 3.20)

project(OpenCvSharpExtern LANGUAGES CXX VERSION 0.1.0)

set(CMAKE_CXX_STANDARD 20)
set(CMAKE_CXX_STANDARD_REQUIRED ON)
set(CMAKE_CXX_EXTENSIONS OFF)
set(CMAKE_POSITION_INDEPENDENT_CODE ON)

add_definitions(-DENABLE_FEATURE_X)

set(OpenCV_DIR ../externals/install/x64/vc17/staticlib)
find_package(OpenCV REQUIRED core imgproc highgui features2d stitching)

include_directories(
    ${OpenCV_INCLUDE_DIRS}
    ${CMAKE_CURRENT_SOURCE_DIR}/includes
    ${CMAKE_CURRENT_SOURCE_DIR}/models
)

# set(CMAKE_MSVC_RUNTIME_LIBRARY "MultiThreaded$<$<CONFIG:Debug>:Debug>")
if(MSVC)
    add_compile_options(
        $<$<CONFIG:Debug>:/MTd>
        $<$<CONFIG:Release>:/MT>
        $<$<CONFIG:MINSIZEREL>:/MT>
        "/utf-8"
    )
endif()

include(CheckCXXCompilerFlag)
check_cxx_compiler_flag("-fuse-ld=gold" COMPILER_SUPPORTS_GOLD)

if(COMPILER_SUPPORTS_GOLD)
    execute_process(COMMAND ${CMAKE_CXX_COMPILER} -fuse-ld=gold -Wl,--version OUTPUT_VARIABLE stdout ERROR_QUIET)

    if("${stdout}" MATCHES "GNU gold")
        set(CMAKE_EXE_LINKER_FLAGS "${CMAKE_EXE_LINKER_FLAGS} -fuse-ld=gold")
        set(CMAKE_SHARED_LINKER_FLAGS "${CMAKE_SHARED_LINKER_FLAGS} -fuse-ld=gold")
    endif()
endif()

add_compile_definitions(CVAPI_EXPORTS)

file(GLOB_RECURSE SOURCE_FILES "src/*.cpp")
message(STATUS "SOURCE_FILES: ${SOURCE_FILES}")
add_library(
    ${PROJECT_NAME} SHARED
    ${SOURCE_FILES}
)

# target_link_libraries(
# ${PROJECT_NAME}
# opencv_world
# opencv_img_hash)
target_link_libraries(
    ${PROJECT_NAME}
    ${OpenCV_LIBS})

message(STATUS "OpenCV_LIBS: ${OpenCV_LIBS}" ${OpenCV_LIBS})

add_executable(main main.cpp)
target_link_libraries(main ${OpenCV_LIBS})

add_executable(stitching stitching.cpp)
target_link_libraries(stitching ${OpenCV_LIBS})

add_executable(models models.cpp)
target_link_libraries(models ${OpenCV_LIBS})

add_executable(old old.cpp)
target_link_libraries(old ${OpenCV_LIBS})

add_executable(demo demo.cpp)
target_link_libraries(demo ${OpenCV_LIBS})

add_executable(motion motion.cpp)
target_link_libraries(motion ${OpenCV_LIBS})

get_filename_component(ROOT_DIR ${CMAKE_CURRENT_SOURCE_DIR} DIRECTORY)
message(STATUS "XXX: ${ROOT_DIR}")

# SET(EXECUTABLE_OUTPUT_PATH ${ROOT_DIR}/bin)
# SET(LIBRARY_OUTPUT_PATH ${ROOT_DIR}/bin)

# set(CMAKE_RUNTIME_OUTPUT_DIRECTORY ${CMAKE_HOME_DIRECTORY}/bin)
add_subdirectory(modules/MicroscopeStitcher)