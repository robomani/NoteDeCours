#Special counter
#Demonstrate the break and continue statments

count = 0

while True:
    count += 1
    #end loop if count grater than 10
    if count > 10:
        break
    # skip 5
    if count == 5:
        continue
    print(count)

input("\n\nPress any key to exit")
