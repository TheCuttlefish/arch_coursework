﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine
{
    public class Earth : Entity
    {

        MyGame main;

        public Earth(MyGame _main): base(_main)
        {
            main = _main;
            texture = sprite.earth;
            position = new Vector2(32, 32);
        }

        int timer = 5;

        public override void Update(GameTime gameTime)
        {
            if (main.utility.paused) return;
            timer--;
            if (timer < 0)
            {
                position.Y -= (position.Y - 480) / 100;
            }
        }

        }


}