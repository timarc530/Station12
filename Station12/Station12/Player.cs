using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmallNet;
using Station12.shared;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Station12
{
    class Player : DefaultPlayer, SceneElement
    {
        private PlayerSettings settings;
        private Sprite sprite;

        public Vector2 position;
        public Vector2 Position { get { return this.position; } set { this.sprite.Position = value; this.position = value; } }

        public Player(int id, PlayerSettings settings) : base(id)
        {
            this.settings = settings;
            this.sprite = new Sprite(this.settings.PlayerImage);
            this.Position = new Vector2(100, 100);
            this.sprite.Depth = .8f;
        }

        public PlayerSettings Settings { get { return this.settings; } }

        public override void draw(object drawdata)
        {
            //throw new NotImplementedException();
        }
        public void draw(SpriteBatch spriteBatch)
        {
            this.sprite.draw(spriteBatch);
        }

        public override void update(Microsoft.Xna.Framework.GameTime time)
        {
            //throw new NotImplementedException();
        }
    }
}
