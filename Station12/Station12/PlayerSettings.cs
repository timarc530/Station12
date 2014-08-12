
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Station12
{
    class PlayerSettings
    {
        private Texture2D playerImage;

        //TODO add key controls, mouse movement speeds, ect

        public PlayerSettings(Texture2D playerImage)
        {
            this.playerImage = playerImage;
        }


        public Texture2D PlayerImage { get { return this.playerImage; } }

    }
}
