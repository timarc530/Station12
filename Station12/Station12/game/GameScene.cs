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
        private ContentManager content;
        private Camera2D camera;
        private KeyboardHelper keyboard;
        private MouseHelper mouse;

        private CameraScrollController cameraController;

        public ContentManager Content { get { return this.content; } }
        public Camera2D Camera { get { return this.camera; } }
        public KeyboardHelper Keyboard { get { return this.keyboard; } }
        public MouseHelper Mouse { get { return this.mouse; } }


        private LevelGeometry levelGeo;


        public LevelGeometry LevelGeometry { get { return this.levelGeo; } set { this.setLevel(value); } }


        public GameScene(ContentManager content,int screenX, int screenY, Camera2D camera, KeyboardHelper keyboard, MouseHelper mouse)
            : base()
        {
            this.camera = camera;
            this.content = content;
            this.keyboard = keyboard;
            this.mouse = mouse;
            this.cameraController = new CameraScrollController(camera,screenX, screenY, mouse, keyboard);
            
           
        }

        /// <summary>
        /// Run by a host to create a level.
        /// </summary>
        /// <returns></returns>
        public LevelGeometry generateLevel()
        {
            //generate a start room
            LevelGeometry level = new LevelGeometry(content);
            this.addObject(level);
            this.levelGeo = level;
            return level;
        }
        
        /// <summary>
        /// Run by clients to set the level
        /// </summary>
        /// <param name="levelGeo"></param>
        /// <returns></returns>
        public LevelGeometry setLevel(LevelGeometry levelGeo)
        {
            this.levelGeo = levelGeo;
            return levelGeo;
        }

        public override void update(GameTime time)
        {

            //camera controls
            this.cameraController.update(time);
            base.update(time);
        }

    }
}
