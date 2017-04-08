using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using MonoGame.Extended.BitmapFonts;

namespace Emergen_si
{
    class Book
    {
        Texture2D tex;
        List<Page> pages;
        BitmapFont font;
        int currentPage = 0;

        bool keyDown = false;


        public Book(ContentManager content)
        {
            pages = new List<Page>();

            pages.Add(new Peggy(content));
            pages.Add(new Fisherman(content));
            pages.Add(new Peggy(content));
            pages.Add(new Fisherman(content));

            tex = content.Load<Texture2D>("Book");
            font = content.Load<BitmapFont>(@"Font\\BIG");
        }

        public void Update()
        {
            if(Keyboard.GetState().IsKeyDown(Keys.Right ) && !keyDown)
            {
                if (currentPage < pages.Count-1)
                    currentPage++;

            }

            if (Keyboard.GetState().IsKeyDown(Keys.Left) && !keyDown)
            {
                if (currentPage > 0)
                    currentPage--;

            }

            if (Keyboard.GetState().GetPressedKeys().Length > 0)
                keyDown = true;
            else
                keyDown = false;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tex, new Vector2(0, 0), Color.White);
             pages[currentPage].Draw(spriteBatch, font);
        }
    }
}
