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

        Texture2D play;
        Rectangle playRect;

        Texture2D menu;
        Rectangle menuRect;

        Texture2D exit;
        Rectangle exitRect;

        float seconds;

        MouseState mouseState;
        MouseState previousMouseState;

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
            butterflyRect = new Rectangle(60, 250, 150, 150);
            playRect = new Rectangle(370, 160, 120, 50);
            menuRect = new Rectangle(370, 210, 120, 50);
            exitRect = new Rectangle(370, 260, 120, 50);
 
            seconds = 0;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            mainBg = Content.Load<Texture2D>("red_bg");
            mainText = Content.Load<Texture2D>("main_text");
            butterfly = Content.Load<Texture2D>("butterfly");
            play = Content.Load<Texture2D>("play");
            menu = Content.Load<Texture2D>("menu");
            exit = Content.Load<Texture2D>("exit");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            previousMouseState = mouseState;
            mouseState = Mouse.GetState();

            this.Window.Title = mouseState.Position.ToString();

            seconds += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (screen == Screen.main)
            {
                if (mouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released && playRect.Contains(mouseState.Position))
                {
                    screen = Screen.veilOfDaze;
                }

                if (mouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released && menuRect.Contains(mouseState.Position))
                {
                    screen = Screen.menu;
                }

                if (mouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released && exitRect.Contains(mouseState.Position))
                {
                    Exit();
                }
            }
            
            if (screen == Screen.menu)
            {

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
                _spriteBatch.Draw(play, playRect, Color.White);
                _spriteBatch.Draw(menu, menuRect, Color.White);
                _spriteBatch.Draw(exit, exitRect, Color.White);
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
