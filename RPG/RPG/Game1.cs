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
        Texture2D exit;
        Texture2D settings;
        Texture2D play;
        int b = 130;
        //private readonly Rectangle screenBounds;
        //private readonly Matrix screenXform;
      //  Vector2 position = Vector2.Zero;
      //  float speed = 5f;
        MouseState lastMouseState;
        int offset = 125;
        int depth = 65;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            //  var screenScale = graphics.PreferredBackBufferHeight / 1080.0f;
            // screenXform = Matrix.CreateScale(screenScale, screenScale, 1.0f);
            self = this; //селфяшка приравнивается к зису
            IsMouseVisible = true;
        }
        public static Game1 self; //переменная селфтип

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {       
            spriteBatch = new SpriteBatch(GraphicsDevice);
            exit = Content.Load<Texture2D>("button");
            settings = Content.Load<Texture2D>("settings");
            play = Content.Load<Texture2D>("play");
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
            mn.ButtonFunction(cursor, w, h);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            // spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, screenXform);


            // отрисовка спрайта
            Vector2 Vector10 = new Vector2((Window.ClientBounds.Width / 2) - 130, (Window.ClientBounds.Height / 3)- offset);
            Vector2 Vector11 = new Vector2((Window.ClientBounds.Width / 2) - 130, (Window.ClientBounds.Height / 3)+ (Window.ClientBounds.Height / 3) - offset);
            Vector2 Vector12 = new Vector2((Window.ClientBounds.Width / 2) - 130, (Window.ClientBounds.Height / 3)+ ((Window.ClientBounds.Height / 3)*2) - offset);
            Sprite(Vector10,Vector11,Vector12);
            base.Draw(gameTime);

        }
        protected void Sprite(Vector2 Vector, Vector2 Vector1, Vector2 Vector2)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(play, Vector, Color.WhiteSmoke);
            spriteBatch.Draw(settings, Vector1, Color.WhiteSmoke);
            spriteBatch.Draw(exit, Vector2, Color.WhiteSmoke);
            spriteBatch.End();
        }
    }
}