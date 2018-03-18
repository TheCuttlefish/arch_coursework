using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shooter
{
    class Entity
    {

        public Vector2 Position;
        public bool Active = true;

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            
        }
    }
}
