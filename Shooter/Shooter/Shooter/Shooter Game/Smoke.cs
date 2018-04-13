using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine
{
    class Smoke : Entity
    {
        MyGame main;
        public Smoke(MyGame _main): base(_main)
        {
            main = _main;
        }
        float projectileMoveSpeed;

        public void Initialize(Vector2 position)
        {
            texture = sprite.smoke;
            base.position = position + new Vector2(main.utility.RandomRange(-10,10),0);
            active = true;
            alpha = 0.5f;
            projectileMoveSpeed = 5f + main.utility.RandomRange(-2,2);
            rotation = main.utility.RandomRange(0, 360);
        }
        public override void Update(GameTime gameTime)
        {
            if( alpha> 0.0f )
               alpha -= 0.02f;
            else
               active = false;

            position.Y += projectileMoveSpeed;
        }


    }
}
