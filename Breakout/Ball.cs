using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Breakout {
    class Ball : GameObject{

        private Vector2 velocity;
        private bool deflected = false;
        private int speed = 1;

        public Ball(Texture2D texture, Vector2 position, Vector2 velocity) {
            this.texture = texture;
            Position = position;
            this.velocity = velocity*speed;
        }

        public bool HandleBrickCollision(Rectangle brickBox) {
            Rectangle intersection = Rectangle.Intersect(BoundingBox, brickBox);
            if(intersection.Height != 0) {
                if((intersection.Width > intersection.Height) && !deflected) {
                    Position -= velocity;
                    velocity.Y *= -1;
                    deflected = true;
                }
                else if((intersection.Height > intersection.Width) && !deflected) {
                    Position -= velocity;
                    velocity.X *= -1;
                    deflected = true;
                }

                Console.WriteLine(intersection);
                return true;
            }
            return false;

        }

        public void HandlePaddleCollision(Rectangle paddleBox) {
            if(this.BoundingBox.Intersects(paddleBox)) {
                velocity.Y *= -1;
            }
        }

        public void HandleWallCollision(Rectangle wallBounds) {
            if (Position.X < 0) {
                Position = new Vector2(0, Position.Y);
                velocity.X *= -1;
            }
            else if(Position.X + texture.Width > wallBounds.Width) {
                velocity.X *= -1;
            }
            if (Position.Y <= 0) {
                velocity.Y *= -1;
            }
            if(Position.Y + texture.Height > wallBounds.Height) {
                velocity.Y *= -1;
            }
        }

        public void Update() {
            Position += velocity;
            deflected = false;
        }

    }
}
