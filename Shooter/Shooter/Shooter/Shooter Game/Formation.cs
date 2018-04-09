﻿using System;
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
        int difficulty;
        int fType;
        int maxFormationLength;

        public Formation(MyGame _main){
            main = _main;
            timer = 800;
            difficulty = 0;// 0,1,2
            //fType = 0;
            maxFormationLength = 0;
        }

       
        public void InitEnemies()  {
            var json = File.ReadAllText("Content/data/formations.json");
            var difficulties = JsonConvert.DeserializeObject<DifficultyData>(json);
            var formations = difficulties.difficulties[difficulty];
            maxFormationLength = difficulties.difficulties[difficulty].Length;
            fType = Mathf.RandomRange(0, maxFormationLength);// maybe it should be - 1? ... 
            Console.WriteLine(maxFormationLength);
            
            string currentFormations;
            currentFormations = formations[fType];
            
            int amount = formations[fType].Length / 3;

            for (int i = 0; i < amount; i++)
            {
                Enemy e = new Enemy(main);
                e.Initialize();
                e.SelectType((currentFormations[i * 3]).ToString());
                e.position.X = int.Parse((currentFormations[(i * 3) + 1]).ToString()) * (64 + 10) + 64;
                e.position.Y = int.Parse((currentFormations[(i * 3) + 2]).ToString()) * (64 + 10) - 400;
            }

        }
        int timer;
        public void Update()
        {

            if (main.utility.paused) return;
            timer++;
            if (timer > 1100)
            {
                InitEnemies();
                timer = 0;
            }
        }



    }



   
}