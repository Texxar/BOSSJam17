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

            rec = new Rectangle(0, 0, 30,30);
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
                        if (s.rec.Intersects(rec) && held == null && returnState == GamePlayState.Idle)
                        {
                            s.held = true;
                            held = s;
                            //held.held = true;
                            if (s is PostIt)
                            {
                                ((PostIt)s).scale = 1;
                                returnState = GamePlayState.Idle;
                            }

                          
			                if (s is Computer)
                            {
                                held = null;
                                returnState = GamePlayState.Screen;
                            }
                               

                            if (s is Book)
                            {
                                held = null;
                                //((Book)s).);
                                returnState = GamePlayState.Book;
                                held = null;
                                
                            }

                            if (s is Phone)
                            {
                                held = null;
                                if (((Phone)s).call != null)
                                {
                                    ((Phone)s).PickUpPhone();
                                    returnState = GamePlayState.Phone;
                                    //held = null;
                                    tex = holdingPhone;
                                    rec.X = 800;
                                    rec.Y = 30;
                                }

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

        public void Draw(SpriteBatch sb,Texture2D fill)
        {
            sb.Draw(tex, new Vector2(rec.X,rec.Y), Color.White);
            sb.Draw(fill, rec, Color.Red);
        }
    }
}
