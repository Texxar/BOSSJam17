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
    class Page
    {
        protected Texture2D avatar;

        protected string name;
        protected string age;
        protected string text;
        Rectangle rec;

        public Page()
        {
            name = "Name: ";
            age = "Age: ";

        }
        public void Initialize()
        {
            rec = new Rectangle(120, 40, avatar.Width, avatar.Height);
        }

        public void Draw(SpriteBatch spriteBatch,BitmapFont font)
        {
            spriteBatch.Draw(avatar, rec, Color.White);

            spriteBatch.DrawString(font, name, new Vector2(520, 50), Color.Black);
            spriteBatch.DrawString(font, age, new Vector2(520, 120), Color.Black);

            // spriteBatch.DrawString(font, text, new Vector2(50, 50), Color.Black);
        }
    }
}
