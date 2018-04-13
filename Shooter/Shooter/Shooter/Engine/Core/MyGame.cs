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
        public int gameState;
        internal SpaceShooter spaceShooter;
        internal Menu menu;
        internal ScoreMenu scoreMenu;
        GraphicsDeviceManager graphics;

        public MyGame() {

            gameState = 0;
            graphics = new GraphicsDeviceManager( this );
            Content.RootDirectory = "Content";
        }

        protected override void Initialize() {

            spriteBatch = new SpriteBatch( GraphicsDevice );
            Services.AddService( typeof( SpriteBatch ), spriteBatch );
            GameInput = new GameInput();
            GameInput.Load( this );
            Services.AddService( typeof( GameInput ), GameInput );
            sprite = new TextureAsset( Content );
            Services.AddService( typeof( TextureAsset ), sprite );
            collision = new Collision();
            Services.AddService( typeof( Collision ), collision );
            utility = new Utility( this );
            Services.AddService( typeof( Utility ), utility );
            menu = new Menu( this );
            base.Initialize();
        }

        protected override void LoadContent() {

            base.LoadContent();
        }
        
        protected override void Update( GameTime gameTime )  {

            ManageGameStates( gameTime );
            GameInput.Update();
            collision.Update();
            utility.Update();
            base.Update( gameTime );
        }


       void ManageGameStates( GameTime gameTime ) {

            if (gameState == 0)
                menu.Update( gameTime );
            if (gameState == 1)
                spaceShooter.Update( gameTime );
            if (gameState == 2)
                scoreMenu.Update( gameTime );
        }


        public void ChangeGameState( int number ) {

            gameState = number;
            menu = null;
            scoreMenu = null;
            spaceShooter = null;

            if (number == 0)
                menu = new Menu( this );
            if (number == 1)
                spaceShooter = new SpaceShooter( this );
            if (number == 2)
                scoreMenu = new ScoreMenu( this );
        }

        protected override bool BeginDraw() {

            GraphicsDevice.Clear( utility.background );
            spriteBatch.Begin();
            return base.BeginDraw();
        }

        protected override void EndDraw() {

            spriteBatch.End();
            base.EndDraw();
        }
    }
}
