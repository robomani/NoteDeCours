# Birthday Wishes
#Demonstrate keywords arguments and default parameter values


def birthday1 (name, age):
    print("Happy Birthday", name, "!", " I hear you're", age, "today.\n")

# parameters with default values
def birthday2 (name = "Raven", age = 18):
    print("Happy Birthday", name, "!", " I hear you're", age, "today.\n")

birthday1("Jackson", 1)
birthday1(1, "Jackson")
birthday1(name = "Jackson", age = 1)

birthday2()
birthday2(age = 9)

input("Press enter to exit")
