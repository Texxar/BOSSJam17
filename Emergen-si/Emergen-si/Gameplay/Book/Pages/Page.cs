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
    class Page
    {
        protected Texture2D avatar;

        string text;
        Rectangle rec;

        public Page()
        {
           
        }
        public void Initialize()
        {
            rec = new Rectangle(40, 40, avatar.Width, avatar.Height);
        }

        public void Draw(SpriteBatch spriteBatchc)
        {
            spriteBatchc.Draw(avatar, rec, Color.White);

        }
    }
}
