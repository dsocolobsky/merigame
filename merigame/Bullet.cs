using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;

namespace merigame {
    class Bullet : Entity {
        const int VELOCITY = 200;

        public Texture2D texture;
        public Vector2 position;
        public Vector2 speed;
        public Vector2 direction;

        public Bullet(Texture2D txt, int x, int y) : base(x, y) {
            texture = txt;

            position.X = x;
            position.Y = y;
        }

        public void Update(GameTime gt, MouseState ms) {
            move(gt, ms);
            base.Update(gt, speed, direction);
        }

        public void move(GameTime gt, MouseState ms) {
            speed = Vector2.Zero;
            direction = Vector2.Zero;

            speed.Y = VELOCITY;
            direction.Y = MOVE_DOWN;
        }

    }
}
