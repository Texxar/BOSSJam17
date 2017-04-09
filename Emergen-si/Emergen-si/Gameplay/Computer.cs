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
    //Imma compuda!
    class Computer : Interactable
    {
        public Computer(ContentManager content) : base()
        {
            tex = content.Load<Texture2D>("Environment\\screen");
            Init();
            rec = new Rectangle(420, 200, tex.Width, tex.Height);
        }

        public void Update(GameTime gameTime)
        {

        }

        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(tex, rec, Color.White);
        }
    }
}
