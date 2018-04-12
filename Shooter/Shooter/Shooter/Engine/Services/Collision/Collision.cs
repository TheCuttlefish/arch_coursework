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
            try
            {
                foreach (Entity i in list)
                // for (int i = list.Count - 1; i >= 0; i--)
                {


                    foreach (Entity j in list)
                    //for (int j = list.Count - 1; j >= 0; j--)
                    {

                        if (j == null || i == null) return;

                        Vector2 pos1 = i.position;
                        Vector2 pos2 = j.position;
                        if (Mathf.Distance(pos1, pos2) < 45)
                        {

                           // if (j == null || i == null) return;
                            i.OnCollision(j); //enemy

                            //if (j == null || i == null) return;
                            j.OnCollision(i); //player
                                              // if (list[j] == null) return;
                        }

                    }

                    // if (!list[i].active)
                    //  {
                    // list.Remove(list[i]);
                    // return;
                    //  }
                }
            }
            catch (InvalidOperationException ex)
            {
                return;
            }




        }

    }
}