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
                float scale = 2f;

                Texture2D img = content.Load<Texture2D>("play_button");
                Panel p = new PlayButton("PLAY", img.Width, screenY - img.Height, scale, img, true, true);
                panels.Add(p);

                img = content.Load<Texture2D>("options_button");
                p = new AboutButton("ABOUT", img.Width * 3, screenY - img.Height, scale, img, true, true);
                panels.Add(p);

                img = content.Load<Texture2D>("about_button");
                p = new AboutButton("ABOUT", img.Width * 5, screenY - img.Height, scale, img, true, true);
                panels.Add(p);

                img = content.Load<Texture2D>("exit_button");
                p = new ExitButton("EXIT", img.Width * 7, screenY - img.Height, scale, img, true, true);
                panels.Add(p);
            }
            else if (type.Contains("about"))
            {

            }
           

                

        }

        public void addPanel(String name, int x, int y, float scale, Texture2D img, bool active, bool visible)
        {
            panels.Add(new Panel(name,x,y,scale,img,active,visible));
        }

        public Panel whatPanel(Vector2 pos)
        {
            Panel ans = null;
            foreach (Panel p in panels)
                if (p.clickedPanel(pos) != null)
                    ans = p.clickedPanel(pos);
     
            return ans;
        }

        public void drawMenus(SpriteBatch spr)
        {
            foreach (Panel p in panels)
                p.drawPanel(spr,0.9f); // top layer is 0, bottom layer is 1 (the map)
                                               // each sub-panel is drawn at a lower layer.
                                               // max is 9 layers
        }
        #endregion
    }
}
