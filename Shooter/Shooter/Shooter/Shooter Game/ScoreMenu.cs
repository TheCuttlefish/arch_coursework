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
    class ScoreMenu : Scene
    {
        Text scoreTitle;
        Text backText;
        List<Text> scoreList;
        List<Text> numbers;
        int totalScores;
        public ScoreMenu(MyGame main) : base (main) {

            Initialize();

        }


        public override void Initialize()
        {
            scoreList = new List<Text>();
            numbers = new List<Text>();
            totalScores = 10;
            int currentAmount = 0;
            while(currentAmount < totalScores)
            {
                Text t = new Text(main);
                t.Display("0000", 1, Color.White, new Vector2(260,100+ 30 * currentAmount));
                scoreList.Add(t);

                currentAmount++;
            }

            int currentNum = 0;
            while(currentNum < totalScores)
            {
                Text t = new Text(main);
                t.Display((currentNum + 1).ToString(), 1, Color.White, new Vector2(150, 100 + 30 * currentNum));
                numbers.Add(t);
                currentNum++;
            }


            scoreTitle = new Text(main);
            scoreTitle.Display("*** HIGH SCORE ***", 2, Color.White, new Vector2(150, 20));

            backText = new Text(main);
            backText.Display(">  Back", 1, Color.White, new Vector2(150, 420));
        }

        public override void Update(GameTime gameTime)
        {
            Input();
        }

        void ClearAll()
        {

            scoreTitle.Dispose();
            backText.Dispose();

            for (int i = 0; i < totalScores; i++)
            {
                numbers[i].Dispose();
                scoreList[i].Dispose();
            }
            this.Dispose();
        }

        int timer = 0;

        void Input()
        {
            timer++;
            if (timer < 20) return;

            if (main.GameInput.SELECT_BUTTON )
            {
               
                ClearAll();
                main.ChangeGameState(0);
            }


        }
    }
}
