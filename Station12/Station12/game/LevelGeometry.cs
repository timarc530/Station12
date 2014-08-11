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
    class LevelGeometry : SceneElement
    {

        Room testRoom;

        public LevelGeometry(ContentManager Content)
        {

            testRoom = new Room(Content);

        }

        public void update(GameTime time)
        {
            testRoom.update(time);
        }

        public void draw(SpriteBatch spriteBatch)
        {
            testRoom.draw(spriteBatch);
        }
    }
}
