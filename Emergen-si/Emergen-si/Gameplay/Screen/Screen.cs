using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using MonoGame.Extended.BitmapFonts;

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

        double crimeSceenCountDown = 3;
        bool atcrimeScreen = false;

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

            if (mouseState.RightButton == ButtonState.Pressed)
                return true;
            
            else
                return false;
        }


        public void UpdateCopCar(GameTime gameTime)
        {
            if (atcrimeScreen)
            {
                crimeSceenCountDown -= gameTime.ElapsedGameTime.TotalSeconds;
            }
            policeCar.Update(gameTime);
        }

        public void Draw(SpriteBatch sb,BitmapFont font)
        {

            map.Draw(sb);
            policeCar.Draw(sb);
            if (atcrimeScreen)
                sb.DrawString(font, "Case in Progress: " + (int)crimeSceenCountDown, new Vector2(policeCar.rec.X, policeCar.rec.Y), Color.Red);

            cursor.Draw(sb);
        }

        public void CheckWinCondition(List<Call> activeCases,Resources resource)
        {
            int crimeCloseTo = 0;
            bool inCrime = false;
            for(int n=0;n< activeCases.Count;n++)
            {
                if (!activeCases[n].hasBeenDealtWith)
                {
                    if (activeCases[n].missionLocation.X == policeCar.posX && activeCases[n].missionLocation.Y == policeCar.posY)
                    {
                        inCrime = true;
                        crimeCloseTo = n;
                    }
                }
            }

            if(inCrime)
            {
                atcrimeScreen = true;
                if(crimeSceenCountDown < 0)
                {
                    activeCases[crimeCloseTo].WinCase(resource);
                }
            }
            else
            {
                crimeSceenCountDown = 3;
                atcrimeScreen = false;
            }
        }
    }
}
