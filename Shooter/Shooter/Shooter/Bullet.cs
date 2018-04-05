using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine
{
    class Bullet : Entity
    {
        Collision collision;
        Game main;
        public Bullet(Game _main): base(_main)
        {
            main = _main;
        }

        public int damage;

        float speedY;

        public void Initialize(Vector2 position, float angle)
        {
            
            tag = "bullet";
            rotation = angle;
            this.texture = sprite.bullet;
            base.position = position;
          
            active = true;
            damage = 2;
            speedY = 10f;

            collision = main.Services.GetService(typeof(Collision)) as Collision;
            collision.list.Add(this);

        }
        public override void Update(GameTime gameTime)
        {

            position.Y -= speedY;
            position.X -= rotation/2;
            if (position.Y < 0) active = false;

            if (!active) Destroy();
        }

        protected override void Destroy()
        {

            collision.list.Remove(this);
            base.Destroy();
        }

        public override void OnCollision(Entity collider = default(Entity))
        {
            if (collider.tag == "enemy")
            {
                active = false;
                
            }
            if (collider.tag == "player") { }

        }
    }
}
