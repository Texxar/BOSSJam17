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
    class PostIt : Interactable
    {
        Texture2D tex;


        public PostIt(ContentManager content) : base()
        {
            tex = content.Load<Texture2D>("HillHorizon");
            rec = new Rectangle(0, 0, tex.Width, tex.Height);
            hitBox = rec;
        }

        public void Update(GameTime gameTime)
        {

        }

        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(tex, rec, Color.Yellow);
        }
    }
}
