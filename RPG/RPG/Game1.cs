using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System.Collections.Generic;

namespace RPG
{

    enum Stat
    {
        MainScreen,
        Game,
        Settings,
        Exit,
        Final
    }

    public class Game1 : Game
    {
        Menu mn = new Menu();
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        int bittonWidth = 130;
        int bittonHeight = 100;
        //private readonly Rectangle screenBounds;
        //private readonly Matrix screenXform;
      //  Vector2 position = Vector2.Zero;
      //  float speed = 5f;
        MouseState lastMouseState;
        int offset = 125;
        int depth = 65;
        Stat status = Stat.MainScreen;

        private State _currentState;

        private State _nextState;

        public void ChangeState(State state)
        {
            _nextState = state;
        }

        private List<Component> _gameComponents; //ура

        public Game1()
        {

            Button btn = new Button(mn.exit);
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            //  var screenScale = graphics.PreferredBackBufferHeight / 1080.0f;
            // screenXform = Matrix.CreateScale(screenScale, screenScale, 1.0f);
            self = this; //селфяшка приравнивается к зису
            IsMouseVisible = true;

            int v3Width = 277; //ширина четвертого спрайта
            int v3Height = 420; //высота четвертого спрайта

            mn.v = new Vector2((Window.ClientBounds.Width / 2) - bittonWidth, (Window.ClientBounds.Height / 3) - offset); // задаем местоположения наших спрайтов
            mn.v1 = new Vector2((Window.ClientBounds.Width / 2) - bittonWidth, (Window.ClientBounds.Height / 3) + (Window.ClientBounds.Height / 3) - offset);
            mn.v2 = new Vector2((Window.ClientBounds.Width / 2) - bittonWidth, (Window.ClientBounds.Height / 3) + ((Window.ClientBounds.Height / 3) * 2) - offset);
            mn.v3 = new Vector2((Window.ClientBounds.Width / 2) - v3Width/2, (Window.ClientBounds.Height / 2) - v3Height/ 2);
            mn.backv = new Vector2((Window.ClientBounds.Width / 2) - bittonWidth, (Window.ClientBounds.Height / 3) + ((Window.ClientBounds.Height / 3) * 2) - offset); //кнопка назад

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

            _currentState = new MenuState(this, graphics.GraphicsDevice, Content,Window.ClientBounds.Width, Window.ClientBounds.Height, offset, bittonWidth);

            var playButton = new Button(mn.play)
            {
                Position = new Vector2((Window.ClientBounds.Width / 2) - bittonWidth, (Window.ClientBounds.Height / 3) - offset),
                Text = "Play",
            };

            var quitButton = new Button(mn.exit)
            {
                Position = new Vector2((Window.ClientBounds.Width / 2) - bittonWidth, (Window.ClientBounds.Height / 3) + ((Window.ClientBounds.Height / 3) * 2) - offset),
                Text = "Quit",
            };
            var settingsButton = new Button(mn.settings)
            {
                Position = new Vector2((Window.ClientBounds.Width / 2) - bittonWidth, (Window.ClientBounds.Height / 3) + (Window.ClientBounds.Height / 3) - offset),
                Text = "Settings",
            };

            quitButton.Click += QuitButton_Click;

            settingsButton.Click += SettingsButton_click;

            _gameComponents = new List<Component>()
            {
                playButton,
                quitButton,
                settingsButton,
            };

            spriteBatch = new SpriteBatch(GraphicsDevice);
            mn.exit = Content.Load<Texture2D>("button");
            mn.settings = Content.Load<Texture2D>("settings");
            mn.play = Content.Load<Texture2D>("play");
            mn.test = Content.Load<Texture2D>("робокот");
            mn.back = Content.Load<Texture2D>("back");
            mn.font = Content.Load<SpriteFont>("Font");
        }



        private void QuitButton_Click(object sender, System.EventArgs e)
        {
            Exit();
        }

        private void SettingsButton_click(object sender, System.EventArgs e)
        {
            
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (_nextState != null)
            {
                _currentState = _nextState;

                _nextState = null;
            }

            _currentState.Update(gameTime);

            _currentState.PostUpdate(gameTime);

            foreach (var component in _gameComponents)
                component.Update(gameTime);

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            Vector3 cursor = new Vector3(Mouse.GetState().X, Mouse.GetState().Y, 0);

            int w = Window.ClientBounds.Width;
            int h = Window.ClientBounds.Height;

            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                if (cursor.X > (w / 2) - 130 & cursor.X < (w / 2) + offset)
                {
                    if (cursor.Y > (h / 3) - offset & cursor.Y < ((h / 3) + (h / 3) - (offset + depth)))// Играть
                    {
                        ;
                    }
                    if (cursor.Y > (h / 3) * 2 - offset & cursor.Y < ((h / 3) + (h / 3) * 2 - (offset + depth))) // Настройки(Мб сложность)
                    {
                        mn.SettingsMenu(mn.v3, spriteBatch, mn.test, mn.newMenuColor, mn.isMenuSettings, false);
                    }
                    if (cursor.Y > (h) - offset & cursor.Y < ((h / 3) + (h) - (offset + depth)))
                    {
                        if (mn.CurrentStatus == mn.Stats[0] && mn.clickFromMenu == true)
                        {
                            Exit();
                        }
                        if (cursor.Y > (h) - offset & cursor.Y < ((h / 3) + (h) - (offset + depth)))
                        {
                            mn.BackFromSettings(mn.v3, spriteBatch, mn.exit, mn.settings, mn.play, mn.newMenuColor);
                        }
                    }
                }
            }
            
        

            switch (status)
            {
                case Stat.MainScreen:
                    {

                        mn.ButtonFunction(cursor, w, h, mn.v, mn.v1, mn.v2, mn.v3, spriteBatch, mn.exit, mn.settings, mn.play, mn.test, mn.color, mn.newMenuColor);
                        break;
                    }
                case Stat.Game:
                    {
                        break;
                    }
                case Stat.Settings:
                    {
                        mn.isMousePressed = true;
                        mn.Sprite(mn.v, mn.v1, mn.v2, mn.v3, spriteBatch, mn.exit, mn.settings, mn.play, mn.test, Color.Transparent, mn.newMenuColor, mn.isMousePressed); //стираем меню
                        mn.isMenuSettings = true;
                        mn.SettingsMenu(mn.v3, spriteBatch, mn.test, mn.newMenuColor, mn.isMenuSettings, false); //рисуем кота и кнопку
                        mn.clickFromMenu = false;
                        break;
                    }
                case Stat.Exit:
                    {
                        Exit();
                        break;
                    }
                case Stat.Final:
                    {

                        break;
                    }
            }


            

          //  mn.ButtonFunction(cursor, w, h, mn.v, mn.v1, mn.v2, mn.v3, spriteBatch, mn.exit, mn.settings, mn.play, mn.test, mn.color, mn.newMenuColor);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            /*         GraphicsDevice.Clear(Color.CornflowerBlue);
                     // spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, screenXform);
                     // mn.Sprite(mn.v, mn.v1, mn.v2,mn.v3, spriteBatch, mn.exit, mn.settings, mn.play,mn.test, mn.color, mn.newMenuColor, mn.isMousePressed); // отрисовка спрайта
                     //  mn.SettingsMenu(mn.v3, spriteBatch, mn.test, mn.newMenuColor, mn.isMenuSettings, false);
                     spriteBatch.Begin();

                     foreach (var component in _gameComponents)
                         component.Draw(gameTime, spriteBatch);

                     spriteBatch.End();

                     base.Draw(gameTime);*/

            GraphicsDevice.Clear(Color.CornflowerBlue);

            _currentState.Draw(gameTime, spriteBatch);

            base.Draw(gameTime);
        }
    }
}