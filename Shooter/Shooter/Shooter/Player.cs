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
        GameInput GameInput;
        Game main;

        public Player(Game _main): base(_main){

            main = _main;
            GameInput = main.Services.GetService(typeof(GameInput)) as GameInput;
            Initialize();
        }

        public void Initialize() {

            //change this into vector 2 later
            screenLimitX = (int)main.GraphicsDevice.Viewport.TitleSafeArea.Width;
            screenLimitY = (int)main.GraphicsDevice.Viewport.TitleSafeArea.Height;
            tag = "player";
            this.texture = sprite.player;
            Vector2 playerPosition = new Vector2( main.GraphicsDevice.Viewport.TitleSafeArea.Width / 2, main.GraphicsDevice.Viewport.TitleSafeArea.Height - 32);
            position = playerPosition;
            base.Initialize();
            
        }


        public override void Update(GameTime gameTime)
        {
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

                        }
                        else if (other_name == "bulletx1")
                            bulletType = 0;
                        else if (other_name == "bulletx2")
                            bulletType = 1;
                        else if (other_name == "bulletx3")
                            bulletType = 2;
                        else if (other_name == "clear") { }
                           
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
