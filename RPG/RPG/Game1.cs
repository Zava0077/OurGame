using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RPG
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D texture;
        private readonly Rectangle screenBounds;
        private readonly Matrix screenXform;



        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            var screenScale = graphics.PreferredBackBufferHeight / 1080.0f;
            screenXform = Matrix.CreateScale(screenScale, screenScale, 1.0f);
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            texture = Content.Load<Texture2D>("button");
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
           // spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, screenXform);


            // отрисовка спрайта
            Vector2 Vector = new Vector2();
            Vector.X = 100;
            Vector.Y = 100;
            Sprite(Vector);
            base.Draw(gameTime);
        }
        protected void Sprite(Vector2 Vector)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(texture, Vector, Color.WhiteSmoke);
            spriteBatch.End();
        }
    }
}