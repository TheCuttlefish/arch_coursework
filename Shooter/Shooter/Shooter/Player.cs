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

        public void Initialize(Texture2D texture, Vector2 position) {
 
            this.texture = texture;
            base.position = position;
            active = true;
            health = 100;
            
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
            if (PLAYER_INPUT.THUMBSTICK_LEFT_X < -0.1f )speedX -= (speedX - MAX_SPEED) / ACCEL;
            if (PLAYER_INPUT.THUMBSTICK_LEFT_X > 0.1f) speedX -= (speedX + MAX_SPEED) / ACCEL;
            if (PLAYER_INPUT.THUMBSTICK_LEFT_Y < -0.1f) speedY -= (speedY + MAX_SPEED) / ACCEL;
            if (PLAYER_INPUT.THUMBSTICK_LEFT_Y > 0.1f) speedY -= (speedY - MAX_SPEED) / ACCEL;

             // Keyboard
            if (PLAYER_INPUT.LEFT) speedX -= (speedX - MAX_SPEED) / ACCEL;
            if (PLAYER_INPUT.RIGHT) speedX -= (speedX + MAX_SPEED) / ACCEL;
            if (PLAYER_INPUT.UP) speedY -= (speedY - MAX_SPEED) / ACCEL;
            if (PLAYER_INPUT.DOWN) speedY -= (speedY + MAX_SPEED) / ACCEL;

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
            spriteBatch.Draw(texture, position, null, Color.White, rotation, new Vector2(32,32), 1f, SpriteEffects.None, 0f);
        }


    }
}
