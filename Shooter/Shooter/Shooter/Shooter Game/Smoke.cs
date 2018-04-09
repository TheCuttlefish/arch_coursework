using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine
{
    class Smoke : Entity
    {

        public Smoke(MyGame main): base(main)
        {

        }
        float projectileMoveSpeed;

        public void Initialize(Vector2 position)
        {
            texture = sprite.smoke;
            base.position = position + new Vector2(Mathf.RandomRange(-10,10),0);
            active = true;
            alpha = 0.5f;
            projectileMoveSpeed = 5f + Mathf.RandomRange(-2,2);
            rotation = Mathf.RandomRange(0, 360);
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
