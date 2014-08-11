using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Station12.shared
{
    public class SimpleMotionObject : SceneElement
    {
        public delegate void MotionFunction(Sprite spr, GameTime time);

        private MotionFunction mFunc;
        private Sprite sprite;

        public SimpleMotionObject(Texture2D image)
        {
            this.sprite = new Sprite(image);
            this.mFunc = (spr, time) => { };
        }

        public void setMotionFunction(MotionFunction mFunc)
        {
            this.mFunc = mFunc;
        }

        public Sprite Sprite { get { return this.sprite; } }




        public void update(GameTime time)
        {
            this.mFunc.Invoke(this.sprite, time);
        }

        public void draw(SpriteBatch spriteBatch)
        {
            this.sprite.draw(spriteBatch);
        }
    }
}
