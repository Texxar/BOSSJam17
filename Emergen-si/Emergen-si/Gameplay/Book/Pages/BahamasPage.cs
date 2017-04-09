using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace Emergen_si
{
    class BahamasPage : Page
    {

        public BahamasPage(ContentManager content) : base()
        {
            avatar = content.Load<Texture2D>(@"Citizens//bahamas");
            name += "Bahamas";
            age += "621";

            text = " Lives in his broken alien ship.\nCame to Earth 2 years ago.\n Incredibly dumb for his age,\n therefore the crash landing.\nI don't think his real name is Bahamas.";
            Initialize();
        }

    }
}
