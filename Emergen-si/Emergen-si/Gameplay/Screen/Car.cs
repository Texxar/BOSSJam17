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
    class Car: Interactable
    {
        Map map;
        public int posX, posY;
        public int goalX, goalY;
        int speed;
        bool locked;
        float rotation;

        public Car(ContentManager content, Map map) : base()
        {
            tex = content.Load<Texture2D>("POLICE");
            Init();
            this.map = map;
            rec.Width = map.tileSize;
            rec.Height = map.tileSize;

            posX = 10;
            posY = 9;
            rec.X = map.tileSize*posX + (map.tileSize/2);
            rec.Y = map.tileSize*posY + (map.tileSize/2);

            UpdatePos();


            speed = 1;
            locked = false;



            goalX = 10;
            goalY = 9;
        }

        public void Update(GameTime gameTime)
        {

            //Move
            if (posX < goalX && map.tileMap[posX+1][posY].road)
            {
                rec.X += speed;
                rotation = 1.57f;
            }
            else if (posX > goalX && map.tileMap[posX-1][posY].road)
            {
                rec.X -= speed;
                rotation = 4.64f;
            }
            else if (posY < goalY && map.tileMap[posX][posY+1].road)
            {
                rec.Y += speed;
                rotation = 3.14f;
            }
            else if (posY > goalY && map.tileMap[posX][posY-1].road)
            {
                rec.Y -= speed;
                rotation = 0;
            }


            UpdatePos();

        }

        void UpdatePos()
        {
            int x = map.GetXTile(rec.X);
            int y = map.GetYTile(rec.Y);
            if (x != posX || y != posY)
            {
                posX = x;
                rec.X = map.tileSize * posX + (map.tileSize / 2); ;

                posY = y;
                rec.Y = map.tileSize * posY + (map.tileSize / 2); ;
            }
        }

        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(tex, rec, null, Color.Wheat, rotation, new Vector2(tex.Width/2, tex.Height/2), SpriteEffects.None, 0 );
        }

    }
}
