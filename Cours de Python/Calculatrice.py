while True:
    print("Options:")
    print("Enter 'add' to add numbers")
    print("Enter 'substract' to substract numbers")
    print("Enter 'multiply' to multiply numbers")
    print("Enter 'divide' to divide numbers")
    print("Enter 'quit' to end the program")
    userInput = input(": ")

    if userInput == "quit":
        break
    elif userInput == "add":
        num1 = float(input("Enter a number: "))
        num2 = float(input("Enter another number: "))
        result = num1 + num2
        print(result)
    elif userInput == "substract":
        num1 = float(input("Enter a number: "))
        num2 = float(input("Enter another number: "))
        result = num1 - num2
        print(result)
    elif userInput == "multiply":
        num1 = float(input("Enter a number: "))
        num2 = float(input("Enter another number: "))
        result = num1 * num2
        print(result)
    elif userInput == "divide":
        num1 = float(input("Enter a number: "))
        num2 = float(input("Enter another number not 0: "))
        if num2 != 0:
            result = num1 / num2
        else:
            num2 = float(input("Enter another number not 0: "))
        print(result)
    else:
        print("You rebel this is not a valid choice!")
    
