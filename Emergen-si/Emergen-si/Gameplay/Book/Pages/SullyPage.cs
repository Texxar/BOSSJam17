using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Emergen_si
{
    class SullyPage : Page
    {
        public SullyPage(ContentManager content) : base()
        {
            avatar = content.Load<Texture2D>(@"Citizens//midlifecrisis");
            name += "Sully Smith";
            age += "48";

            text = "Owner of the city bank. A professional\n businessman with no sense of humor.";
            Initialize();
        }
    }
}
