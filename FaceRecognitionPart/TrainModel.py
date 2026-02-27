from keras.models import Sequential
from keras.layers import Dense, Flatten
import numpy as np
import os
import cv2
import dlib


# Function to get the images and labels for training
def get_images_and_labels(dataset_path):
    images = []
    labels = []
    label_id = 0

    for root, dirs, files in os.walk(dataset_path):
        for dir_name in dirs:
            label_id += 1
            subject_path = os.path.join(root, dir_name)

            for filename in os.listdir(subject_path):
                img_path = os.path.join(subject_path, filename)
                img = cv2.imread(img_path, cv2.IMREAD_GRAYSCALE)

                images.append(img)
                labels.append(label_id)

    return np.array(images), np.array(labels)

# Path to the dataset (each person in a separate folder)
dataset_path = "captured_images"
images, labels = get_images_and_labels(dataset_path)

# Create a simple neural network for face recognition
model = Sequential()
model.add(Flatten(input_shape=(images.shape[1], images.shape[2])))
model.add(Dense(128, activation='relu'))
model.add(Dense(labels.max() + 1, activation='softmax'))

# Compile the model
model.compile(optimizer='adam', loss='sparse_categorical_crossentropy', metrics=['accuracy'])

# Train the model
model.fit(images, labels, epochs=10)

# Save the trained model to a file
model.save('my_model.keras')
