using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Station12.shared
{
    public class Sprite
    {
        public Texture2D Image { get; set; }
        public Vector2 Position { get; set; }
        public Color Color { get; set; }
        public float Rotation { get; set; }
        public Vector2 Origin { get; set; }
        public Vector2 Scale { get; set; }

        private float depth;
        public float Depth { get { return this.depth * 2; } set { this.depth = value/2f; } }

        public Sprite(Texture2D image) : this(image, Vector2.Zero) { }
        public Sprite(Texture2D image, Vector2 position) : this(image, position, Color.White) { }
        public Sprite(Texture2D image, Vector2 position, Color color) : this(image, position, color, 0) { }
        public Sprite(Texture2D image, Vector2 position, Color color, float rotation) : this(image, position, color, rotation, Vector2.Zero) { }
        public Sprite(Texture2D image, Vector2 position, Color color, float rotation, Vector2 origin) : this(image, position, color, rotation, origin, Vector2.One) { }
        public Sprite(Texture2D image, Vector2 position, Color color, float rotation, Vector2 origin, Vector2 scale) : this(image, position, color, rotation, origin, scale, 1) { }
        public Sprite(Texture2D image, Vector2 position, Color color, float rotation, Vector2 origin, Vector2 scale, float depth)
        {
            this.Image = image;
            this.Position = position;
            this.Color = color;
            this.Rotation = rotation;
            this.Origin = origin;
            this.Scale = scale;
            this.Depth = depth;
        }

        public void autoCenter()
        {
            this.Origin = new Vector2(this.Image.Width / 2, this.Image.Height / 2);
        }

        /// <summary>
        /// Draws the Sprite with its current configuration.
        /// The spritebatch must be begun.
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Image, Position, null, Color, Rotation, Origin, Scale, SpriteEffects.None, depth);
        }

    }
}
