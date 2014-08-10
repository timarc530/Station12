#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using SmallNet;
using Station12.shared;
#endregion

namespace Station12
{
    enum GameState
    {
        MAIN,
        EXIT
    }
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        #region variables
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        MouseHelper mouse;
        Camera2D camera;
        Random random;


        GameState gs;
        Menu menu;
        //float camZoom;
        int screenX;
        int screenY;
        bool fullScreen;

        #endregion

        #region snet
        BaseHost<StationClientModel, StationHostModel> host;
        BaseClient<StationClientModel> client;
        #endregion

        Scene menuBackground;

        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            //net
            host = new BaseHost<StationClientModel, StationHostModel>();
            host.IpAddress = "0.0.0.0";
            host.start();
            client = new BaseClient<StationClientModel>();
            client.connectTo(SNetUtil.getLocalIp(), "loc");

            //random
            random = new Random();

            //camZoom = 0.5f;
            screenX = 1024;
            screenY = 768;
            fullScreen = true;

            gs = GameState.MAIN;
            mouse = new MouseHelper();
            IsMouseVisible = true;
            camera = new Camera2D(new Vector2(screenX, screenY));

            // screen resolution
            graphics.PreferredBackBufferWidth = screenX;
            graphics.PreferredBackBufferHeight = screenY;
            graphics.ApplyChanges();
            if (fullScreen)
                graphics.ToggleFullScreen();

            menu = new Menu(screenX, screenY, "main", Content);
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            menuBackground = new Scene();

            //make planet
            SimpleMotionObject planet = new SimpleMotionObject(Content.Load<Texture2D>("planet1.png"));
            Vector2 planetOrigin = new Vector2(screenX * .35f, screenY / 2);
            planet.Sprite.Depth = 0.6f;
            planet.Sprite.Position = planetOrigin;
            planet.Sprite.autoCenter();
            planet.Sprite.Scale *= .8f;
            int radius = Math.Min(planet.Sprite.Image.Height,planet.Sprite.Image.Width)/2;
           // planet.setMotionFunction((spr, time) => { });
            menuBackground.addObject(planet);


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
                menuBackground.addObject(stars[i]);
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
                float dir = Math.Sign((float)random.NextDouble()-.5);
                float speed = dir*(float)random.NextDouble() * .003f;
                nebulas[i].setMotionFunction((spr, time) => {
                    spr.Rotation += speed;
                });
                menuBackground.addObject(nebulas[i]);
            }


            SimpleMotionObject tobj = new SimpleMotionObject(Content.Load<Texture2D>("100x100 Box White.png"));
            menuBackground.addObject(tobj);
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
                angle +=.001f* modifer;
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

                if (flip ==3)
                {
                    
                    spr.Depth = 0.4f;
                }
                else
                    spr.Depth = 0.7f;


                


            
            });

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            this.client.shutdown();
            this.host.shutdown();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (gs == GameState.EXIT)
                Exit();

            if (mouse.LeftButtonNew())
                if (menu.whatPanel(mouse.Location) != null)
                {
                    gs = menu.whatPanel(mouse.Location).onLeftClick(gs);
                }

            menuBackground.update(gameTime);

            camera.Update(gameTime);
            mouse.Update();
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(ColorPalette.SPACE);

            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.NonPremultiplied, SamplerState.AnisotropicWrap, DepthStencilState.None, RasterizerState.CullNone, null, camera.Translation);
            menu.drawMenus(spriteBatch, camera);



            menuBackground.draw(spriteBatch);
            
            spriteBatch.End();
            // TODO: Add your drawing code here

            client.ClientModel.draw(spriteBatch);


            base.Draw(gameTime);
        }
    }
}
