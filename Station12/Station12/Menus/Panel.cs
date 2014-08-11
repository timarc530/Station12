using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Station12
{
    class Panel
    {
        #region Variables
        protected String name;
        protected bool active;
        protected bool visible;
        protected Texture2D img = null;
        protected static Texture2D defaultImg;
        protected Rectangle posData;
        protected List<Panel> panelObjs;
        #endregion

        #region Constructor

        // use when x and y describe the center of the panel.
        public Panel(String name, int x, int y, float scale, Texture2D img, bool active, bool visible)
        {
            this.name = name;
            this.active = active;
            this.visible = visible;
            this.img = img;
            panelObjs = new List<Panel>();
            int xOffset = (int)(scale * img.Width / 2);
            int yOffset = (int)(scale * img.Height / 2);
            posData = new Rectangle((x - xOffset),( y - yOffset), (int)(scale * img.Width), (int)(scale * img.Height));
        }
        #endregion

        public static void setDefaultTexture(Texture2D img)
        {
            defaultImg = img;
        }

        public void setTexture(Texture2D img)
        {
            this.img = img;
        }

        public Panel clickedPanel(Vector2 pos)
        {
            Panel ans = null;
            Panel subAns = null;
            if (active && visible)
            {
                if (posData.Contains(new Rectangle((int)pos.X, (int)pos.Y, 1, 1)))
                {
                    foreach (Panel p in panelObjs)
                    {
                        subAns = p.clickedPanel(pos);
                        if (subAns != null)
                            ans = subAns;
                    }
                    if (ans == null)
                        ans = this;
                }
            }
            return ans;
        }

        
        public virtual void drawPanel(SpriteBatch spr, float layer)
        {
            if (visible)
            {
                /* NOTE: Camera removed.
                 */
                int x = (int)(posData.X);
                int y = (int)(posData.Y);
                int w = (int)(posData.Width);
                int h = (int)(posData.Height);
                Rectangle r = new Rectangle(x, y, w, h);

                if (img == null)
                    spr.Draw(defaultImg, r, Color.White);
                else
                    spr.Draw(img,r,null,Color.White,0,new Vector2(0,0),SpriteEffects.None,layer);
                    //spr.Draw(img, r, Color.White);

                foreach (Panel p in panelObjs)
                    p.drawPanel(spr, layer - 0.1f);

                
                
            }
        }

        public virtual GameState onLeftClick(GameState gs)
        {
            return gs;
        }

        //public virtual void onRightClick(Tile currentHex, Tile lastHex, GameState gs)
        //{

        //}

        public String toString()
        {
            return this.name;
        }

        public void setVisible(bool val)
        {
            this.visible = val;
        }

        public void setActive(bool val)
        {
            this.active = val;
        }
 
    }
}
