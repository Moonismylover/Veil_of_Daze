using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Veil_of_Daze
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        
        enum Screen
        {
            main,
            menu,
            veilOfDaze,
            endGame
        }

        Screen screen;

        Rectangle window;

        Texture2D mainBg;

        Texture2D mainText;
        Rectangle mainTextRect;

        Texture2D butterfly;
        Rectangle butterflyRect;

        Texture2D flower;
        Rectangle flowerRect;

        float seconds;

        MouseState mouseState;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            screen = Screen.main;

            window = new Rectangle(0, 0, 930, 630);
            _graphics.PreferredBackBufferWidth = 930;
            _graphics.PreferredBackBufferHeight = 630;
            _graphics.ApplyChanges();

            mainTextRect = new Rectangle(30, 130, 500, 300);
            flowerRect = new Rectangle(370, 190, 100, 100);
            butterflyRect = new Rectangle(60, 250, 150, 150);

            seconds = 0;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            mainBg = Content.Load<Texture2D>("red_bg");
            mainText = Content.Load<Texture2D>("main_text");
            butterfly = Content.Load<Texture2D>("butterfly");
            flower = Content.Load<Texture2D>("flower");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            mouseState = Mouse.GetState();

            this.Window.Title = mouseState.Position.ToString();

            seconds += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (screen == Screen.main)
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    screen = Screen.menu;
                }
            }


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            if (screen == Screen.main)
            {
                _spriteBatch.Draw(mainBg, window, Color.White);
                _spriteBatch.Draw(mainText, mainTextRect, Color.White);
                _spriteBatch.Draw(butterfly, butterflyRect, Color.White);
                _spriteBatch.Draw(flower, flowerRect, Color.White);
            }
            else if (screen == Screen.menu)
            {

            }
            else if (screen == Screen.veilOfDaze)
            {

            }
            else if (screen == Screen.endGame)
            {

            }

                _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
