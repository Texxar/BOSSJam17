using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
namespace Emergen_si
{
    class MartinRobsPAge : Page
    {
        public MartinRobsPAge(ContentManager content) : base()
        {
            avatar = content.Load<Texture2D>(@"Citizens//normal guy");
            name += "Martin Robson";
            age += "20";

            text = "Live with his parents in a fine Clayhill Parkway villa.\nSpoiled.Seriously, how does this guy \nsurvive!? He can't seem to walk outside \nhis house by himself without calling us\n for help for something unnecessary.";
            Initialize();
        }
    }
}
