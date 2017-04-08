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

        public List<Interactable> stuff;
        public Interactable held;

        Rectangle rec;
        Texture2D tex;


        public Hand(ContentManager content, List<Interactable> stuff)
        {
           
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
                if (held == null)
                {
                    stuff.ForEach(delegate (Interactable s)
                    {
                        if (s.rec.Intersects(rec))
                        {
                            held = s;
                            //held.held = true;
                            if (s is PostIt)
                                ((PostIt)s).scale = 3;

                        }
                    });
                }
            }
            else
            {
                color = Color.Wheat;
                if (held is PostIt)
                    ((PostIt)held).scale = 1;


                //held.held = false;
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
