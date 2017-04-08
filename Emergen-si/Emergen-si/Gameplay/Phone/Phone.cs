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
    class Phone : Interactable
    {
        Texture2D tex;

        double countDownTillNextCall;

        Call call;
        List<Call> callList;

        float rotation = 0;
        float roationValue = 0;
        float roatationSpeed = 0.1f;

        bool plusDirection = true;

        public Phone(ContentManager content): base()
        {
            tex = content.Load<Texture2D>("Environment\\fon_tom");
            rec = new Rectangle(930, 470, tex.Width, tex.Height);


            Random rand = new Random();
            countDownTillNextCall = rand.Next(3,5);

            call = null;

            callList = new List<Call>();

            callList.Add(new FishermanCall(content));

        }

        public void IdleUpdate(GameTime gameTime)
        {
            if (countDownTillNextCall > 0 && call == null)
                countDownTillNextCall -= gameTime.ElapsedGameTime.TotalSeconds;
            else if (call == null)
            {
                Random rand = new Random();

                call = callList[rand.Next(0, callList.Count)];
            }

            if(call != null)
            {
                if (plusDirection)
                {
                    roationValue += roatationSpeed;

                    if (roationValue > 1)
                        plusDirection = false;
                }
                else
                {
                    roationValue -= roatationSpeed;
                    if (roationValue <= 0)
                        plusDirection = true;
                }

                rotation = MathHelper.Lerp(-0.14f, 0.24f, roationValue);
            }
        }

        public void CallUpdate(GameTime gameTime)
        {
            call.Update();
        }

        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(tex, rec,null, Color.Blue,rotation,new Vector2(rec.Width/2,rec.Height/2),SpriteEffects.None,0);
            //if(call != null)
            //    call.Draw(sb);
        }
    }
}
