using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace GameEngine
{
    class Player : Entity
    {

        // Position of the Player relative to the upper left side of the screen
        public int screenLimitX;
        public int screenLimitY;
        public int bulletType = 0;
        public int lives;
        int health;
        GameInput GameInput;
        MyGame main;
        Collision collision;
       

        public Player(MyGame _main): base(_main){

            main = _main;
            GameInput = main.Services.GetService(typeof(GameInput)) as GameInput;
            collision = main.Services.GetService(typeof(Collision)) as Collision;
          
            collision.list.Add(this);
            Initialize();
            
        }

        public void Initialize() {

            //change this into vector 2 later
            screenLimitX = (int)main.GraphicsDevice.Viewport.TitleSafeArea.Width;
            screenLimitY = (int)main.GraphicsDevice.Viewport.TitleSafeArea.Height;
            tag = "player";
            lives = 3;
            health = 1;
            this.texture = sprite.player;
            Vector2 playerPosition = new Vector2( main.GraphicsDevice.Viewport.TitleSafeArea.Width / 2, main.GraphicsDevice.Viewport.TitleSafeArea.Height - 32);
            position = playerPosition;
           
            base.Initialize();
            
        }


        public override void Update(GameTime gameTime)
        {

            if (main.utility.paused) return;
            Respawn();
            if (dead) return;
            damageTimeOut++;
            DamageSmoke();
            
            UpdateBullets();
            Movement();
            base.Update(gameTime);
        }

        public  float speedX = 0.0f;
        float speedY = 0.0f;
        const float MAX_SPEED = 15.0f;
        const float ACCEL = 5.0f;
        const float DEACCEL = 10.0f;

        public void Movement()
        {
             // Joystick
            if (GameInput.THUMBSTICK_LEFT_X < -0.1f )speedX -= (speedX - MAX_SPEED) / ACCEL;
            if (GameInput.THUMBSTICK_LEFT_X > 0.1f) speedX -= (speedX + MAX_SPEED) / ACCEL;
            if (GameInput.THUMBSTICK_LEFT_Y < -0.1f) speedY -= (speedY + MAX_SPEED) / ACCEL;
            if (GameInput.THUMBSTICK_LEFT_Y > 0.1f) speedY -= (speedY - MAX_SPEED) / ACCEL;

             // Keyboard
            if (GameInput.LEFT) speedX -= (speedX - MAX_SPEED) / ACCEL;
            if (GameInput.RIGHT) speedX -= (speedX + MAX_SPEED) / ACCEL;
            if (GameInput.UP) speedY -= (speedY - MAX_SPEED) / ACCEL;
            if (GameInput.DOWN) speedY -= (speedY + MAX_SPEED) / ACCEL;

            speedX -= (speedX - 0) / DEACCEL;
            position.X -= speedX;
            speedY -= (speedY - 0) / DEACCEL;
            position.Y -= speedY;

            //rotation
            rotation = -speedX / 50;

            // Clamp to screen
            position.X = MathHelper.Clamp(position.X, width / 2, screenLimitX - width/2);
            position.Y = MathHelper.Clamp(position.Y, height / 2, screenLimitY - height/2);
            
        }

        int bTimer = 100;
        int damageTimeOut = 0;
        void UpdateBullets()
        {

            bTimer++;
            if (bTimer > 10)//20
            {
                if (bulletType == 0)
                {
                    Bullet b = new Bullet(main);
                    b.Initialize(position, 0);
                } else if (bulletType == 1)
                {

                    Bullet b;
                    b = new Bullet(main);
                    b.Initialize(position + new Vector2(-20, 0), 0);
                    b = new Bullet(main);
                    b.Initialize(position + new Vector2(20, 0), 0);
                    
                } else if( bulletType == 2) {
                    Bullet b;
                    b = new Bullet(main);
                    b.Initialize(position + new Vector2(-30, 0), 0);
                    b = new Bullet(main);
                    b.Initialize(position, 0);
                    b = new Bullet(main);
                    b.Initialize(position + new Vector2(30, 0), 0);
                }

                    bTimer = 0;
            }
        }

        public void DamageSmoke()
        {
            if (health < 1)
            {
                Explosion exp = new Explosion(main);
                exp.Initialize(position);
                exp.Trail();
            }
        }

        
        public void Kill(int amount)
        {
            dead = true;
            tag = "dead";
            alpha = 0;
            respawnTimer = 100;

            //particles
            while (amount > 0)
            {
                Explosion exp = new Explosion(main);
                exp.Initialize(position);
                amount--;
            }
        }
        int respawnTimer = 0;
        bool dead = false;
        void Respawn()
        {
            respawnTimer--;
            if (respawnTimer == 0)
            {
                bulletType = 0;
                alpha = 1;
                speedX = speedY = 0;
                position = new Vector2(main.GraphicsDevice.Viewport.TitleSafeArea.Width / 2, main.GraphicsDevice.Viewport.TitleSafeArea.Height - 32);
                tag = "player";
                dead = false;
            }
        }
        public void TakeDamage()
        {
            if (damageTimeOut > 20)
            {
               
                health--;
                speedY = -10;
                
                if (health < 0)
                {
                    Kill(10);
                    
                    
                    if (lives > 0) lives--;

                    health = 1;

                }
                damageTimeOut = 0;
            }

        }

        public override void OnCollision(Entity collider = default(Entity))
        {
            switch (collider.tag)
            {

                case "powerup":
                    
                    //if (Mathf.Distance(position, collider.position) < 15)
                    //{
                        if (collider.name == "oneUp")
                        {
                            if (collider.scale > 0.9f)
                            {
                                lives++;
                                collider.scale = 0.8f;
                            }

                        }
                        else if (collider.name == "bulletx1")
                            bulletType = 0;
                        else if (collider.name == "bulletx2")
                            bulletType = 1;
                        else if (collider.name == "bulletx3")
                            bulletType = 2;
                        else if (collider.name == "clear") { }
                           
                    //}
                    
                    break;

                case "enemy":
                    
                    TakeDamage();
                    

                 break;

                default:
                    
                   // position = position + new Vector2(Mathf.RandomRange(-10, 10), 0);
                   // 
                    break;


            }
        }


    }
}
