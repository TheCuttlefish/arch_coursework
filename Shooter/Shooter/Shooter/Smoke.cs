﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shooter
{
    class Smoke : Entity
    {
        public int damage;
        Viewport viewport;
        float projectileMoveSpeed;

        public void Initialize(Viewport viewport, Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            base.position = position + new Vector2(rnd.Next(-10,10),0);
            this.viewport = viewport;
            active = true;
            damage = 2;
            projectileMoveSpeed = 5f + rnd.Next(-2,2);
            rotation = rnd.Next(0, 360);
        }
        public override void Update()
        {
            if( alpha> 0.0f )
               alpha -= 0.05f;
            else
               active = false;

            position.Y += projectileMoveSpeed;
        }
        public override void Draw( SpriteBatch spriteBatch )
        {
            spriteBatch.Draw(texture, position, null, colour * alpha, rotation,
            new Vector2(width / 2, height / 2), scale/2, SpriteEffects.None, 0f);
        }

    }
}