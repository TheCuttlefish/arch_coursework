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
    public class Formation
    {

        MyGame main;
        private int difficulty;
        private int fType;
        private int maxFormationLength;

        public Formation( MyGame _main ) {

            main = _main;
            difficulty = 0;// 0,1,2 - easy, normal, hard
            maxFormationLength = 0;

            main.utility.CallAfter(3.0f, () => {
                InitEnemies();
                main.utility.RepeatEvery(9.1666f, InitEnemies);
            });

        }

       
        public void InitEnemies()  {

            var json = File.ReadAllText( "Content/data/formations.json" );
            var difficulties = JsonConvert.DeserializeObject< DifficultyData >( json );
            var formations = difficulties.difficulties[ difficulty ];
            maxFormationLength = difficulties.difficulties[ difficulty ].Length;
            fType = main.utility.RandomRange( 0, maxFormationLength );
            string currentFormations;
            currentFormations = formations[ fType ];
            int amount = formations[ fType ].Length / 3;

            for ( int i = 0; i < amount; i++ ) {

                Enemy e = new Enemy( main );
                e.SelectType( (currentFormations[i * 3]).ToString() );
                e.position.X = int.Parse( (currentFormations[(i * 3) + 1]).ToString() ) * (64 + 10) + 64;
                e.position.Y = int.Parse( (currentFormations[(i * 3) + 2]).ToString() ) * (64 + 10) - 400;
            }
        }
       
        public void Update() {

            if ( main.utility.paused ) return;
        }
    }



   
}
