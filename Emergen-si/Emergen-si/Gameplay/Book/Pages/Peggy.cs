using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Emergen_si
{
    class Peggy : Page
    {
        
        public Peggy(ContentManager content):base()
        {
            avatar = content.Load<Texture2D>(@"Citizens//peggy");

            Initialize();
        }
    }
}
