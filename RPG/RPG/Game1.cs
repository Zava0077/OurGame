using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RPG
{
    public class Game1 : Game
    {
        Menu mn = new Menu();
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        int bittonWidth = 130;
        //private readonly Rectangle screenBounds;
        //private readonly Matrix screenXform;
      //  Vector2 position = Vector2.Zero;
      //  float speed = 5f;
        MouseState lastMouseState;
        int offset = 125;
        //int depth = 65;
        

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            //  var screenScale = graphics.PreferredBackBufferHeight / 1080.0f;
            // screenXform = Matrix.CreateScale(screenScale, screenScale, 1.0f);
            self = this; //селфяшка приравнивается к зису
            IsMouseVisible = true;

            int v3Width = 277; //ширина четвертого спрайта
            int v3Height = 420; //высота четвертого спрайта

            mn.v = new Vector2((Window.ClientBounds.Width / 2) - bittonWidth, (Window.ClientBounds.Height / 3) - offset); // задаем местоположения 3-х кнопок
            mn.v1 = new Vector2((Window.ClientBounds.Width / 2) - bittonWidth, (Window.ClientBounds.Height / 3) + (Window.ClientBounds.Height / 3) - offset);
            mn.v2 = new Vector2((Window.ClientBounds.Width / 2) - bittonWidth, (Window.ClientBounds.Height / 3) + ((Window.ClientBounds.Height / 3) * 2) - offset);
            mn.v3 = new Vector2((Window.ClientBounds.Width / 2) - v3Width/2, (Window.ClientBounds.Height / 2) - v3Height/ 2);
            
            mn.color = Color.WhiteSmoke;
            mn.newMenuColor = Color.WhiteSmoke;

        }
        public static Game1 self; //переменная селфтип

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {       
            spriteBatch = new SpriteBatch(GraphicsDevice);
            mn.exit = Content.Load<Texture2D>("button");
            mn.settings = Content.Load<Texture2D>("settings");
            mn.play = Content.Load<Texture2D>("play");
            mn.test = Content.Load<Texture2D>("робокот");
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            Vector3 cursor = new Vector3(Mouse.GetState().X, Mouse.GetState().Y, 0);

            int w = Window.ClientBounds.Width;
            int h = Window.ClientBounds.Height;
            mn.ButtonFunction(cursor, w, h, mn.v, mn.v1, mn.v2, mn.v3, spriteBatch, mn.exit, mn.settings, mn.play, mn.test, mn.color, mn.newMenuColor);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            // spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, screenXform);
            mn.Sprite(mn.v, mn.v1, mn.v2,mn.v3, spriteBatch, mn.exit, mn.settings, mn.play,mn.test, mn.color, mn.newMenuColor); // отрисовка спрайта
            mn.SettingsMenu(mn.v3, spriteBatch, mn.test, mn.newMenuColor, mn.isMenuSettings);
            base.Draw(gameTime);
        }
    }
}