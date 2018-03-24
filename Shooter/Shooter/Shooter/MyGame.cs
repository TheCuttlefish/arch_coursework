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

        public PlayerInput playerInput;
        public SpriteBatch spriteBatch;
        public TextureAsset sprite;

        GraphicsDeviceManager graphics;
        
        Text text;

        
        Background bgLayer1;
        Background bgLayer2;
        Background bgLayer3;

        public MyGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }


        SpaceShooter spaceShooter;

        protected override void Initialize()
        {

            spriteBatch = new SpriteBatch(GraphicsDevice);
            Services.AddService(typeof(SpriteBatch), spriteBatch);

            //create a new game


            //input
            playerInput = new PlayerInput();
            playerInput.Load(this);
            Services.AddService(typeof(PlayerInput), playerInput);

            sprite = new TextureAsset(Content);
            //initialising my main objects
            bgLayer1 = new Background(this);
            bgLayer2 = new Background(this);
            bgLayer3 = new Background(this);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            //loadging my resourses

            bgLayer1.Initialize(sprite.bg1, GraphicsDevice.Viewport.Width, -0.2f);
            
            bgLayer2.Initialize(sprite.bg2, GraphicsDevice.Viewport.Width, -0.3f);
            
            bgLayer3.Initialize(sprite.bg3, GraphicsDevice.Viewport.Width, -0.4f);
            

            //text - ui
            text = new Text(spriteBatch);
            text.Load(Content);

            spaceShooter = new SpaceShooter(this);

            base.LoadContent();
            
        }
        
        protected override void Update(GameTime gameTime)
        {
            playerInput.Update();
            if (playerInput.QUIT) this.Exit();
            base.Update(gameTime);
        }

        Color backgroundColour = Color.DarkCyan;

        protected override bool BeginDraw()
        {
            GraphicsDevice.Clear(backgroundColour);
            spriteBatch.Begin();
            return base.BeginDraw();
        }
        protected override void Draw(GameTime gameTime)
        {  
           //DrawEntities();
            //spaceShooter.extraDraw(spriteBatch);
            //text.Draw("LIVES ", new Vector2 (10, 10));
            base.Draw(gameTime);
        }
        protected override void EndDraw()
        {
            spriteBatch.End();
            base.EndDraw();
        }


    }
}
