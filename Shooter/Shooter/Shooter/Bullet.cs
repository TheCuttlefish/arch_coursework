using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine
{
    class Bullet : Entity
    {

        public Bullet(Game main): base(main)
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


        public override void OnCollision(Entity collider = default(Entity))
        {
            if(collider.tag == "enemy")
                active = false;
        }
    }
}
