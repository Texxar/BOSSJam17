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


        public Phone(ContentManager content)
        {
            hitBox = new Rectangle(0, 0, 64, 64);


            tex = content.Load<Texture2D>("HillHorizon");
            rec = new Rectangle(0,0,64,64);
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(tex, rec, Color.Blue);
        }
    }
}
