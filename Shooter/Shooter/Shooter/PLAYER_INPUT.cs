using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shooter
{
    public static class PLAYER_INPUT
    {


        //Keyboard
       public static  KeyboardState currentKeyboardState;
       public static KeyboardState previousKeyboardState;

       // Joystick
       public static GamePadState currentGamePadState;
       public static  GamePadState previousGamePadState;

        //Input names
        public static bool LEFT;
        public static bool RIGHT;
        public static bool UP;
        public static bool DOWN;
        public static float THUMBSTICK_LEFT_X;
        public static float THUMBSTICK_LEFT_Y;
        public static bool FIRE;
        public static bool QUIT;
        
        static public void Update()
        {
            previousGamePadState = currentGamePadState;
            previousKeyboardState = currentKeyboardState;

            // Read the current state of the keyboard and gamepad and store it
            currentKeyboardState = Keyboard.GetState();
            currentGamePadState = GamePad.GetState(PlayerIndex.One);

            LEFT = currentKeyboardState.IsKeyDown(Keys.Left) || currentKeyboardState.IsKeyDown(Keys.A) || currentGamePadState.DPad.Left == ButtonState.Pressed;
            RIGHT = currentKeyboardState.IsKeyDown(Keys.Right) || currentKeyboardState.IsKeyDown(Keys.D) || currentGamePadState.DPad.Right == ButtonState.Pressed;
            UP = currentKeyboardState.IsKeyDown(Keys.Up) || currentKeyboardState.IsKeyDown(Keys.W) || currentGamePadState.DPad.Up == ButtonState.Pressed;
            DOWN = currentKeyboardState.IsKeyDown(Keys.Down) || currentKeyboardState.IsKeyDown(Keys.S) || currentGamePadState.DPad.Down == ButtonState.Pressed;

            FIRE = currentKeyboardState.IsKeyDown(Keys.Space) || currentGamePadState.IsButtonDown(Buttons.A);

            THUMBSTICK_LEFT_X = currentGamePadState.ThumbSticks.Left.X;
            THUMBSTICK_LEFT_Y = currentGamePadState.ThumbSticks.Left.Y;

            QUIT =  GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || currentKeyboardState.IsKeyDown(Keys.Back);
        }



    }
}
