using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine
{
    class PowerUp : Entity
    {
        Collision collision;
        MyGame main;
        public PowerUp(MyGame _main): base(_main)
        {
            main = _main;
            collision = main.Services.GetService(typeof(Collision)) as Collision;
            collision.list.Add(this);
        }

        public void Initialize()
        {
            tag = "powerup";
            int rnd = Mathf.RandomRange(0, 4);
            if (rnd == 0) {
                name = "oneUp";
                texture = sprite.extraLife;
            } else if (rnd == 1)
            {
                name = "bulletx1";
                texture = sprite.power1;
            }
            else if (rnd == 2)
            {
                name = "bulletx2";
                texture = sprite.power2;
            }
            else if (rnd == 3)
            {
                name = "bulletx3";
                texture = sprite.power3;
            }
            else if (rnd == 4)
            {
                name = "clear";
                texture = sprite.clearScreen;
            }


         
         
        }
        float alphaFlash;
        public override void Update(GameTime gameTime)
        {
            if (main.utility.paused) return;
            position.Y += 3f;
            alphaFlash -= 0.01f;
            if(position.Y > 550)Destroy();


            if (alphaFlash < 0) alphaFlash = 1;
            alpha = Math.Abs( (float)Math.Cos(position.Y/30));
            if (scale < 0.1f) Destroy();
        }

        protected override void Destroy()
        {
            collision.list.Remove(this);
            base.Destroy();
        }
        public override void OnCollision(Entity collider = default(Entity))
        {


            switch (collider.tag)
            {

                case "player":
                    position -= (position - collider.position) / 5;
                    if (scale > 0 && scale < 0.9f) { scale -= 0.1f; }
                   //
                    if (Mathf.Distance(position, collider.position) < 20)
                    {
                        position = collider.position;
                        Destroy();
                     }
                    break;


            }
        }

    }

}
