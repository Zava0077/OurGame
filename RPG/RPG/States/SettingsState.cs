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
    public class SettingsState : State
    {
        private List<Component> _components;

        Menu mn = new Menu();

        public SettingsState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content, int width, int height, int offset, int bittonWidth,int texwidth, int texheight) : base(game, graphicsDevice, content)
        {
            var catsprite = _content.Load<Texture2D>("робокот");
            var backButton = _content.Load<Texture2D>("back");

            var sprite = new SpriteLoad(catsprite)
            {
                Position = new Vector2((_game.Window.ClientBounds.Width / 2) - 277/2, (_game.Window.ClientBounds.Height / 2) -420/2),
            };
            var button = new Button(backButton)
            {
                Position = new Vector2((_game.Window.ClientBounds.Width / 2) - 130, (_game.Window.ClientBounds.Height / 3) + ((_game.Window.ClientBounds.Height / 3) * 2) - 125),
            };

            button.Click += BackButtonClick;

            _components = new List<Component>()
            {
                sprite,
                button,
            };
        }

        public void BackButtonClick(object sender, EventArgs e)
        {
            _game.ChangeState(new MenuState(_game, _graphicsDevice, _content, _game.Window.ClientBounds.Width, _game.Window.ClientBounds.Height, 125, 130));
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            foreach (var component in _components)
                component.Draw(gameTime, spriteBatch);

            spriteBatch.End();
        }

        public override void PostUpdate(GameTime gameTime)
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var component in _components)
                component.Update(gameTime);
        }
    }
}
