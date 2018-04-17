using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine
{
    public class Collision : Microsoft.Xna.Framework.Game
    {

        public List< Entity > list;

        public Collision() {

            list = new List< Entity >();
        }

        public void Update() {

            try {
                foreach ( Entity i in list ) {
                    foreach ( Entity j in list ) {
                        if ( j == null || i == null ) return;
                            Vector2 pos1 = i.position;
                            Vector2 pos2 = j.position;

                        if ( ( pos1 - pos2 ).Length() < 45 ) {
                            i.OnCollision( j );
                            j.OnCollision( i );
                        }
                    }
                }
            }
            catch ( InvalidOperationException ex ) {
                return;
            }
        }

    }
}