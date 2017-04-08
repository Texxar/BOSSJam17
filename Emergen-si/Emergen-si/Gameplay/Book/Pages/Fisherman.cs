using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace Emergen_si
{
    class Fisherman : Page
    {

        public Fisherman(ContentManager content) : base()
        {
            avatar = content.Load<Texture2D>(@"Citizens//Fisherman");
            name += "Fisherman";
            age += "28";

            text = "HELP ME YOU GOBTROTTER ";
            Initialize();
        }
    }
}
