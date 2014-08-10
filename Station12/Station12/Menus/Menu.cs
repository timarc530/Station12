using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Station12
{
    class Menu
    {
        #region Variables
        List<Panel> panels;
        #endregion

        #region  Constructor
        public Menu()
        {
            panels = new List<Panel>();
        }

        public Menu(int screenX, int screenY, String type, ContentManager content)
        {
            panels = new List<Panel>();
            if (type.Contains("main"))
            {
                Texture2D img = content.Load<Texture2D>("exit_button");
                Panel p = new ExitButton("EXIT", screenX / 2, screenY * 8 / 10, 2, img, true);
                panels.Add(p);

                img = content.Load<Texture2D>("about_button");
                p = new AboutButton("ABOUT", screenX / 2, screenY * 6 / 10, 2, img, true);
                panels.Add(p);

                img = content.Load<Texture2D>("options_button");
                p = new AboutButton("ABOUT", screenX / 2, screenY * 4 / 10, 2, img, true);
                panels.Add(p);
            }
           

                

        }

        public void addPanel(String name, int x, int y, float scale, Texture2D img, bool active)
        {
            panels.Add(new Panel(name,x,y,scale,img,active));
        }

        public Panel whatPanel(Vector2 pos)
        {
            Panel ans = null;
            foreach (Panel p in panels)
                if (p.clickedPanel(pos) != null)
                    ans = p.clickedPanel(pos);
     
            return ans;
        }

        public void drawMenus(SpriteBatch spr,Camera2D camera)
        {
            foreach (Panel p in panels)
                p.drawPanel(spr, camera,0.9f); // top layer is 0, bottom layer is 1 (the map)
                                               // each sub-panel is drawn at a lower layer.
                                               // max is 9 layers
        }
        #endregion
    }
}
