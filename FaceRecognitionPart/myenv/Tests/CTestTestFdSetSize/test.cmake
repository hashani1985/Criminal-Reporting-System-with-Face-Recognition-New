cmake_minimum_required(VERSION 3.5)

# Settings:
set(CTEST_DASHBOARD_ROOT                "D:/Project/Application/FaceRecognitionPart/myenv/Tests/CTestTest")
set(CTEST_SITE                          "DESKTOP-BU7QFI6")
set(CTEST_BUILD_NAME                    "CTestTest-Win32-MSBuild-FdSetSize")

set(CTEST_SOURCE_DIRECTORY              "D:/Project/Application/FaceRecognitionPart/cmake-3.27.7/Tests/CTestTestFdSetSize")
set(CTEST_BINARY_DIRECTORY              "D:/Project/Application/FaceRecognitionPart/myenv/Tests/CTestTestFdSetSize")
set(CTEST_CVS_COMMAND                   "")
set(CTEST_CMAKE_GENERATOR               "Visual Studio 17 2022")
set(CTEST_CMAKE_GENERATOR_PLATFORM      "")
set(CTEST_CMAKE_GENERATOR_TOOLSET       "")
set(CTEST_BUILD_CONFIGURATION           "$ENV{CMAKE_CONFIG_TYPE}")
set(CTEST_COVERAGE_COMMAND              "COVERAGE_COMMAND-NOTFOUND")
set(CTEST_NOTES_FILES                   "${CTEST_SCRIPT_DIRECTORY}/${CTEST_SCRIPT_NAME}")

ctest_start(Experimental)
ctest_configure(BUILD "${CTEST_BINARY_DIRECTORY}" RETURN_VALUE res)
message("build")
ctest_build(BUILD "${CTEST_BINARY_DIRECTORY}" RETURN_VALUE res)
message("test")
ctest_test(BUILD "${CTEST_BINARY_DIRECTORY}" PARALLEL_LEVEL 20 RETURN_VALUE res)
message("done")
