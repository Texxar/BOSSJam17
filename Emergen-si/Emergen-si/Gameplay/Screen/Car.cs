using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Emergen_si.Gameplay.Screen
{
    class Car: Interactable
    {
        int posX, posY;
        int goalX, goalY;
        int speed;

        public Car(ContentManager content, Map map) : base()
        {
            tex = content.Load<Texture2D>("HillHorizon");
            Init();
            speed = 5;
        }

        public void Update(GameTime gameTime)
        {
            if (posX < goalX)
            {
                rec.X += speed;
            }
            else if (posX > goalX)
            {
                rec.X -= speed;
            }
            else if (posY < goalY)
            {
                rec.Y += speed;
            }
            else if (posY > goalY)
            {
                rec.Y -= speed;
            }

        }

        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(tex, rec, Color.Blue);
        }

    }
}
