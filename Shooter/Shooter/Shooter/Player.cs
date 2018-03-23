using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Shooter
{
    class Player : Entity
    {

        // Position of the Player relative to the upper left side of the screen
        public int health;
        public int screenLimitX;
        public int screenLimitY;
        public int bulletType = 0;
        public bool clearAll = false;
        PlayerInput playerInput;
        Game game;

        public Player(Game game){
            this.game = game;
            playerInput = game.Services.GetService(typeof(PlayerInput)) as PlayerInput;
        }

        public void Initialize(Texture2D texture, Vector2 position, Vector2 screenLimit) {

            //change this into vector 2 later
            screenLimitX = (int)screenLimit.X;
            screenLimitY = (int)screenLimit.Y;
            tag = "player";
            this.texture = texture;
            base.position = position;
            active = true;
            health = 0;
            
        }


        public override void Update()
        {
            Movement();
        }

        public  float speedX = 0.0f;
        float speedY = 0.0f;
        const float MAX_SPEED = 15.0f;
        const float ACCEL = 5.0f;
        const float DEACCEL = 10.0f;

        public void Movement()
        {
             // Joystick
            if (playerInput.THUMBSTICK_LEFT_X < -0.1f )speedX -= (speedX - MAX_SPEED) / ACCEL;
            if (playerInput.THUMBSTICK_LEFT_X > 0.1f) speedX -= (speedX + MAX_SPEED) / ACCEL;
            if (playerInput.THUMBSTICK_LEFT_Y < -0.1f) speedY -= (speedY + MAX_SPEED) / ACCEL;
            if (playerInput.THUMBSTICK_LEFT_Y > 0.1f) speedY -= (speedY - MAX_SPEED) / ACCEL;

             // Keyboard
            if (playerInput.LEFT) speedX -= (speedX - MAX_SPEED) / ACCEL;
            if (playerInput.RIGHT) speedX -= (speedX + MAX_SPEED) / ACCEL;
            if (playerInput.UP) speedY -= (speedY - MAX_SPEED) / ACCEL;
            if (playerInput.DOWN) speedY -= (speedY + MAX_SPEED) / ACCEL;

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

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, null, colour * alpha, rotation, new Vector2(32,32), 1f, SpriteEffects.None, 0f);
        }


        public override void OnCollision(String other_tag = "", Vector2 other_position = default(Vector2), String other_name = "")
        {
            switch (other_tag)
            {

                case "powerup":

                    if (Mathf.Distance(position, other_position) < 15)
                    {
                        if (other_name == "oneUp")
                        {
                            alpha = 1;
                            health++;
                        }
                        else if (other_name == "bulletx1")
                            bulletType = 0;
                        else if (other_name == "bulletx2")
                            bulletType = 1;
                        else if (other_name == "bulletx3")
                            bulletType = 2;
                        else if (other_name == "clear")
                            clearAll = true;
                    }
                    
                    break;

                default:
                    alpha = 0.5f;
                    position = position + new Vector2(Mathf.RandomRange(-10, 10), +10);
                    break;


            }
        }


    }
}
