cmake_minimum_required(VERSION 3.20)

project(OpenCvSharpExtern LANGUAGES CXX VERSION 0.1.0)

set(CMAKE_CXX_STANDARD 17)
set(CMAKE_CXX_STANDARD_REQUIRED ON)
set(CMAKE_CXX_EXTENSIONS OFF)
set(CMAKE_POSITION_INDEPENDENT_CODE ON)

add_definitions(-DENABLE_FEATURE_X)

set(OpenCV_DIR ../externals/install/x64/vc17/staticlib)
find_package(OpenCV REQUIRED)

include_directories(
    ${OpenCV_INCLUDE_DIRS},
    ${CMAKE_CURRENT_SOURCE_DIR}/includes
)

# set(CMAKE_MSVC_RUNTIME_LIBRARY "MultiThreaded$<$<CONFIG:Debug>:Debug>")
if(MSVC)
    add_compile_options(
        $<$<CONFIG:Debug>:/MTd>
        $<$<CONFIG:Release>:/MT>
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

target_link_libraries(
    ${PROJECT_NAME}
    ${OpenCV_LIBRARIES})

message(STATUS "EMSCRIPTEN2: ${EMSCRIPTEN}")

add_executable(main main.cpp)
target_link_libraries(main ${PROJECT_NAME})