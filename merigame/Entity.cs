using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;

namespace merigame {

    // Entity: Objeto o cosa en el juego
    class Entity {

        public const int MOVE_UP = -1;
        public const int MOVE_DOWN = 1;
        public const int MOVE_LEFT = -1;
        public const int MOVE_RIGHT = 1;

        public string assetName;
        public Vector2 position;
        public Rectangle size;
        public Texture2D texture;
        private float scale;

        public Entity(int x, int y) {
            position = new Vector2(x, y);
            scale = 1f;
        }

        public float Scale {
            get { return scale; }
            set {
                scale = value;
                size = new Rectangle(0, 0, (int)(texture.Width * scale),
                    (int)(texture.Height * scale));
            }
        }


        public void LoadContent(ContentManager cm, string assetName) {
            texture = cm.Load<Texture2D>(assetName);
            this.assetName = assetName;
            // Apply scale
            size = new Rectangle(0, 0, (int)(texture.Width * scale), (int)(texture.Height * scale));
        }

        public void Update(GameTime gt, Vector2 speed, Vector2 direction) {
            position += direction * speed * (float)gt.ElapsedGameTime.TotalSeconds;
        }

        public void Draw(SpriteBatch sb) {
            sb.Draw(texture, position, new Rectangle(0, 0, texture.Width,
                texture.Height), Color.White, 0.0f, Vector2.Zero, Scale, SpriteEffects.None, 0);
        }
    }
}
