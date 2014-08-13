using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmallNet;
using Station12.game;
using Station12.shared;
namespace Station12.game.messages
{
    class LevelDataMsg : SMessage
    {
       // private LevelGeometry level;

        int x;

        public LevelDataMsg() { }

        public LevelDataMsg(Id id, LevelGeometry levelGeometry) : base(id)
        {
            this.x = 5;
           // this.level = levelGeometry;
        }

        public int getX()
        {
            return this.x;
        }
        //public LevelGeometry getLevelGeometry()
        //{
        //    return this.level;
        //}
    }
}
