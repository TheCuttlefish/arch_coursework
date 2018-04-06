using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine
{
    public class Earth : Entity
    {

        Game main;

        public Earth(Game _main): base(_main)
        {
            main = _main;
            texture = sprite.earth;
            position = new Vector2(32, 32);
        }

        int timer = 5;

        public override void Update(GameTime gameTime)
        {
            timer--;
            if (timer < 0)
            {
                position.Y -= (position.Y - 480) / 100;
            }
        }

        }


}
