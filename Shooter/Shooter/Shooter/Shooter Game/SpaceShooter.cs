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
    public class SpaceShooter : Scene {

        Player player;
        Earth earth;
        Background bgLayer1;
        Background bgLayer2;
        Background bgLayer3;
        Formation formation;

        public string getScore() { return string.Format("score: {0}", currentScore); }
        internal int currentScore;
        internal int earthHealth;

        Image earthIcon;
        Image lifeIcon;

        Text scoreText;
        Text livesText;
        Text planetText;
        Text pauseText;

        
        public SpaceShooter (MyGame main) : base (main) {

            Initialize ();

        }

        public override void Initialize () {
            
            player = new Player (main);
            earth = new Earth(main);
            bgLayer1 = new Background (main);
            bgLayer2 = new Background (main);
            bgLayer3 = new Background (main);

            formation = new Formation(main);

            bgLayer1.Initialize (0, -0.2f);
            bgLayer2.Initialize (1, -0.3f);
            bgLayer3.Initialize (2, -0.4f);

            //ui
            earthIcon = new Image(main.sprite.icon_earth, new Vector2(45, 475), main);
            lifeIcon = new Image(main.sprite.icon_live, new Vector2(45, 455), main);
            scoreText = new Text (main);
            livesText = new Text(main);
            planetText = new Text(main);
            pauseText = new Text(main);
            earthHealth = 100;

        }

        public override void Update (GameTime gameTime) {

            formation.Update();
            scoreText.Display (getScore(), 0, Color.White, new Vector2 (10, 10));
            livesText.Display(player.lives.ToString(), 0, Color.White, new Vector2(40, 420));
            planetText.Display(earthHealth + "%", 0, Color.White, new Vector2(40, 440));
            pauseText.Display("", 2, Color.White, new Vector2(300, 200));
            if (main.utility.paused) pauseText.Display("Paused", 2, Color.White, new Vector2(290, 200));
            
        }
    }
}