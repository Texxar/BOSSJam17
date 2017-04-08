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

        public Phone(ContentManager content): base()
        {
            hitBox = new Rectangle(0, 0, 64, 64);

            tex = content.Load<Texture2D>("HillHorizon");
            rec = new Rectangle(830, 370, tex.Width, tex.Height);

            Random rand = new Random();
            countDownTillNextCall = rand.Next();

            call = new Call(content);
        }

        public void Update(GameTime gameTime)
        {
            call.Update();

            if (countDownTillNextCall > 0)
                countDownTillNextCall -= gameTime.TotalGameTime.TotalSeconds;
            else
            {

            }
            
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(tex, rec, Color.Blue);
            call.Draw(sb);
        }
    }
}
