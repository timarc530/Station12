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
        private LevelGeometry level;
        private int testVar;
        public LevelDataMsg() :base() { }
        
        public LevelDataMsg(Id id, LevelGeometry levelGeometry) : base(id)
        {
            this.testVar = 234;
            this.level = levelGeometry;
        }
        public LevelGeometry getLevelGeometry()
        {
            return this.level;
        }
        public int getTest()
        {
            return testVar;
        }
    }
}
