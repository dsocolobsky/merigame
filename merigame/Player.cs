using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;

namespace merigame {
    class Player : Entity {

        const string ASSET_NAME = "guy";
        const int VELOCITY = 160;
        const int MOVE_UP = -1;
        const int MOVE_DOWN = 1;
        const int MOVE_LEFT = -1;
        const int MOVE_RIGHT = 1;

        enum State { Walking }
        State currentState = State.Walking;

        KeyboardState prevKbState;

        Vector2 direction;
        Vector2 speed;

        public Texture2D bulletTexture;

        public List<Bullet> bullets;

        public Player(int x, int y) : base(x, y) {
            position = new Vector2(x, y);
            speed = Vector2.Zero;
            direction = Vector2.Zero;
            bullets = new List<Bullet>();
        }

        public void LoadContent(ContentManager cm) {
            base.LoadContent(cm, ASSET_NAME);
        }

        public void Update(GameTime gt, MouseState ms) {
            KeyboardState kbState = Keyboard.GetState();
            UpdateMovement(kbState, ms);

            prevKbState = kbState;
            base.Update(gt, speed, direction);
        }

        private void shoot(int x, int y) {
            bullets.Add(new Bullet(bulletTexture, (int)position.X, (int)position.Y));
        }

        private void UpdateMovement(KeyboardState kbState, MouseState ms) {
            if (currentState == State.Walking) {
                speed = Vector2.Zero;
                direction = Vector2.Zero;

                // Shoot
                if (ms.LeftButton == ButtonState.Pressed) {
                    shoot(ms.X, ms.Y);
                }

                // Move left
                if (kbState.IsKeyDown(Keys.A) == true) {
                    speed.X = VELOCITY;
                    direction.X = MOVE_LEFT;
                }

                // Move right
                else if (kbState.IsKeyDown(Keys.D) == true) {
                    speed.X = VELOCITY;
                    direction.X = MOVE_RIGHT;
                }

                // Move up
                else if (kbState.IsKeyDown(Keys.W) == true) {
                    speed.Y = VELOCITY;
                    direction.Y = MOVE_UP;
                }

                // Move down
                else if (kbState.IsKeyDown(Keys.S) == true) {
                    speed.Y = VELOCITY;
                    direction.Y = MOVE_DOWN;
                }

            }
        }        

    }
}
