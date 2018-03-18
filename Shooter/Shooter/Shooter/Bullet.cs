using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shooter
{
    class Bullet : Entity
    {

        public int damage;
        Viewport viewport;
        float speedY;

        public void Initialize(Viewport viewport, Texture2D texture, Vector2 position, float angle)
        {
            rotation = angle;
            this.texture = texture;
            base.position = position;
            this.viewport = viewport;
            active = true;
            damage = 2;
            speedY = 20f;

        }
        public override void Update()
        {

            position.Y -= speedY;
            position.X -= rotation;
            if (position.Y + texture.Height / 2 < -50) active = false;
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, null, Color.White, - rotation/40,
            new Vector2(width / 2, height/2 ), 1f, SpriteEffects.None, 0f);
        }
    }
}
