import tkinter as tk
import cv2
import os
import datetime

# Global variable to store the folder for saving images
save_folder = 'data/images'  # Specify the folder where you want to save images

# Create the folder if it doesn't exist
if not os.path.exists(save_folder):
    os.makedirs(save_folder)

# Function to capture and save an image
def capture_image():
    cap = cv2.VideoCapture(0)  # Open the default camera (0)

    if not cap.isOpened():
        print("Error: Unable to access the camera")
        return

    ret, frame = cap.read()  # Capture a frame

    if ret:
        timestamp = datetime.datetime.now().strftime('%Y%m%d%H%M%S')
        file_path = os.path.join(save_folder, f"captured_{timestamp}.jpg")
        cv2.imwrite(file_path, frame)
        print("Image saved:", file_path)

    cap.release()

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
