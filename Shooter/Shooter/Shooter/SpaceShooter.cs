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
        Enemy enemy;
        Background bgLayer1;
        Background bgLayer2;
        Background bgLayer3;
        Text text;

        public SpaceShooter (MyGame main) : base (main) {

            Initialize ();

        }

        public override void Initialize () {
            // List<Entity> list = new List<Entity>();

            player = new Player (main);

            //  list.Add(player);
            bgLayer1 = new Background (main);
            bgLayer2 = new Background (main);
            bgLayer3 = new Background (main);

            
            enemy = new Enemy (main);

            // here but I want like you know spawn from that array
            // where did you read the other json? so we can copy
            enemy.Initialize ();

            InitEnemies();
            bgLayer1.Initialize (0, -0.2f);
            bgLayer2.Initialize (1, -0.3f);
            bgLayer3.Initialize (2, -0.4f);

            //ui
            text = new Text (main);

        }

        void InitEnemies () {
            var json = File.ReadAllText ("Content/data/formations.json");
            var difficulties = JsonConvert.DeserializeObject<DifficultyData> (json);

            var formations = difficulties.difficulties[0];


            for ( int i = 0; i < formations[0].Length; i++)
            {
                Console.WriteLine(formations[0][i]);
            }

            
            string currentFormations;
            currentFormations = formations[0];

            int amount = formations[0].Length/ 3;
            Console.WriteLine(amount + " length");
            for (int i = 0; i < amount; i++)
            {
                Enemy e = new Enemy(main);
                e.Initialize();
                e.position.X = int.Parse( (currentFormations[(i * 3) + 1]).ToString()) * (64 + 10) + 64;
                e.position.Y = int.Parse((currentFormations[(i * 3) + 2]).ToString()) * (64 + 10) - 400;
                Console.WriteLine(currentFormations[i * 3] + "x" + currentFormations[(i * 3) + 1] + "x" + currentFormations[(i * 3) + 2]);
            }
               
        }

        public override void Update (GameTime gameTime) {

            text.Display ("score" + player.position.X, 0, Color.White, new Vector2 (10, 10));

        }
    }
}