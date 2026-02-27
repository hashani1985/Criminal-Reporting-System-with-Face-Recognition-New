
import sys
import tkinter as tk



#def main():
    #if len(sys.argv) != 2:
        #print("Usage: python your_python_script.py <parameter1> ")
        #return

#parameter1 = sys.argv[1]

print(sys.executable)

    

    # Process the parameters
    #print(f"Received parameter1: {parameter1}")
   

#if __name__ == '__main__':
 #   main()




# Create the main application window
app = tk.Tk()
app.title("Display Parameter in Label")

# Function to set the label text
def set_label_text(parameter):
    label.config(text=f"Received Parameter: {parameter}")

# Get the parameter from the command line arguments (sys.argv)
if len(sys.argv) > 1:
    parameter1 = sys.argv[1]
else:
    parameter1 = "No parameter received"

# Create a Label widget
label = tk.Label(app, text="", font=("Arial", 12))
label.pack(pady=20)

# Set the label text initially
set_label_text(parameter1)

# Run the Tkinter main loop
app.mainloop()



