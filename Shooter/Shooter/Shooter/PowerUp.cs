using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shooter
{
    class PowerUp : Entity
    {

        
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
        public override void Update()
        {
            position.Y += 2f;
            alphaFlash -= 0.01f;
            if (alphaFlash < 0) alphaFlash = 1;
            alpha = Math.Abs( (float)Math.Cos(position.Y/20));

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, null, colour * alpha, rotation,
            new Vector2(width / 2, height / 2), scale, SpriteEffects.None, 0f);
        }
        public override void OnCollision(String other_tag = "", Vector2 other_position = default(Vector2), String other_name="")
        {


            switch (other_tag)
            {

                case "player":
                    position -= (position - other_position) / 7;
                    if(scale>0) scale -= 0.1f;
                    if (Mathf.Distance(position, other_position) < 15)
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
