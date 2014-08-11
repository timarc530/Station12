using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
namespace Station12.shared
{
    public interface Updatable
    {
        void update(GameTime time);
    }
}
