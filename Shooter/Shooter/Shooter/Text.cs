using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace GameEngine
{
    class Text : DrawableGameComponent
    {
        SpriteFont smallFont;
        SpriteFont mediumFont;
        SpriteFont largeFont;
        SpriteBatch sb;
        String text;
        Color color;
        Vector2 position;
        int size = 0;
        public Text(Game game) : base(game)
        {
            text = "empty";
            color = Color.White;
            game.Components.Add(this);
            sb = game.Services.GetService(typeof(SpriteBatch)) as SpriteBatch;
        }

        public void Load( ContentManager c ) {
            smallFont = c.Load< SpriteFont >( "EightBitMadness" );
            mediumFont = c.Load< SpriteFont >( "EightBitMadnessMedium" );
            largeFont = c.Load< SpriteFont >( "EightBitMadnessLarge" );
        }
      
        override public void Draw(GameTime gameTime) {

           

           SpriteFont font;
            font = smallFont;
           if ( size == 0 ) font = smallFont;
            else if ( size == 1 ) font = mediumFont;
            else font = largeFont;

            sb.DrawString( font, text ,position,color );
        }


        public void Display(String _text, int _size = 0, Color _color = default(Color), Vector2 _position = default(Vector2))
        {
            if (_color == default( Color ))_color = Color.White;
            position = _position;
            text = _text;
            size = _size;
            color = _color;
        }

    }
}
