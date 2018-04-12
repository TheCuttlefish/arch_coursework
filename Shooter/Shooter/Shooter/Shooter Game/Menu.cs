using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;


namespace GameEngine
{
    class Menu : Scene
    {

        Text titleText;
        Text playText;
        string playString;

        Text exitText;
        string exitString;

        Text scoreText;
        string scoreString;

        int selected;

        public Menu(MyGame main) : base (main) {

            Initialize();

        }

        public override void Initialize() {
            main.utility.newColour = Color.BlueViolet * 0.3f;
            selected = 0;
            titleText = new Text(main);

            playText = new Text(main);
            playString = "Play";

            scoreText = new Text(main);
            scoreString = "Highscore";

            exitText = new Text(main);
            exitString = "Exit";
        }

        public override void Update(GameTime gameTime) {
            Input();
            UpdateText();
            OnSelect();
        }

        void OnSelect() {
            if (!main.GameInput.SELECT_BUTTON) return;


            if (selected == 0)
            {
                ClearAll();
                main.ChangeGameState(1);
            }

            if(selected == 1)
            {
                ClearAll();
                main.ChangeGameState(2);
            }

            if (selected == 2)
                main.Exit();
        }
        
        void UpdateText() {
            titleText.Display("SUPER SPACE SHOOTER", 2, Color.White, new Vector2(80, 80));
            playText.Display(playString, 1, Color.White, new Vector2(80, 220));
            scoreText.Display(scoreString, 1, Color.White, new Vector2(80, 250));
            exitText.Display(exitString, 1, Color.White, new Vector2(80, 280));
            
            playString = "Play";
            scoreString = "Highscore";
            exitString = "Exit";
            if (selected == 0)
                playString = "> Play";
            if (selected == 1)
                scoreString = "> Highscore";
            if (selected == 2)
                exitString = "> Exit";

        }

        void Input() {

            if (main.GameInput.QUIT)
                main.Exit();

            if (main.GameInput.SELECT_DOWN) {
                selected++;
                if (selected > 2) selected = 0;
            }


            if (main.GameInput.SELECT_UP) {
                selected--;
                if (selected < 0) selected = 2;
            }

        }


        void ClearAll()
        {
            titleText.Dispose();
            playText.Dispose();
            scoreText.Dispose();
            exitText.Dispose();
            this.Dispose();
        }

    }
}
