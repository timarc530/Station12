using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Station12
{
    class AboutButton : Panel
        {
        #region Constructor
        public AboutButton(String name, int x, int y, float scale, Texture2D img, bool active, bool visible)
            : base(name, x, y, scale, img, active, visible) { }

        #endregion

        #region Left Mouse Button
        public override GameState onLeftClick(GameState gs)
        { 
            return GameState.MAIN;
        }
        #endregion
    }
}
