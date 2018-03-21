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
        Texture2D bulletTexture;
        Texture2D enemyTexture;
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
        Text text;

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
            //start level function() - which needs resetLevel();
            //initialising my main objects
            updateList.Add(player);
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
            Vector2 playerPosition = new Vector2((GraphicsDevice.Viewport.TitleSafeArea.Width / 2) , GraphicsDevice.Viewport.TitleSafeArea.Height -32);
            player.Initialize(Content.Load<Texture2D>("ship2"), playerPosition,new Vector2( GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height));
            objectsToDraw.Add(player);
            bulletTexture = Content.Load<Texture2D>("bullet");
            enemyTexture = Content.Load<Texture2D>("enemy2");
            smokeTexture = Content.Load<Texture2D>("smoke2");
            bgLayer1.Initialize(Content, "bg_4", GraphicsDevice.Viewport.Width, -0.2f);
            objectsToDraw.Add(bgLayer1);
            bgLayer2.Initialize(Content, "bg_3", GraphicsDevice.Viewport.Width, -0.3f);
            objectsToDraw.Add(bgLayer2);
            bgLayer3.Initialize(Content, "bg_5", GraphicsDevice.Viewport.Width, -0.4f);
            objectsToDraw.Add(bgLayer3);

            //text - ui
            text = new Text(spriteBatch);
            text.Load(Content);

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
        }
        Color backgroundColour = Color.DarkCyan;
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(backgroundColour);
            spriteBatch.Begin();
            DrawEntities();

            //draw fonts
            text.Draw("LIVES 3", new Vector2 (10, 10));

            if (paused)
            text.Draw("Pause", new Vector2(GraphicsDevice.Viewport.Width/2 - 100, GraphicsDevice.Viewport.Height / 2), 2);

            spriteBatch.End();
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

            CollisionDetection();
            AddEnemies();

            // Fire only every interval we set as the fireTime
            if (gameTime.TotalGameTime - previousFireTime > fireTime && PLAYER_INPUT.FIRE)
            {
                previousFireTime = gameTime.TotalGameTime;
                AddProjectile(player.position);
            }

           // ShipTrail();

            // Allows the game to exit
            if (PLAYER_INPUT.QUIT) this.Exit();
        }
        
        
        private void CollisionDetection()
        {
            for (int i = updateList.Count - 1; i >= 0; i--)
            {
                for (int j = updateList.Count - 1; j >= 0; j--)
                {
                    if (updateList[i].tag == "enemy" && updateList[j].tag == "bullet")
                    {
                        if (Mathf.Distance(updateList[i].position, updateList[j].position) < 45)
                        {
                            Random rnd = new Random();
                            updateList[i].OnCollision();
                            updateList[j].OnCollision("enemy");
                        }
                    }
                    if (updateList[i].tag == "enemy" && updateList[j].tag == "player")
                    {
                        if (Mathf.Distance(updateList[i].position, updateList[j].position) < 45)
                        {
                            updateList[i].OnCollision("player", updateList[j].position);
                            updateList[j].OnCollision();
                        }
                    }
                }
            }
        }

        private void AddProjectile(Vector2 position)
        {
            
            Bullet projectile = new Bullet();
            projectile.Initialize(GraphicsDevice.Viewport, bulletTexture, position, player.speedX);
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
        
        int enemyNum = 7;
        int enemyTimer = 250;
        private void AddEnemies()
        {
            
            enemyTimer++;
            if (enemyTimer > 250)
            {
                enemyNum = 7;
                while (enemyNum > 0)
                {
                    Enemy enemy = new Enemy();
                    enemy.Initialize(GraphicsDevice.Viewport, enemyTexture, new Vector2((64+ 38) * enemyNum, -32 ));
                    updateList.Add(enemy);
                    objectsToDraw.Add(enemy);
                    enemyNum--;
                }
                enemyTimer = 0;
            }
        }
        private void PauseLogic()
        {
            if (PLAYER_INPUT.PAUSE)
            {
                paused = !paused;
                if(paused) backgroundColour = Color.Gray;
                else backgroundColour = Color.DarkCyan;
            }
        }

    }
}
