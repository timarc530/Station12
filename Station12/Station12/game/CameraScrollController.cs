using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Station12.shared;
using Station12.Menus;
using Station12.game;
namespace Station12.game
{
    class CameraScrollController : Updatable
    {

        private Camera2D camera;
        private MouseHelper mouse;
        private KeyboardHelper keyboard;

        private int screenX, screenY;

        private Vector2 cameraVelocity;
        public float CameraDrag { get; set; }
        public float CameraMaxSpeed { get; set; }
        public float CameraAcc { get; set; }
        public float CameraZoomSpeed { get; set; }
        public float CameraZoomMin { get; set; }
        public float CameraZoomMax { get; set; }
        public int ScreenScrollingDistance { get; set; }


        public CameraScrollController(Camera2D camera,int screenX, int screenY, MouseHelper mouse, KeyboardHelper keyboard)
        {
            this.camera = camera;
            this.mouse = mouse;
            this.keyboard = keyboard;
            this.screenX = screenX;
            this.screenY = screenY;
            this.cameraVelocity = Vector2.Zero;
            this.CameraDrag = .7f;
            this.CameraMaxSpeed = 6f;
            this.CameraAcc = 2f;
            this.CameraZoomMax = 2;
            this.CameraZoomMin = 0;
            this.CameraZoomSpeed = .05f;
            this.ScreenScrollingDistance = 40;
        }


        public void update(GameTime time)
        {
            Vector2 cameraAcceleration = Vector2.Zero;
            

            //simple keyboard scrolling
            if (this.keyboard.KeyDown(Keys.A))
            {
                cameraAcceleration -= Vector2.UnitX;
            }
            if (this.keyboard.KeyDown(Keys.D))
            {
                cameraAcceleration += Vector2.UnitX;
            }
            if (this.keyboard.KeyDown(Keys.W))
            {
                cameraAcceleration -= Vector2.UnitY;
            }
            if (this.keyboard.KeyDown(Keys.S))
            {
                cameraAcceleration += Vector2.UnitY;
            }
            
            //mouse scrolling
            if (this.mouse.Location.X > (screenX - ScreenScrollingDistance))
            {
                float mouseRatio = (this.mouse.Location.X - (screenX - ScreenScrollingDistance))/(float)ScreenScrollingDistance;
                cameraAcceleration += Vector2.UnitX * mouseRatio;
            }
            if (this.mouse.Location.X < ScreenScrollingDistance)
            {
                float mouseRatio = (ScreenScrollingDistance-this.mouse.Location.X) / (float)ScreenScrollingDistance;
                cameraAcceleration -= Vector2.UnitX * mouseRatio;
            }
            if (this.mouse.Location.Y > (screenY - ScreenScrollingDistance))
            {
                float mouseRatio = (this.mouse.Location.Y - (screenY - ScreenScrollingDistance)) / (float)ScreenScrollingDistance;
                cameraAcceleration += Vector2.UnitY * mouseRatio;
            }
            if (this.mouse.Location.Y < ScreenScrollingDistance)
            {
                float mouseRatio = (ScreenScrollingDistance - this.mouse.Location.Y) / (float)ScreenScrollingDistance;
                cameraAcceleration -= Vector2.UnitY * mouseRatio;
            }

            //mouse zoom
            if (this.mouse.ScrolledUp() && this.camera.Scale < this.CameraZoomMax)
            {
                this.camera.ZoomIncrease(this.mouse.Location, this.CameraZoomSpeed);
            }
            if (this.mouse.ScrolledDown() && this.camera.Scale > this.CameraZoomMin)
            {
                this.camera.ZoomDecrease(this.mouse.Location, this.CameraZoomSpeed);
            }
            
            cameraAcceleration *= -CameraAcc;

            cameraVelocity += cameraAcceleration;
            cameraVelocity *= CameraDrag;

            //make sure camera is not going too fast
            if (cameraVelocity.Length() > CameraMaxSpeed)
            {
                cameraVelocity.Normalize();
                cameraVelocity *= CameraMaxSpeed;
            }

            this.camera.Position += cameraVelocity;

        }
    }
}
