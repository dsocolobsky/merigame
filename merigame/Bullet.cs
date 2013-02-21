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

        public Vector2 speed;
        public Vector2 direction;
        public Vector2 destiny;
        public Vector2 angle;

        public Bullet(Texture2D txt, Vector2 origin, Vector2 dest) : base(origin) {
            this.texture = txt;

            this.Scale = 0.5f;
            this.position = origin;

            destiny = dest;
        }

        public void Update(GameTime gt, MouseState ms) {
            move(gt, ms);
            base.Update(gt, speed, direction);
        }

        public void move(GameTime gt, MouseState ms) {
            speed = Vector2.Zero;
            direction = Vector2.Zero;
            
            speed.Y = VELOCITY;
            speed.X = VELOCITY;

            if (destiny.Y > position.Y) {
                direction.Y = MOVE_DOWN;
            }
            else {
                direction.Y = MOVE_UP;
            }

            if (destiny.X > position.X) {
                direction.X = MOVE_RIGHT;
            }
            else {
                direction.X = MOVE_LEFT;
            }
        }

    }
}
