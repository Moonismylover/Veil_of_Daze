using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Veil_of_Daze
{
    public class Game1 : Game
    {
        Rectangle window;

        Texture2D mainMenuBackground;
        Rectangle mainMenuBackgroundRect;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        
        enum Screen
        {
            mainMenu,
            veilOfDaze,
            endGame
        }

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            window = new Rectangle(0, 0, 930, 630);
            _graphics.PreferredBackBufferWidth = 930;
            _graphics.PreferredBackBufferHeight = 630;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            mainMenuBackground = Content.Load<Texture2D>("red_bg");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //if (Screen == Screen.mainMenu)
            //{

            //}

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();
            _spriteBatch.Draw(mainMenuBackground, window, Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
