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
    class Interactable
    {
        public Texture2D tex;
        public Rectangle rec;
        public bool held;

        public Interactable()
        {
            held = false;
        }

        public void Init()
        {

            rec = new Rectangle(0, 0, tex.Width, tex.Height);
        }

        public virtual void Draw(SpriteBatch sb) { }
    }
}
