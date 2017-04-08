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
    class Book
    {
        List<Page> pages;

        public Book(ContentManager content)
        {
            pages = new List<Page>();

            pages.Add(new Peggy(content));
        }

        public void Update()
        {


        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for(int n = 0;n< pages.Count;n++)
            {
                pages[n].Draw(spriteBatch);
            }
        }
    }
}
