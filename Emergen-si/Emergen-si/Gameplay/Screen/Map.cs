using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Emergen_si
{
    class Tile
    {
        public bool road;
        public String streetName;
        public int streetNumber;

        public Tile(bool road = false, String streetName = "", int streetNumber = 0)
        {
            this.road = road;
            this.streetName = streetName;
            this.streetNumber = streetNumber;
        }

    }

    class Map
    {
        public Tile[][] tileMap;
        public int mapWidth, mapHeight;
        public int tileSize;
        Texture2D tex;
        public Rectangle rec;


        public Map(ContentManager content)
        {
            mapWidth = 10;//33;
            mapHeight = 10;//16;
            tileSize = 50;
            tex = content.Load<Texture2D>("HillHorizon");
            //Set size of tilemap
            SetUpTileMap();

            rec = new Rectangle(0, 0, 64, 64);

        }

        void SetUpTileMap()
        {
            //Init
            tileMap = new Tile[mapWidth][];
            for (int x = 0; x < mapWidth; x++)
            {
                tileMap[x] = new Tile[mapHeight];

                for (int y = 0; y < mapHeight; y++)
                {
                    tileMap[x][y] = new Tile();
                    if (x % 2 != 0 || y % 2 != 0)
                    {
                        tileMap[x][y].road = true;
                    }
                }
            }


        }

        public int GetXTile(int x)
        {
            return (x - rec.X) / tileSize;
        }
        public int GetYTile(int y)
        {
            return (y - rec.Y) / tileSize;
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch sb)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                for (int y = 0; y < mapHeight; y++)
                {
                    if (tileMap[x][y].road)
                        sb.Draw(tex, new Rectangle(tileSize * x, tileSize * y, tileSize, tileSize), Color.Black);
                    else
                        sb.Draw(tex, new Rectangle(tileSize * x, tileSize * y, tileSize, tileSize), Color.ForestGreen);

                }
            }
        }
    }
}
