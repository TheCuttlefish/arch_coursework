using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine
{
    class PowerUp : Entity
    {
        public PowerUp(Game main): base(main)
        {

        }

        public void Initialize(Texture2D _texture, Vector2 _position, TextureAsset sprite)
        {
            int rnd = 0;

            rnd = Mathf.RandomRange(0, 5);
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


            tag = "powerup";
            base.position = _position;
        }
        float alphaFlash;
        public override void Update(GameTime gameTime)
        {
            position.Y += 2f;
            alphaFlash -= 0.01f;
            if (alphaFlash < 0) alphaFlash = 1;
            alpha = Math.Abs( (float)Math.Cos(position.Y/20));

        }


        public override void OnCollision(Entity collider = default(Entity))
        {


            switch (collider.tag)
            {

                case "player":
                    position -= (position - collider.position) / 7;
                    if(scale>0) scale -= 0.1f;
                    if (Mathf.Distance(position, collider.position) < 15)
                    {
                        active = false;
                    }
                    break;

                default:
                    alpha -= 0.5f;
                    position = position + new Vector2(Mathf.RandomRange(-10, 10), -10);
                    break;


            }
        }

    }

}
