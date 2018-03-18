using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shooter
{
    class Smoke : Entity
    {
        public int Damage;
        Viewport viewport;

        public int Width { get { return texture.Width; } }
        public int Height { get { return texture.Height; } }
        float projectileMoveSpeed;

        public void Initialize(Viewport viewport, Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            base.position = position + new Vector2(rnd.Next(-10,10),0);
            this.viewport = viewport;
            active = true;
            Damage = 2;
            projectileMoveSpeed = 5f + rnd.Next(-2,2);
            rotation = rnd.Next(0, 360);
           

        }
        public override void Update()
        {
            if(alpha> 0.0f)
            {
                alpha -= 0.05f;

            }else
            {
                active = false;
            }
            position.Y += projectileMoveSpeed;
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            
            spriteBatch.Draw(texture, position, null, colour * alpha, rotation,
            new Vector2(Width / 2, Height / 2), scale/2, SpriteEffects.None, 0f);
        }

    }
}
