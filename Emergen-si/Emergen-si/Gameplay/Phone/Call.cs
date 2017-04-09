using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using MonoGame.Extended.BitmapFonts;

namespace Emergen_si
{
    enum CaseIntensity
    {
        low,
        medium,
        high
    }
    class Call
    {
        Rectangle rec;
        protected Texture2D avatar;
        float rotation = 0;
        float roationValue = 0;
        float roatationSpeed = 0.03f;

        protected Dialogue dia;

        bool plusDirection = true;

        bool openCall = true;

        public bool hasBeenDealtWith;

        public PostIt postIt;

         public double countDown;

        protected CaseIntensity caseIntensity;

        bool failed;
        /// Penelties
        protected string failMessage;
        protected int negativeHappiness;
        protected int negativeMoney;
        //protected

        /// Award
        protected string awardMessage;
        protected int PositiveHappiness;
        protected int PositivteMoney;
        //protected
        ///

        public Call()
        {
            
        }
        public Call(Call call, ContentManager content, NoteBoard noteBoard, List<Interactable> stuff, string inString)
        {
            avatar = call.avatar;
            postIt = new PostIt(content, noteBoard, inString);
            stuff.Add(postIt);
        }

        public virtual void Initialzie()
        {
            Random rand = new Random();
            if (caseIntensity == CaseIntensity.low)
                countDown = rand.Next(40,60);
            if (caseIntensity == CaseIntensity.medium)
                countDown = rand.Next(30,50);
            if (caseIntensity == CaseIntensity.high)
                countDown = rand.Next(20,30);

            failed = false;

            rec = new Rectangle(100, 620, avatar.Width, avatar.Height);
            openCall = true;
            hasBeenDealtWith = false;
        }

        public bool Update(GameTime gameTime)
        {
            if(plusDirection)
            {
                roationValue += roatationSpeed;

                if (roationValue > 1)
                    plusDirection = false;
            }
            else
            {
                roationValue -= roatationSpeed;
                if (roationValue <= 0)
                    plusDirection = true;
            }
                
            rotation = MathHelper.Lerp(-0.14f, 0.24f, roationValue);
            if(openCall == true)
                openCall = dia.Update(gameTime);

            return openCall;
        }

        public void ActiveCaseUpdate(GameTime gameTime)
        {
            countDown -= gameTime.ElapsedGameTime.TotalSeconds;

            if(countDown<0 && !failed)
            {
                failed = true;
            }

            if (postIt != null)
                postIt.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch,Vector2 dialogueVec,Texture2D fill)
        {
            spriteBatch.Draw(avatar,new Vector2(dialogueVec.X+90, dialogueVec.Y+20+ avatar.Height / 2),null,Color.White, rotation,new Vector2(avatar.Width/2,avatar.Height/2),1,SpriteEffects.None,0);

            dia.Draw(spriteBatch, dialogueVec, fill);
        }

        public void ActiveCaseDraw(SpriteBatch spriteBatch, BitmapFont font)
        {
            if (postIt != null)
                postIt.Draw(spriteBatch, font);
        }
    }
}
