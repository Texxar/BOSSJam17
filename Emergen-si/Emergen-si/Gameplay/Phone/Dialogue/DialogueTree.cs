using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Emergen_si
{
    public class DialogueTree
    {
        public List<DialogueNode> treeNodes;

        public int currentLevel { get; set; }

        public int currentNode;

        public DialogueState dialogueState { get; set; }

        #region
        int chosenQuestion;
        bool btnDown;
        #endregion

        public DialogueTree(int currentLevel)
        {
            this.currentLevel = currentLevel;
            treeNodes = new List<DialogueNode>();


            currentNode = 0;
            chosenQuestion = 0;

            btnDown = true;
        }

        public int Update(GameTime gameTime, Dialogue dialogue)
        {
            if (dialogueState == DialogueState.Question)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.W) && chosenQuestion != 0 && !btnDown)
                {
                    chosenQuestion--;
                    btnDown = true;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.S) && chosenQuestion < treeNodes.Count - 1 && !btnDown)
                {
                    chosenQuestion++;
                    btnDown = true;
                }

                currentNode = chosenQuestion;
            }

            int tempInt = treeNodes[currentNode].Update(gameTime, dialogue, ref btnDown);
            if (tempInt == -2)
            {
                tempInt = currentLevel;
            }
            else if (tempInt == -1)
            {
                chosenQuestion = 0;
                currentNode = 0;
                btnDown = true;
            }

            if (Keyboard.GetState().IsKeyUp(Keys.W) && Keyboard.GetState().IsKeyUp(Keys.S) && Keyboard.GetState().IsKeyUp(Keys.E) && Mouse.GetState().LeftButton == ButtonState.Released)
                btnDown = false;

            return tempInt;
        }

        public void Draw(SpriteBatch spriteBatch,Vector2 dialogueVec,Texture2D fill)
        {
            Rectangle tempRec = spriteBatch.GraphicsDevice.ScissorRectangle;
            spriteBatch.GraphicsDevice.ScissorRectangle = new Rectangle(0, (int)dialogueVec.Y,1280, 900);
            int heightCounter = 0;

            if (dialogueState == DialogueState.Question)
            {
                for (int n = 0; n < treeNodes.Count; n++)
                {
                    if (n == currentNode)
                        spriteBatch.Draw(fill, new Rectangle((int)dialogueVec.X + 180, (int)dialogueVec.Y + 5, 1280, treeNodes[n].GetHeight()), Color.Crimson);
                    heightCounter = treeNodes[n].GetHeight();
                    treeNodes[n].Draw(spriteBatch, new Vector2(dialogueVec.X+ 180, dialogueVec.Y + 5 - currentNode * heightCounter + n * heightCounter));

                }
            }
            else
            {
                treeNodes[currentNode].Draw(spriteBatch, new Vector2(dialogueVec.X + 180, dialogueVec.Y + heightCounter));
            }

            spriteBatch.GraphicsDevice.ScissorRectangle = tempRec;
        }

    }
}
