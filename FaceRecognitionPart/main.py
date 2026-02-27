import face_recognition
import os,sys
import cv2
import numpy as np
import math
import keyboard
import matplotlib.pyplot as plt


# Load known faces and their names
known_faces = []
known_names = []

# Load and encode known faces
for name in ["bill1", "bill2","hashani1","hashani2","hashani3"]:  #  image names (without file extensions)
    image = face_recognition.load_image_file(f"known_faces/{name}.jpg")
    encoding = face_recognition.face_encodings(image)[0]
    known_faces.append(encoding)
    known_names.append(name)

# Initialize webcam
video_capture = cv2.VideoCapture(0)

while True:
    ret, frame = video_capture.read()

    # Find face locations and encodings in the current frame
    face_locations = face_recognition.face_locations(frame)
    face_encodings = face_recognition.face_encodings(frame, face_locations)

    for face_encoding, face_location in zip(face_encodings, face_locations):
        # Compare the face with known faces
        matches = face_recognition.compare_faces(known_faces, face_encoding)
        name = "Unknown"

        if True in matches:
            match_index = matches.index(True)
            name = known_names[match_index]

        # Draw rectangle around the face and display name
        top, right, bottom, left = face_location
        cv2.rectangle(frame, (left, top), (right, bottom), (0, 255, 0), 2)
        cv2.putText(frame, name, (left, top - 10), cv2.FONT_HERSHEY_SIMPLEX, 0.75, (0, 255, 0), 2)

    # Display the resulting frame
    cv2.imshow('Video', frame)

    

    if cv2.waitKey(1) & 0xFF == ord('q'): # stop video by pressing q
        break

# Release webcam and close windows
video_capture.release()
cv2.destroyAllWindows()


#--------------------------------------------------


