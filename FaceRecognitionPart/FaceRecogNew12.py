import cv2
import tkinter as tk
from tkinter import messagebox, Entry
from PIL import Image, ImageTk
import pyodbc
import datetime
import os
import face_recognition

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
        create_offender_folder(offender_id)
        capture_webcam()
    else:
        capture_button.config(text="Start Capture")

# Function to create a folder for the offender on the local machine
def create_offender_folder(offender_id):
    folder_path = os.path.join("captured_images", offender_id)
    os.makedirs(folder_path, exist_ok=True)

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
        imgtk = ImageTk.PhotoImage(image=img)

        # Update the label with the new frame
        label.config(image=imgtk)
        label.img = imgtk
        root.update()

        # Save the captured image with the relevant Offender ID and image number
        filename = f"{offender_id}_{image_number}.jpg"
        folder_path = os.path.join("captured_images", offender_id)
        image_path = os.path.join(folder_path, filename)
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
        except Exception as e:
            messagebox.showerror("Capture Image", f"Error: {str(e)}")

        # Schedule the function to capture the next frame
        root.after(10, capture_webcam)

# Function to capture an image
def capture_image():
    if capturing:
        offender_id = offender_id_entry.get()

        if not offender_id:
            messagebox.showerror("Capture Image", "Please enter the Offender ID.")
            return

        create_offender_folder(offender_id)

        # Capture a single frame from the webcam
        ret, frame = cap.read()
        if not ret:
            return

        # Convert the OpenCV BGR frame to RGB format
        rgb_frame = cv2.cvtColor(frame, cv2.COLOR_BGR2RGB)
        img = Image.fromarray(rgb_frame)

        # Generate a unique filename based on the offender ID
        filename = f"{offender_id}.jpg"
        folder_path = os.path.join("captured_images", offender_id)
        image_path = os.path.join(folder_path, filename)
        img.save(image_path)

        try:
            connection = pyodbc.connect('Driver={SQL Server};Server=DESKTOP-BU7QFI6\SQLEXPRESS;Database=CriminalReportingDB')
            cursor = connection.cursor()

            with open(image_path, "rb") as image_file:
                binary_data = image_file.read()

            cursor.execute("UPDATE Offenders SET ImageData2 = ? WHERE OffenderId = ?", binary_data, offender_id)
            connection.commit()
            cursor.close()
            connection.close()

            messagebox.showinfo("Capture Image", "Image captured and saved to the database and local folder.")
        except Exception as e:
            messagebox.showerror("Capture Image", f"Error: {str(e)}")

# Function to recognize the captured image
def recognize_image():
    # Load the known face descriptors from the database
    known_face_descriptors, known_offender_ids = load_known_faces_from_database()

    # Load the captured image
    captured_image_path = f'captured_images/{offender_id}/{offender_id}_{image_number}.jpg'
    captured_image = face_recognition.load_image_file(captured_image_path)
    captured_face_locations = face_recognition.face_locations(captured_image)
    captured_face_descriptors = face_recognition.face_encodings(captured_image, captured_face_locations)

    if not captured_face_descriptors:
        messagebox.showinfo("Recognize Image", "No faces detected in the captured image.")
        return

    # Check for matches in the database
    matches = face_recognition.compare_faces(known_face_descriptors, captured_face_descriptors[0])

    if any(matches):
        match_index = matches.index(True)
        offender_id = known_offender_ids[match_index]
        messagebox.showinfo("Recognize Image", f"Offender ID: {offender_id} detected!")
    else:
        messagebox.showinfo("Recognize Image", "No matches found in the database.")

def load_known_faces_from_database():
    # Assuming you have a function to fetch face descriptors and associated offender IDs from the database
    # Modify this function based on your actual database structure and how you store face descriptors

    # Example implementation:
    known_face_descriptors = []
    known_offender_ids = []

    connection = pyodbc.connect('Driver={SQL Server};Server=DESKTOP-BU7QFI6\SQLEXPRESS;Database=CriminalReportingDB')
    cursor = connection.cursor()
    
    try:
        cursor.execute("SELECT OffenderId, ImageData1 FROM Offenders WHERE ImageData1 IS NOT NULL")
        rows = cursor.fetchall()

        for row in rows:
            offender_id = row[0]
            binary_data = row[1]
            
            # Assuming you have a function to convert binary data to numpy array
            # Modify this function based on how you store the image data in the database
            face_descriptor = convert_binary_data_to_numpy_array(binary_data)

            known_face_descriptors.append(face_descriptor)
            known_offender_ids.append(offender_id)
    except Exception as e:
        messagebox.showerror("Recognize Image", f"Error: {str(e)}")
    finally:
        cursor.close()
        connection.close()

    return known_face_descriptors, known_offender_ids

def convert_binary_data_to_numpy_array(binary_data):
    # Convert binary data to numpy array
    # Modify this function based on how you store the image data in the database
    pass

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
