using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Breakout {
    class Ball : GameObject{

        Vector2 Velocity { get; set; }

        public Ball(Texture2D texture, Vector2 position, Vector2 velocity) {
            this.texture = texture;
            Position = position;
            Velocity = velocity;
        }

        public bool BrickCollision(Rectangle brickBox) {

            return false;
        }

        public void Update() {
            Position += Velocity;
        }

    }
}
