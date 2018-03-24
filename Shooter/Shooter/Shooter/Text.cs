using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace GameEngine
{
    class Text
    {
        SpriteFont smallFont;
        SpriteFont mediumFont;
        SpriteFont largeFont;
        SpriteBatch sb;

        public Text( SpriteBatch spriteBatch ) {
            sb = spriteBatch;
        }

        public void Load( ContentManager c ) {
            smallFont = c.Load< SpriteFont >( "EightBitMadness" );
            mediumFont = c.Load< SpriteFont >( "EightBitMadnessMedium" );
            largeFont = c.Load< SpriteFont >( "EightBitMadnessLarge" );
        }
      
        public void Draw( string text, Vector2 position = default( Vector2 ), int size = 0, Color color = default( Color )) {

            if (color == default( Color ))color = Color.White;

            SpriteFont font;
            if ( size == 0 ) font = smallFont;
            else if ( size == 1 ) font = mediumFont;
            else font = largeFont;

            sb.DrawString( font, text, position, color );
        }
    }
}
