# CMake generated Testfile for 
# Source directory: D:/Project/Application/FaceRecognitionPart/cmake-3.27.7/Utilities/KWIML/test
# Build directory: D:/Project/Application/FaceRecognitionPart/myenv/Utilities/KWIML/test
# 
# This file includes the relevant testing commands required for 
# testing this directory and lists subdirectories to be tested as well.
if(CTEST_CONFIGURATION_TYPE MATCHES "^([Dd][Ee][Bb][Uu][Gg])$")
  add_test([=[kwiml.test]=] "D:/Project/Application/FaceRecognitionPart/myenv/Utilities/KWIML/test/Debug/kwiml_test.exe")
  set_tests_properties([=[kwiml.test]=] PROPERTIES  _BACKTRACE_TRIPLES "D:/Project/Application/FaceRecognitionPart/cmake-3.27.7/Utilities/KWIML/test/CMakeLists.txt;45;add_test;D:/Project/Application/FaceRecognitionPart/cmake-3.27.7/Utilities/KWIML/test/CMakeLists.txt;0;")
elseif(CTEST_CONFIGURATION_TYPE MATCHES "^([Rr][Ee][Ll][Ee][Aa][Ss][Ee])$")
  add_test([=[kwiml.test]=] "D:/Project/Application/FaceRecognitionPart/myenv/Utilities/KWIML/test/Release/kwiml_test.exe")
  set_tests_properties([=[kwiml.test]=] PROPERTIES  _BACKTRACE_TRIPLES "D:/Project/Application/FaceRecognitionPart/cmake-3.27.7/Utilities/KWIML/test/CMakeLists.txt;45;add_test;D:/Project/Application/FaceRecognitionPart/cmake-3.27.7/Utilities/KWIML/test/CMakeLists.txt;0;")
elseif(CTEST_CONFIGURATION_TYPE MATCHES "^([Mm][Ii][Nn][Ss][Ii][Zz][Ee][Rr][Ee][Ll])$")
  add_test([=[kwiml.test]=] "D:/Project/Application/FaceRecognitionPart/myenv/Utilities/KWIML/test/MinSizeRel/kwiml_test.exe")
  set_tests_properties([=[kwiml.test]=] PROPERTIES  _BACKTRACE_TRIPLES "D:/Project/Application/FaceRecognitionPart/cmake-3.27.7/Utilities/KWIML/test/CMakeLists.txt;45;add_test;D:/Project/Application/FaceRecognitionPart/cmake-3.27.7/Utilities/KWIML/test/CMakeLists.txt;0;")
elseif(CTEST_CONFIGURATION_TYPE MATCHES "^([Rr][Ee][Ll][Ww][Ii][Tt][Hh][Dd][Ee][Bb][Ii][Nn][Ff][Oo])$")
  add_test([=[kwiml.test]=] "D:/Project/Application/FaceRecognitionPart/myenv/Utilities/KWIML/test/RelWithDebInfo/kwiml_test.exe")
  set_tests_properties([=[kwiml.test]=] PROPERTIES  _BACKTRACE_TRIPLES "D:/Project/Application/FaceRecognitionPart/cmake-3.27.7/Utilities/KWIML/test/CMakeLists.txt;45;add_test;D:/Project/Application/FaceRecognitionPart/cmake-3.27.7/Utilities/KWIML/test/CMakeLists.txt;0;")
else()
  add_test([=[kwiml.test]=] NOT_AVAILABLE)
endif()
