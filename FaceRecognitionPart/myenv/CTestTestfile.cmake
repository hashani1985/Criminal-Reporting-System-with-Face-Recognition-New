# CMake generated Testfile for 
# Source directory: D:/Project/Application/FaceRecognitionPart/cmake-3.27.7
# Build directory: D:/Project/Application/FaceRecognitionPart/myenv
# 
# This file includes the relevant testing commands required for 
# testing this directory and lists subdirectories to be tested as well.
include("D:/Project/Application/FaceRecognitionPart/myenv/Tests/EnforceConfig.cmake")
add_test([=[SystemInformationNew]=] "D:/Project/Application/FaceRecognitionPart/myenv/bin/cmake" "--system-information" "-G" "Visual Studio 17 2022")
set_tests_properties([=[SystemInformationNew]=] PROPERTIES  _BACKTRACE_TRIPLES "D:/Project/Application/FaceRecognitionPart/cmake-3.27.7/CMakeLists.txt;519;add_test;D:/Project/Application/FaceRecognitionPart/cmake-3.27.7/CMakeLists.txt;0;")
subdirs("Source/kwsys")
subdirs("Utilities/std")
subdirs("Utilities/KWIML")
subdirs("Utilities/cmlibrhash")
subdirs("Utilities/cmzlib")
subdirs("Utilities/cmcurl")
subdirs("Utilities/cmnghttp2")
subdirs("Utilities/cmexpat")
subdirs("Utilities/cmbzip2")
subdirs("Utilities/cmzstd")
subdirs("Utilities/cmliblzma")
subdirs("Utilities/cmlibarchive")
subdirs("Utilities/cmjsoncpp")
subdirs("Utilities/cmlibuv")
subdirs("Utilities/cmcppdap")
subdirs("Source")
subdirs("Utilities")
subdirs("Tests")
subdirs("Auxiliary")
