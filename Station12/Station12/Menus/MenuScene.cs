using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Station12;
using Station12.shared;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Station12.Menus
{
    class MenuScene : Scene
    {

        private Random random;

        public MenuScene()
            : base()
        {
            this.random = new Random();
        }

        public void init(int screenX, int screenY, ContentManager Content)
        {
            //make planet
            SimpleMotionObject planet = new SimpleMotionObject(Content.Load<Texture2D>("planet1.png"));
            Vector2 planetOrigin = new Vector2(screenX * .35f, screenY / 2);
            planet.Sprite.Depth = 0.6f;
            planet.Sprite.Position = planetOrigin;
            planet.Sprite.autoCenter();
            planet.Sprite.Scale *= .8f;
            int radius = Math.Min(planet.Sprite.Image.Height, planet.Sprite.Image.Width) / 2;
            // planet.setMotionFunction((spr, time) => { });
            this.addObject(planet);


            //make stars
            SimpleMotionObject[] stars = new SimpleMotionObject[8];
            Texture2D starImg = Content.Load<Texture2D>("stars1.png");
            for (int i = 0; i < stars.Length; i++)
            {
                stars[i] = new SimpleMotionObject(starImg);
                stars[i].Sprite.Position = new Vector2(screenX * (float)random.NextDouble(), screenY * (float)random.NextDouble());
                //stars[i].Sprite.Color = ColorPalette.NEBULA;
                stars[i].Sprite.autoCenter();
                stars[i].Sprite.Depth = .4f;
                stars[i].Sprite.Scale *= .5f;
                float dir = Math.Sign((float)random.NextDouble() - .5);
                float speed = dir * (float)random.NextDouble() * .00001f;
                stars[i].setMotionFunction((spr, time) =>
                {
                    spr.Rotation += speed;
                });
                this.addObject(stars[i]);
            }

            //make clouds
            SimpleMotionObject[] nebulas = new SimpleMotionObject[4];
            Texture2D cloudImg = Content.Load<Texture2D>("nebula1.png");
            for (int i = 0; i < nebulas.Length; i++)
            {
                nebulas[i] = new SimpleMotionObject(cloudImg);
                nebulas[i].Sprite.Position = new Vector2(screenX * (float)random.NextDouble(), screenY * (float)random.NextDouble());
                nebulas[i].Sprite.Color = ColorPalette.NEBULA;
                nebulas[i].Sprite.autoCenter();
                nebulas[i].Sprite.Depth = .5f;
                nebulas[i].Sprite.Scale *= 1.7f;
                float dir = Math.Sign((float)random.NextDouble() - .5);
                float speed = dir * (float)random.NextDouble() * .003f;
                nebulas[i].setMotionFunction((spr, time) =>
                {
                    spr.Rotation += speed;
                });
                this.addObject(nebulas[i]);
            }


            SimpleMotionObject tobj = new SimpleMotionObject(Content.Load<Texture2D>("100x100 Box White.png"));
            this.addObject(tobj);
            tobj.Sprite.Depth = 0.7f;
            tobj.Sprite.Scale *= .5f;
            tobj.Sprite.autoCenter();
            float angle = 0;
            double ecA = screenX * .35f;
            double ecB = 80;
            double ecPhi = 0;
            int flip = 0;

            tobj.setMotionFunction((spr, time) =>
            {
                Vector2 oldpos = spr.Position;
                bool transition;
                double f = (ecA * ecB) / Math.Sqrt(Math.Pow(ecB * Math.Cos(angle), 2) + Math.Pow(ecA * Math.Sin(angle), 2));
                float modifer = (float)(ecA - ecB) / (planetOrigin - spr.Position).Length();
                angle += .001f * modifer;
                angle = angle % (float)(Math.PI * 2);
                Vector2 traj = new Vector2((float)Math.Cos(angle + ecPhi), (float)Math.Sin(angle + ecPhi));
                Vector2 add = ((float)f) * traj;
                spr.Position = planetOrigin + add;
                float v1 = (oldpos - planetOrigin).Length();
                float v2 = (spr.Position - planetOrigin).Length();
                transition = ((v1 > radius) ^ (v2 > radius));

                if (transition)
                {
                    flip++;
                    flip = flip % 4;
                }

                if (flip == 3)
                {

                    spr.Depth = 0.4f;
                }
                else
                    spr.Depth = 0.7f;



            });
        }

    }
}
