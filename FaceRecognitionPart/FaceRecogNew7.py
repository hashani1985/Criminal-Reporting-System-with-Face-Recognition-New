import pyodbc
import tensorflow as tf
from tensorflow.keras.preprocessing import image
from tensorflow.keras.applications.mobilenet_v2 import MobileNetV2, preprocess_input, decode_predictions
import numpy as np

# Database connection settings
#server = 'your_server'
#database = 'your_database'
#username = 'your_username'
#password = 'your_password'
table_name = 'Offenders'
image_column = 'ImageData'
id_column = 'OffenderId'
id_value = 1  # Specify the ID of the image you want to recognize

# Connect to the database
connection = pyodbc.connect('Driver={SQL Server};Server=DESKTOP-BU7QFI6\SQLEXPRESS;Database=CriminalReportingDB')
#connection = pyodbc.connect(connection_string)

# Retrieve the image data from the database
query = f"SELECT {image_column} FROM {table_name} WHERE {id_column} = ?"
cursor = connection.cursor()
cursor.execute(query, id_value)
image_data = cursor.fetchone()[0]

# Save the image data to a temporary file
temp_image_path = 'temp_image.jpg'
with open(temp_image_path, 'wb') as img_file:
    img_file.write(image_data)

# Load the image using TensorFlow and preprocess it
img = image.load_img(temp_image_path, target_size=(224, 224))
img_array = image.img_to_array(img)
img_array = np.expand_dims(img_array, axis=0)
img_array = preprocess_input(img_array)

# Load the pre-trained MobileNetV2 model
model = MobileNetV2(weights='imagenet')

# Make predictions
predictions = model.predict(img_array)

# Decode and print the top predicted classes
decoded_predictions = decode_predictions(predictions, top=3)[0]
print(f"Top predictions for image {id_value}:")
for i, (imagenet_id, label, score) in enumerate(decoded_predictions):
    print(f"{i + 1}: {label} ({score:.2f})")

# Close the database connection
cursor.close()
connection.close()
