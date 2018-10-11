#Receive and return
#Demonstrate parameters and return value

def display(message):
    print(message)

def give_me_five():
    five = 5
    return five

def ask_yes_no(question):
    """Ask a yes no question"""
    answer = None
    while answer not in ("y", "n"):
        answer = input(question).lower()
    return answer

display("Here's a message. \n")

number = give_me_five()
print(number)
display(give_me_five())
answer = ask_yes_no("Do you like me")
display(answer)


input("\n\nPress enter to quit")
