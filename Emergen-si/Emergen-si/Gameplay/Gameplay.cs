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


        List<Call> activeCases;

       public GamePlay (ContentManager content)
        {
            gameplayState = GamePlayState.Idle;
            book = new Book(content);

            background = content.Load<Texture2D>("Environment\\bakgrund_color");
            bord = content.Load<Texture2D>("Environment\\bord");
            font = content.Load<BitmapFont>("Font\\BIG");

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

        }

        public void Update(GameTime gameTime)
        {
            for (int n = 0; n < activeCases.Count; n++)
                activeCases[n].ActiveCaseUpdate(gameTime);
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
                    screen.Update(gameTime);
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
                activeCases[n].ActiveCaseDraw(spriteBatch,font);
            switch (gameplayState)
            {
                case GamePlayState.Idle:
                    
                    
                    hand.Draw(spriteBatch);

                    if (hand.held != null)
                        hand.held.Draw(spriteBatch);


                    break;

                case GamePlayState.Book:
                    book.Draw(spriteBatch);
                    break;

                case GamePlayState.Phone:
                    phone.Draw(spriteBatch,fill,font);
                    hand.Draw(spriteBatch);
                    break;

                case GamePlayState.Screen:
                    screen.Draw(spriteBatch);
                    break;
            }
        }
    }
}
