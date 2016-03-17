using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Breakout {
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Breakout : Game {

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        KeyboardState KeyboardOldState;

        GameController gameController;

        bool gameSetup = false;
        bool gameStarted = false;

        public Breakout() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 800;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize() {
            // TODO: Add your initialization logic here
            gameController = new GameController(this);
            base.Initialize();
            KeyboardOldState = Keyboard.GetState();
            
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent() {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here
            gameController.LoadContent();
           
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent() {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
            if(!gameSetup) {
                gameController.Setup(KeyboardOldState);
                gameSetup = true;
            }
            else if(!gameStarted) {
                gameController.GameStart();
                gameStarted = true;
            }
            else {
                KeyboardState KeyboardNewState = Keyboard.GetState();
                gameController.TakeInput(KeyboardOldState, KeyboardNewState);
                gameController.Update();
                KeyboardOldState = KeyboardNewState;
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            gameController.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
