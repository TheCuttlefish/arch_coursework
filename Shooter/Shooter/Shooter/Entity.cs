using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine
{
    class Entity :  DrawableGameComponent
    {

        protected SpriteBatch spriteBatch;
        Game main;

        public Entity(Game _main) : base(_main)
        {
            main = _main;
            main.Components.Add(this);
            spriteBatch = main.Services.GetService(typeof(SpriteBatch)) as SpriteBatch;
        }

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
        public string name = "unnamed";
        public string tag = "none";
        public bool active = true;

        public virtual void Destroy()
        {
            
            main.Components.Remove(this);
        }



        override public void Draw(GameTime gameTime)
        {
            spriteBatch.Draw(texture, position, null, colour * alpha, rotation, new Vector2(32, 32), 1f, SpriteEffects.None, 0f);
        }

        public virtual void OnCollision(String other_tag = "", Vector2 other_position = default(Vector2), String other_name = "")
        {

        }
    }
}
