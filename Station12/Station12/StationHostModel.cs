using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmallNet;
using Microsoft.Xna;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Station12.shared;
using Station12.game;
using Station12.game.messages;
using SmallNet.Messages;

namespace Station12
{
    class StationHostModel : DefaultHostModel<StationClientModel>
    {
        private GameScene gameScene;


        public override void destroy()
        {
            //throw new NotImplementedException();
        }

        public override void init()
        {
            //throw new NotImplementedException();
        }

        public void setGameScene(GameScene gameScene)
        {
            this.gameScene = gameScene;
        }


        public override void onMessage(SMessage message)
        {
            //throw new NotImplementedException();
        }

        public override void updateHost(Microsoft.Xna.Framework.GameTime time)
        {
            //throw new NotImplementedException();
        }

        public override bool validateMessage(SMessage message)
        {
            //throw new NotImplementedException();
            return true;
        }

        public override void playerJoined(int id)
        {
            //a player joined!
            //we should send them the level geo
            
            LevelDataMsg ldm = new LevelDataMsg(this, this.gameScene.LevelGeometry);
            StringMessage test = new StringMessage(this, "test");
            this.clientIdTable[id].sendMessage(ldm);
        }
    }
}
