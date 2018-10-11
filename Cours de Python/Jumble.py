#Word Jumble
#
#The computer pick a random word and then "Jumbles" it
#The player has to guess the original word

import random

# Create sequance of words to choose from
WORDS = ("python", "jumble", "easy", "difficult", "jimmy", "patin", "tipat", "answer", "xylophone")
#pick one word randomly from the sequence
word = random.choice(WORDS)
#Create a variable to use later to see if the guess is correct
correct = word

# create a jumbled version of the word
jumble = ""
while word:
    position = random.randrange(len(word))
    jumble += word[position]
    word = word[:position] + word[(position + 1):]

# Start game
print("Welcome to the jumble")
print("\nThe jumble word is:", jumble)

guess = input("Enter your guess: ")
while guess != correct and guess != "":
    print("Wrong")
    guess = input("Enter your guess: ")

if guess == correct:
    print("Right!")


print("Thanks for playing")

input("\n\nPress any key to end")
