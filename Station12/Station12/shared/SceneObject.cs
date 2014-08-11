using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Station12.shared
{
    public abstract class SceneObject
    {
        public abstract void update(GameTime time);
        public abstract void draw(SpriteBatch spriteBatch);
    }
}
