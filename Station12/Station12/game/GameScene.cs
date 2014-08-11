using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Station12.Menus;
using Station12.shared;
namespace Station12.game
{
    class GameScene : Scene
    {
        private ContentManager Content;

        public GameScene(ContentManager Content)
            : base()
        {
            this.Content = Content;
        }

        public void generateLevel()
        {
        }
    }
}
