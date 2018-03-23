using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;
using Newtonsoft.Json;

namespace Shooter
{
    public class PlayerInput
    {

        //Keyboard
       public  KeyboardState currentKeyboardState;
       public KeyboardState previousKeyboardState;

       // Joystick
       public GamePadState currentGamePadState;
       public  GamePadState previousGamePadState;

        //Input names
        public bool LEFT;
        public bool RIGHT;
        public bool UP;
        public bool DOWN;
        public float THUMBSTICK_LEFT_X;
        public float THUMBSTICK_LEFT_Y;
        public bool FIRE;
        public bool QUIT;
        public bool PAUSE;
        public bool CLEAR;

        PlayerInputData data;

        public void Load() {
            var json = File.ReadAllText("Content/data/input.json");
            data = JsonConvert.DeserializeObject<PlayerInputData>(json);
        }

        public void Update()
        {
            previousGamePadState = currentGamePadState;
            previousKeyboardState = currentKeyboardState;

            // Read the current state of the keyboard and gamepad and store it
            currentKeyboardState = Keyboard.GetState();
            currentGamePadState = GamePad.GetState(PlayerIndex.One);

            LEFT = currentKeyboardState.IsKeyDown( data.keyMap[data.left.keys[0]]) || currentKeyboardState.IsKeyDown(data.keyMap[data.left.keys[1]]) || currentGamePadState.DPad.Left == ButtonState.Pressed;
            RIGHT = currentKeyboardState.IsKeyDown(Keys.Right) || currentKeyboardState.IsKeyDown(Keys.D) || currentGamePadState.DPad.Right == ButtonState.Pressed;
            UP = currentKeyboardState.IsKeyDown(Keys.Up) || currentKeyboardState.IsKeyDown(Keys.W) || currentGamePadState.DPad.Up == ButtonState.Pressed;
            DOWN = currentKeyboardState.IsKeyDown(Keys.Down) || currentKeyboardState.IsKeyDown(Keys.S) || currentGamePadState.DPad.Down == ButtonState.Pressed;

            FIRE = currentKeyboardState.IsKeyDown(Keys.Space) || currentGamePadState.IsButtonDown(Buttons.A) || currentGamePadState.IsButtonDown(Buttons.RightTrigger);

            CLEAR = currentKeyboardState.IsKeyDown(Keys.C);

            THUMBSTICK_LEFT_X = currentGamePadState.ThumbSticks.Left.X;
            THUMBSTICK_LEFT_Y = currentGamePadState.ThumbSticks.Left.Y;

            QUIT =  GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || currentKeyboardState.IsKeyDown(Keys.Back);
            PAUSE = previousGamePadState.Buttons.Start == ButtonState.Pressed && currentGamePadState.Buttons.Start == ButtonState.Released || 
                    previousKeyboardState.IsKeyDown(Keys.P) && currentKeyboardState.IsKeyUp(Keys.P);

        }



    }
}
