# Bounce Pizza

from livewires import games
import random

games.init(screen_width = 640, screen_height = 480, fps = 50)

class Pizza(games.Sprite):
    def update(self):
        """ Reverse a velocity component if edge of screen reached. """
        if self.right > games.screen.width or self.left < 0:
            self.dx = -self.dx

        if self.bottom > games.screen.height or self.top < 0:
            self.dy = -self.dy

def main():
    wallImage = games.load_image("wall.jpg", transparent = False)
    games.screen.background = wallImage

    pizzaImage = games.load_image("pizza.bmp")
    pizza = Pizza(image = pizzaImage, x = games.screen.width/2, y = games.screen.height/2, dx = 1, dy = 1)

    games.screen.add(pizza)
    
    games.screen.mainloop()

main()
