﻿using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine
{
   public class Collision : Microsoft.Xna.Framework.Game
    {


        public List<Entity> list;

        public Collision()
        {
            list = new List<Entity>();
        }

        public void Update()
        {
            for (int i = list.Count - 1; i >= 0; i--)
            {

                if (!list[i].active)
                {
                    list.Remove(list[i]);
                    return; // avoid checking the rest
                }


                for (int j = list.Count - 1; j >= 0; j--)
                {

                    //if (list[i].tag == "enemy" && list[j].tag == "player")
                   // {
                        Vector2 pos1 = list[i].position;
                        Vector2 pos2 = list[j].position;
                        if (Mathf.Distance(pos1, pos2) < 45)
                        {
                            list[i].OnCollision(list[j]); //enemy
                            list[j].OnCollision(list[i]); //player
                        }
                   // }
                
                    /*
                    if (list[i].tag == "enemy" && list[j].tag == "bullet")
                    {
                        Vector2 pos1 = list[i].position;
                        Vector2 pos2 = list[j].position;
                        if (Mathf.Distance(pos1, pos2) < 45)
                        {
                            list[i].OnCollision(list[j]); //enemy
                            list[j].OnCollision(list[i]); //player
                        }
                    }
                    */
                }
            }
            
        }

    }
}
