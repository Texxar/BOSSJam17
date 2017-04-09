using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Emergen_si
{
    class RonaldPage : Page
    {
        public RonaldPage(ContentManager content) : base()
        {
            avatar = content.Load<Texture2D>(@"Citizens//workout");
            name += "Ronald Woods";
            age += "54";

            text = "Lives in the Clayhill apartments.\nMargaret’s son, which has quite a resemblance.\n He seems to have started working out a lot. \nThat’s reassuring, he looks really cold!";
            Initialize();
        }
    }
}
