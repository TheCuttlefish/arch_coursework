using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine
{
   public class TextureAsset : Microsoft.Xna.Framework.Game
    {

        public Texture2D player;
        public Texture2D enemy;
        public Texture2D eater;
        public Texture2D slider;
        public Texture2D spitter;
        public Texture2D splitter;
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
        public Texture2D earth;
        public Texture2D nebula;
        public Texture2D fire;
        public Texture2D rocket;
        //icons
        public Texture2D icon_earth;
        public Texture2D icon_live;
        public Texture2D icon_bullet;
        public Texture2D icon_bullet2;
        public Texture2D icon_bullet3;
        public Texture2D icon_infinity;


        public TextureAsset(ContentManager c)
        {
            player = c.Load<Texture2D>("Sprites/ship4");
            enemy = c.Load<Texture2D>("Sprites/eater2");
            eater = c.Load<Texture2D>("Sprites/eater2");
            slider = c.Load<Texture2D>("Sprites/slider");
            spitter = c.Load<Texture2D>("Sprites/spitter");
            splitter = c.Load<Texture2D>("Sprites/splitter2");
            bullet = c.Load<Texture2D>("Sprites/bullet");
            smoke = c.Load<Texture2D>("Sprites/smoke2");
            bg1 = c.Load<Texture2D>("Sprites/bg_4");
            bg2 = c.Load<Texture2D>("Sprites/bg_3");
            bg3 = c.Load<Texture2D>("Sprites/bg_5");
            power1 = c.Load<Texture2D>("Sprites/power1");
            power2 = c.Load<Texture2D>("Sprites/power2");
            power3 = c.Load<Texture2D>("Sprites/power3");
            extraLife = c.Load<Texture2D>("Sprites/extra");
            clearScreen = c.Load<Texture2D>("Sprites/clear");
            earth = c.Load<Texture2D>("Sprites/earth");
            icon_earth = c.Load<Texture2D>("Sprites/earth_icon");
            icon_live = c.Load<Texture2D>("Sprites/live_icon");
            icon_bullet = c.Load<Texture2D>("Sprites/icon_bullet");
            icon_bullet2 = c.Load<Texture2D>("Sprites/icon_bullet2");
            icon_bullet3 = c.Load<Texture2D>("Sprites/icon_bullet3");
            icon_infinity = c.Load<Texture2D>("Sprites/infinity");
            nebula = c.Load<Texture2D>("Sprites/nebula2");
            fire = c.Load<Texture2D>("Sprites/fire2");
            rocket = c.Load<Texture2D>("Sprites/rocket");
        }

        
    }
}
