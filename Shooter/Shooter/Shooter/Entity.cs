using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine
{
    class Entity :  DrawableGameComponent
    {

        Game main;
        //graphics
        protected SpriteBatch spriteBatch;
        public TextureAsset sprite;
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

        public Entity(Game _main) : base(_main)
        {
            main = _main;
            sprite = main.Services.GetService(typeof(TextureAsset)) as TextureAsset;
            main.Components.Add(this);
            spriteBatch = main.Services.GetService(typeof(SpriteBatch)) as SpriteBatch;
        }


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
