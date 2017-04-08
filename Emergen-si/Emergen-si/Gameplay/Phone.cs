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
    class Phone
    {
        public Rectangle rec;

        Texture2D tex;
        public Phone(ContentManager content)
        {
            tex = content.Load<Texture2D>("HillHorizon");
            rec = new Rectangle(830, 370, tex.Width, tex.Height);
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(tex, rec, Color.Wheat);
        }
    }
}
