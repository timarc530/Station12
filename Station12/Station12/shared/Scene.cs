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
        private List<SceneObject> objs;

        public Color BackgroundColor { get; set; }

        public Scene()
        {
            this.BackgroundColor = Color.Orange;
            this.objs = new List<SceneObject>();
        }

        public void addObject(SceneObject obj)
        {
            this.objs.Add(obj);
        }

        public void update(GameTime time)
        {
            foreach (SceneObject obj in objs)
            {
                obj.update(time);
            }
        }

        public void draw(SpriteBatch spriteBatch)
        {
            foreach (SceneObject obj in objs)
            {
                obj.draw(spriteBatch);
            }
        }

    }
}
