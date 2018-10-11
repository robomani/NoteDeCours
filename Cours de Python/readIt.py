#ReadIt
#demonstrate reading from a text file.

textFile = open("writeIt.txt", "r")
print(textFile.read(1))
print(textFile.read(5))

textFile.close()

textFile = open("writeIt.txt", "r")
print(textFile.readline())
print(textFile.readline())
print(textFile.readline())
textFile.close()

textFile = open("writeIt.txt", "r")
lines = textFile.readlines()
print(lines)
print(len(lines))
for line in lines:
    print(line)
textFile.close()

textFile = open("writeIt.txt", "r")
for line in textFile:
    print(line)
textFile.close()
