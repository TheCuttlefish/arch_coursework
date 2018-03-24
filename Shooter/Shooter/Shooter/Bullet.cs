using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine
{
    class Bullet : Entity
    {

        public Bullet(Game game): base(game)
        {

        }

        public int damage;
        Viewport viewport;
        float speedY;

        public void Initialize(Viewport viewport, Texture2D texture, Vector2 position, float angle)
        {
            
            tag = "bullet";
            rotation = angle;
            this.texture = texture;
            base.position = position;
            this.viewport = viewport;
            active = true;
            damage = 2;
            speedY = 10f;
            
        }
        public override void Update(GameTime gameTime)
        {

            position.Y -= speedY;
            position.X -= rotation/2;
            if (position.Y + texture.Height / 2 < -50) active = false;
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, null, colour * alpha, - rotation/80,
            new Vector2(width / 2, height/2 ), scale, SpriteEffects.None, 0f);
        }

        public override void OnCollision(String other_tag = "", Vector2 other_position = default(Vector2), String other_name = "")
        {
            if(other_tag == "enemy")
                active = false;
        }
    }
}
