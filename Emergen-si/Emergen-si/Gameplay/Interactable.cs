using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using MonoGame.Extended.BitmapFonts;

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

        public virtual void Draw(SpriteBatch sb,Texture2D fill) { }
        public virtual void Draw(SpriteBatch sb, Texture2D fill, BitmapFont font) { }
        public virtual void Draw(SpriteBatch sb,BitmapFont font ) { }
        public virtual void Draw(SpriteBatch sb) { }
    }
}
