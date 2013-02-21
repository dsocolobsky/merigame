using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;

namespace merigame {
    class Player : SpriteEntity {

        const string ASSET_NAME = "skel";
        const int VELOCITY = 160;

        const int MOVE_UP = -1;
        const int MOVE_DOWN = 1;
        const int MOVE_LEFT = -1;
        const int MOVE_RIGHT = 1;

        const int START_X = 200;
        const int START_Y = 200;

        const int MAX_BULLETS = 20;  //pregunto, el numero de balas no seria mejor meterlas dentrto
                                     //de la propia clase de cada arma? porque no tiene sentido que sea la misma para todas
        enum State { LookingLeft, LookingRight, LookingUp,
        LookingDown}
        enum TotalState { Alive }
        State currentState = State.LookingUp;
        TotalState totalState = TotalState.Alive;

        KeyboardState prevKbState;

        Vector2 direction;
        Vector2 speed;

        public int currentBullets;

        public Texture2D bulletTexture;

        public List<Bullet> bullets;

        public Player(Vector2 origin) : base(origin) {
            speed = Vector2.Zero;
            direction = Vector2.Zero;
            bullets = new List<Bullet>();
            scale = 2.5f;
        }

        public void LoadContent(ContentManager cm) {
            position = new Vector2(START_X, START_Y);
            base.LoadContent(cm, ASSET_NAME);
            source = new Rectangle(0, 0, 200, source.Height);
        }

        public void Update(GameTime gt, MouseState ms) {
            KeyboardState kbState = Keyboard.GetState();
            UpdateMovement(gt, kbState, ms);
            currentBullets = bullets.Count;
            prevKbState = kbState;
            base.Update(gt, speed, direction);
        }

        private void shoot(GameTime gt, Vector2 direction) {
            if (currentBullets < MAX_BULLETS) {
                bullets.Add(new Bullet(bulletTexture, new Vector2((int)position.X, (int)position.Y),
                    new Vector2(direction.X, direction.Y)));
            }
        }

        private void UpdateMovement(GameTime gt, KeyboardState kbState, MouseState ms) {
            if (totalState == TotalState.Alive) {
                speed = Vector2.Zero;
                direction = Vector2.Zero;
                

                // Shoot
                if (ms.LeftButton == ButtonState.Pressed) {
                    shoot(gt, new Vector2(ms.X, ms.Y));
                }

                // Move left
                if (kbState.IsKeyDown(Keys.A) == true) {
                    move("left");
                }

                // Move right
                else if (kbState.IsKeyDown(Keys.D) == true) {
                    move("right");
                }

                // Move up
                else if (kbState.IsKeyDown(Keys.W) == true) {
                    move("up");
                }

                // Move down
                else if (kbState.IsKeyDown(Keys.S) == true) {
                    move("down");
                }

            }

        }

        private void move(string dir) {
            switch (dir) {
                case "left":
                    speed.X = VELOCITY;
                    direction.X = MOVE_LEFT;
                    source = new Rectangle(0, 96, 12, 17);
                    currentState = State.LookingLeft;
                    break;

                case "right":
                    speed.X = VELOCITY;
                    direction.X = MOVE_RIGHT;
                    source = new Rectangle(0, 64, 12, 17);
                    currentState = State.LookingLeft;
                    break;

                case "up":
                    speed.Y = VELOCITY;
                    direction.Y = MOVE_UP;
                    source = new Rectangle(0, 32, 12, 16);
                    currentState = State.LookingLeft;
                    break;

                case "down":
                    speed.Y = VELOCITY;
                    direction.Y = MOVE_DOWN;
                    source = new Rectangle(0, 0, 12, 16);
                    currentState = State.LookingLeft;
                    break;
            }
        }

    }
}
