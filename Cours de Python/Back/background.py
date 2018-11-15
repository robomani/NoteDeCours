# Background
# Demonstrate setting the background image of a graphics screen

from livewires import games
import random

games.init(screen_width = 640, screen_height = 480, fps = 50)

class FollowMouse(games.Sprite):
    """ An image controlled by the mouse"""
    def update(self):
        """ Move to mouse position """
        self.x = games.mouse.x
        self.y = games.mouse.y
        self.check_collider()

    def check_collider(self):
        """ Check collision with shield """
        for chef in self.overlapping_sprites:
            chef.handle_collide()

class Chef(games.Sprite):
    """ a slippery chef """
    def handle_collide(self):
        """ Move to random pos in screen """
        self.x = random.randrange(games.screen.width)
        self.y = random.randrange(games.screen.height)

def main():
    fateImage = games.load_image("wall.jpg", transparent = False)
    games.screen.background = fateImage

    chefImage = games.load_image("chef.bmp")
    chefPosX = random.randrange(games.screen.width)
    chefPosY = random.randrange(games.screen.height)
    chef = Chef(image = chefImage, x = chefPosX, y = chefPosY)
    games.screen.add(chef)

    mouseFollowImage = games.load_image("Chakram.png")
    mouseFollow = FollowMouse(image = mouseFollowImage)
    games.screen.add(mouseFollow)

    games.mouse.is_visible = False

    games.screen.event_grab = True

    games.screen.mainloop()

# Start the game
main()
