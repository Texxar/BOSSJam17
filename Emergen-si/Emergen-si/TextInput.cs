using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using MonoGame.Extended.BitmapFonts;

namespace Emergen_si
{
    public class TextInput
    {
        private Keys[] lastPressedKeys;

        public string returnString;

        bool done;
        public TextInput()
        {
            lastPressedKeys = new Keys[0];
            returnString = "";
            done = false;
        }
        public bool Update()
        {
            KeyboardState kbState = Keyboard.GetState();
            Keys[] pressedKeys = kbState.GetPressedKeys();

            //check if any of the previous update's keys are no longer pressed
            foreach (Keys key in lastPressedKeys)
            {
                if (!pressedKeys.Contains(key))
                    OnKeyUp(key);
            }

            //check if the currently pressed keys were already pressed
            foreach (Keys key in pressedKeys)
            {
                if (!lastPressedKeys.Contains(key))
                    OnKeyDown(key);
            }

            //save the currently pressed keys so we can compare on the next update
            lastPressedKeys = pressedKeys;
            return done;
        }

        public void Clear()
        {
            returnString = "";
            done = false;
        }

        private void OnKeyDown(Keys key)
        {
            if (key == Keys.Back && returnString.Length >0)
            {
               returnString=  returnString.Remove(returnString.Length-1);
            }
            else if(key == Keys.Enter)
            {
                done = true;
            }
            else if (key == Keys.Space)
            {
                returnString += " ";
            }
            else if(key >= Keys.A && key <= Keys.Z)
            {
                returnString += key.ToString();
            }
        }

        private void OnKeyUp(Keys key)
        {
            
        }

        public void Draw(SpriteBatch spriteBatch, BitmapFont font)
        {
            spriteBatch.DrawString(font, returnString,new Vector2(50,120),Color.Red);
        }
    }
}
