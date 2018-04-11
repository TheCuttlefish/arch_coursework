using System;
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

                

                for (int j = list.Count - 1; j >= 0; j--)
                {
                   
                    if (list[j] == null || list[i] == null) return;
                    
                    Vector2 pos1 = list[i].position;
                    Vector2 pos2 = list[j].position;
                    if (Mathf.Distance(pos1, pos2) < 45)
                    {

                        if (list[i] == null) return;
                        list[i].OnCollision(list[j]); //enemy
                                                      
                        if (list[j] == null) return;
                             list[j].OnCollision(list[i]); //player
                       // if (list[j] == null) return;
                    }
                  
                }

                if (!list[i].active)
                {
                   // list.Remove(list[i]);
                   // return;
                }



            }
            
        }

    }
}
