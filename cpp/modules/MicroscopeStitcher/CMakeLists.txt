cmake_minimum_required(VERSION 3.20)

project(MicroscopeStitcher)

include_directories(
    ${CMAKE_CURRENT_SOURCE_DIR}/includes
)

file(GLOB_RECURSE SOURCE_FILES "src/*.cpp")

add_library(
    ${PROJECT_NAME} SHARED
    ${SOURCE_FILES}
)

target_link_libraries(
    ${PROJECT_NAME}
    ${OpenCV_LIBS}
)