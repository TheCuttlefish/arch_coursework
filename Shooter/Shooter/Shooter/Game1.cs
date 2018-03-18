using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;



namespace Shooter
{

    public class Game1 : Microsoft.Xna.Framework.Game
    {
        Player player;
        // Image used to display the static background
        Texture2D projectileTexture;
        Texture2D smokeTexture;
        List<Entity> objectsToDraw;
        List<Entity> updateList;

        // The rate of fire of the player laser
        TimeSpan fireTime;
        TimeSpan previousFireTime;

        // Parallaxing Layers
        Background bgLayer1;
        Background bgLayer2;
        Background bgLayer3;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;


        bool paused = false;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            
            objectsToDraw = new List<Entity>();
            updateList = new List<Entity>();

            player = new Player();
            updateList.Add(player);
            player.screenLimitX = GraphicsDevice.Viewport.Width;
            player.screenLimitY = GraphicsDevice.Viewport.Height;
            fireTime = TimeSpan.FromSeconds(.15f);

            bgLayer1 = new Background();
            updateList.Add(bgLayer1);
            bgLayer2 = new Background();
            updateList.Add(bgLayer2);
            bgLayer3 = new Background();
            updateList.Add(bgLayer3);
            base.Initialize();
        }


        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //loadging my resourses
            Vector2 playerPosition = new Vector2((GraphicsDevice.Viewport.TitleSafeArea.Width / 2) -32, GraphicsDevice.Viewport.TitleSafeArea.Height -32);
            player.Initialize(Content.Load<Texture2D>("ship2"), playerPosition);
            objectsToDraw.Add(player);
            projectileTexture = Content.Load<Texture2D>("bullet");
            smokeTexture = Content.Load<Texture2D>("smoke2");
            bgLayer1.Initialize(Content, "bg_4", GraphicsDevice.Viewport.Width, -0.2f);
            objectsToDraw.Add(bgLayer1);
            bgLayer2.Initialize(Content, "bg_3", GraphicsDevice.Viewport.Width, -0.3f);
            objectsToDraw.Add(bgLayer2);
            bgLayer3.Initialize(Content, "bg_5", GraphicsDevice.Viewport.Width, -0.4f);
            objectsToDraw.Add(bgLayer3);

        }


        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
           
            PLAYER_INPUT.Update(); // update Input
            PauseLogic();
            if (paused) return;
                UpdateEntities();
                GameLogic(gameTime);
               // base.Update(gameTime);// what is this??(game works without it)

        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkCyan);
            spriteBatch.Begin();
            DrawEntities();
            spriteBatch.End();
            base.Draw(gameTime);
        }

        // other functions

        private void DrawEntities()
        {
            for (int i = objectsToDraw.Count - 1; i >= 0; i--)
            {
                objectsToDraw[i].Draw(spriteBatch);
                if (objectsToDraw[i].active == false)
                { //remove unactive ones
                    objectsToDraw.RemoveAt(i);
                }
            }
        }

        private void UpdateEntities()
        {
            for (int i = updateList.Count - 1; i >= 0; i--)
            {
                updateList[i].Update();
                if (updateList[i].active == false)
                {
                   // updateList[i] = null; - garbage collection?
                    updateList.RemoveAt(i);
             
                }
            }
        }

        private void GameLogic(GameTime gameTime)
        {

            

            // Fire only every interval we set as the fireTime
            if (gameTime.TotalGameTime - previousFireTime > fireTime && PLAYER_INPUT.FIRE)
            {
                previousFireTime = gameTime.TotalGameTime;
                AddProjectile(player.position);
            }

            ShipTrail();

            // Allows the game to exit
            if (PLAYER_INPUT.QUIT) this.Exit();
        }

        private void AddProjectile(Vector2 position)
        {
            Bullet projectile = new Bullet();
            projectile.Initialize(GraphicsDevice.Viewport, projectileTexture, position, player.speedX);
            updateList.Add(projectile);
            objectsToDraw.Add(projectile);




        }

        private void ShipTrail()
        {
            Smoke smokeParticle = new Smoke();
            smokeParticle.Initialize(GraphicsDevice.Viewport, smokeTexture, player.position + new Vector2(0, 32));
            updateList.Add(smokeParticle);
            objectsToDraw.Add(smokeParticle);
        }

        private void PauseLogic()
        {
            if (PLAYER_INPUT.PAUSE)
            {
                paused = !paused;
            }
        }

    }
}
