﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RPG
{
    class ExpBarLoad : Component
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

        public int maxLenght = 20000;

        private SpriteFont _font;

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y,((maxLenght/Game1.self.MaxExp) *Game1.self.Exp) /200, _texture.Height);
            }
        }

        public string Text { get; set; }

        public ExpBarLoad(Texture2D texture, SpriteFont font)
        {
            _texture = texture;

            _font = font;

            PenColour = Color.Black;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            var colour = Color.White;

            spriteBatch.Draw(_texture,new Vector2 ((int)Position.X, (int)Position.Y),Rectangle, colour,0,Vector2.Zero,0.8f ,SpriteEffects.None,0);

            if (!string.IsNullOrEmpty(Text))
            {
                var x = (Rectangle.X + (Rectangle.Width / 2)) - (_font.MeasureString(Text).X / 2);
                var y = (Rectangle.Y + (Rectangle.Height / 2)) - (_font.MeasureString(Text).Y / 2);

                spriteBatch.DrawString(_font, Text, new Vector2(x, y), PenColour);
            }
        }

        public override void Update(GameTime gameTime)
        {
            _previousMouse = _currentMouse;
            _currentMouse = Mouse.GetState();

            var mouseRectangle = new Rectangle(_currentMouse.X, _currentMouse.Y, 1, 1);

            _isHovering = false;

            if (mouseRectangle.Intersects(Rectangle))
            {
                _isHovering = true;

                if (_currentMouse.LeftButton == ButtonState.Released && _previousMouse.LeftButton == ButtonState.Pressed)
                {
                    Click?.Invoke(this, new EventArgs());
                }
            }
        }
        #endregion
    }
}
