using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace GameEngine {
    class SpaceShooter : Scene {

        Player player;
        Enemy enemy;
        Background bgLayer1;
        Background bgLayer2;
        Background bgLayer3;
        Text text;

        public SpaceShooter(MyGame main) : base(main) {

            Initialize();

        }

        public override void Initialize()
        {

            player = new Player(main);
            bgLayer1 = new Background(main);
            bgLayer2 = new Background(main);
            bgLayer3 = new Background(main);
            enemy = new Enemy(main);

            player.Initialize(main.sprite);
            enemy.Initialize(main.sprite.enemy);
            bgLayer1.Initialize(main.sprite.bg1, -0.2f);
            bgLayer2.Initialize(main.sprite.bg2,  -0.3f);
            bgLayer3.Initialize(main.sprite.bg3,  -0.4f);

            //ui
            text = new Text(main);

        }


        public override void Update(GameTime gameTime)
        {

            text.Display("score" + player.position.X, 0, Color.White, new Vector2(10, 10));

        }
    }
}