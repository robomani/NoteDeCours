# Score

from livewires import games, color
import random

games.init(screen_width = 640, screen_height = 480, fps = 50)

class Pizza(games.Sprite):
    def update(self):
        """ Reverse a velocity component if edge of screen reached. """
        if self.right > games.screen.width or self.left < 0:
            self.dx = -self.dx
            score.value = value + 1

        if self.bottom > games.screen.height or self.top < 0:
            self.dy = -self.dy
            score.value = value + 1

def main():
    wallImage = games.load_image("wall.jpg", transparent = False)
    games.screen.background = wallImage

    pizzaImage = games.load_image("pizza.bmp")
    pizza = Pizza(image = pizzaImage, x = games.screen.width/2, y = games.screen.height/2, dx = 1, dy = 1)

    games.screen.add(pizza)
    
    score = games.Text(value = 0, size = 60, color = color.black, x = 550. y = 30)
    games.screen.add(score)
    
    games.screen.mainloop()


main()
