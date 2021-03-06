using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RPG
{
    class SpriteLoad : Component
    {
        #region Поля
        Menu mn = new Menu();
        private Texture2D _texture;
        #endregion
        #region Свойства
        public event EventHandler Click;
        private MouseState _previousMouse;
        private MouseState _currentMouse;
        private bool _isHovering;
        public Color PenColour { get; set; }
        public Vector2 Position { get; set; }

        private SpriteFont _font;

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height);
            }
        }

        public string Text { get; set; }

        public SpriteLoad(Texture2D texture, SpriteFont font)
        {
            _texture = texture;

            _font = font;

            PenColour = Color.Black;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            var colour = Color.White;

            if (!string.IsNullOrEmpty(Text))
            {
                var x = (Rectangle.X + (Rectangle.Width / 2)) - (_font.MeasureString(Text).X / 2);
                var y = (Rectangle.Y + (Rectangle.Height / 2)) - (_font.MeasureString(Text).Y / 2);

                spriteBatch.DrawString(_font, Text, new Vector2(x, y), PenColour);
            }

            spriteBatch.Draw(_texture, Rectangle, colour);

        }

        public override void Update(GameTime gameTime)
        {

        }
        #endregion
    }
}
