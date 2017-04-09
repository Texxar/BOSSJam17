using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Emergen_si
{
    class GrannyPage : Page
    {

        public GrannyPage(ContentManager content) : base()
        {
            avatar = content.Load<Texture2D>(@"Citizens//granny");
            name += "Margaret Woods";
            age += "73";

            text = "Lives alone in a Clayhill apartment. \nHer cat gets stuck in trees a lot.\nIs severely senile.";
            Initialize();
        }
    }
}
