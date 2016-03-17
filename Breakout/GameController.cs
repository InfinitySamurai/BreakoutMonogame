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
        private List<Brick> AllBricks { get; set; }
        private Breakout game;
        private Rectangle screenBounds;
        private List<Color> brickColors;
        private int bricksStartY;
        private int bricksFromEdges = 2;
        private Vector2 ballStartDirection = new Vector2(0,1);

        // All the sprites that will be used in the game
        private Dictionary<string, Texture2D> paddleTextures;
        private Texture2D blackBrickTexture;
        private Texture2D ballTexture;

        public GameController(Breakout game) {
            this.game = game;
            paddleTextures = new Dictionary<string, Texture2D>();
            screenBounds = new Rectangle(0, 0, game.GraphicsDevice.Viewport.Width, game.GraphicsDevice.Viewport.Height);
            brickColors = new List<Color>();
            brickColors.Add(Color.Red);
            brickColors.Add(Color.Blue);
            brickColors.Add(Color.Green);
            brickColors.Add(Color.Yellow);
            bricksStartY = screenBounds.Height / 10;
        }

        

        public void LoadContent() {
            paddleTextures["default"] = game.Content.Load<Texture2D>("paddles/defaultPaddle");
            paddleTextures["longPaddle"] = game.Content.Load<Texture2D>("paddles/longPaddle");
            blackBrickTexture = game.Content.Load<Texture2D>("bricks/blackBrick");
            ballTexture = game.Content.Load<Texture2D>("balls/defaultBall");
        }

        public void Setup(KeyboardState keyboardState) {
            playerPaddle = new Paddle(paddleTextures, GetPaddleStartingLocation());
            AllBricks = new List<Brick>();
            SpawnBricks();
            ball = new Ball(ballTexture, GetBallStartingLocation(), ballStartDirection);
            //while (true) {
            //    if (keyboardState.GetPressedKeys() != null) {
            //        break;
            //    }
            //}
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

        private Vector2 GetPaddleStartingLocation() {
            float startx = (screenBounds.Width / 2) - (paddleTextures["default"].Width / 2);
            float starty = screenBounds.Height - screenBounds.Height / 10f;
            return new Vector2(startx, starty);
        }

        private Vector2 GetBallStartingLocation() {
            float startx = (screenBounds.Width / 2) - (ballTexture.Width / 2);
            float starty = screenBounds.Height * 0.6f;
            return new Vector2(startx, starty);
        }

        private void SpawnBricks() {
            int bricksInRow = (int)(screenBounds.Width / blackBrickTexture.Width) - bricksFromEdges;
            int bricksStartX = (screenBounds.Width - bricksInRow * blackBrickTexture.Width) / 2;
            int j = 0;
            foreach(Color color in brickColors) {
                for(int i = 0; i < bricksInRow; i++) {
                    Vector2 brickPosition = new Vector2(bricksStartX + i * blackBrickTexture.Width, bricksStartY + j * blackBrickTexture.Height);
                    AllBricks.Add(new Brick(blackBrickTexture, brickPosition, color));
                }
                j++;
            }
        }

        public void Update() {
            ball.Update();
            ball.HandlePaddleCollision(playerPaddle.BoundingBox);
            ball.HandleWallCollision(screenBounds);
            foreach( Brick brick in AllBricks) {
                if(ball.HandleBrickCollision(brick.BoundingBox)) {
                    AllBricks.Remove(brick);
                    break;
                }
            }

            if(ball.Position.Y > playerPaddle.Position.Y) {
                Setup(new KeyboardState());
            }
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
