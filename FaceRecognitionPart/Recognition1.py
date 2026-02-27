import tkinter as tk
from PIL import Image, ImageTk
import sqlite3  # Use the appropriate database library for your case
import cv2
from tkinter import messagebox, Entry
from PIL import Image, ImageTk
import pyodbc
import datetime
import os
import face_recognition


class FaceRecognitionApp:
    def __init__(self, root):
        self.root = root
        self.root.title("Face Recognition App")

        self.label = tk.Label(self.root, text="Enter Offender ID:")
        self.label.pack()

        self.offender_id_entry = tk.Entry(self.root)
        self.offender_id_entry.pack()

        self.start_webcam_button = tk.Button(self.root, text="Start Webcam", command=self.start_webcam)
        self.start_webcam_button.pack()

        self.start_recognition_button = tk.Button(self.root, text="Start Recognition", command=self.start_recognition)
        self.start_recognition_button.pack()

        self.stop_webcam_button = tk.Button(self.root, text="Stop Webcam", command=self.stop_webcam)
        self.stop_webcam_button.pack()

        self.video_source = 0  # Use 0 for default webcam, change if needed
        self.cap = None
        self.canvas = tk.Canvas(self.root)
        self.canvas.pack()

    def start_webcam(self):
        self.cap = cv2.VideoCapture(self.video_source)
        self.update()

    def update(self):
        ret, frame = self.cap.read()
        if ret:
            self.photo = ImageTk.PhotoImage(image=Image.fromarray(cv2.cvtColor(frame, cv2.COLOR_BGR2RGB)))
            self.canvas.create_image(0, 0, anchor=tk.NW, image=self.photo)
            self.root.after(10, self.update)


def start_recognition(self):
    offender_id = self.offender_id_entry.get()

    # Your MSSQL connection parameters
    server = 'your_server'
    database = 'your_database'
    username = 'your_username'
    password = 'your_password'

    # Establish the database connection
    connection = pyodbc.connect('Driver={SQL Server};Server=DESKTOP-BU7QFI6\SQLEXPRESS;Database=CriminalReportingDB')
    cursor = connection.cursor()

    try:
        # Retrieve image from the database based on offender_id
        query = f"SELECT image FROM offenders WHERE offender_id = '{offender_id}'"
        cursor = connection.cursor()
        cursor.execute(query)

        # Fetch the image data
        result = cursor.fetchone()
        image_data = result[0] if result else None

        # Process the retrieved image_data as needed
        if image_data:
            # Convert binary image data to a NumPy array
            image_np = np.frombuffer(image_data, dtype=np.uint8)

            # Assuming the image is stored as RGB, you might reshape it
            # according to your actual image format
            image = image_np.reshape((height, width, channels))

            # Now 'image' contains the retrieved image data, you can proceed
            # with your recognition process

    finally:
        # Close the cursor and connection
        cursor.close()
        connection.close()


    def stop_webcam(self):
        if self.cap is not None:
            self.cap.release()

if __name__ == "__main__":
    root = tk.Tk()
    app = FaceRecognitionApp(root)
    root.mainloop()
