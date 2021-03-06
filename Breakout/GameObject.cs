﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Breakout {
    public class GameObject {

        public Vector2 Position { get; set; }
        public Texture2D texture;

        public Rectangle BoundingBox
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, texture.Width, texture.Height);
            }
        }

        public Vector2 GetCentre
        {
            get
            {
                return new Vector2(Position.X+texture.Width/2, Position.Y+texture.Height/2);
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(texture, Position, Color.White);
        }
    }
}
