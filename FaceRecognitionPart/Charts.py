import sqlalchemy
import pandas as pd
from datetime import datetime, timedelta
from sklearn.model_selection import train_test_split
from sklearn.ensemble import RandomForestClassifier
import pyodbc

# Create an SQLAlchemy engine
engine = sqlalchemy.create_engine('mssql+pyodbc://DESKTOP-BU7QFI6\SQLEXPRESS/CriminalReportingDB?driver=SQL+Server&legacy_schema_aliasing=false')

#engine = sqlalchemy.create_engine('mssql+pyodbc://DESKTOP-BU7QFI6\SQLEXPRESS/CriminalReportingDB?driver=SQL+Server')
connection_string = 'DRIVER={SQL Server};SERVER=DESKTOP-BU7QFI6\SQLEXPRESS;DATABASE=CriminalReportingDB'
connection = pyodbc.connect(connection_string)

# Fetch crime records from the database
query = 'SELECT CrimeType, Date FROM CrimeRecords'
df = pd.read_sql(query, engine)

# Rest of your code remains the same...

# Fetch crime records from the database
query = 'SELECT CrimeType, Date FROM CrimeRecords'
df = pd.read_sql(query, connection)

# Convert the 'Date' column to datetime
df['Date'] = pd.to_datetime(df['Date'])

# Print the columns in the DataFrame
print("Columns in DataFrame:", df.columns)

# Extract month and year from the 'Date' column
df['Month'] = df['Date'].dt.month
df['Year'] = df['Date'].dt.year

# Assuming you have a 'CrimeType' column with categorical values
# You might need to preprocess this column based on your data

# Feature engineering: Convert categorical values to numerical using one-hot encoding
df = pd.get_dummies(df, columns=['CrimeType'])

try:
    X = df.drop(['CrimeType', 'Date'], axis=1)
except KeyError as e:
    print(f"Error: {e}")

# Train a simple predictive model (Random Forest in this example)
# X = df.drop(['CrimeType', 'Date'], axis=1)
y = df['CrimeType']
X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.2, random_state=42)

model = RandomForestClassifier(n_estimators=100, random_state=42)
model.fit(X_train, y_train)

# Make predictions for the next month
current_date = datetime.now()
next_month = current_date + timedelta(days=30)
next_month_features = [[next_month.month, next_month.year] + [0] * (len(df.columns)-2)]  # assuming all other crime types are 0
prediction = model.predict(next_month_features)

print(f"Predicted high crime type for next month: {prediction[0]}")

# Close the database connection
connection.close()
