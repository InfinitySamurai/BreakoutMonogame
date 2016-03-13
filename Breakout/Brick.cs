using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Breakout {

    class Brick : GameObject{

        private Color brickColor;

        public Brick(Texture2D texture, Vector2 position, Color color){
            Position = position;
            brickColor = color;
            this.texture = texture;
        }

        public void Update() {

        }

        public override void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(texture, Position, brickColor);
        }
    }
}
