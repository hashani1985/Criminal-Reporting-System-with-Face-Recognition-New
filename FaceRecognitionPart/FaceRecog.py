import cv2
import os

# Load the pre-trained Haar Cascade Classifier for face detection
face_cascade = cv2.CascadeClassifier(cv2.data.haarcascades + 'haarcascade_frontalface_default.xml')

# Path to the folder containing your images
image_folder = 'data\images'

# Create the output folder for captured faces
output_folder = 'data\labels'
os.makedirs(output_folder, exist_ok=True)

# Function to detect and capture faces in an image
def detect_and_capture_faces(image_path):
    img = cv2.imread(image_path)
    gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)
    
    # Detect faces in the image
    faces = face_cascade.detectMultiScale(gray, scaleFactor=1.1, minNeighbors=5, minSize=(30, 30))

    # Iterate over detected faces and save them
    for i, (x, y, w, h) in enumerate(faces):
        face = img[y:y+h, x:x+w]
        output_path = os.path.join(output_folder, f'face_{i}.jpg')
        cv2.imwrite(output_path, face)

# Loop through images in the image folder and process each one
for filename in os.listdir(image_folder):
    if filename.endswith(('.jpg', '.jpeg', '.png', '.bmp')):
        image_path = os.path.join(image_folder, filename)
        detect_and_capture_faces(image_path)

print("Face detection and capture completed.")
