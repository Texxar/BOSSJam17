using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Emergen_si
{
    class GhostPage : Page
    {

        public GhostPage(ContentManager content) : base()
        {
            avatar = content.Load<Texture2D>(@"Citizens//ghostofforestmanor");
            name += "Gabriel the ghost";
            age += "?";

            text = "Lives in the ghost house.\nIs easily offended.";
            Initialize();
        }
    }
}
