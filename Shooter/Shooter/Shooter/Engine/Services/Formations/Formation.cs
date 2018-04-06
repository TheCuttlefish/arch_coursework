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
        public Formation(MyGame _main){
            main = _main;
        }








        public void InitEnemies()
        {
            var json = File.ReadAllText("Content/data/formations.json");
            var difficulties = JsonConvert.DeserializeObject<DifficultyData>(json);
            var formations = difficulties.difficulties[0];
            string currentFormations;
            currentFormations = formations[0];

            int amount = formations[0].Length / 3;

            for (int i = 0; i < amount; i++)
            {
                Enemy e = new Enemy(main);
                e.Initialize();
                e.SelectType((currentFormations[i * 3]).ToString());
                e.position.X = int.Parse((currentFormations[(i * 3) + 1]).ToString()) * (64 + 10) + 64;
                e.position.Y = int.Parse((currentFormations[(i * 3) + 2]).ToString()) * (64 + 10) - 400;
                //Console.WriteLine(currentFormations[i * 3] + "x" + currentFormations[(i * 3) + 1] + "x" + currentFormations[(i * 3) + 2]);
            }

        }



    }



   
}
