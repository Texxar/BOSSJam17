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
        public List<Interactable> stuff;
        public Interactable held;

        Rectangle rec;
        Texture2D tex;

        Texture2D normal;
        Texture2D closed;
        Texture2D holdingPhone;

        public Hand(ContentManager content, List<Interactable> stuff)
        {
           
            this.stuff = stuff;
            held = null;

            normal = content.Load<Texture2D>("Arm\\hand");
            closed = content.Load<Texture2D>("Arm\\fistadman");
            holdingPhone = content.Load<Texture2D>("Arm\\hold_phone_x");

            tex = normal;

            rec = new Rectangle(0, 0, tex.Width, tex.Height);
        }

        public GamePlayState Update(GameTime gameTime)
        {
            tex = normal;

            GamePlayState returnState = GamePlayState.Idle;
            MouseState mouseState = Mouse.GetState();

            rec.X = mouseState.X;
            rec.Y = mouseState.Y;

            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                tex = closed;
                if (held == null)
                {
                    stuff.ForEach(delegate (Interactable s)
                    {
                        if (s.rec.Intersects(rec) && held == null)
                        {
                            s.held = true;
                            held = s;
                            //held.held = true;
                            if (s is PostIt)
                            {
                                ((PostIt)s).scale = 1;
                                returnState = GamePlayState.Idle;
                            }

                            if (s is Phone)
                            {
                               if(((Phone)s).call != null)
                                {
                                    ((Phone)s).PickUpPhone();
                                    returnState = GamePlayState.Phone;
                                    held = null;
                                    tex = holdingPhone;
                                    rec.X = 400;
                                    rec.Y = 220;
                                }
                            
                            }
			    if (s is Computer)
                                returnState = GamePlayState.Screen;

                            if (s is Book)
                            {
                                //((Book)s).);
                                returnState = GamePlayState.Book;
                                held = null;
                                
                            }
                            
                        }
                    });
                }
            }
            else
            {
                if (held != null)
                    held.held = false;
                if (held is PostIt)
                    ((PostIt)held).scale = 0.1f;
                //held.held = false;
                held = null;
            }


            if (held != null)
            {
                held.rec.X = rec.X;
                held.rec.Y = rec.Y;
            }

            return returnState;
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(tex, new Vector2(rec.X,rec.Y), Color.White);
        }
    }
}
