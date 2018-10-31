# Lasy buttons
# Demonstrate creating button

from tkinter import *

# create the root window
root = Tk()

# modify the window
root.title("Lazy Buttons")
root.geometry("200x85")

#create a frame in the window to hold other widgets
app = Frame(root)
app.grid()

#create a button in the frame
bttn1 = Button(app, text = "I do nothing!")
bttn1.grid()

# create a second button in the frame
bttn2 = Button(app)
bttn2.grid()
bttn2.configure(text = "Me too!")

#create a third button in the frame
bttn3 = Button(app)
bttn3.grid()
bttn3["text"] = "same here !"

# kick of the window's event-loop
root.mainloop()
