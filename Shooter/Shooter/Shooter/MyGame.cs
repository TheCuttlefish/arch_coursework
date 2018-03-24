using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;



namespace GameEngine
{
    
    public class MyGame : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        TextureAsset sprite;
        Text text;
        List<Entity> objectsToDraw;

        Player player;
        Background bgLayer1;
        Background bgLayer2;
        Background bgLayer3;

        PlayerInput playerInput;

        public MyGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }


        SpaceShooter spaceShooter;

        protected override void Initialize()
        {
            //create a new game
            spaceShooter = new SpaceShooter(this);

            //input
            playerInput = new PlayerInput();
            playerInput.Load(this);
            Services.AddService(typeof(PlayerInput), playerInput);

            sprite = new TextureAsset(Content);
            objectsToDraw = new List<Entity>();
            player = new Player(this);

            //initialising my main objects
            bgLayer1 = new Background(this);
            bgLayer2 = new Background(this);
            bgLayer3 = new Background(this);

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
            playerInput.Update();
            if (playerInput.QUIT) this.Exit();
            base.Update(gameTime);
        }

        Color backgroundColour = Color.DarkCyan;
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(backgroundColour);
            spriteBatch.Begin();
            DrawEntities();
            text.Draw("LIVES ", new Vector2 (10, 10));
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


    }
}
