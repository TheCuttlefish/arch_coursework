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
        Enemy e;
        Background bgLayer1;
        Background bgLayer2;
        Background bgLayer3;
        Text text;
        public SpaceShooter(MyGame game) : base(game) {

            Initialize();

        }

        public override void Initialize()
        {
            player = new Player(main);
            e = new Enemy(main);

           // main.Components.Remove(player);
            Vector2 playerPosition = new Vector2(
                  main.GraphicsDevice.Viewport.TitleSafeArea.Width / 2,
                  main.GraphicsDevice.Viewport.TitleSafeArea.Height - 32
              );
            e.Initialize(main.sprite.enemy, Vector2.Zero);
            player.Initialize(
               main.sprite.player,
               playerPosition,
               new Vector2(
                   main.GraphicsDevice.Viewport.Width,
                   main.GraphicsDevice.Viewport.Height)
               );
            
            //initialising my main objects
            bgLayer1 = new Background(main);
            bgLayer2 = new Background(main);
            bgLayer3 = new Background(main);

            bgLayer1.Initialize(main.sprite.bg1, main.GraphicsDevice.Viewport.Width, -0.2f);
            bgLayer2.Initialize(main.sprite.bg2, main.GraphicsDevice.Viewport.Width, -0.3f);
            bgLayer3.Initialize(main.sprite.bg3, main.GraphicsDevice.Viewport.Width, -0.4f);

            //ui
            text = new Text(main);
            text.Load(main.Content);
            text.Display("zhan" + player.position.X, 0, Color.White, new Vector2(10, 10));

        }


        public override void Update(GameTime gameTime)
        {
            text.Display("score" + player.position.X, 0, Color.White, new Vector2(10, 10));

        }
    }
}