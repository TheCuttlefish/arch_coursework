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
        public Color currentColour;
        public Color newColour;
        MyGame main;
        public Utility(MyGame _main)  {
            main = _main;
            background = Color.DarkCyan;
            paused = false;
            newColour = currentColour = Color.White ;
        }

        public void Update()
        {



            main.utility.currentColour = Color.Lerp(main.utility.currentColour, newColour, 0.01f);




            if (main.GameInput.PAUSE) paused =! paused;

            if (paused) background = Color.Gray * 0.3f;
            else background = currentColour;
            //Color.Cyan * 0.3f;
            //Color.BlueViolet * 0.3f;

        }

    }

}
