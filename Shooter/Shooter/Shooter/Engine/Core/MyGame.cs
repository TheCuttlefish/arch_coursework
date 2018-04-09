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
        
        public GameInput GameInput;
        public SpriteBatch spriteBatch;
        public TextureAsset sprite;
        public Collision collision;
        public Utility utility;
        GraphicsDeviceManager graphics;

        public MyGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }


       internal SpaceShooter spaceShooter;

        protected override void Initialize()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Services.AddService(typeof(SpriteBatch), spriteBatch);
            GameInput = new GameInput();
            GameInput.Load(this);
            Services.AddService(typeof(GameInput), GameInput);

            sprite = new TextureAsset(Content);
            Services.AddService(typeof(TextureAsset), sprite);

            collision = new Collision();
            Services.AddService(typeof(Collision), collision);

            utility = new Utility(this);
            Services.AddService(typeof(Utility), utility);

            spaceShooter = new SpaceShooter(this);
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();
        }
        
        protected override void Update(GameTime gameTime)
        {
            spaceShooter.Update(gameTime);
            GameInput.Update();
            collision.Update();
            utility.Update();
            if (GameInput.QUIT) this.Exit();
            base.Update(gameTime);
        }

       

        protected override bool BeginDraw()
        {
            GraphicsDevice.Clear(utility.background);
            spriteBatch.Begin();
            return base.BeginDraw();
        }
        protected override void EndDraw()
        {
            spriteBatch.End();
            base.EndDraw();
        }


    }
}
