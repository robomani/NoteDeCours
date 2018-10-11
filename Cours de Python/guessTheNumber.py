#Gess my number
#
#The computer picks a random number between 1 and 100
#the player tries to gess it and the computer lets
#the player konw if the gess is to high, to low or right

import random

print("\tWelcome to 'Guess my number' !")
print("\nI'm thinking of a number between 1 and 100.")
print("Try to guess it in as few attemps as possible. \n")

mode = input("chose your difficulty: Easy(e) / Hard (h)")

if mode == "e":
    # set the initial value
    theNumber = random.randint(1,100)
    guess = int(input("Take a guess: "))
    tries = 1

elif mode == "h":
    # set the initial value
    temp = random.randint(1,10000)
    theNumber = float(temp/100)
    guess = float(input("Take a guess: "))
    tries = 1

#guessing loop
while guess != theNumber:
    if guess < theNumber:
        print("To low")
    elif guess > theNumber:
        print("To high")

    if mode == "e"
        guess = int(input("Take a guess: "))
    else:
        guess = float(input("Take a guess: "))
    tries += 1
    

print("You won in ", tries, " tries.")

input("Press any key to end")
