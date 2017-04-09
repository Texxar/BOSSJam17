using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace Emergen_si
{
    class DonniePage : Page
    {
        public DonniePage(ContentManager content) : base()
        {
            avatar = content.Load<Texture2D>(@"Citizens//teenagewasteland");
            name += "Donnie Doug";
            age += "27";

            text = "Owner of the donut shop.\n Probably lives there too?\nA policeman's best friend.\n He seems kinda lonely though.";
            Initialize();
        }
    }
}
