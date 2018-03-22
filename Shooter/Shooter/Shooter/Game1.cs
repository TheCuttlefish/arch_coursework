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
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        TextureAsset sprite;
        Text text;
        List<Entity> objectsToDraw;
        List<Entity> updateList;

        Player player;
        Background bgLayer1;
        Background bgLayer2;
        Background bgLayer3;

        TimeSpan fireTime;
        TimeSpan previousFireTime;

        bool paused = false;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
   
        protected override void Initialize()
        {
            sprite = new TextureAsset(Content);
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
            player.Initialize(sprite.player, playerPosition,new Vector2( GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height));
            objectsToDraw.Add(player);
            bgLayer1.Initialize(sprite.bg1, GraphicsDevice.Viewport.Width, -0.2f);
            objectsToDraw.Add(bgLayer1);
            bgLayer2.Initialize(sprite.bg2, GraphicsDevice.Viewport.Width, -0.3f);
            objectsToDraw.Add(bgLayer2);
            bgLayer3.Initialize(sprite.bg3, GraphicsDevice.Viewport.Width, -0.4f);
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
            text.Draw("LIVES "+ player.health, new Vector2 (10, 10));

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


                    int rndNum = Mathf.RandomRange(0, 7);
                    if (updateList[i].tag == "enemy" && rndNum == 0)
                    {
                        AddPowerUp(updateList[i].position);
                    }
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
                if(player.bulletType == 0)
                AddProjectile(player.position);
                else if (player.bulletType == 1)
                {
                    AddProjectile(player.position + new Vector2(10,0));
                    AddProjectile(player.position + new Vector2(-10, 0));
                }
                else if (player.bulletType == 2)
                {
                    AddProjectile(player.position + new Vector2(20, 0));
                    AddProjectile(player.position);
                    AddProjectile(player.position + new Vector2(-20, 0));
                }

                
            }


            if (player.clearAll ||  PLAYER_INPUT.CLEAR)
            {
                foreach (Entity e in updateList)
                {
                    if (e.tag == "enemy")
                        e.active = false;
                }
                player.clearAll = false;
            }

            //ShipTrail();

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

                    if (updateList[i].tag == "powerup" && updateList[j].tag == "player")
                    {
                        if (Mathf.Distance(updateList[i].position, updateList[j].position) < 90)
                        {
                            updateList[i].OnCollision("player", updateList[j].position);
                            updateList[j].OnCollision("powerup", updateList[i].position, updateList[i].name);
                        }
                    }
                }
            }
        }

        private void AddPowerUp(Vector2 _position)
        {
            PowerUp p = new PowerUp();
            p.Initialize(sprite.extraLife, _position, sprite);
            updateList.Add(p);
            objectsToDraw.Add(p);

        }
        private void AddProjectile(Vector2 position)
        {
            
            Bullet projectile = new Bullet();
            projectile.Initialize(GraphicsDevice.Viewport, sprite.bullet, position, player.speedX);
            updateList.Add(projectile);
            objectsToDraw.Add(projectile);
        }
        private void ShipTrail()
        {
            Smoke smokeParticle = new Smoke();
            smokeParticle.Initialize(GraphicsDevice.Viewport, sprite.smoke, player.position + new Vector2(0, 32));
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
                    enemy.Initialize( sprite.enemy, new Vector2((64 + 38) * enemyNum, -32));

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
