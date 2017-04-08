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
    class Hand
    {
        Color color;

        List<Interactable> stuff;
        Interactable held;

        Rectangle rec;
        Texture2D tex;

        Rectangle hitBox;


        public Hand(ContentManager content, List<Interactable> stuff)
        {
            hitBox = new Rectangle(8, 8, 56, 56);
            color = Color.Wheat;
            this.stuff = stuff;
            held = null;

            tex = content.Load<Texture2D>("HillHorizon");
            rec = new Rectangle(0, 0, 64, 64);

        }

        public void Update(GameTime gameTime)
        {
            MouseState mouseState = Mouse.GetState();

            rec.X = mouseState.X;
            rec.Y = mouseState.Y;

            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                color = Color.Red;

                stuff.ForEach(delegate (Interactable s)
                {
                    if (s.hitBox.Intersects(hitBox))
                    {
                        held = s;
                    }
                });

            }
            else
            {
                color = Color.Wheat;
                held = null;
            }


            if (held != null)
            {
                held.rec.X = rec.X;
                held.rec.Y = rec.Y;
            }


        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(tex, rec, color);
        }
    }
}
