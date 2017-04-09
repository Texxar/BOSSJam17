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
    class Book:Interactable
    {
        Texture2D openBook;
        List<Page> pages;
        BitmapFont font;
        int currentPage = 0;

        bool keyDown = false;


        public Book(ContentManager content)
            :base()
        {
            pages = new List<Page>();

            pages.Add(new GhostPage(content));
            pages.Add(new DonniePage(content));
            pages.Add(new KidPage(content));
            pages.Add(new ChickOritaPage(content));
            pages.Add(new GrannyPage(content));
            pages.Add(new BahamasPage(content));
            pages.Add(new ButchPage(content));
            pages.Add(new SullyPage(content));
            pages.Add(new RonaldPage(content));
            pages.Add(new MartinRobsPAge(content));

            //pages.Add(new Fisherman(content));

            tex = content.Load<Texture2D>("Environment\\bok_kanske");
            openBook = content.Load<Texture2D>("Environment\\BookOpen");
            font = content.Load<BitmapFont>(@"Font\\BIG");

            rec = new Rectangle(50, 400, tex.Width, tex.Height);
        }

        public bool Update()
        {
            if(Keyboard.GetState().IsKeyDown(Keys.D ) && !keyDown)
            {
                if (currentPage < pages.Count-1)
                    currentPage++;

            }

            if (Keyboard.GetState().IsKeyDown(Keys.A) && !keyDown)
            {
                if (currentPage > 0)
                    currentPage--;

            }
            

            if (Keyboard.GetState().GetPressedKeys().Length > 0)
                keyDown = true;
            else
                keyDown = false;
            return Mouse.GetState().RightButton == ButtonState.Pressed;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            
            spriteBatch.Draw(tex, rec, Color.White);
            spriteBatch.Draw(openBook, new Vector2(0, 0), Color.White);
            pages[currentPage].Draw(spriteBatch, font);
        }
        
        public void IdleDraw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tex, rec, Color.White);
        }
    }
}
