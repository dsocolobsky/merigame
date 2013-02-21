using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;

namespace merigame {
    class SpriteEntity : Entity {
        public Rectangle source;

        public SpriteEntity(Vector2 origin) : base(origin) {
            this.position = origin;
            scale = 1f;
        }

        public Rectangle Source {
            get { return source; }
            set {
                source = value;
                size = new Rectangle(0, 0, (int)(source.Width * scale), (int)(source.Height * scale));
            }
        }

        public float Scale {
            get { return scale; }
            set {
                scale = value;
                size = new Rectangle(0, 0, (int)(source.Width * scale),
                    (int)(source.Height * scale));
            }
        }

        public void LoadContent(ContentManager cm, string assetName) {
            texture = cm.Load<Texture2D>(assetName);
            this.assetName = assetName;
            // Apply scale
            size = new Rectangle(0, 0, (int)(texture.Width * scale), (int)(texture.Height * scale));
        }

        public void Draw(SpriteBatch sb) {
            sb.Draw(texture, position, source, Color.White, 0.0f,
                Vector2.Zero, Scale, SpriteEffects.None, 0);
        }
    }
}
