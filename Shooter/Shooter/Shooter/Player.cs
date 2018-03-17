using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Shooter
{
    class Player
    {
        // Animation representing the player
        public Texture2D PlayerTexture;

        // Position of the Player relative to the upper left side of the screen
        public Vector2 Position;
      
        // State of the player
        public bool Active;

        // Amount of hit points that player has
        public int Health;

        // Get the width of the player ship
        public int Width
        {
            get { return PlayerTexture.Width; }
        }

        // Get the height of the player ship
        public int Height
        {
           
            get { return PlayerTexture.Height; }

            
        }

        float playerMoveSpeed = 8.0f;
        public int ScreenLimitX;
        public int ScreenLimitY;

      
        public void Initialize(Texture2D texture, Vector2 position)
        {

            
            PlayerTexture = texture;

            // Set the starting position of the player around the middle of the screen and to the back
            Position = position;

            // Set the player to be active
            Active = true;

            // Set the player health
            Health = 100;
            
        }


        public void Update()
        {
            Movement();
        }

        public void Movement()
        {


             // Get Thumbstick Controls
            Position.X += PLAYER_INPUT.THUMBSTICK_LEFT_X * playerMoveSpeed;
            Position.Y -= PLAYER_INPUT.THUMBSTICK_LEFT_Y * playerMoveSpeed;
            
            // Use the Keyboard / Dpad
            // - maybe make am iput class later
            if ( PLAYER_INPUT.LEFT ) Position.X -= playerMoveSpeed; 
            if (PLAYER_INPUT.RIGHT) Position.X += playerMoveSpeed;
            if (PLAYER_INPUT.UP) Position.Y -= playerMoveSpeed;
            if (PLAYER_INPUT.DOWN) Position.Y += playerMoveSpeed;
            

            // Make sure that the player does not go out of bounds
            Position.X = MathHelper.Clamp(Position.X, 0, ScreenLimitX - Width);
            Position.Y = MathHelper.Clamp(Position.Y, 0, ScreenLimitY - Height);

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(PlayerTexture, Position, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }


    }
}
