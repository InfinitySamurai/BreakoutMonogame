using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Breakout {

    public class GameController {

        private Paddle playerPaddle;
        private Ball ball;
        public List<Brick> AllBricks { get; set; }
        private Breakout game;

        // All the sprites that will be used in the game
        private Dictionary<string, Texture2D> paddleTextures;
        private Texture2D blackBrickTexture;
        private Texture2D ballTexture;

        public GameController(Breakout game) {
            this.game = game;
            paddleTextures = new Dictionary<string, Texture2D>();
        }

        

        public void LoadContent() {
            paddleTextures["default"] = game.Content.Load<Texture2D>("paddles/defaultPaddle");
            paddleTextures["longPaddle"] = game.Content.Load<Texture2D>("paddles/longPaddle");
            blackBrickTexture = game.Content.Load<Texture2D>("bricks/blackBrick");
            ballTexture = game.Content.Load<Texture2D>("balls/defaultBall");
        }

        public void Setup() {
            playerPaddle = new Paddle(paddleTextures, GetStartingLocation(game.GraphicsDevice.Viewport.Width, game.GraphicsDevice.Viewport.Height));
            AllBricks = new List<Brick>();
            AllBricks.Add(new Brick(blackBrickTexture, new Vector2(250, 200), Color.Red));
            ball = new Ball(ballTexture, new Vector2(0, 500), new Vector2(2, -2));
        }

        public void GameStart() {

        }

        public void TakeInput(KeyboardState oldState, KeyboardState newState) {
            if (newState.IsKeyDown(Keys.Right)){
                playerPaddle.Move(1);
            }
            else if (newState.IsKeyDown(Keys.Left)){
                playerPaddle.Move(-1);
            }
        }

        private Vector2 GetStartingLocation(int width, int height) {
            float startx = (width / 2) - (paddleTextures["default"].Width / 2);
            float starty = height - height / 10f;
            return new Vector2(startx, starty);
        }

        public void Update() {
            ball.Update();
        }

        public void Draw(SpriteBatch spriteBatch) {
            playerPaddle.Draw(spriteBatch);
            foreach (Brick brick in AllBricks) {
                brick.Draw(spriteBatch);
            }
            ball.Draw(spriteBatch);
        }
    }
}
