# Labeler
# Demonstrate a label

from tkinter import *

# create the root window
root = Tk()
root.title("Labeler")
root.geometry("200x50")

# create a frame in the window to hold other widget
app = Frame(root)
app.grid()

# create a lable in the frame
lbl = Label(app, text = "I'm a lable")
lbl.grid()

# start the window's event loop
root.mainloop()
