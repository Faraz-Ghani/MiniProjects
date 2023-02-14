import pygame

class enemy:
    enemyx=5
    enemyy=5
    sliding=False

pygame.init()

# Set up the drawing window
clock =pygame.time.Clock()

screen = pygame.display.set_mode([800,400])

background =pygame.image.load("bg.png")
background = pygame.transform.rotozoom(background,0,2.5)

ball =pygame.image.load("ball.png")
ball=pygame.transform.rotozoom(ball,0,0.1)
ball_rect=ball.get_rect(topleft=(20,300))


acc = False
down=False
grav = False
count = 0
count2 = 0
running = True

#enemy
enemyx=600
enemyy= 175
sliding = False

def enemymove():
    global enemy_rect 
    enemy_rect.right-=5    

def move():
        global ball_rect
        global ball
        ball_rect.left+=10
        ball=pygame.transform.rotate(ball,90)

def jump(): 
    global ball_rect
    global grav
    if ball_rect.bottom<=300:
        grav=True

enemy_surf = pygame.image.load('enemy.png')    
enemy_surf = pygame.transform.rotozoom(enemy_surf,0,0.7)    
enemy_rect =enemy_surf.get_rect(topleft = (enemyx,enemyy))

while running:
    
    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            running = False

        
        

        if event.type == pygame.KEYDOWN:

            if event.key == pygame.K_d:
                move()
        
            if event.key == pygame.K_w:
                jump()

               
              
    screen.fill((255, 255, 255))
    #collision()
    #move()
    enemymove()
#move across screen
    if ball_rect.left>810:
        ball_rect.right=-50
    
    #slide
    

#fall down
    if down: 
        if(count2>0):
            ball_rect.bottom+=10
            count2-=1


#jump distance
    if count>=10:
        grav=False
        count=0
        down = True
        count2+=10
        
#go up
    if grav :
        ball_rect.bottom-=10
        count+=1
    
    



    # if acc== False:
    #     ballx-=30
    #     count-=1
    #     if count==0:
    #         acc=True


    #blits
    screen.blit(background,(0,-400))
    screen.blit(ball,ball_rect)
    screen.blit(enemy_surf,enemy_rect)
    
    pygame.display.flip()
    clock.tick(30)
    