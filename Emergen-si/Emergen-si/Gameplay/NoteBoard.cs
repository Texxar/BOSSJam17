
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
    class NoteBoard
    {
        Texture2D tex;
        public Rectangle rec;

        public NoteBoard(ContentManager content) : base()
        {
            tex = content.Load<Texture2D>("Environment\\board");
            rec = new Rectangle(800, 50, tex.Width, tex.Height);
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(tex, rec, Color.White);
        }
    }
}