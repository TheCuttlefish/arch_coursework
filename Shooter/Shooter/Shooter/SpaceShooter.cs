using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Newtonsoft.Json;

namespace GameEngine {
    class SpaceShooter : Scene {

        Player player;
        Earth earth;
        Background bgLayer1;
        Background bgLayer2;
        Background bgLayer3;
        
        Formation formation;

        public SpaceShooter (MyGame main) : base (main) {

            Initialize ();

        }

        public override void Initialize () {

            earth = new Earth(main);

            player = new Player (main);

            bgLayer1 = new Background (main);
            bgLayer2 = new Background (main);
            bgLayer3 = new Background (main);

            formation = new Formation(main);
            

            bgLayer1.Initialize (0, -0.2f);
            bgLayer2.Initialize (1, -0.3f);
            bgLayer3.Initialize (2, -0.4f);

            //ui
            score = new Text (main);
            lives = new Text(main);
            planet = new Text(main);
        }

        int timer = 800;
        void UpdateEnemies()
        {
            timer++;
            if (timer > 1100)
            {
                formation.InitEnemies();
                timer = 0;
            }
        }


        Text score;
        Text lives;
        Text planet;
        public override void Update (GameTime gameTime) {
            
            UpdateEnemies();
            score.Display ("Score " + "000000", 0, Color.White, new Vector2 (10, 10));
            lives.Display("Lives x " + player.lives, 0, Color.White, new Vector2(10, 420));
            planet.Display("Planet " +100 + "%", 0, Color.White, new Vector2(10, 440));
        }
    }
}