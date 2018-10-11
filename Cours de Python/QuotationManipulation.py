# Quote manipulation
# Demonstrate string methode

quote = "We are going to dream of things ."

print("Original quote: ")
print(quote)

print("\nUpperCase:")
print(quote.upper())

print("\nLowerCase:")
print(quote.lower())

print("\nTitle:")
print(quote.title())

print("\nWith a minor remplacement:")
print(quote.replace("things", "furries"))

print("\nOriginal quote is still:")
print(quote)

quote = "Fake news "
quote1 = "Fake "
quote2 = "news "

print((quote1 + quote2)*5)

input("\n\nPress enter to exit")
