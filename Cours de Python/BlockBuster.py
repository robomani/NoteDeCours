# Movie chooser
# Binding check buttons

from tkinter import *

class Application(Frame):
    """ GUI application that count button clicks """
    def __init__(self, master):
        super(Application, self).__init__(master)
        self.grid()
        self.createWidget()

    def createWidget(self):
        Label(self, text = "Choose your favorite movie types").grid(row = 0, column = 0, sticky = W)

        # create instruction label
        Label(self, text = "Select all that apply:").grid(row = 1, column = 0, sticky = W)

        # create Comedy check button
        self.likes_comedy = BooleanVar()
        Checkbutton(self, text = "Comedy", variable = self.likes_comedy, command = self.updateText).grid(row = 2, column = 1, sticky = W)

        self.likes_drama = BooleanVar()
        Checkbutton(self, text = "Drama", variable = self.likes_drama, command = self.updateText).grid(row = 2, column = 2, sticky = W)

        self.likes_romance = BooleanVar()
        Checkbutton(self, text = "Romance", variable = self.likes_romance, command = self.updateText).grid(row = 2, column = 3, sticky = W)

        # create text feild to display results
        self.results_text = Text(self, width = 40, height = 5, wrap = WORD)
        self.results_text.grid(row = 3, column = 0, columnspan = 3)

    def updateText(self):
        """Update text widget and display user's favorite movie types. """
        likes = ""

        if self.likes_comedy.get():
            likes += "You like comedic movies. \n"

        if self.likes_drama.get():
            likes += "You like dramatic movies. \n"

        if self.likes_romance.get():
            likes += "You like romantic movies. \n"

        self.results_text.delete(0.0, END)
        self.results_text.insert(0.0, likes)
                           
root = Tk()
root.title("Click counter")
root.geometry("400x200")
app = Application(root)

root.mainloop()
