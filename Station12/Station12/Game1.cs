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

        SimpleMotionObject tobj;


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


            //camZoom = 0.5f;
            screenX = 1024;
            screenY = 768;
            fullScreen = false;

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


            tobj = new SimpleMotionObject(Content.Load<Texture2D>("100x100 Box White.png"));
            Vector2 origin = new Vector2(300, 300);
            float angle = 0;
            tobj.setMotionFunction((spr, time) =>
            {
                float radius = 100;
                angle += .01f;
                Vector2 add = radius * new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
                spr.Position = origin + add;
                spr.Scale =Vector2.One* (add.X/radius);
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


            tobj.update(gameTime);
            mouse.Update();
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, SamplerState.AnisotropicWrap, DepthStencilState.None, RasterizerState.CullNone, null, camera.Translation);
            menu.drawMenus(spriteBatch, camera);



            tobj.draw(spriteBatch);
            spriteBatch.End();
            // TODO: Add your drawing code here

            client.ClientModel.draw(spriteBatch);


            base.Draw(gameTime);
        }
    }
}
