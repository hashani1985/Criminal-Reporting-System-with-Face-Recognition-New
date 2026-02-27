# create the binary directory
make_directory("D:/Project/Application/FaceRecognitionPart/myenv/Tests/CMakeBuildCOnly")

# remove the CMakeCache.txt file from the source dir
# if there is one, so that in-source cmake tests
# still pass
message("Remove: D:/Project/Application/FaceRecognitionPart/cmake-3.27.7/Tests/COnly/CMakeCache.txt")
file(REMOVE "D:/Project/Application/FaceRecognitionPart/cmake-3.27.7/Tests/COnly/CMakeCache.txt")

# run cmake in the binary directory
message("running: ${CMAKE_COMMAND}")
execute_process(COMMAND "${CMAKE_COMMAND}"
  "D:/Project/Application/FaceRecognitionPart/cmake-3.27.7/Tests/COnly"
  "-GVisual Studio 17 2022"
  -A ""
  -T ""
  WORKING_DIRECTORY "D:/Project/Application/FaceRecognitionPart/myenv/Tests/CMakeBuildCOnly"
  RESULT_VARIABLE RESULT)
if(RESULT)
  message(FATAL_ERROR "Error running cmake command")
endif()

# Now use the --build option to build the project
message("running: ${CMAKE_COMMAND} --build")
execute_process(COMMAND "${CMAKE_COMMAND}"
  --build "D:/Project/Application/FaceRecognitionPart/myenv/Tests/CMakeBuildCOnly" --config Debug
  RESULT_VARIABLE RESULT)
if(RESULT)
  message(FATAL_ERROR "Error running cmake --build")
endif()

# run the executable out of the Debug directory if using a
# multi-config generator
set(_isMultiConfig 1)
if(_isMultiConfig)
  set(RUN_TEST "D:/Project/Application/FaceRecognitionPart/myenv/Tests/CMakeBuildCOnly/Debug/COnly")
else()
  set(RUN_TEST "D:/Project/Application/FaceRecognitionPart/myenv/Tests/CMakeBuildCOnly/COnly")
endif()
# run the test results
message("running [${RUN_TEST}]")
execute_process(COMMAND "${RUN_TEST}" RESULT_VARIABLE RESULT)
if(RESULT)
  message(FATAL_ERROR "Error running test COnly")
endif()

# build it again with clean and only COnly target
execute_process(COMMAND "${CMAKE_COMMAND}"
  --build "D:/Project/Application/FaceRecognitionPart/myenv/Tests/CMakeBuildCOnly" --config Debug
  --clean-first --target COnly
  RESULT_VARIABLE RESULT)
if(RESULT)
  message(FATAL_ERROR "Error running cmake --build")
endif()

# run it again after clean
execute_process(COMMAND "${RUN_TEST}" RESULT_VARIABLE RESULT)
if(RESULT)
  message(FATAL_ERROR "Error running test COnly after clean ")
endif()
