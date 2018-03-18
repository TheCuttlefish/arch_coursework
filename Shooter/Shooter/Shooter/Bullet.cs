using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shooter
{
    class Bullet : Entity
    {
        public Texture2D Texture;
        public int Damage;
        Viewport viewport;
        public int Width { get { return Texture.Width; } }
        public int Height { get { return Texture.Height; } }
        float projectileMoveSpeed;


        public void Initialize(Viewport viewport, Texture2D texture, Vector2 position)
        {
            Texture = texture;
            Position = position;
            this.viewport = viewport;
            Active = true;
            Damage = 2;
            projectileMoveSpeed = 20f;

        }
        public void Update()
        {

            Position.Y -= projectileMoveSpeed;

            if (Position.Y + Texture.Height / 2 < 50) Active = false;
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, null, Color.White, 0f,
            new Vector2(Width / 2, Height / 2), 1f, SpriteEffects.None, 0f);
        }
    }
}
