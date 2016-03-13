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
        
        public void Move(int direction) {
            Vector2 movement = new Vector2(direction * moveSpeed, 0);
            Position += movement;
        }

        public void Update() {

        }

    }
}
