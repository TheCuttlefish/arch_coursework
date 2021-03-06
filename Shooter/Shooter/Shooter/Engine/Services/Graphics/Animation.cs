﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine
{
    class Animation
    {

        Texture2D spriteStrip;
        float scale;
        int elapsedTime;
        int frameTime;
        int frameCount;
        int currentFrame;
        Color color;
        Rectangle sourceRect = new Rectangle();
        Rectangle destinationRect = new Rectangle();
        public int frameWidth;
        public int frameHeight;
        public bool active;
        public bool looping;
        public Vector2 position;
        public float alpha;

        public void Initialize(Texture2D texture, Vector2 position, int frameWidth, int frameHeight, int frameCount,int frametime, Color color, float scale, bool looping) {
           
            this.color = color;
            this.frameWidth = frameWidth;
            this.frameHeight = frameHeight;
            this.frameCount = frameCount;
            this.frameTime = frametime;
            this.scale = scale;
            this.looping = looping;
            this.position = position;
            spriteStrip = texture;
            elapsedTime = 0;
            currentFrame = 0;
            alpha = 1;
            active = true;
        }

        public void Update(GameTime gameTime) {
            
            if (active == false)
                return;

            elapsedTime += (int)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (elapsedTime > frameTime) {
          
                currentFrame++;

                if (currentFrame == frameCount) {
                    currentFrame = 0;
                    
                    if (looping == false)
                        active = false;
                }

                elapsedTime = 0;
            }

            sourceRect = new Rectangle(currentFrame * frameWidth, 0, frameWidth, frameHeight);

            destinationRect = new Rectangle((int)position.X - (int)(frameWidth * scale) / 2,
            (int)position.Y - (int)(frameHeight * scale) / 2,
            (int)(frameWidth * scale),
            (int)(frameHeight * scale));
        }

        public void Draw(SpriteBatch spriteBatch) {

            if (active) {
                spriteBatch.Draw(spriteStrip, destinationRect, sourceRect, color * alpha);
            }
        }
    }
}
