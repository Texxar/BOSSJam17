using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using MonoGame.Extended.BitmapFonts;

namespace Emergen_si
{
    public class Dialogue
    {

        List<DialogueTree> dialogueTree;
        Rectangle sourceRec;

        public SoundEffect voice;

        public float maximumSpeed, minimumSpeed;

        public int lasteTree;
        int currentTree;

        public string fileName;

        BitmapFont font;

        Texture2D dialogueTex;
        Rectangle dialogueRec;


        public Dialogue(string fileName, ContentManager content)
        {
            this.fileName = fileName;
            dialogueRec = new Rectangle(0, 0, 1280, 200);


            currentTree = 0;
            font = content.Load<BitmapFont>("Font\\BIG");
            if (fileName != null)
                LoadDialogue(fileName, content, dialogueRec);

            dialogueTex = content.Load<Texture2D>("DialogueAvatar\\DialogBox");

           // avatar = new Avatar(avatarTexture, new Vector2(213, 111));
            sourceRec = new Rectangle(0, 0, 42, 42);

        }

        public void LoadDialogue(string fileName, ContentManager content, Rectangle dialogueRec)
        {
            fileName = "Content/Dialogue/" + fileName + ".DIA";
            if (fileName != "")
            {
                //editor.ClearAll();
                StreamReader sReader = new StreamReader(fileName);

                string tempString = sReader.ReadLine();

                dialogueTree = new List<DialogueTree>();

                float minimumSpeed = 0, maximumSpeed = 0;
                int interval = 2, speed = 45;

                int nextTree = -1;

                string playerText = "";
                string text = "";

                while (!sReader.EndOfStream)
                {

                    tempString = sReader.ReadLine();
                    string[] tempStrings = tempString.Split(' ');
                    string tempChar = tempStrings[0];



                    switch (tempChar)
                    {
                        case ("v"):
                            //voice = content.Load<SoundEffect>("Voices" + '\\' + tempStrings[1]);//dialogueTree.Add(new DialogueTree(dialogueTree.Count));
                            break;

                        case ("minS"):
                            minimumSpeed = float.Parse(tempStrings[1]);
                            break;
                        case ("maxS"):
                            maximumSpeed = float.Parse(tempStrings[1]);
                            break;

                        case ("si"):
                            interval = int.Parse(tempStrings[1]);
                            break;

                        case ("ss"):
                            speed = int.Parse(tempStrings[1]);
                            break;

                        case ("nr"):
                            dialogueTree.Add(new DialogueTree(dialogueTree.Count));
                            break;

                        case ("n"):
                            nextTree = int.Parse(tempStrings[1]);
                            break;

                        case ("t"):
                            for (int n = 1; n < tempStrings.Length; n++)
                                text += tempStrings[n] + " ";
                            break;

                        case ("q"):
                            for (int n = 1; n < tempStrings.Length; n++)
                                playerText += tempStrings[n] + " ";
                            break;

                        case (""):

                            if (playerText != "")
                            {
                                dialogueTree[dialogueTree.Count - 1].treeNodes.Add(new DialogueNode(DialogueState.Question,dialogueRec, font, null, playerText, nextTree, speed, interval));

                                dialogueTree[dialogueTree.Count - 1].dialogueState = DialogueState.Question;

                            }
                            else if (text != "")
                            {
                                dialogueTree[dialogueTree.Count - 1].treeNodes.Add(new DialogueNode(DialogueState.Text, dialogueRec,font, text, null, nextTree, speed, interval));
                                dialogueTree[dialogueTree.Count - 1].dialogueState = DialogueState.Text;
                            }
                            playerText = "";
                            text = "";
                            break;
                    }
                }
                sReader.DiscardBufferedData();
                sReader.Dispose();
                sReader.Close();
                
            }
        }

        public bool Update(GameTime gameTime)
        {
            lasteTree = currentTree;
            currentTree = dialogueTree[currentTree].Update(gameTime, this);

            if (currentTree == -1)
            {
                currentTree = 0;
                return false;
            }
            return true;
        }

        public void Draw(SpriteBatch spriteBatch,Vector2 dialogueVec,Texture2D fill)
        {
            RasterizerState rasterState = new RasterizerState();
            rasterState.ScissorTestEnable = true;

           // spriteBatch.Begin(SpriteSortMode.Immediate, null, SamplerState.PointWrap, DepthStencilState.None, rasterState, null, null);
            dialogueTree[currentTree].Draw(spriteBatch, dialogueVec, fill);

           // spriteBatch.End();
        }

    }
}
