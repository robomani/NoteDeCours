# Lazy button 2
# Demonstrate using a class TKinter

from tkinter import *

class Application(Frame):
    """A GUI application with 3 buttons."""
    def __init__(self, master):
        """ Initialise the frame """
        super(Application, self).__init__(master)
        self.grid()
        self.createWidgets()

    def createWidgets(self):
        """ Create 3 buttons that do nothing """
        self.btn1 = Button(self, text = "Ido nothing!")
        self.btn1.grid()

        self.bttn2 = Button(self)
        self.bttn2.grid()
        self.bttn2.configure(text = "Me too!")

        self.bttn3 = Button(self)
        self.bttn3.grid()
        self.bttn3["text"] = "same here !"

#main
root = Tk()
root.title("Lazy buttons 2: The reckoning")
root.geometry("200x85")
app = Application(root)
root.mainloop()
