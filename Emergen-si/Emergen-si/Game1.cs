using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Emergen_si
{
    enum GameState
    {
        menu,
        gameplay
    }
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;


        GameState gameState;

        GamePlay gamePlay;
        #region Resolution stuff

        public Vector2 virtualScreen;
        Vector3 scalingFactor;
        public Matrix scale;
        #endregion

        Texture2D fill;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferMultiSampling = false;

            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;

            virtualScreen = new Vector2(1280, 720);
           // graphics.IsFullScreen = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            CalculateScaling(0);

            gamePlay = new GamePlay(Content);
            gameState = GameState.gameplay;

            fill = new Texture2D(GraphicsDevice, 1, 1);
            fill.SetData(new Color[] { Color.White });

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            // TODO: Add your update logic here

            switch(gameState)
            {
                case GameState.gameplay:
                    gamePlay.Update(gameTime);
                    break;

                case GameState.menu:
                    break;
            }
           
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            Matrix WVP = scale;// * cam.viewMatrix;
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointWrap, null, null, null, WVP);

            switch(gameState)
            {
                case GameState.gameplay:
                    gamePlay.Draw(spriteBatch, fill);
                    break;

                case GameState.menu:

                    break;
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }

        protected void CalculateScaling(float value)
        {
            float widthScale = (float)(GraphicsDevice.PresentationParameters.BackBufferWidth / virtualScreen.X) + value;
            float heightScale = (float)(GraphicsDevice.PresentationParameters.BackBufferHeight / virtualScreen.Y) + value;
            scalingFactor = new Vector3(widthScale, heightScale, 1);
            scale = Matrix.CreateScale(scalingFactor);
        }
    }
}
