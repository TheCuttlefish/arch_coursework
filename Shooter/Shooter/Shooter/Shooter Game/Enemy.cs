using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine
{
    class Enemy : Entity
    {
        MyGame main;
        Collision collision;

        float knockBack;
        float speedY;
        float rotInc = 0.01f;
        int timer = 0;

        public Enemy(MyGame _main): base(_main)
        {
            main = _main;
            Initialize();
        }
        
        public void Initialize()
        {
            
            tag = "enemy";
            this.texture = sprite.eater;
            base.position = position + new Vector2(400, 0);
            active = true;
           
            speedY = -0.8f;
            rotation = 0.1f;
            knockBack = -0.3f;
            collision = main.Services.GetService(typeof(Collision)) as Collision;
            collision.list.Add(this);
        }
        

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
            if (main.utility.paused) return;
            timer++;
            if (timer > 30)
            {
                rotInc = -rotInc;
                timer = 0;
            }
                rotation -= rotInc;

            if (alpha < 1) alpha += 0.005f;

            if (position.Y > 450)
            {
                if(main.spaceShooter.earthHealth>1)
                main.spaceShooter.earthHealth -= 20;
                active = false;

            }

            if (alpha<0.1f) { active = false;  }


            scale -= (scale -  1.0f)/10;


            position.Y -= speedY;


            if(name == "slider")
            {

                position.X -= (rotation + 0.0452f) * 50;
            }

            if (speedY > -0.4f) speedY -= 0.001f;



            if (!active) Destroy();
        }
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Draw(texture, position, null, colour * alpha, rotation,
            new Vector2(width / 2, height / 2), scale, SpriteEffects.None, 0f);
        }


        protected override void Destroy()
        {
            


            int total = 5;
            while (total > 0)
            {
                Explosion s = new Explosion(main);
                s.Initialize(position);
                total--;
            }

            if (main.utility.RandomRange(0, 10) == 0) { 
                PowerUp p = new PowerUp(main);
                p.Initialize();
                p.position = position;
            }

            collision.list.Remove(this);
            
            main.spaceShooter.currentScore += 200;
            base.Destroy();

            System.GC.Collect();
        }


        public override void OnCollision(Entity collider = default(Entity))
        {

            
            switch (collider.tag)
            {
                
                case "player":
                    speedY = knockBack;
                    position -= (position - collider.position) / 15;
                break;

                case "bullet":
                    scale = 1.2f;
                    speedY = knockBack;
                    position = position + new Vector2(main.utility.RandomRange(-10, 10), -10);
                    alpha -= 0.4f;
                break;

                default:

                break;

                    
            }
        }
    }
}
