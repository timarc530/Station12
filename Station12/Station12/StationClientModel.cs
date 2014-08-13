using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmallNet;
using Microsoft.Xna;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Station12
{
    class StationClientModel : DefaultClientModel<Player>
    {

        private Texture2D playerImage;
        private Player me;

        public override void destroy()
        {
            //throw new NotImplementedException();
        }

        protected override void gotMessage(SMessage message)
        {
           // throw new NotImplementedException();
        }

        public override void init()
        {
            //throw new NotImplementedException();
        }

        public void loadContent(ContentManager content)
        {
            this.playerImage = content.Load<Texture2D>("tempMan.png");
        }

        public override void playerJoined(int id)
        {
            PlayerSettings settings = new PlayerSettings(this.playerImage);
            Player plr = new Player(id, settings);

            this.addPlayer(id, plr);
            if (id == this.Id)
            {
                me = plr;
            }
        }

        public override void update(Microsoft.Xna.Framework.GameTime time)
        {
            //throw new NotImplementedException();
        }

        public override bool validateMessage(SMessage message)
        {
           // throw new NotImplementedException();
            return true;
        }


        public void draw(SpriteBatch spriteBatch)
        {
        }
    }
}
