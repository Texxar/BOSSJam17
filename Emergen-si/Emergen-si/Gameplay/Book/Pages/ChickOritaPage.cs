using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace Emergen_si
{
    class ChickOritaPage:Page
    {
        public ChickOritaPage(ContentManager content) : base()
        {
            avatar = content.Load<Texture2D>(@"Citizens//hawtchick");
            name += "Chick Orita";
            age += "11";

            text = "Lives together with her parents in\n Marble Lane.She's sweet, but there's \nsomething.... odd about her.\nI'm not sure why yet.";
            Initialize();
        }
    }
}
