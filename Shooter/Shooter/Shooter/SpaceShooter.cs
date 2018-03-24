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
        }
    }
}