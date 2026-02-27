import cv2
import tkinter as tk
from tkinter import messagebox, Entry
from PIL import Image, ImageTk
import pyodbc
import os

# Create a flag to control webcam capture
capturing = False
cap = cv2.VideoCapture(0)

# Offender ID and image number
offender_id = ""
image_number = 1

# Function to start or stop capturing from the webcam
def toggle_capture():
    global capturing, offender_id, image_number
    capturing = not capturing
    if capturing:
        capture_button.config(text="Stop Capture")
        offender_id = offender_id_entry.get()
        image_number = 1
        capture_webcam()
    else:
        capture_button.config(text="Start Capture")

# Function to capture an image from the webcam
def capture_webcam():
    global image_number
    if capturing and image_number <= 5:
        ret, frame = cap.read()
        if not ret:
            return

        # Convert the OpenCV BGR frame to RGB format
        rgb_frame = cv2.cvtColor(frame, cv2.COLOR_BGR2RGB)
        img = Image.fromarray(rgb_frame)

        # Generate a unique filename based on the offender ID and image number
        filename = f"{offender_id}_{image_number}.jpg"
        image_path = os.path.join("captured_images", filename)
        img.save(image_path)

        try:
            connection = pyodbc.connect('Driver={SQL Server};Server=DESKTOP-BU7QFI6\SQLEXPRESS;Database=CriminalReportingDB')
            cursor = connection.cursor()

            with open(image_path, "rb") as image_file:
                binary_data = image_file.read()

            # Save the captured image to the database with the relevant Offender ID and image number
            cursor.execute(f"UPDATE Offenders SET ImageData{image_number} = ? WHERE OffenderId = ?", binary_data, offender_id)
            connection.commit()

            cursor.close()
            connection.close()

            messagebox.showinfo("Capture Image", f"Image {image_number} captured and saved to the database and local folder.")
            image_number += 1
            # Update the label with the new frame
            update_label(img)
            # Schedule the function to capture the next frame
            root.after(10, capture_webcam)
        except Exception as e:
            messagebox.showerror("Capture Image", f"Error: {str(e)}")

# Function to update the label with the new frame
def update_label(img):
    imgtk = ImageTk.PhotoImage(image=img)
    label.imgtk = imgtk
    label.configure(image=imgtk)

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

window_width = 800  # window's width
window_height = 600  # window's height

# Use the geometry method to set the window size
root.geometry(f"{window_width}x{window_height}")

# Pack buttons
capture_button.pack(side=tk.LEFT, padx=10)

root.mainloop()
