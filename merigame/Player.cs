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

        // Diversos estados: Walking, Dead, Shooting, etc.
        enum State { Walking }
        State currentState = State.Walking;

        KeyboardState prevKbState; // Tecla anteriormente presionada

        Vector2 direction;
        Vector2 speed;

        public Player(int x, int y) : base(x, y) {
            position = new Vector2(x, y);
            speed = Vector2.Zero;
            direction = Vector2.Zero;
        }

        public void LoadContent(ContentManager cm) {
            base.LoadContent(cm, ASSET_NAME);
        }

        public void Update(GameTime gt) {
            KeyboardState kbState = Keyboard.GetState();
            UpdateMovement(kbState);

            prevKbState = kbState;
            base.Update(gt, speed, direction);
        }

        private void UpdateMovement(KeyboardState kbState) {
            if (currentState == State.Walking) {
                speed = Vector2.Zero;
                direction = Vector2.Zero;

                // Moverse a la Izquierda
                if (kbState.IsKeyDown(Keys.A) == true) {
                    speed.X = VELOCITY;
                    direction.X = MOVE_LEFT;
                }

                // Moverse a la Derecha
                else if (kbState.IsKeyDown(Keys.D) == true) {
                    speed.X = VELOCITY;
                    direction.X = MOVE_RIGHT;
                }

                // Moverse Arriba
                else if (kbState.IsKeyDown(Keys.W) == true) {
                    speed.Y = VELOCITY;
                    direction.Y = MOVE_UP;
                }

                // Moverse Abajo
                else if (kbState.IsKeyDown(Keys.S) == true) {
                    speed.Y = VELOCITY;
                    direction.Y = MOVE_DOWN;
                }

            }
        }        

    }
}
