using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine
{
    class Explosion : Entity
    {
        MyGame main;
        public Explosion(MyGame _main) : base(_main)
        {
            main = _main;
        }
        float ySpeed;
        float xSpeed;
        public void Initialize(Vector2 position)
        {
            
            texture = sprite.smoke;
            base.position = position + new Vector2(main.utility.RandomRange(-20, 20), main.utility.RandomRange(-20, 20));
            active = true;
            alpha = 0.1f * main.utility.RandomRange(6, 10);
            scale = 0.1f * main.utility.RandomRange(5, 15);
            xSpeed = 0.1f * main.utility.RandomRange(-10, 10);
            ySpeed = 0.1f * main.utility.RandomRange(-10, 20);
            rotation = main.utility.RandomRange(0, 360);
        }
        
        public void Trail()
        {
            alpha = 0.1f * main.utility.RandomRange(4, 5);
            ySpeed = 0.1f * main.utility.RandomRange(20, 60);
            scale = 0.1f * main.utility.RandomRange(5, 7);
        }

        public override void Update(GameTime gameTime)
        {
            if (main.utility.paused) return;
            position.X += xSpeed;
            position.Y += ySpeed;

            if (alpha > 0.0f)
                alpha -= 0.02f;
            else
                Destroy();


        }


    }
}
