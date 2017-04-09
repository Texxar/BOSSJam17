using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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
        PostIt postIt;
        Hand hand;
        List<Interactable> stuff;

        Texture2D bord;

        public GamePlay(ContentManager content)
        {
            gameplayState = GamePlayState.Idle;
            book = new Book(content);

            bord = content.Load<Texture2D>("Environment\\bord");
            noteBoard = new NoteBoard(content);
            screen = new Screen(content);

            stuff = new List<Interactable>();

            phone = new Phone(content); //Who dis?
            stuff.Add(phone);

            computer = new Computer(content);
            stuff.Add(computer);
            postIt = new PostIt(content, noteBoard);
            stuff.Add(postIt);


            hand = new Hand(content, stuff);

        }

        public void Update(GameTime gameTime)
        {
            switch(gameplayState)
            {
                case GamePlayState.Idle:
                    GamePlayState temPState = hand.Update(gameTime);
                    if (temPState != GamePlayState.Idle)
                        gameplayState = temPState;
                    phone.IdleUpdate(gameTime);
                    postIt.Update(gameTime);
                    break;

                case GamePlayState.Book:
                    book.Update();
                    break;

                case GamePlayState.Phone:
                    phone.CallUpdate(gameTime);
                    break;

                case GamePlayState.Screen:
                    screen.Update(gameTime);
                    break;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(bord, new Vector2(0, 0), Color.White);

            switch (gameplayState)
            {
                case GamePlayState.Idle:
                    book.IdleDraw(spriteBatch);
                    computer.Draw(spriteBatch);
                    phone.Draw(spriteBatch);
                    noteBoard.Draw(spriteBatch);
                    postIt.Draw(spriteBatch);
                    hand.Draw(spriteBatch);

                    if (hand.held != null)
                        hand.held.Draw(spriteBatch);


                    break;

                case GamePlayState.Book:
                    book.Draw(spriteBatch);
                    break;

                case GamePlayState.Phone:
                    phone.Draw(spriteBatch);
                    break;

                case GamePlayState.Screen:
                    screen.Draw(spriteBatch);
                    break;
            }
        }
    }
}
