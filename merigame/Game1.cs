#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
#endregion

namespace merigame {

    public class Game1 : Game {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Entity pointer; // Para apuntar
        Player player; // Jugador principal

        public Game1() : base() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }


        protected override void Initialize() {
            IsMouseVisible = false;
            pointer = new Entity(200, 200);
            player = new Player(300, 300);

            base.Initialize();
        }


        protected override void LoadContent() {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            pointer.LoadContent(this.Content, "aim");
            player.LoadContent(this.Content, "guy");
        }

        protected override void UnloadContent() {

        }

        protected override void Update(GameTime gameTime) {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            player.Update(gameTime);

            MouseState ms = Mouse.GetState();

            // Actualizar posicion del puntero
            pointer.position.X = ms.X;
            pointer.position.Y = ms.Y;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();

            pointer.Draw(this.spriteBatch);
            player.Draw(this.spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
