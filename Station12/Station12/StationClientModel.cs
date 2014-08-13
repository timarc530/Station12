using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmallNet;
using Microsoft.Xna;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

using Station12.shared;
using Station12.game;

namespace Station12
{
    class StationClientModel : DefaultClientModel<Player>
    {

        public static Texture2D playerImage;
        private Player me;

        private GameScene gameScene;


        public override void destroy()
        {
            //throw new NotImplementedException();
        }

        protected override void gotMessage(SMessage message)
        {

            Console.WriteLine("GOT:" + message.GetType());


        }

        public override void init()
        {
            //throw new NotImplementedException();
        }

        public void setGameScene(GameScene gameScene)
        {
            this.gameScene = gameScene;
           
        }

        public override void playerJoined(int id)
        {
            PlayerSettings settings = new PlayerSettings(playerImage);
            Player plr = new Player(id, settings);

            this.addPlayer(id, plr);
            if (id == this.Id)
            {
                me = plr;
            }
        }

        public override void update(Microsoft.Xna.Framework.GameTime time)
        {
            
        }

        public override bool validateMessage(SMessage message)
        {
           // throw new NotImplementedException();
            return true;
        }


        public void draw(SpriteBatch spriteBatch)
        {

            //if I exist...
            if (me != null)
            {
                me.draw(spriteBatch);
            }
            gameScene.draw(spriteBatch);

        }
    }
}
