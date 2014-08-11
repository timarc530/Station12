using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Station12.shared
{
    public class Scene
    {
        private List<SceneElement> objs;

        public Color BackgroundColor { get; set; }

        public Scene()
        {
            this.BackgroundColor = Color.Orange;
            this.objs = new List<SceneElement>();
        }

        public void addObject(SceneElement obj)
        {
            this.objs.Add(obj);
        }

        public virtual void update(GameTime time)
        {
            foreach (SceneElement obj in objs)
            {
                obj.update(time);
            }
        }

        public virtual void draw(SpriteBatch spriteBatch)
        {
            foreach (SceneElement obj in objs)
            {
                obj.draw(spriteBatch);
            }
        }

    }
}
