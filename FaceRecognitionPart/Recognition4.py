import cv2
import dlib
import numpy as np


# Load the pre-trained face detector from dlib
detector = dlib.get_frontal_face_detector()

# Load the pre-trained facial landmarks predictor from dlib
predictor = dlib.shape_predictor("shape_predictor_68_face_landmarks.dat")

# Load the pre-trained face recognition model from dlib
face_recognizer = dlib.face_recognition_model_v1("dlib_face_recognition_resnet_model_v1.dat")

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
# Function to recognize faces in an image
# Function to recognize faces in an image
# Function to recognize faces in an image
def recognize_faces(known_faces, image_to_check):
    target_face_encodings = get_face_encodings(image_to_check)

    for i, known_face_encoding in enumerate(known_faces):
        for target_face_encoding in target_face_encodings:
            # Compare the face encodings using Euclidean distance
            distance = np.linalg.norm(np.array(known_face_encoding) - np.array(target_face_encoding))
            
            # You can adjust the distance threshold based on your application
            if distance < 0.6:
                print(f"Person {i + 1} recognized!")
                # You can perform further actions for recognized faces here

                # You can perform further actions for recognized faces here




# Load images of known faces and get their face encodings
known_face_images = ["O002_4.jpg", "O005_3.jpg"]  # Replace with your own images
known_faces = []

for image_path in known_face_images:
    known_image = cv2.imread(image_path)
    known_faces.extend(get_face_encodings(known_image))

# Capture video from the webcam
cap = cv2.VideoCapture(0)

while True:
    ret, frame = cap.read()

    # Perform face recognition on the current frame
    recognize_faces(known_faces, frame)

    # Display the frame
    cv2.imshow("Face Recognition", frame)

    # Break the loop when 'q' key is pressed
    if cv2.waitKey(1) & 0xFF == ord('q'):
        break

# Release the video capture object and close the OpenCV windows
cap.release()
cv2.destroyAllWindows()
