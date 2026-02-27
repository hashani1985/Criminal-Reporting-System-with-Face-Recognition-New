import tkinter as tk
import cv2
from PIL import Image, ImageTk
import pyodbc
from io import BytesIO


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

        connection = pyodbc.connect('Driver={SQL Server};Server=DESKTOP-BU7QFI6\SQLEXPRESS;Database=CriminalReportingDB')
        cursor = connection.cursor()

        # Assuming the 'offenders' table has columns: offender_id, name, image
        query = "SELECT ImageData1 FROM offenders WHERE offenderId = ?"
        cursor.execute(query, (offender_id,))
        result = cursor.fetchone()

        if result:
            image_data = result[0]
            self.process_image(image_data)
        else:
            print("Offender ID not found in the database.")

        connection.close()

    def process_image(self, image_data):
        if image_data:
            # Convert binary image data to PIL Image
            image = Image.open(BytesIO(image_data))

            # Resize the image if needed
            # image = image.resize((desired_width, desired_height), Image.ANTIALIAS)

            # Convert PIL Image to Tkinter PhotoImage
            photo = ImageTk.PhotoImage(image=image)

            # Display the image on the canvas
            self.canvas.create_image(0, 0, anchor=tk.NW, image=photo)

            # Save a reference to the image to prevent it from being garbage collected
            self.canvas.image = photo
        else:
            print("Image data is empty.")

    def stop_webcam(self):
        if self.cap is not None:
            self.cap.release()


if __name__ == "__main__":
    root = tk.Tk()
    app = FaceRecognitionApp(root)
    root.mainloop()
