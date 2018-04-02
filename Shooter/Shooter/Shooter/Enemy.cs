using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine
{
    class Enemy : Entity
    {
        Game main;

        public Enemy(Game _main): base(_main)
        {
            main = _main;
        }
        public int damage;
        float projectileMoveSpeed;
        Collision collision;
        public void Initialize()
        {
            
            tag = "enemy";
            this.texture = sprite.eater;
            base.position = position + new Vector2(400, 0);
            active = true;
            damage = 2;
            projectileMoveSpeed = -0.4f;
            rotation = 0.1f;

            collision = main.Services.GetService(typeof(Collision)) as Collision;
            collision.list.Add(this);
        }
        float rotInc = 0.01f;
        int timer = 0;

        public void SelectType(string enemyType)
        {
            switch (enemyType)
            {
                case "A":
                    name = "eater";
                    texture = sprite.eater;
                break;
                case "B":
                    name = "slider";
                    texture = sprite.slider;
                break;
                case "C":
                    name = "spitter";
                    texture = sprite.spitter;
                break;
                case "D":
                    name = "splitter";
                    texture = sprite.splitter;
                break;

            }

        }

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

            if(position.Y > 450) active = false;

            if (alpha<0.1f) { active = false;  }


            scale -= (scale -  1.0f)/10;




            position.Y -= projectileMoveSpeed;
            if (projectileMoveSpeed > -0.4f) projectileMoveSpeed -= 0.001f;



            if (!active) Destroy();
        }
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Draw(texture, position, null, colour * alpha, rotation,
            new Vector2(width / 2, height / 2), scale, SpriteEffects.None, 0f);
        }


        public override void Destroy()
        {
            int total = 5;
            while (total > 0)
            {
                Explosion s = new Explosion(main);
                s.Initialize(position);
                total--;
            }

            PowerUp p = new PowerUp(main);
            p.Initialize();
            p.position = position;
            base.Destroy();
        }
        public override void OnCollision(Entity collider = default(Entity))
        {

            
            switch (collider.tag)
            {
                
                case "player":
                    projectileMoveSpeed = 0;
                   position =  Mathf.LerpVector2(position, collider.position, 15.0f);
                    
                    break;
                case "bullet":
                    scale = 1.2f;
                    //active = false;
                    position = position + new Vector2(Mathf.RandomRange(-10, 10), -10);
                    alpha -= 0.5f;
                    break;
                default:
                   // alpha -= 0.5f;
                  //  position = position + new Vector2(Mathf.RandomRange(-10, 10), -10);
                break;

                    
            }
        }
    }
}
