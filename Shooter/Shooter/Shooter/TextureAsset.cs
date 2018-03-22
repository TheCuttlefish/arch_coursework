using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Shooter
{
    class TextureAsset : Microsoft.Xna.Framework.Game
    {

        public Texture2D player;
        public Texture2D enemy;
        public Texture2D enemy2;
        public Texture2D bullet;
        public Texture2D smoke;

        public Texture2D bg1;
        public Texture2D bg2;
        public Texture2D bg3;

        public Texture2D power1;
        public Texture2D power2;
        public Texture2D power3;
        public Texture2D extraLife;
        public Texture2D clearScreen;

        public TextureAsset(ContentManager c)
        {
            player = c.Load<Texture2D>("ship4");
            enemy = c.Load<Texture2D>("enemy2");
            enemy2 = c.Load<Texture2D>("enemyvar2");
            bullet = c.Load<Texture2D>("bullet");
            smoke = c.Load<Texture2D>("smoke2");

            bg1 = c.Load<Texture2D>("bg_4");
            bg2 = c.Load<Texture2D>("bg_3");
            bg3 = c.Load<Texture2D>("bg_5");

            power1 = c.Load<Texture2D>("power1");
            power2 = c.Load<Texture2D>("power2");
            power3 = c.Load<Texture2D>("power3");
            extraLife = c.Load<Texture2D>("extra");
            clearScreen = c.Load<Texture2D>("clear");

        }

        
    }
}
