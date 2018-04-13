using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine
{
  public  class Entity :  DrawableGameComponent
    {

        Game main;
        //graphics
        protected SpriteBatch spriteBatch;
        protected TextureAsset sprite;
        protected Texture2D texture;
        protected int width { get { return texture.Width; } }
        protected int height { get { return texture.Height; } }
        protected Color colour = Color.White;
        protected float alpha = 1.0f;
        //transform
        public Vector2 position;
        protected float rotation = 0.0f;
        public float scale = 1.0f;
        //other
        public string name = "unnamed";
        public string tag = "none";
        public bool active = true;

        public Entity( MyGame _main ) : base( _main ) {

            main = _main;
            sprite = main.Services.GetService( typeof( TextureAsset ) ) as TextureAsset;
            main.Components.Add( this );
            spriteBatch = main.Services.GetService( typeof (SpriteBatch ) ) as SpriteBatch;
        }


        protected virtual void Destroy() {

            main.Components.Remove( this );
        }



        override public void Draw( GameTime gameTime ) {

            spriteBatch.Draw( texture, position, null, colour * alpha, rotation, new Vector2(32, 32), scale, SpriteEffects.None, 0f );
        }

        public virtual void OnCollision( Entity collider = default( Entity ) ) {

        }
    }
}
