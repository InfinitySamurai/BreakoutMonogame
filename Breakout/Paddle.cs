using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Breakout {
    public class Paddle : GameObject{

        private float moveSpeed = 5;

        private Dictionary<string, Texture2D> textures;

        public Paddle(Dictionary<string, Texture2D> textures, Vector2 position){
            Position = position;
            this.textures = textures;
            texture = textures["default"];
        }
        
        public void Move(int direction, Rectangle screenBounds) {
            Vector2 newPosition = Position + new Vector2(direction * moveSpeed, 0);
            if(newPosition.X > screenBounds.X) {
                if(newPosition.X + texture.Width < screenBounds.Width) {
                    Position = newPosition;
                }
            }
        }

        public void Update() {

        }

    }
}
