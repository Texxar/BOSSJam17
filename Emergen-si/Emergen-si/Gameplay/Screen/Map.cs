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
        Tile[][] tileMap;
        int mapWidth, mapHeight;
        Texture2D tex;
        Rectangle rec;

        public Map(ContentManager content)
        {
            mapWidth = 10;//16;
            mapHeight = 10;//33;

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
                }
            }

            tileMap[0][0].road = true;

        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch sb)
        {
            //sb.Draw(tex, rec, Color.ForestGreen);
            /*
            int incrX = 1280 / 32;
            int incrY = 720 / 32;

            for (int x = 0; x < mapWidth; x++)
            {
                for (int y = 0; y < mapHeight; y++)
                {
                    if (tileMap[x][y].road)
                        sb.Draw(tex, new Rectangle(rec.X + (x * incrX), rec.Y + (y * incrY), 64, 64), Color.Black);
                    else 
                        sb.Draw(tex, new Rectangle(rec.X + (x*incrX), rec.Y +(y*incrY), 64, 64), Color.ForestGreen);
                }
            }*/
            int b = 50;
            for (int x = 0; x < mapWidth; x++)
            {
                for (int y = 0; y < mapHeight; y++)
                {
                    if (tileMap[x][y].road)
                        sb.Draw(tex, new Rectangle(b*x, b*y, b, b), Color.Black);
                    else
                        sb.Draw(tex, new Rectangle(b * x, b * y, b, b), Color.ForestGreen);

                }
            }
        }
    }
}
