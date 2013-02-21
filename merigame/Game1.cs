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

        Entity pointer;
        Player player;

        Texture2D bulletTexture;

        public Game1() : base() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }


        protected override void Initialize() {
            IsMouseVisible = false;
            pointer = new Entity(new Vector2(200, 200));
            player = new Player(new Vector2(300, 300));

            base.Initialize();
        }


        protected override void LoadContent() {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            pointer.LoadContent(this.Content, "aim");
            player.LoadContent(this.Content);
            player.bulletTexture = this.Content.Load<Texture2D>("bullet");
        }

        protected override void UnloadContent() {

        }

        protected override void Update(GameTime gameTime) {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            MouseState ms = Mouse.GetState();

            player.Update(gameTime, ms);

            pointer.position.X = ms.X;
            pointer.position.Y = ms.Y;

            foreach(Bullet b in player.bullets) {
                b.Update(gameTime, ms);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();

            pointer.Draw(this.spriteBatch);
            player.Draw(this.spriteBatch);

            foreach (Bullet b in player.bullets) {
                b.Draw(this.spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
