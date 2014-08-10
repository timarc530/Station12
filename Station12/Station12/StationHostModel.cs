using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmallNet;
using Microsoft.Xna;

namespace Station12
{
    class StationHostModel : DefaultHostModel<StationClientModel>
    {
        public override void destroy()
        {
            //throw new NotImplementedException();
        }

        public override void init()
        {
            //throw new NotImplementedException();
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
    }
}
