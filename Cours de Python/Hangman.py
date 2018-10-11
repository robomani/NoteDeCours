#Hangman Game

import random

# constants
HANGMAN = (
"""
 ------
 |    |
 |
 |
 |
 |
 |
 |
 |
----------
""",
"""
 ------
 |    |
 |    O
 |
 |
 |
 |
 |
 |
----------
""",
"""
 ------
 |    |
 |    O
 |   -+-
 | 
 |   
 |   
 |   
 |   
----------
""",
"""
 ------
 |    |
 |    O
 |  /-+-
 |   
 |   
 |   
 |   
 |   
----------
""",
"""
 ------
 |    |
 |    O
 |  /-+-/
 |   
 |   
 |   
 |   
 |   
----------
""",
"""
 ------
 |    |
 |    O
 |  /-+-/
 |    |
 |   
 |   
 |   
 |   
----------
""",
"""
 ------
 |    |
 |    O
 |  /-+-/
 |    |
 |    |
 |   | 
 |   | 
 |   
----------
""",
"""
 ------
 |    |
 |    O
 |  /-+-/
 |    |
 |    |
 |   | |
 |   | |
 |  
----------
""")

MAX_WRONG = len(HANGMAN) - 1
WORDS = ("STAMINA", "OVERUSED", "MEXICAN", "PYTHON", "BRIAN", "TRILLIONS", "LOAN")

# INITIALISE VARRIABLE

word = random.choice(WORDS)
progression = "-" * len(word)
wrong = 0
used = []


print("Welcome to Hangman. Good luck!")

while wrong < MAX_WRONG and progression != word:
    print(HANGMAN[wrong])
    print("\nYou've used the following letters : \n", used)
    print("\nSo far, the word is:\n", progression)

    guess = input("\nEnter your guess: ")
    guess = guess.upper()

    while guess in used:
        print("You've already guessed this letter", guess)
        guess = input("\nEnter your guess: ")
        guess = guess.upper()

    used.append(guess)

    if guess in word:
        print("\nYes!", guess, "is in the word!")
        new = ""
        for i in range(len(word)):
            if guess == word[i]:
                new += guess
            else:
                new += progression[i]

        progression = new
        
    else:
        print("\nSorry", guess, "isn't in the word")
        wrong += 1

if wrong == MAX_WRONG:
    print(HANGMAN[wrong])
    print("\nYou lost")
else:
    print("\nYou guessed it!")

print("The word was", word)

input("\n\nPress enter to quit")
