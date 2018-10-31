# Click counter
# Binding an event with an event endler

from tkinter import *

class Application(Frame):
    """ GUI application that count button clicks """
    def __init__(self, master):
        super(Application, self).__init__(master)
        self.grid()
        self.btn_clicks = 0
        self.createWidget()

    def createWidget(self):
        self.btn = Button(self)
        self.btn.configure(text = "Total Clicks : 0")
        self.btn.configure(command = self.updateCount)
        self.btn.grid()

    def updateCount(self):
        """ Increase click count and display new total"""
        self.btn_clicks += 1
        self.btn["text"] = "Total clicks: " + str(self.btn_clicks)
                           
root = Tk()
root.title("Click counter")
root.geometry("200x50")
app = Application(root)

root.mainloop()
