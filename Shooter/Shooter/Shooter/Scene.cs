using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;


namespace GameEngine
{
    public abstract class Scene : GameComponent
    {
        public MyGame main;
        public Scene(MyGame _main) : base(_main)
        {
            main = _main;

        }



    }
}
