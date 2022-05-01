using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace RPG
{
    public class MenuState : State
    {
        private List<Component> _components;

        Menu mn = new Menu();

        public MenuState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content, int width ,int height, int offset, int bittonWidth) : base(game, graphicsDevice, content)
        {

            var PlaybuttonTexture = _content.Load<Texture2D>("play");
            var SettingsbuttonTexture = _content.Load<Texture2D>("settings");
            var ExitbuttonTexture = _content.Load<Texture2D>("button");

            var playButton = new Button(PlaybuttonTexture)
            {
                Position = new Vector2((width / 2) - bittonWidth, (height / 3) - offset),
            };

            playButton.Click += NewGameButton_Click;

            var settingsButton = new Button(SettingsbuttonTexture)
            {
                Position = new Vector2((width / 2) - bittonWidth, (height / 3) + (height / 3) - offset),
            };

            settingsButton.Click += SettingsButton_Click;

            var quitButton = new Button(ExitbuttonTexture)
            {
                Position = new Vector2((width / 2) - bittonWidth, (height / 3) + ((height / 3) * 2) - offset),
            };

            quitButton.Click += QuitGameButton_Click;

            _components = new List<Component>()
            {
                playButton,
                settingsButton,
                quitButton,
            };
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            foreach (var component in _components)
                component.Draw(gameTime, spriteBatch);

            spriteBatch.End();
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Settings menu!");
            _game.ChangeState(new SettingsState(_game, _graphicsDevice, _content, mn.Width, mn.Height, mn.offset, mn.bittonWidth, 200, 200));
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {

            _game.ChangeState(new GameState(_game, _graphicsDevice, _content));
        }

        public override void PostUpdate(GameTime gameTime)
        {
            // удаляет спрайты, если те не нужны
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var component in _components)
                component.Update(gameTime);
        }

        private void QuitGameButton_Click(object sender, EventArgs e)
        {
            _game.Exit();
        }
    }
}
