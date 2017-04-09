using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Emergen_si
{
    class ButchPage : Page
    {
        public ButchPage(ContentManager content) : base()
        {
            avatar = content.Load<Texture2D>(@"Citizens//mobster");
            name += "Butch Ingyou";
            age += "33";

            text = "Lives with his wife and two kids in\n Arrowfield Row.Looks like a hitman and gets\n accused for criminal acts often.But he's \nactually really nice and thoughtful.What's up \nwith his name? Is he Japanese or something?";
            Initialize();
        }
    }
}
