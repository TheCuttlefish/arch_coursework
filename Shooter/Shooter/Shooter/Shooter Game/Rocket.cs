using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine
{
    class Rocket : Entity
    {
        MyGame main;
        Animation fire;
        float ySpeed;
        Collision collision;

        public Rocket(MyGame _main) : base(_main) {
            main = _main;
            collision = main.Services.GetService(typeof(Collision)) as Collision;
            collision.list.Add(this);
            fire = new Animation();
            position = new Vector2(main.utility.RandomRange(64, 736), -50);
            ySpeed = 1.5f;
            tag = "enemy";
            fire.Initialize(sprite.fire, position + new  Vector2(0,-50), 64, 64, 4, 100, Color.White, 1.2f, true);
            this.texture = sprite.rocket;
            

        }


        public override void Update(GameTime gameTime) {
            if (main.utility.paused) return;
            Movement();
            fire.Update(gameTime);
        }

        void Movement() {
            
            fire.position = position + new Vector2(0, -50);
            fire.position.Y += ySpeed;
            position.Y += ySpeed;
            fire.alpha = alpha;

            if (position.Y > 450) {
                if (main.spaceShooter.earthHealth > 1)
                    main.spaceShooter.earthHealth -= 20;
                Destroy();
            }
            if (alpha < 0 || !active) Destroy();
        }

        public override void Draw(GameTime gameTime) {
            fire.Draw(spriteBatch);
            base.Draw(gameTime);
        }

        public override void OnCollision(Entity collider = default(Entity)) {

            switch (collider.tag) {

                case "player":
                    position -= (collider.position - position) / 15;
                    break;

                case "bullet":
                    position = position + new Vector2(main.utility.RandomRange(-10, 10), -10);
                    alpha -= 0.1f;
                    break;
            }
        }


        protected override void Destroy() {
            main.spaceShooter.currentScore += 1000;

            int total = 5;
            while (total > 0) {
                Explosion s = new Explosion(main);
                s.Initialize(position);
                total--;
            }

            collision.list.Remove(this);
            fire.active = false;
            base.Destroy();
        }
    }
}
