import cv2
import tkinter as tk
from tkinter import filedialog
from tkinter import messagebox
from tkinter import PhotoImage
from PIL import Image, ImageTk
import pyodbc


# Function to capture and display the webcam feed
def show_webcam():
    cap = cv2.VideoCapture(0)
    if not cap.isOpened():
        return

    while True:
        ret, frame = cap.read()
        if not ret:
            break

        # Convert the OpenCV BGR frame to RGB format
        rgb_frame = cv2.cvtColor(frame, cv2.COLOR_BGR2RGB)
        img = Image.fromarray(rgb_frame)
        imgtk = ImageTk.PhotoImage(image=img)

        # Update the label with the new frame
        label.config(image=imgtk)
        label.img = imgtk
        root.update()

    cap.release()



# Function to capture an image
def capture_image():
   cap = cv2.VideoCapture(0)
   if not cap.isOpened():
    return

    # Capture an image
    ret, frame = cap.read()
    if not ret:
        return

    # Convert the OpenCV BGR frame to RGB format
    rgb_frame = cv2.cvtColor(frame, cv2.COLOR_BGR2RGB)
    img = Image.fromarray(rgb_frame)

    
    
    # Generate a unique filename based on the current date and time
    current_datetime = datetime.datetime.now()
    filename = f"captured_image_{current_datetime.strftime('%Y%m%d%H%M%S')}.jpg"

    # Insert the image into the SQL Server database
    try:
        connection = pyodbc.connect('Driver={SQL Server};Server=DESKTOP-BU7QFI6\SQLEXPRESS;Database=CriminalReportingDB')
        cursor = connection.cursor()
        
        with open(filename, "rb") as image_file:
            binary_data = image_file.read()
        
        #cursor.execute("INSERT INTO Offenders (ImageData) VALUES (?) WHERE OffenderId=O001", binary_data)
        cursor.execute("UPDATE Offenders SET ImageData = ? WHERE OffenderId = ?", binary_data, 'O001')

        connection.commit()
        cursor.close()
        connection.close()
        
        messagebox.showinfo("Capture Image", "Image captured and saved to the database.")
    except Exception as e:
        messagebox.showerror("Capture Image", f"Error: {str(e)}")

    cap.release()

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

# Function to train an image classifier (dummy example)
def train_image_classifier():
    # Replace this with your actual image classification training code
    messagebox.showinfo("Train Image Classifier", "Training the image classifier...")

# Create the main window
root = tk.Tk()
root.title("Image Processing App")

# Create a label to display the webcam feed
label = tk.Label(root)
label.pack()

button_frame = tk.Frame(root)
button_frame.pack(side=tk.BOTTOM, fill=tk.BOTH, expand=True)

# Create buttons
opencam_button = tk.Button(button_frame, text="Open Camera", command=show_webcam)
capture_button = tk.Button(button_frame, text="Capture Image", command=capture_image)
recognize_button = tk.Button(button_frame, text="Recognize Image", command=recognize_image)
train_button = tk.Button(button_frame, text="Train Image", command=train_image_classifier)

window_width = 800  # Replace with your desired width
window_height = 600  # Replace with your desired height

# Use the geometry method to set the window size
root.geometry(f"{window_width}x{window_height}")

# Pack buttons
opencam_button.pack(side=tk.LEFT,padx=10)
capture_button.pack(side=tk.LEFT,padx=10)
recognize_button.pack(side=tk.LEFT,padx=10)
train_button.pack(side=tk.LEFT,padx=10)


root.mainloop()
