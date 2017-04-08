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

    class Gameplay
    {
        GamePlayState gameplayState;
        Phone phone;
        Book book;

        Texture2D background;

        public Gameplay(ContentManager content)
        {
            gameplayState = GamePlayState.Book;
            phone = new Phone(content);
            book = new Book(content);
            background = content.Load<Texture2D>("Prototyp_0_1");
        }

        public void Update(GameTime gameTIme)
        {
            switch(gameplayState)
            {
                case GamePlayState.Idle:
                    
                    break;

                case GamePlayState.Book:
                    book.Update();
                    break;

                case GamePlayState.Phone:
                    
                    break;

                case GamePlayState.Screen:

                    break;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background, new Vector2(0, 0), Color.White);

            switch (gameplayState)
            {
                case GamePlayState.Idle:

                    break;

                case GamePlayState.Book:
                    book.Draw(spriteBatch);
                    break;

                case GamePlayState.Phone:
                    phone.Draw(spriteBatch);
                    break;

                case GamePlayState.Screen:

                    break;
            }
        }
    }
}
