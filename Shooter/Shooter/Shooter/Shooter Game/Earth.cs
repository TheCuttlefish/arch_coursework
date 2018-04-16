using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Timers;

namespace GameEngine
{
    public class Earth : Entity
    {

        MyGame main;
        float speedY = 1f;
        bool canMoveEarth = false;

        public Earth( MyGame _main ): base( _main ) {

            main = _main;
            texture = sprite.earth;
            position = new Vector2( 32, 32 );
            main.utility.CallAfter( 0.6f , EnableMoveEarth );

        }

        void EnableMoveEarth() {

            canMoveEarth = true;
        }
        
        public override void Update(GameTime gameTime) {

            if (main.utility.paused) return;
            if (canMoveEarth) MoveEarth();
            
        }

        void MoveEarth() {

            if ( position.Y < 480 ) {
                speedY += 0.05f;
                position.Y += speedY;
            }
        }

    }


}
