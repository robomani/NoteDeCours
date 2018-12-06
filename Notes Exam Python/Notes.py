#Feuilles de notes

from livewires import games
from livewires import color
import random
import math

# La fenêtre de jeu
games.init(screen_width = 800, screen_height = 600, fps = 50)

#load sound file
#missileSound = games.load_sound("missile.wav")

#load the music file
#games.music.load("theme.mid")

cooldown = 2
ShootDown = 4
points = 0

explosionFiles = ["explosion1.bmp",
                        "explosion2.bmp",
                        "explosion3.bmp",
                        "explosion4.bmp",
                        "explosion5.bmp",
                        "explosion6.bmp",
                        "explosion7.bmp",
                        "explosion8.bmp",
                        "explosion9.bmp",]


class TextScore(games.Text):
    def handle_collide(self):
        """ Move to random pos in screen """
        self.x = self.x



class FollowMouse(games.Sprite):
    """ comme def __init__(self): pour un games.Sprite"""
    def start(self):
        constructor = True
		
    """ An image controlled by the mouse"""
    def update(self):
        """ Move to mouse position """
        self.x = games.mouse.x
        self.y = games.mouse.y  
    def handle_collide(self):
        """ Move to random pos in screen """
        self.x = self.x
    

class Explosion(games.Animation):
    """ An explosion at mouse coordinate"""
    def update(self):
        self.x = games.mouse.x
        self.y = games.mouse.y 
        self.check_collider()
    def handle_collide(self):
        """ Move to random pos in screen """
        self.x = self.x
    def check_collider(self):
        """ Check collision with shield """
        for sprite in self.overlapping_sprites:
            sprite.handle_collide()

class Teleporter(games.Sprite):
    """ a teleporting sprite """
    def handle_collide(self):
        """ Move to random pos in screen """
        self.x = random.randrange(games.screen.width)
        self.y = random.randrange(games.screen.height)
        global points
        points += 1
        Score.value = "Score : " + str(points)

class Tank(games.Sprite):
    """ a Tank """
    def update(self):
        self.angle = math.degrees(math.atan2((self.y - games.mouse.y),(self.x - games.mouse.x))) +270
        global cooldown
        global ShootDown
        if cooldown <= 0:
            if games.keyboard.is_pressed(games.K_a):
                self.x = self.x - 1
                cooldown = 2
            elif games.keyboard.is_pressed(games.K_d):
                self.x = self.x + 1
                cooldown = 2
            if games.keyboard.is_pressed(games.K_w):
                self.y = self.y - 1
                cooldown = 2
            elif games.keyboard.is_pressed(games.K_s):
                self.y = self.y + 1
                cooldown = 2
        else:
            cooldown -= 1
            ShootDown -= 1
        if games.mouse.is_pressed(0) and ShootDown <= 0:
            boom = Explosion(images = explosionFiles,
                            x = games.mouse.x,
                            y = games.mouse.y,
                            n_repeats = 1,
                            repeat_interval = 5)
            games.screen.add(boom)
            #missileSound.play()
    def handle_collide(self):
        """ Move to random pos in screen """
        self.x = self.x
    

Score = TextScore("Score : ", 30, color.red, x = 70, y = 50)
def main():
    backgroundImage = games.load_image("nebula.jpg", transparent = False)
    games.screen.background = backgroundImage

    teleportImage = games.load_image("head.jpg")
    PosX = random.randrange(games.screen.width)
    PosY = random.randrange(games.screen.height)
    teleport = Teleporter(image = teleportImage, x = PosX, y = PosY)
    games.screen.add(teleport)


    target = games.load_image("Chakram.gif")
    mouseFollow = FollowMouse(image = target,
                                x = games.screen.width/2,
                                y = games.screen.height/2,)
    
    games.screen.add(mouseFollow)

    teleportImage = games.load_image("Arm.jpg")
    tank = Tank(image = teleportImage,
                x = games.screen.width/2,
                y = games.screen.height/2,)
    games.screen.add(tank)


    Score.value = "Score : " + str(points)
    games.screen.add(Score)

    # -1 == forever else == nbr time
    #games.music.play(-1)
    
    
    #mouse Visibility
    games.mouse.is_visible = False
    
    #lock mouse in screen
    games.screen.event_grab = True

    games.screen.mainloop()

# Start the game
main()

