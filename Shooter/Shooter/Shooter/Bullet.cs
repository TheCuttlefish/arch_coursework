using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shooter
{
    class Bullet : Entity
    {

        public int Damage;
        Viewport viewport;
        public int Width { get { return texture.Width; } }
        public int Height { get { return texture.Height; } }
        float projectileMoveSpeed;


        public void Initialize(Viewport viewport, Texture2D texture, Vector2 position, float angle)
        {
            rotation = angle;
            this.texture = texture;
            base.position = position;
            this.viewport = viewport;
            active = true;
            Damage = 2;
            projectileMoveSpeed = 20f;

        }
        public override void Update()
        {

            position.Y -= projectileMoveSpeed;
            position.X -= rotation;
            if (position.Y + texture.Height / 2 < -50) active = false;
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, null, Color.White, - rotation/40,
            new Vector2(Width / 2, Height/2 ), 1f, SpriteEffects.None, 0f);
        }
    }
}
