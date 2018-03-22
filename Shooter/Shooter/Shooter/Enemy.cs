using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shooter
{
    class Enemy : Entity
    {
        public int damage;
        float projectileMoveSpeed;
        public void Initialize( Texture2D texture, Vector2 position)
        {
            
            tag = "enemy";
            this.texture = texture;
            base.position = position + new Vector2(Mathf.RandomRange(-10, 10), 0);
            active = true;
            damage = 2;
            projectileMoveSpeed = -0.3f;
            rotation = 0.1f;
        }
        float rotInc = 0.01f;
        int timer = 0;
        public override void Update()
        {
            timer++;
            if (timer > 30)
            {
                timer = 0;
                rotInc = -rotInc;
            }
                rotation -= rotInc;

            if (alpha < 1) alpha += 0.01f;

            if(position.Y > 300) active = false;

            if (alpha<0.1f) { active = false;  }
           
            position.Y -= projectileMoveSpeed;
            if (projectileMoveSpeed > -0.3f) projectileMoveSpeed -= 0.001f;
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, null, colour * alpha, rotation,
            new Vector2(width / 2, height / 2), scale, SpriteEffects.None, 0f);
        }
       
        public override void OnCollision(String other_tag = "", Vector2 other_position = default(Vector2))
        {

            
            switch (other_tag)
            {
                
                case "player":
                    projectileMoveSpeed = 0;
                   position =  Mathf.LerpVector2(position, other_position, 15.0f);
                    break;

                default:
                    alpha -= 0.5f;
                    position = position + new Vector2(Mathf.RandomRange(-10, 10), -10);
                break;

                    
            }
        }
    }
}
