using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Emergen_si
{
    class Interactable
    {
        public Rectangle rec;
        public Rectangle hitBox;


        public Interactable()
        {
            rec = new Rectangle(0, 0, 10, 10);
            hitBox = rec;
        }

    }
}
