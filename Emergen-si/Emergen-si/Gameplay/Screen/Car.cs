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
        int posX, posY;
        int goalX, goalY;
        int speed;

        public Car(ContentManager content, Map map) : base()
        {
            tex = content.Load<Texture2D>("HillHorizon");
            Init();
            this.map = map;
            rec.X = 50;
            rec.Y = 50;
            rec.Width = 20;
            rec.Height = 20;
            speed = 5;

            posX = 1;
            posY = 1;

            goalX = 5;
            goalY = 5;
        }

        public void Update(GameTime gameTime)
        {
            //Move
            if (posX < goalX && map.tileMap[posX+1][posY].road)
            {
                rec.X += speed;
            }
            else if (posX > goalX && map.tileMap[posX-1][posY].road)
            {
                rec.X -= speed;
            }
            else if (posY < goalY && map.tileMap[posX][posY+1].road)
            {
                rec.Y += speed;
            }
            else if (posY > goalY && map.tileMap[posX][posY-1].road)
            {
                rec.Y -= speed;
            }

            UpdatePos();

        }

        void UpdatePos()
        {
            posX = map.GetXTile(rec.X);
            posY = map.GetYTile(rec.Y);
        }

        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(tex, rec, Color.Blue);
        }

    }
}
