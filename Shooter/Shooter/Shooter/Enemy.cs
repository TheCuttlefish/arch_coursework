using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine
{
    class Enemy : Entity
    {


        public Enemy(Game main): base(main)
        {

        }
        public int damage;
        float projectileMoveSpeed;
        public void Initialize()
        {
            
            tag = "enemy";
            this.texture = sprite.enemy;
            base.position = position + new Vector2(400, 0);
            active = true;
            damage = 2;
            projectileMoveSpeed = -0.3f;
            rotation = 0.1f;
        }
        float rotInc = 0.01f;
        int timer = 0;
        public override void Update(GameTime gameTime)
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



            if (!active) Destroy();
        }
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Draw(texture, position, null, colour * alpha, rotation,
            new Vector2(width / 2, height / 2), scale, SpriteEffects.None, 0f);
        }
       
        public override void OnCollision(String other_tag = "", Vector2 other_position = default(Vector2), String other_name = "")
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
