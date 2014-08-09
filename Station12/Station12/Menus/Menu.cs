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
                Panel p = new ExitButton("exit",screenX/3,screenY*8/10,100,45,true);
                p.setTexture(content.Load<Texture2D>("exit_button"));
                panels.Add(p);
            }
           

                

        }

        public void addPanel(String name, int x, int y, int width, int height, bool active)
        {
            panels.Add(new Panel(name,x,y,width,height,active));
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
