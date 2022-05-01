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
        public Color PenColour { get; set; }
        public Vector2 Position { get; set; }

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, 277, 420);
            }
        }

        public SpriteLoad(Texture2D texture)
        {
            _texture = texture;
            
            PenColour = Color.Black;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            var colour = Color.White;

            spriteBatch.Draw(_texture, Rectangle, colour);
        }

        public override void Update(GameTime gameTime)
        {

        }
        #endregion
    }
}
