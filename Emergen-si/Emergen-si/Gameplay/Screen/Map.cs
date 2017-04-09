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
            mapWidth = 27;
            mapHeight = 16;
            tileSize = 46;
            tex = content.Load<Texture2D>("MAPfinished");
            rec = new Rectangle(0, 0, 1280, 720);
            //Set size of tilemap
            SetUpTileMap();



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
                }
            }

            for (int x = 1; x < 27; x++)
            {
                tileMap[x][1].road = true;
                tileMap[x][9].road = true;
                tileMap[x][14].road = true;
            }
            for (int y = 1; y < 15; y++)
            {
                tileMap[1][y].road = true;
                tileMap[15][y].road = true;
                tileMap[26][y].road = true;
                if(y < 9) tileMap[10][y].road = true;
                if (y > 9) tileMap[7][y].road = true;

            }


        }

        public int GetXTile(int x)
        {
            int tile = x / tileSize;

            if (tile > mapWidth-1)
            {
                tile = 0;
            }

            return tile;
        }
        public int GetYTile(int y)
        {
            int tile = y / tileSize;

            if (tile > mapHeight-1)
            {
                tile = 0;
            }

            return tile;
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(tex, rec, Color.Wheat);
            //for (int x = 0; x < mapWidth; x++)
            //{
            //    for (int y = 0; y < mapHeight; y++)
            //    {
            //        if (tileMap[x][y].road)
            //            sb.Draw(tex, new Rectangle(tileSize * x, tileSize * y, tileSize, tileSize), new Color(255, 255, 255, 0));
            //    }
            //}

        }
    }
}
