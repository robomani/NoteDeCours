# Private critter
#Demonstrate private variable and methode

class Critter(object):
    def __init__(self, name, mood):
        print("A new critter is born!")
        self.name = name        #puplic
        self.__mood = mood      #private

    def talk(self):
        print("\nI'm", self.name)
        print("Right now I feel", self.__mood, "\n")

    def __private_method(self):
        print("this is a private method")

    def public_method(self):
        print("this is a public method")
        self.__private_method()

#main
crit = Critter(name = "Poochie", mood = "happy")
crit.talk()
crit.public_method()

print(crit.__mood)
crit.__private_method()

input("\n\nPress enter to exit")
