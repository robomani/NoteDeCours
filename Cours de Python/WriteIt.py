#write it
#demonstrate writing to a text file

print("Creating a text file with the write() methode.")
textFile = open("writeIt.txt", "w")
textFile.write("Line 1\n")
textFile.write("This is Line 2\n")
textFile.close()

print("\nReading the newly created file")
textFile = open("writeIt.txt", "r")
print(textFile.read())
textFile.close()

print("\nCreating a text file with the writelines() methode.")
textFile = open("writeIt.txt","w")
lines = ["1\n",
         "2\n",
         "3\n"]
textFile.writelines(lines)
textFile.close()

print("\nReading the newly created file.")
textFile = open("writeIt.txt", "r")
print(textFile.read())
textFile.close()

input("\n\nPress the enter key to exit")
