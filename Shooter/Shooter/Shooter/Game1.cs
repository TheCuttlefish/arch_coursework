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
        List<Bullet> projectiles;
        List<Entity> objectsToDraw;

        // The rate of fire of the player laser
        TimeSpan fireTime;
        TimeSpan previousFireTime;


        // Parallaxing Layers
        Background bgLayer1;
        Background bgLayer2;
        Background bgLayer3;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            

            player = new Player();
            player.ScreenLimitX = GraphicsDevice.Viewport.Width;
            player.ScreenLimitY = GraphicsDevice.Viewport.Height;

            projectiles = new List<Bullet>();
            objectsToDraw = new List<Entity>();
            fireTime = TimeSpan.FromSeconds(.15f);

            bgLayer1 = new Background();
            bgLayer2 = new Background();
            bgLayer3 = new Background();
            base.Initialize();
        }


        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);


            // Load the player resources 
            Vector2 playerPosition = new Vector2((GraphicsDevice.Viewport.TitleSafeArea.Width / 2) -32, GraphicsDevice.Viewport.TitleSafeArea.Height -32);
            player.Initialize(Content.Load<Texture2D>("ship"), playerPosition);
            objectsToDraw.Add(player);
            //bullet
            projectileTexture = Content.Load<Texture2D>("bullet");

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

            UpdateProjectiles();

            // Fire only every interval we set as the fireTime
            if (gameTime.TotalGameTime - previousFireTime > fireTime && PLAYER_INPUT.FIRE)
            {
                // Reset our current time
                previousFireTime = gameTime.TotalGameTime;

                // Add the projectile, but add it to the front and center of the player
                AddProjectile(player.Position);

            }

           

            bgLayer1.Update();
            bgLayer2.Update();
            bgLayer3.Update();
            PLAYER_INPUT.Update();
            //Update the player
            player.Update();
          //  UpdatePlayer(gameTime);


            // Allows the game to exit
            if (PLAYER_INPUT.QUIT) this.Exit();
            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.DarkCyan);

            // Start drawing
            spriteBatch.Begin();

           // draw objects
            for (int i = 0; i < objectsToDraw.Count; i++)
            {
                   objectsToDraw[i].Draw(spriteBatch);
            }

            // Stop drawing
            spriteBatch.End();



            base.Draw(gameTime);
        }

        // other functions
        private void AddProjectile(Vector2 position)
        {
            Bullet projectile = new Bullet();
            projectile.Initialize(GraphicsDevice.Viewport, projectileTexture, position);
            projectiles.Add(projectile);
            objectsToDraw.Add(projectile);
        }

        private void UpdateProjectiles()
        {
            // Update the Projectiles
            for (int i = projectiles.Count - 1; i >= 0; i--)
            {
                projectiles[i].Update();

                if (projectiles[i].Active == false)
                {
                    projectiles.RemoveAt(i);
                }
            }

            for (int i = objectsToDraw.Count - 1; i >= 0; i--)
            {
             
                if (objectsToDraw[i].Active == false)
                {
                    objectsToDraw.RemoveAt(i);
                }
            }


        }
    }
}
