#no vowels
#Demonstrate creating a new strings whit for x loop
target = input("Enter what you want: ")
message = input("Enter a message: ")
newMessage = ""
VOWELS = "aeiou"




print()
for letter in message:
    if letter.lower() not in VOWELS:
        newMessage += letter
        #print("A new string has benne created: ", newMessage)
    else:
        newMessage += target

print("\nYour message without vowels is: ", newMessage)

input("\n\nPress the enter key to exit.")
