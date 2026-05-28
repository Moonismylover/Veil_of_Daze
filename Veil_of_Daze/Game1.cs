using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

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
            chamberOfLegends,
            veilOfDaze,
            endGame
        }

        Screen screen;

        Rectangle window;
        
        // Backgrounds
        Texture2D mainBg;
        Texture2D menuBg;

        // Text & Titles
        Texture2D mainText;
        Rectangle mainTextRect;

        Texture2D settingsTitle;
        Rectangle settingsTitleRect;

        Texture2D characterTitle;
        Rectangle characterTitleRect;

        // Visual elements
        Texture2D butterfly;
        Rectangle butterflyRect;

        // Buttons 
        Texture2D playButton;
        Rectangle playButtonRect;

        Texture2D settingsButton;
        Rectangle settingsButtonRect;

        Texture2D quitButton;
        Rectangle quitButtonRect;

        // Time 
        float seconds;

        // Mouse & Keyboard
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

            // Text & Titles
            mainTextRect = new Rectangle(30, 130, 500, 300);
            settingsTitleRect = new Rectangle(380, 20, 150, 70);
            characterTitleRect = new Rectangle(160, 20, 600, 80);

            // Visual elements
            butterflyRect = new Rectangle(60, 250, 150, 150);

            // Buttons
            playButtonRect = new Rectangle(370, 160, 120, 50);
            settingsButtonRect = new Rectangle(370, 210, 120, 50);
            quitButtonRect = new Rectangle(370, 260, 120, 50);
 
            seconds = 0;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // Backgrounds
            mainBg = Content.Load<Texture2D>("red_bg");
            //menuBg = Content.Load<Texture2D>("menubg");

            // Text & Titles
            mainText = Content.Load<Texture2D>("main_text");
            settingsTitle = Content.Load<Texture2D>("settings_title");
            characterTitle = Content.Load<Texture2D>("chamberoflegends_title");

            //Visual elements
            butterfly = Content.Load<Texture2D>("butterfly");

            // Buttons
            playButton = Content.Load<Texture2D>("playbutton");
            settingsButton = Content.Load<Texture2D>("settingsbutton");
            quitButton = Content.Load<Texture2D>("quitbutton");
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
                if (mouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released && playButtonRect.Contains(mouseState.Position))
                {
                    screen = Screen.chamberOfLegends;
                }

                if (mouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released && settingsButtonRect.Contains(mouseState.Position))
                {
                    screen = Screen.menu;
                }

                if (mouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released && quitButtonRect.Contains(mouseState.Position))
                {
                    Exit();
                }
            }

            else if (screen == Screen.menu)
            {

            }

            else if (screen == Screen.chamberOfLegends)
            {

            }

            else if (screen == Screen.veilOfDaze)
            {

            }

            else if (screen == Screen.endGame)
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
                _spriteBatch.Draw(playButton, playButtonRect, Color.White);
                _spriteBatch.Draw(settingsButton, settingsButtonRect, Color.White);
                _spriteBatch.Draw(quitButton, quitButtonRect, Color.White);
            }

            else if (screen == Screen.menu)
            {
                //_spriteBatch.Draw(menuBg, window, Color.White);
                _spriteBatch.Draw(settingsTitle, settingsTitleRect, Color.White);
               
            }

            else if (screen == Screen.chamberOfLegends)
            {
                _spriteBatch.Draw(characterTitle, characterTitleRect, Color.White);
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
