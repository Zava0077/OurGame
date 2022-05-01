﻿using System;

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

            mn.bittonWidth = bittonWidth;
            mn.Width = Window.ClientBounds.Width;
            mn.Height = Window.ClientBounds.Height;
            mn.texHeight = v3Height;
            mn.texWidth = v3Width;
            mn.offset = offset;

            mn.v = new Vector2((Window.ClientBounds.Width / 2) - bittonWidth, (Window.ClientBounds.Height / 3) - offset); // задаем местоположения наших спрайтов
            mn.v1 = new Vector2((Window.ClientBounds.Width / 2) - bittonWidth, (Window.ClientBounds.Height / 3) + (Window.ClientBounds.Height / 3) - offset);
            mn.v2 = new Vector2((Window.ClientBounds.Width / 2) - bittonWidth, (Window.ClientBounds.Height / 3) + ((Window.ClientBounds.Height / 3) * 2) - offset);
            mn.v3 = new Vector2((Window.ClientBounds.Width / 2) - v3Width/2, (Window.ClientBounds.Height / 2) - v3Height/ 2);
            mn.backv = new Vector2((Window.ClientBounds.Width / 2) - bittonWidth, (Window.ClientBounds.Height / 3) + ((Window.ClientBounds.Height / 3) * 2) - offset); //кнопка назад

            mn.color = Color.WhiteSmoke;
        }
        public static Game1 self;

        protected override void Initialize()
        {
            base.Initialize();
            graphics.PreferredBackBufferWidth = 1000;
            graphics.PreferredBackBufferHeight = 850;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {

            _currentState = new MenuState(this, graphics.GraphicsDevice, Content,Window.ClientBounds.Width, Window.ClientBounds.Height, offset, bittonWidth); //Текущее состояние меню

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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (_nextState != null)
            {
                _currentState = _nextState;

                _nextState = null;
            }

            _currentState.Update(gameTime);

            _currentState.PostUpdate(gameTime);

            switch (status)
            {
                case Stat.MainScreen:
                    {

                        break;
                    }
                case Stat.Game:
                    {

                        break;
                    }
                case Stat.Settings:
                    {

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
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.CornflowerBlue);

            _currentState.Draw(gameTime, spriteBatch);

            base.Draw(gameTime);
        }
    }
}