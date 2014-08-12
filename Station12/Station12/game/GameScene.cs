using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Station12.Menus;
using Station12.shared;
namespace Station12.game
{
    class GameScene : Scene
    {
        private ContentManager Content;
        private Camera2D camera;
        private KeyboardHelper keyboard;
        private MouseHelper mouse;

        private CameraScrollController cameraController;


        //test add player
        private Player player;


        public GameScene(ContentManager Content,int screenX, int screenY, Camera2D camera, KeyboardHelper keyboard, MouseHelper mouse)
            : base()
        {
            this.camera = camera;
            this.Content = Content;
            this.keyboard = keyboard;
            this.mouse = mouse;
            this.cameraController = new CameraScrollController(camera,screenX, screenY, mouse, keyboard);

            PlayerSettings settings = new PlayerSettings(Content.Load<Texture2D>("tempMan.png"));
            this.player = new Player(1, settings);
           
            this.addObject(this.player);
        }

        public void generateLevel()
        {

            //generate a start room
            LevelGeometry level = new LevelGeometry(Content);

            this.addObject(level);
        }

        public override void update(GameTime time)
        {

            //camera controls
            this.cameraController.update(time);
            base.update(time);
        }

    }
}
