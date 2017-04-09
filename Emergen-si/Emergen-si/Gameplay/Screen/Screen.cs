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
    class Cursor
    {
        public Texture2D tex;
        public Rectangle rec;

        public Cursor(ContentManager content)
        {
            tex = content.Load<Texture2D>("HillHorizon");
            rec = new Rectangle(0, 0, 8, 8);
        }

        public void Update(GameTime gameTime)
        {
            MouseState mouseState = Mouse.GetState();

            rec.X = mouseState.X;
            rec.Y = mouseState.Y;
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(tex, rec, Color.Wheat);
        }
    }
    class Screen
    {
        Cursor cursor;
        Map map;
        Car policeCar;

        bool keyDown = false;

        public Screen(ContentManager content)
        {
            cursor = new Cursor(content);
            map = new Map(content);
            policeCar = new Car(content, map);
        }

        public bool Update(GameTime gameTime)
        {
            cursor.Update(gameTime);

            MouseState mouseState = Mouse.GetState();

            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                int clickX = map.GetXTile(mouseState.X);
                int clickY = map.GetYTile(mouseState.Y);
                if (map.tileMap[clickX][clickY].road == true)
                {
                    policeCar.goalX = clickX;
                    policeCar.goalY = clickY;
                }

            }

            policeCar.Update(gameTime);

            if (mouseState.RightButton == ButtonState.Pressed)
                return true;
            
            else
                return false;
        }

        public void Draw(SpriteBatch sb)
        {
            map.Draw(sb);
            policeCar.Draw(sb);

            cursor.Draw(sb);
        }
    }
}
