# Games
# Demonstrates module creation

class Player(object):
    """A player for a game"""
    def __init__(self, name, score = 0):
        self.name = name
        self.score = score

    def __str__(self):
        rep = self.name + ":\t" + str(self.score)
        return rep

def ask_yes_no(question):
    """Ask a yes or no question."""
    answer = None
    while answer not in ("y", "n"):
        answer = input(question).lower()
    return answer

def ask_number(question, low, high):
    """Ask for a number within a range."""
    answer = None
    while answer not in range(low, high):
        answer = input(question)
        if answer.isnumeric():
            answer = int(answer)
    return answer

if __name__ == "__main__":
    print("You ran this module directly(instead of importing it)")
    input("\n\nPress the enter key to exit.")

