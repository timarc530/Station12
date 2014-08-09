using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Station12
{
    class ExitButton : Panel
    {
        #region Constructor
        public ExitButton(String name,int x, int y, int width, int height, bool active)
            : base(name, x, y, width, height, active)
        {
          
        }
        #endregion

        #region Left Mouse Button
        public override gameState onLeftClick(gameState gs)
        { 
            return gameState.EXIT;
        }
        #endregion
    }
}
