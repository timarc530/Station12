using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmallNet;
using Station12.shared;

namespace Station12
{
    class Player : DefaultPlayer, Updatable, Drawable
    {
        private PlayerSettings settings;
        


        public Player(int id, PlayerSettings settings) : base(id)
        {
            this.settings = settings;
        }

        public PlayerSettings Settings { get { return this.settings; } }

        public override void draw(object drawdata)
        {
            //throw new NotImplementedException();
        }

        public override void update(Microsoft.Xna.Framework.GameTime time)
        {
            //throw new NotImplementedException();
        }
    }
}
