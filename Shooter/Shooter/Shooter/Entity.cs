using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shooter
{
    class Entity
    {
        public Texture2D texture;
        public int width { get { return texture.Width; } }
        public int height { get { return texture.Height; } }
        public Vector2 position;
        public bool active = true;
        public Color colour = Color.White;
        public float alpha = 1.0f;
        public float scale = 1.0f;
        public float rotation = 0.0f;
        public Random rnd = new Random();

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            
        }

        public virtual void Update()
        {

        }
    }
}
