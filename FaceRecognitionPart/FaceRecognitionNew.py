import tkinter as tk
import cv2
import os
import datetime
import face_recognition
import os,sys
import numpy as np
import math
import keyboard


import cv2

# Set the window backend to cv2.WINDOW_GUI_NORMAL
cv2.namedWindow('Video', cv2.WINDOW_GUI_NORMAL)

cap = cv2.VideoCapture(0)

while True:
    ret, frame = cap.read()
    if not ret:
        break

    cv2.imshow('Video', frame)

    if cv2.waitKey(1) & 0xFF == ord('q'):
        break

cap.release()
cv2.destroyAllWindows()

# Global variable to store the folder for saving images
save_folder = 'data/images'  # Specify the folder where you want to save images

# Create the folder if it doesn't exist
if not os.path.exists(save_folder):
    os.makedirs(save_folder)

    # Load known faces and their names
    known_faces = []
    known_names = []
# Function to capture and save an image
def capture_image():


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
# Function to train the image using a pre-trained TensorFlow model
def train_image():
    # Replace this with your actual training code using TensorFlow
    # You would load your images and use a pre-trained model for training
    print("Training image...")

# Function to recognize the image using the trained model
def recognize_image():
    # Replace this with your image recognition code using TensorFlow
    # Load your trained model and use it to recognize the captured image
    print("Recognizing image...")

# Create the main window
root = tk.Tk()
root.title("Image Capture and Recognition")

# Create buttons for image capture, training, and recognition
capture_button = tk.Button(root, text="Capture Image", command=capture_image)
train_button = tk.Button(root, text="Train Image", command=train_image)
recognize_button = tk.Button(root, text="Recognize Image", command=recognize_image)

# Pack buttons to display them
capture_button.pack()
train_button.pack()
recognize_button.pack()

# Start the main event loop
root.mainloop()
