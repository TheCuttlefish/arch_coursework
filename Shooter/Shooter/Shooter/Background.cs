using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Shooter
{
    class Background : Entity
    {

        Vector2[] positions;

        float speed;
        public void Initialize(Texture2D bg_texture, int screenWidth, float _speed)
        {

            texture = bg_texture;
            this.speed = _speed;

            positions = new Vector2[480 / texture.Height + 1];

            for (int i = 0; i < positions.Length; i++)
            {
                positions[i] = new Vector2(0, i * texture.Height);
            }
        }
        public override void Update()
        {

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
        public override void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < positions.Length; i++)
            {
                spriteBatch.Draw(texture, positions[i], Color.White);
            }
        }
    }
}
