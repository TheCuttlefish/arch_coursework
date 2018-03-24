using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;
using Newtonsoft.Json;

namespace GameEngine
{
    public class PlayerInput
    {
        //mouse
        public Vector2 mouse ;


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

        Game game;

        public void Load(Game game) {

            this.game = game;
            var json = File.ReadAllText("Content/data/input.json");
            data = JsonConvert.DeserializeObject<PlayerInputData>(json);
        }

        public void Update()
        {

            var mousePos = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
            var viewport = new Vector2(game.Window.ClientBounds.X, game.Window.ClientBounds.Y);
            Console.WriteLine(viewport);
            mouse = mousePos - viewport;
            previousGamePadState = currentGamePadState;
            previousKeyboardState = currentKeyboardState;

            // Read the current state of the keyboard and gamepad and store it
            currentKeyboardState = Keyboard.GetState();
            currentGamePadState = GamePad.GetState(PlayerIndex.One);
            
            LEFT = IsDown(data.left);
            RIGHT = IsDown(data.right);
            UP = IsDown(data.up);
            DOWN = IsDown(data.down);
            FIRE = IsDown(data.fire);
            CLEAR = IsDown(data.clear);
            QUIT = IsDown(data.quit);
            PAUSE = IsDown(data.pause, false) && !IsDown(data.pause);

            THUMBSTICK_LEFT_X = currentGamePadState.ThumbSticks.Left.X;
            THUMBSTICK_LEFT_Y = currentGamePadState.ThumbSticks.Left.Y;
        }

        bool IsDown(KeyData keyData, bool isCurrent = true )
        {
            var keyboard = isCurrent ? currentKeyboardState : previousKeyboardState;
            var gamePad = isCurrent ? currentGamePadState : previousGamePadState;

            foreach (var key in keyData.keys)
            {
                if(keyboard.IsKeyDown(data.keyMap[key]))
                {
                    return true;
                }
            }
            foreach (var key in keyData.buttons)
            {
                if (gamePad.IsButtonDown(data.buttonMap[key]))
                {
                    return true;
                }
            }
            return false;
        }



    }
}
