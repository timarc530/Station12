using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmallNet;
namespace Station12
{
    class StationClientModel : DefaultClientModel
    {
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

        public override void playerJoined(int id)
        {
           // throw new NotImplementedException();
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
    }
}
