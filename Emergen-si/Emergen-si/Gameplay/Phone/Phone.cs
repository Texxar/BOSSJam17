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
    class Phone : Interactable
    {
        ContentManager content;
        Texture2D dialogueTex;
        Vector2 dialogueVec;
        double countDownTillNextCall;

        public Call call;
        List<Call> callList;

        float rotation = 0;
        float roationValue = 0;
        float roatationSpeed = 0.3f;

        bool plusDirection = true;

        bool active = false;
        bool writeNote = false;
        TextInput textInput;

        public Phone(ContentManager content): base()
        {
            this.content = content;
            tex = content.Load<Texture2D>("Environment\\fon_tom");
            dialogueTex = content.Load<Texture2D>("DialogueAvatar\\DialogBox");
            rec = new Rectangle(930, 470, tex.Width, tex.Height);

            Random rand = new Random();
            countDownTillNextCall = rand.Next(0,2);

            call = null;

            callList = new List<Call>();

            callList.Add(new FishermanCall(content));

            dialogueVec = new Vector2(0, 800);

            textInput = new TextInput();


        }

        public void IdleUpdate(GameTime gameTime)
        {
            if (countDownTillNextCall > 0 && call == null)
                countDownTillNextCall -= gameTime.ElapsedGameTime.TotalSeconds;
            else if (call == null)
            {
                Random rand = new Random();

                call = callList[rand.Next(0, callList.Count)];
                call.Initialzie();
            }

            if(call != null)
            {
                if (plusDirection)
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
            }
        }

        public bool CallUpdate(GameTime gameTime,List<Call> activeCases,List<Interactable> stuff,NoteBoard noteBoard)
        {
            if (call.Update(gameTime) == true)
            {
                if (dialogueVec.Y > 540)
                    dialogueVec.Y -= 2;
            }
            else
            {
                if (dialogueVec.Y < 850)
                    dialogueVec.Y += 2;
                else
                {
                    writeNote = true;
                  
                }
            }

            if(writeNote == true)
            {
                if(textInput.Update())
                {
                    active = false;
                    if (!call.hasBeenDealtWith)
                        if (call.GetType() == typeof(FishermanCall))
                            activeCases.Add(new FishermanCall(call, content, noteBoard, stuff, textInput.returnString));

                    textInput.Clear();
                    writeNote = false;
                    call = null;
                    return false;
                }

                
            }
            return true;
        }

        public override void Draw(SpriteBatch sb,Texture2D fill,BitmapFont font)
        {
            sb.Draw(tex, rec,null, Color.White,rotation,new Vector2(rec.Width/2,rec.Height/2),SpriteEffects.None,0);

            textInput.Draw(sb, font);
            if (call != null && active)
            {
                sb.Draw(dialogueTex, dialogueVec, Color.White);
                call.Draw(sb, dialogueVec, fill);
            }
        }

        public void PickUpPhone()
        {
            Random rand = new Random();
            
            countDownTillNextCall = rand.Next(6, 20);
            active = true;
            dialogueVec = new Vector2(0, 800);
        }
    }
}
