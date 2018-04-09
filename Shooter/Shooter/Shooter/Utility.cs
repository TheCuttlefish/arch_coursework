using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine
{

   public class Utility : Microsoft.Xna.Framework.Game {
        public bool paused;
        public Color background;
        MyGame main;
        public Utility(MyGame _main)  {
            main = _main;
            background = Color.DarkCyan;
            paused = false;

        }

        public void Update()
        {
            if (main.GameInput.PAUSE) paused =! paused;

            if (paused) background = Color.Black;
            else background = Color.Cyan * 0.3f;
            //Color.Cyan * 0.3f;
            //Color.BlueViolet * 0.3f;

        }

    }

}
