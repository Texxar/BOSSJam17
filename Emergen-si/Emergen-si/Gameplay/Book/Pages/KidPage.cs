using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Emergen_si
{
    class KidPage:Page
    {
        public KidPage(ContentManager content) : base()
        {
            avatar = content.Load<Texture2D>(@"Citizens//kid");
            name += "Lemm Probb";
            age += "7";

            text = "Lives with foster parents in Arrowfield Row.\nCalls every once in a while\n to get help with school.";
            Initialize();
        }
    }
}
