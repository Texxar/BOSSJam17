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
    enum GamePlayState
    {
        Idle,
        Screen,
        Phone,
        Book
    }

    class GamePlay
    {
        GamePlayState gameplayState;
        Phone phone;
        Book book;
        Computer computer;
        Screen screen;
        NoteBoard noteBoard;
        Hand hand;
        List<Interactable> stuff;

        BitmapFont font;

        Texture2D background;
        Texture2D bord;

        Texture2D happinessIcon;
        Texture2D moneyIcon;

        Resources resource;


        List<Call> activeCases;

       public GamePlay (ContentManager content)
        {
            gameplayState = GamePlayState.Idle;
            book = new Book(content);

            background = content.Load<Texture2D>("Environment\\bakgrund_color");
            bord = content.Load<Texture2D>("Environment\\bord");
            font = content.Load<BitmapFont>("Font\\BIG");

            happinessIcon = content.Load<Texture2D>("happinessIcon");
            moneyIcon = content.Load<Texture2D>("moneyIcon");

            noteBoard = new NoteBoard(content);
            screen = new Screen(content);

            stuff = new List<Interactable>();

            phone = new Phone(content); //Who dis?
            stuff.Add(phone);
            stuff.Add(book);

            activeCases = new List<Call>();
            computer = new Computer(content);
            stuff.Add(computer);

            hand = new Hand(content, stuff);

            resource = new Resources();

        }

        public void Update(GameTime gameTime)
        {
            for (int n = 0; n < activeCases.Count; n++)
               if( activeCases[n].ActiveCaseUpdate(gameTime,resource))
                {
                    activeCases.RemoveAt(n);
                }
            switch (gameplayState)
            {
                case GamePlayState.Idle:
                    GamePlayState temPState = hand.Update(gameTime);
                    if (temPState != GamePlayState.Idle)
                        gameplayState = temPState;
                    phone.IdleUpdate(gameTime);
                    break;

                case GamePlayState.Book:
                    if (book.Update())
                        gameplayState = GamePlayState.Idle;
                    break;

                case GamePlayState.Phone:
                    if (!phone.CallUpdate(gameTime, activeCases,stuff,noteBoard))
                        gameplayState = GamePlayState.Idle;
                    break;

                case GamePlayState.Screen:
                    if(screen.Update(gameTime))
                        gameplayState = GamePlayState.Idle;
                    break;
            }
        }

        public void Draw(SpriteBatch spriteBatch,Texture2D fill)
        {
            
            spriteBatch.Draw(background, new Vector2(0, 0), Color.White);
            spriteBatch.Draw(bord, new Vector2(0, 400), Color.White);

            book.IdleDraw(spriteBatch);
            phone.Draw(spriteBatch,fill,font);
            noteBoard.Draw(spriteBatch);
            computer.Draw(spriteBatch);

            for (int n = 0; n < activeCases.Count; n++)
                activeCases[n].ActiveCaseDraw(spriteBatch,font,fill);
            switch (gameplayState)
            {
                case GamePlayState.Idle:
                    
                    
                    hand.Draw(spriteBatch,fill);

                    if (hand.held != null)
                        hand.held.Draw(spriteBatch);


                    break;

                case GamePlayState.Book:
                    book.Draw(spriteBatch);
                    break;

                case GamePlayState.Phone:
                    phone.Draw(spriteBatch,fill,font);
                    hand.Draw(spriteBatch,fill);
                    break;

                case GamePlayState.Screen:
                    screen.Draw(spriteBatch);
                    break;
            }

            spriteBatch.Draw(happinessIcon, new Vector2(40, 0), Color.White);
            spriteBatch.DrawString(font,resource.happiness.ToString(), new Vector2(110, 0),Color.White);

            spriteBatch.Draw(moneyIcon, new Vector2(400, 0), Color.White);
            spriteBatch.DrawString(font, resource.money.ToString(), new Vector2(450, 0), Color.White);
        }
    }
}
