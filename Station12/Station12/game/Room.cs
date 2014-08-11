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
    class Room : SceneElement
    {
        private int width, height;
        private Vector2 position;


        private List<Sprite> tiles;
        private Texture2D tileImage;

        public Room(ContentManager Content)
        {
            this.width = 5;
            this.height = 5;
            this.position = new Vector2(100, 100);

            this.tileImage = Content.Load<Texture2D>("tempTile.png");
            this.tiles = new List<Sprite>();
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Sprite tile = new Sprite(this.tileImage);
                    tile.Position = this.position + new Vector2(x*tileImage.Width, y*tileImage.Height);

                    if (x == 0 || y == 0 || x == width - 1 || y == height - 1)
                    {
                        tile.Color = Color.Black;
                    }
                    //tile.Depth = .5f;
                    this.tiles.Add(tile);
                }
            }

        }

        /// <summary>
        /// the number of tiles accross the room is.
        /// </summary>
        public int Width { get { return this.width; } }
        
        /// <summary>
        /// the number of tiles tall the room is.
        /// </summary>
        public int Height { get { return this.height; } }
        
        /// <summary>
        /// The top-left corner position of the room
        /// </summary>
        public Vector2 Position { get { return this.position; } }

        public void update(GameTime time)
        {
            foreach (Sprite tile in this.tiles)
            {
                
            }
        }

        public void draw(SpriteBatch spriteBatch)
        {
            foreach (Sprite tile in this.tiles)
            {
                tile.draw(spriteBatch);
            }
        }
    }
}
