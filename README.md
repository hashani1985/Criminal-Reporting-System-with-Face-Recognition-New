Criminal Reporting System with Face Recognition
-----------------------------------------------

This project is a Windows-based Criminal Reporting System developed for the 
Assistant Commissioner of Excise Office – Galle, Sri Lanka. The system replaces 
traditional manual record-keeping with an automated solution for managing offender 
records, crime records, officer rewards, and offender identification using 
face recognition technology.

Technologies Used
-----------------
- C#.NET (Frontend & Backend)
- Microsoft SQL Server (Database)
- Python (Face Recognition module)
- TensorFlow (Training and recognition)
- OpenCV (Image capture and processing)

Main Features
-------------
1. Offender Data Management  
   - Add, update, delete offender details  
   - Store and retrieve offender information efficiently  
   - Prevent duplicate entries using NIC validation  

2. Crime Records Management  
   - Record new crimes  
   - Update and delete crime entries  
   - Generate monthly and yearly crime summaries  

3. Face Recognition Integration  
   - Capture offender images using webcam  
   - Perform face detection and recognition  
   - Match captured images with stored records  

4. Officer Reward Calculation  
   - Automatically calculate officer rewards based on detected offenses  
   - Generate reports for monthly and annual performance  

5. Reporting  
   - Generate reports for crime statistics  
   - Officer performance reports  
   - Offender history reports  

Project Aim
-----------
The system was developed to reduce paperwork, increase accuracy, speed up record 
retrieval, and introduce modern biometric technology into the Excise Department 
workflow.

How to Run
----------
1. Open the C#.NET solution in Visual Studio 2022.  
2. Restore the Microsoft SQL Server database using the included scripts.  
3. Ensure Python (with required libraries: OpenCV, TensorFlow, PIL, pyodbc) is installed.  
4. Update database connection strings if needed.  
5. Start the application from Visual Studio.  
6. Use the integrated Python GUI for the face recognition module.

Status
------
The system has been fully implemented, tested, and documented as part of a final 
year research project.

Author
------
K.B.H.V.S. De Silva  
London Metropolitan University  
2023
