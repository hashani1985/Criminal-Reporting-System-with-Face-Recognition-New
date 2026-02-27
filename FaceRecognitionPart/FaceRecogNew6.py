import cv2
import tkinter as tk
from tkinter import messagebox, Entry
from PIL import Image, ImageTk
import pyodbc
import datetime
import os

# Create a flag to control webcam capture
capturing = False
cap = cv2.VideoCapture(0)

# Function to start or stop capturing from the webcam
def toggle_capture():
    global capturing
    capturing = not capturing
    if capturing:
        capture_button.config(text="Stop Capture")
        capture_webcam()
    else:
        capture_button.config(text="Start Capture")

# Function to capture an image from the webcam
def capture_webcam():
    if capturing:
        ret, frame = cap.read()
        if not ret:
            return

        # Convert the OpenCV BGR frame to RGB format
        rgb_frame = cv2.cvtColor(frame, cv2.COLOR_BGR2RGB)
        img = Image.fromarray(rgb_frame)
        imgtk = ImageTk.PhotoImage(image=img)

        # Update the label with the new frame
        label.config(image=imgtk)
        label.img = imgtk
        root.update()

        # Schedule the function to capture the next frame
        root.after(10, capture_webcam)

# Function to capture an image
def capture_image():
    if capturing:
        offender_id = offender_id_entry.get()

        if not offender_id:
            messagebox.showerror("Capture Image", "Please enter the Offender ID.")
            return

        # Capture a single frame from the webcam
        ret, frame = cap.read()
        if not ret:
            return

        # Convert the OpenCV BGR frame to RGB format
        rgb_frame = cv2.cvtColor(frame, cv2.COLOR_BGR2RGB)
        img = Image.fromarray(rgb_frame)

        # Generate a unique filename based on the current date and time
        current_datetime = datetime.datetime.now()
        filename = f"{offender_id}_{current_datetime.strftime('%Y%m%d%H%M%S')}.jpg"
        output_folder = "captured_images"

        # Create the output folder if it doesn't exist
        os.makedirs(output_folder, exist_ok=True)

        # Save the captured image with the relevant Offender ID
        image_path = os.path.join(output_folder, filename)
        img.save(image_path)

        try:
            connection = pyodbc.connect('Driver={SQL Server};Server=DESKTOP-BU7QFI6\SQLEXPRESS;Database=CriminalReportingDB')
            cursor = connection.cursor()

            with open(image_path, "rb") as image_file:
                binary_data = image_file.read()

            cursor.execute("UPDATE Offenders SET ImageData = ? WHERE OffenderId = ?", binary_data, offender_id)
            connection.commit()
            cursor.close()
            connection.close()

            messagebox.showinfo("Capture Image", "Image captured and saved to the database.")
        except Exception as e:
            messagebox.showerror("Capture Image", f"Error: {str(e)}")

# Function to recognize the captured image
def recognize_image():
    face_cascade = cv2.CascadeClassifier('haarcascade_frontalface_default.xml')  # Sample Haar Cascade XML
    img = cv2.imread('captured_image.png')
    gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)
    faces = face_cascade.detectMultiScale(gray, scaleFactor=1.3, minNeighbors=5)

    if len(faces) > 0:
        messagebox.showinfo("Recognize Image", f"{len(faces)} face(s) detected in the image.")
    else:
        messagebox.showinfo("Recognize Image", "No faces detected in the image.")

# Create the main window
root = tk.Tk()
root.title("Image Processing App")

# Create a label to display the webcam feed
label = tk.Label(root)
label.pack()

# Create a label and textbox for entering Offender ID
offender_id_label = tk.Label(root, text="Enter Offender ID:")
offender_id_label.pack()

offender_id_entry = Entry(root)
offender_id_entry.pack()

button_frame = tk.Frame(root)
button_frame.pack(side=tk.BOTTOM, fill=tk.BOTH, expand=True)

# Create buttons
capture_button = tk.Button(button_frame, text="Start Capture", command=toggle_capture)
capture_image_button = tk.Button(button_frame, text="Capture Image", command=capture_image)
recognize_image_button = tk.Button(button_frame, text="Recognize Image", command=recognize_image)

window_width = 800  # window's width
window_height = 600  # window's height

# Use the geometry method to set the window size
root.geometry(f"{window_width}x{window_height}")

# Pack buttons
capture_button.pack(side=tk.LEFT, padx=10)
capture_image_button.pack(side=tk.LEFT, padx=10)
recognize_image_button.pack(side=tk.LEFT, padx=10)

root.mainloop()
