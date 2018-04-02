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
        
        Background bgLayer1;
        Background bgLayer2;
        Background bgLayer3;
        Text text;
        Formation formation;

        public SpaceShooter (MyGame main) : base (main) {

            Initialize ();

        }

        public override void Initialize () {

            player = new Player (main);

            bgLayer1 = new Background (main);
            bgLayer2 = new Background (main);
            bgLayer3 = new Background (main);

            formation = new Formation(main);
            

            bgLayer1.Initialize (0, -0.2f);
            bgLayer2.Initialize (1, -0.3f);
            bgLayer3.Initialize (2, -0.4f);

            //ui
            text = new Text (main);

        }

        int timer = 1500;
        void UpdateEnemies()
        {
            timer++;
            if (timer > 1100)
            {
                formation.InitEnemies();
                timer = 0;
            }
        }

       

        public override void Update (GameTime gameTime) {
            
            UpdateEnemies();
            text.Display ("score" + player.position.X, 0, Color.White, new Vector2 (10, 10));

        }
    }
}