using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Shooter
{
    class Player : Entity
    {
        // Animation representing the player
        public Texture2D PlayerTexture;

        // Position of the Player relative to the upper left side of the screen
        public int Health;
        public int Width { get { return PlayerTexture.Width; } }
        public int Height { get { return PlayerTexture.Height; } }
        float rotation = 0.0f;
        public int ScreenLimitX;
        public int ScreenLimitY;

      
        public void Initialize(Texture2D texture, Vector2 position) {
 
            PlayerTexture = texture;
            Position = position;
            Active = true;
            Health = 100;
            
        }


        public void Update()
        {
            Movement();
        }
       public  float xSpeed = 0.0f;
        float ySpeed = 0.0f;
        const float MAX_SPEED = 15.0f;
        const float ACCEL = 5.0f;
        const float DEACCEL = 10.0f;
        public void Movement()
        {
             // Joystick
            if (PLAYER_INPUT.THUMBSTICK_LEFT_X < -0.1f )xSpeed -= (xSpeed - MAX_SPEED) / ACCEL;
            if (PLAYER_INPUT.THUMBSTICK_LEFT_X > 0.1f) xSpeed -= (xSpeed + MAX_SPEED) / ACCEL;
            if (PLAYER_INPUT.THUMBSTICK_LEFT_Y < -0.1f) ySpeed -= (ySpeed + MAX_SPEED) / ACCEL;
            if (PLAYER_INPUT.THUMBSTICK_LEFT_Y > 0.1f) ySpeed -= (ySpeed - MAX_SPEED) / ACCEL;

             // Keyboard
            if (PLAYER_INPUT.LEFT) xSpeed -= (xSpeed - MAX_SPEED) / ACCEL;
            if (PLAYER_INPUT.RIGHT) xSpeed -= (xSpeed + MAX_SPEED) / ACCEL;
            if (PLAYER_INPUT.UP) ySpeed -= (ySpeed - MAX_SPEED) / ACCEL;
            if (PLAYER_INPUT.DOWN) ySpeed -= (ySpeed + MAX_SPEED) / ACCEL;

            xSpeed -= (xSpeed - 0) / DEACCEL;
            Position.X -= xSpeed;
            ySpeed -= (ySpeed - 0) / DEACCEL;
            Position.Y -= ySpeed;

            //rotation
            rotation = -xSpeed / 50;

            // Clamp to screen
            Position.X = MathHelper.Clamp(Position.X, Width / 2, ScreenLimitX - Width/2);
            Position.Y = MathHelper.Clamp(Position.Y, Height / 2, ScreenLimitY - Height/2);

        }

          public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(PlayerTexture, Position, null, Color.White, rotation, new Vector2(32,32), 1f, SpriteEffects.None, 0f);
        }


    }
}
