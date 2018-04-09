using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine
{
    class Background : Entity
    {
        MyGame main;
        public Background(MyGame _main): base(_main)
        {
            main = _main;  
        }
        Vector2[] positions;
        
        float speed;
        public void Initialize(int bg_type, float _speed)
        {
            if (bg_type == 0)
                texture = sprite.bg1;
            if (bg_type == 1)
                texture = sprite.bg2;
            if (bg_type == 2)
                texture = sprite.bg3;

            alpha = 0;
            this.speed = _speed;

            positions = new Vector2[480 / texture.Height + 1];

            for (int i = 0; i < positions.Length; i++)
            {
                positions[i] = new Vector2(0, i * texture.Height);
            }
        }
        public override void Update(GameTime gameTime)
        {
            if (main.utility.paused) return;
            if (alpha < 1)
            {
                alpha += 0.002f;
            }

            for (int i = 0; i < positions.Length; i++)
            {

                positions[i].Y -= speed; 
                if (speed <= 0)
                {
                    if (positions[i].Y >= texture.Height)
                    {
                        positions[i].Y = -texture.Height * (positions.Length - 1);
                    }
                }
                else
                {
                    if (positions[i].X <= texture.Height * (positions.Length - 1))
                    {
                        positions[i].X = texture.Height;
                    }
                }
            }
        }
        public override void Draw(GameTime gameTime)
        {
            for (int i = 0; i < positions.Length; i++)
            {
                spriteBatch.Draw(texture, positions[i], Color.White * alpha);
            }
        }
    }
}
