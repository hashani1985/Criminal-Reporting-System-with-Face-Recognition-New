cmake_minimum_required(VERSION 3.5)

# Settings:
set(CTEST_DASHBOARD_ROOT                "D:/Project/Application/FaceRecognitionPart/myenv/Tests/CTestTest")
set(CTEST_SITE                          "DESKTOP-BU7QFI6")
set(CTEST_BUILD_NAME                    "CTestTest-Win32-MSBuild-Upload")

set(CTEST_SOURCE_DIRECTORY              "D:/Project/Application/FaceRecognitionPart/cmake-3.27.7/Tests/CTestTestUpload")
set(CTEST_BINARY_DIRECTORY              "D:/Project/Application/FaceRecognitionPart/myenv/Tests/CTestTestUpload")
set(CTEST_CMAKE_GENERATOR               "Visual Studio 17 2022")
set(CTEST_CMAKE_GENERATOR_PLATFORM      "")
set(CTEST_CMAKE_GENERATOR_TOOLSET       "")
set(CTEST_BUILD_CONFIGURATION           "$ENV{CMAKE_CONFIG_TYPE}")

CTEST_START(Experimental)
CTEST_CONFIGURE(BUILD "${CTEST_BINARY_DIRECTORY}" RETURN_VALUE res)
CTEST_BUILD(BUILD "${CTEST_BINARY_DIRECTORY}" RETURN_VALUE res)
CTEST_UPLOAD(FILES "${CTEST_SOURCE_DIRECTORY}/sleep.c" "${CTEST_BINARY_DIRECTORY}/CMakeCache.txt")
CTEST_SUBMIT()
