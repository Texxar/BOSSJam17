using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

using MonoGame.Extended.BitmapFonts;

namespace Emergen_si
{
    public enum DialogueState
    {
        Question,
        Text
    }
    public class DialogueNode
    {
        DialogueState dialogueState;

        public string text { get; set; }
        public string playerText { get; set; }

        Rectangle textWriteArea;
        Rectangle questionWriteArea;


        BitmapFont font;

        int nextTree;

        int speakSpeed, speakInterval;

        double timer;

        string readLine = "";
        bool lineIsRead;
        int textPos;

        public DialogueNode(DialogueState dialogueState,Rectangle dialogueRec, BitmapFont font, string text, string playerText, int nextTree, int speed, int interval)
        {
            this.dialogueState = dialogueState;
            this.font = font;
            this.text = text;
            this.playerText = playerText;
            this.nextTree = nextTree;

            speakSpeed = speed;

            speakInterval = interval;

            this.textWriteArea = dialogueRec;
            this.questionWriteArea = new Rectangle(0, 300, 256, 44);

            if (playerText != null)
                playerText = ParseText(playerText);

            if (text != null)
                this.text = ParseText(text);

            timer = 0;

            textPos = 0;

            lineIsRead = false;

        }

        public int Update(GameTime gameTime, Dialogue dialogue, ref bool btnDown)
        {
            if (dialogueState == DialogueState.Text && !lineIsRead)
            {
                lineIsRead = ReadLine(gameTime, dialogue, ref btnDown);
            }

            if (Mouse.GetState().LeftButton == ButtonState.Pressed && !btnDown)
            {
                btnDown = true;
                if (dialogueState == DialogueState.Text && lineIsRead)
                {

                        textPos = 0;
                        readLine = "";
                        lineIsRead = false;
                        return nextTree;
                }
                else
                {
                    textPos = 0;
                    readLine = "";
                    lineIsRead = false;
                    return nextTree;
                }
            }

            return -2;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 abovePos)
        {

            if (dialogueState == DialogueState.Question)
            {
                if(abovePos.Y > 500)
                    spriteBatch.DrawString(font, playerText, abovePos, Color.White);
            }
            else
            {
                spriteBatch.DrawString(font, readLine, abovePos, Color.White);
            }
        }

        private bool ReadLine(GameTime gameTime, Dialogue dialogue, ref bool btnDown)
        {

            if (timer == 0)
            {
                timer = gameTime.TotalGameTime.TotalMilliseconds;

            }
            if (Mouse.GetState().LeftButton == ButtonState.Pressed && !btnDown)
            {
                btnDown = true;

                while (textPos < text.Length)
                {
                    readLine += text[textPos];
                    textPos++;
                }
            }
            else if (gameTime.TotalGameTime.TotalMilliseconds - timer > speakSpeed && textPos < text.Length)
            {
                // int length = (int)font.MeasureString(textPrint).Length();

                Random randomFloat = new Random();

                readLine += text[textPos];
                textPos++;
                timer = 0;

                if (text[textPos - 1] != ' ')
                {

                   // if (textPos % speakInterval == 0)
                   //     dialogue.voice.Play(1, (float)(randomFloat.NextDouble() * (dialogue.minimumSpeed - dialogue.maximumSpeed) + dialogue.maximumSpeed), 0);
                }

            }
            else if (textPos >= text.Length)
            {
                textPos = 0;
                return true;
            }


            return false;
        }

        public int GetHeight()
        {
            return font.GetStringRectangle("A",new Vector2(0,0)).Height;
        }

        private string ParseText(string inputText)
        {
            String line = "";
            String returnString = String.Empty;
            String[] wordArray = inputText.Split(' ');


            foreach (String word in wordArray)
            {
                if (dialogueState == DialogueState.Text)
                {
                    if(Keyboard.GetState().IsKeyDown(Keys.I))
                    {

                    }
                    if (font.GetStringRectangle(line + word, new Vector2(textWriteArea.X, textWriteArea.Y)).Width > textWriteArea.Width- 180)
                    {
                        returnString = returnString + line + '\n' + ' ';
                        line = String.Empty;
                        textWriteArea.Height += 6;
                    }
                }
                else
                {
                    if (font.GetStringRectangle(line + word, new Vector2(questionWriteArea.X, questionWriteArea.Y)).Width > questionWriteArea.Width)
                    {
                        returnString = returnString + line + '\n' + ' ';
                        line = String.Empty;
                        questionWriteArea.Height += 6;
                    }
                }


                line = line + word + ' ';
            }

            return returnString + line;
        }
    }
}
