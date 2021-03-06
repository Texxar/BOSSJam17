﻿using System;
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
    class PostIt : Interactable
    {
        public float scale;
        NoteBoard noteBoard;

        string flavortext = "Something went wrong";

        public PostIt(ContentManager content, NoteBoard noteBoard,string inText) : base()
        {
            tex = content.Load<Texture2D>("Environment\\Postit_2");
            Init();
            scale = 0.1f;
            
            rec = new Rectangle(460, rec.Y, (int)(rec.Width * scale), (int)(rec.Height * scale));
            this.noteBoard = noteBoard;
            flavortext = inText;
        }

        public void Update(GameTime gameTime)
        {
            if (!rec.Intersects(noteBoard.rec) && rec.Y < 580 && !held)
            {
                rec.Y += 20;
            }
        }

        public void Draw(SpriteBatch sb,BitmapFont font)
        {
            sb.Draw(
                tex,
                new Vector2(rec.X, rec.Y), 
                null, 
                Color.White, 
                0,                                              //rotation
                new Vector2(tex.Width*0.5f, tex.Height*0.5f),   //origin
                scale,                                          //scale
                SpriteEffects.None, 
                0 );
            if(held)
                sb.DrawString(font, ParseText(flavortext, font), new Vector2(rec.X- ((tex.Width*scale)/2), rec.Y - ((tex.Height*scale)/2) ), Color.White);

        }

        private string ParseText(string inputText,BitmapFont font)
        {
            String line = "";
            String returnString = String.Empty;
            String[] wordArray = inputText.Split(' ');


            foreach (String word in wordArray)
            {
                    if (font.GetStringRectangle(line + word, new Vector2(rec.X, rec.Y)).Width > (tex.Width))
                    {
                        returnString = returnString + line + '\n' + ' ';
                        line = String.Empty;

                    }
                line = line + word + ' ';
            }

            return returnString + line;
        }
    }
}
