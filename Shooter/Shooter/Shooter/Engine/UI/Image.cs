using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine
{
    class Image : Entity
    {
        MyGame main;
        public Image (Texture2D _texture, Vector2 _pos, MyGame _main): base(_main)
        {
            main = _main;
            texture = _texture;
            position = _pos;

        }


    }
}
