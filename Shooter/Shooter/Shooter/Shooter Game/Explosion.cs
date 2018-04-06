using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine
{
    class Explosion : Entity
    {

        public Explosion(Game main) : base(main)
        {
            
        }
        float ySpeed;
        float xSpeed;

        public void Initialize(Vector2 position)
        {
            
            texture = sprite.smoke;
            base.position = position + new Vector2(Mathf.RandomRange(-20, 20), Mathf.RandomRange(-20, 20));
            active = true;
            alpha = 0.1f * Mathf.RandomRange(6, 10);
            scale = 0.1f * Mathf.RandomRange(5, 15);
            xSpeed = 0.1f * Mathf.RandomRange(-10, 10);
            ySpeed = 0.1f * Mathf.RandomRange(-10, 20);
            rotation = Mathf.RandomRange(0, 360);
        }
        public override void Update(GameTime gameTime)
        {
            position.X += xSpeed;
            position.Y += ySpeed;

            if (alpha > 0.0f)
                alpha -= 0.02f;
            else
                Destroy();


        }


    }
}
