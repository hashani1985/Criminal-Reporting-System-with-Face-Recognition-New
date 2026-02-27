import tkinter as tk
#from receiver import ReceiverForm
import sys

def open_receiver_form():
    parameter = entry.get()
    #receiver = ReceiverForm(parameter)
    #receiver.show_form()

# Create the sender form
sender = tk.Tk()
sender.title("Sender Form")

label = tk.Label(sender, text="Enter Parameter:")
label.pack()


entry = sys.argv[1]
entry.pack()

button = tk.Button(sender, text="Open Receiver Form", command=open_receiver_form)
button.pack()

sender.mainloop()
