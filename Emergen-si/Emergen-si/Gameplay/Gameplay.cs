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
        ContentManager content;

        GamePlayState gameplayState;
        Phone phone;
        Book book;
        Computer computer;
        Screen screen;
        NoteBoard noteBoard;
        Hand hand;
        List<Interactable> stuff;

        BitmapFont font;
        BitmapFont smallFont;

        Texture2D background;
        Texture2D bord;

        Texture2D happinessIcon;
        Texture2D moneyIcon;

        Resources resource;

        List<Call> activeCases;

        Texture2D gameOverTex;
        Texture2D gameWinTex;
        bool gameOver = false;
        bool gameWin = false;
        float alphaGameOver = 0;

       public GamePlay (ContentManager content)
        {
            this.content = content;
            Initialize(content);
        }

        public void Initialize(ContentManager content)
        {
            gameplayState = GamePlayState.Idle;
            book = new Book(content);

            background = content.Load<Texture2D>("Environment\\bakgrund_color");
            bord = content.Load<Texture2D>("Environment\\bord");
            font = content.Load<BitmapFont>("Font\\OneFont");
            smallFont = content.Load<BitmapFont>("Font\\FreePixel");

            happinessIcon = content.Load<Texture2D>("happinessIcon");
            moneyIcon = content.Load<Texture2D>("moneyIcon");
            gameOverTex = content.Load<Texture2D>("GameOver");
            gameWinTex = content.Load<Texture2D>("GameOver");

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
            if (!gameOver && !gameWin)
            {
                for (int n = 0; n < activeCases.Count; n++)
                {
                    if (activeCases[n].ActiveCaseUpdate(gameTime, resource))
                    {
                        activeCases.RemoveAt(n);
                    }
                }
                screen.CheckWinCondition(activeCases, resource);

                screen.UpdateCopCar(gameTime);

                phone.IdleUpdate(gameTime, resource);

                switch (gameplayState)
                {
                    case GamePlayState.Idle:
                        GamePlayState temPState = hand.Update(gameTime);
                        if (temPState != GamePlayState.Idle)
                            gameplayState = temPState;

                        break;

                    case GamePlayState.Book:
                        if (book.Update())
                            gameplayState = GamePlayState.Idle;
                        break;

                    case GamePlayState.Phone:
                        if (!phone.CallUpdate(gameTime, activeCases, stuff, noteBoard))
                            gameplayState = GamePlayState.Idle;
                        break;

                    case GamePlayState.Screen:
                        if (screen.Update(gameTime))
                            gameplayState = GamePlayState.Idle;
                        break;
                }

                if (resource.happiness < 0 || resource.money < 0)
                    gameOver = true;

                if (resource.happiness > 35 || resource.money > 1600)
                    gameWin = true;

            }
            else
            {
                if(alphaGameOver <1)
                {
                    alphaGameOver += 0.01f;
                }
                else
                {
                    if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                    {
                        gameOver = false;
                        gameWin = false;
                        Initialize(content);
                    }
                }
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
                activeCases[n].PostItDraw(spriteBatch, font);

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
                    screen.Draw(spriteBatch, font);
                    break;
            }
            for (int n = 0; n < activeCases.Count; n++)
                activeCases[n].ActiveCaseDraw(spriteBatch, smallFont, fill);


            spriteBatch.Draw(happinessIcon, new Vector2(40, 0), Color.White);
            spriteBatch.DrawString(font,resource.happiness.ToString(), new Vector2(110, 0),Color.White);

            spriteBatch.Draw(moneyIcon, new Vector2(400, 0), Color.White);
            spriteBatch.DrawString(font, resource.money.ToString(), new Vector2(450, 0), Color.White);

            if (gameOver)
                spriteBatch.Draw(gameOverTex, new Vector2(0, 0), new Color(Color.White,alphaGameOver));
            if(gameWin)
                spriteBatch.Draw(gameWinTex, new Vector2(0, 0), new Color(Color.White, alphaGameOver));
        }
    }
}
