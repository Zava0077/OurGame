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
    class RoomHeal : Room
    {
        Vector2 Pos;
        int ButtonPressede;
        public static Texture2D texture { get; set; }
        private MouseState _currentMouse;
        private MouseState _previousMouse;
        public event EventHandler Click;
        private bool _isHovering;
        int idRoom;
        public bool Clicked { get; private set; }

        public RoomHeal(Vector2 pos, int idRoom)
        {
            this.Pos = pos;
            this.idRoom = idRoom;
        }
        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Pos.X, (int)Pos.Y, texture.Width, texture.Height);
            }
        }

        public void Update()
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

                }
            }
        }
        public void Draw()
        {
            spriteBatch.Begin();
            Room.spriteBatch.Draw(texture, Pos, Color.White);
            spriteBatch.End();
        }
    }
}
