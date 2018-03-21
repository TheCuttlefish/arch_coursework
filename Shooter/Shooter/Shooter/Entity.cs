using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shooter
{
    class Entity
    {
        //graphics
        public Texture2D texture;
        public int width { get { return texture.Width; } }
        public int height { get { return texture.Height; } }
        public Color colour = Color.White;
        public float alpha = 1.0f;
        //transform
        public Vector2 position;
        public float rotation = 0.0f;
        public float scale = 1.0f;
        //other
        public string tag = "none";
        public bool active = true;
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            
        }
        public virtual void Update()
        {

        }
        public virtual void OnCollision(String other_tag = "", Vector2 other_position = default(Vector2))
        {

        }
    }
}
