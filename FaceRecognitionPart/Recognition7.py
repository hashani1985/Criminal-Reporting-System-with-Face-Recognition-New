import cv2
import dlib
import numpy as np
import tkinter as tk
from tkinter import ttk
from PIL import Image, ImageTk
import os

# Load the pre-trained face detector from dlib
detector = dlib.get_frontal_face_detector()

# Load the pre-trained facial landmarks predictor from dlib
predictor = dlib.shape_predictor("shape_predictor_68_face_landmarks.dat")

# Load the pre-trained face recognition model from dlib
face_recognizer = dlib.face_recognition_model_v1("dlib_face_recognition_resnet_model_v1.dat")

# Global variable to store the video capture object
cap = None

# Function to extract facial features (face encodings) from an image
def get_face_encodings(image):
    face_locations = detector(image, 1)
    face_encodings = []

    for face_location in face_locations:
        landmarks = predictor(image, face_location)
        face_encoding = face_recognizer.compute_face_descriptor(image, landmarks)
        face_encodings.append(face_encoding)

    return face_encodings

# Function to recognize faces in an image
def recognize_faces(known_faces, image_to_check):
    target_face_encodings = get_face_encodings(image_to_check)

    for i, known_face_encoding in enumerate(known_faces):
        for target_face_encoding in target_face_encodings:
            # Compare the face encodings using Euclidean distance
            distance = np.linalg.norm(np.array(known_face_encoding) - np.array(target_face_encoding))
            
            # You can adjust the distance threshold based on your application
            if distance < 0.6:
                result_label.config(text=f"Person recognized: {os.path.basename(known_face_images[i])}")
                # You can perform further actions for recognized faces here

# Function to start the webcam
def start_webcam():
    global cap
    cap = cv2.VideoCapture(0)

    def update_frame():
        ret, frame = cap.read()
        if ret:
            frame = cv2.cvtColor(frame, cv2.COLOR_BGR2RGB)
            image = Image.fromarray(frame)
            imgtk = ImageTk.PhotoImage(image=image)
            video_label.imgtk = imgtk
            video_label.configure(image=imgtk)
            video_label.after(10, update_frame)

    update_frame()

# Function to stop the webcam
def stop_webcam():
    if cap is not None:
        cap.release()
        video_label.config(image="")
        result_label.config(text="Webcam stopped.")

# Function to get image names from a local folder
def get_image_names(folder_path):
    image_names = []
    for filename in os.listdir(folder_path):
        if filename.lower().endswith(('.png', '.jpg', '.jpeg', '.gif')):
            image_names.append(os.path.join(folder_path, filename))
    return image_names

# Create Tkinter window
root = tk.Tk()
root.title("Face Recognition App")

# Create buttons
start_button = ttk.Button(root, text="Start Webcam", command=start_webcam)
recognize_button = ttk.Button(root, text="Recognize Faces", command=lambda: recognize_faces(known_faces, cap.read()[1]))
stop_button = ttk.Button(root, text="Stop Webcam", command=stop_webcam)

# Create labels
video_label = ttk.Label(root)
result_label = ttk.Label(root, text="")

# Place widgets in the window
start_button.pack(pady=10)
recognize_button.pack(pady=10)
stop_button.pack(pady=10)
video_label.pack()
result_label.pack()

# Load images of known faces and get their face encodings
known_faces_folder = "captured_images/O002"  #  folder path
known_face_images = get_image_names(known_faces_folder)
known_faces = []

for image_path in known_face_images:
    known_image = cv2.imread(image_path)
    known_faces.extend(get_face_encodings(known_image))

# Start Tkinter event loop
root.mainloop()
