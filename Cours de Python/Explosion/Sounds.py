# Sound and music

from livewires import games

games.init(screen_width = 640, screen_height = 480, fps = 50)

#load sound file
missileSound = games.load_sound("missile.wav")

#load the music file
games.music.load("theme.mid")

choice = None
while choice != "0":

    print(
        """
        Sound and Music

        0 - Quit
        1 - Play missile sound
        2 - Loop missile sound
        3 - Stop missile sound
        4 - Play theme music
        5 - Loop theme music
        6 - Stop theme music
        """)

    choice = input("Choice: ")
    print()

    if choice == "0":
        print("Good bye.")

    elif choice == "1":
        missileSound.play()
        print("Playing missile sound.")

    elif choice == "2":
        missileSound.play(5)
        # -1 == forever else == nbr time
        print("Looping missile sound 5 times.")

    elif choice == "3":
        missileSound.stop()
        print("Stopping missile sound.")

    elif choice == "4":
        games.music.play()
        print("Playing the music.")

    elif choice == "5":
        games.music.play(-1)
        print("loop the music.")

    elif choice == "6":
        games.music.stop()
        print("stop the music.")

    else:
        print("\n Sorry, but", choice, "isn't a valid choice")

input("\n\nPress the enter key to exit")
