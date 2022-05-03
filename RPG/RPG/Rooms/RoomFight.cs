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
    class RoomFight : Room
    {
        Vector2 Pos;

        public static List<Room> typeRooms = new List<Room>();
        public static Texture2D texture { get; set; }
        private MouseState _currentMouse;
        private MouseState _previousMouse;
        public event EventHandler Click;
        private bool _isHovering;
        public bool Clicked { get; private set; }

        Menu mn = new Menu();

        public RoomFight(Vector2 pos)
        {
            this.Pos = pos;
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
                    Click?.Invoke(this, new EventArgs());
                    Game1.self.PlayerHP -= 10;
                }
            }
        }

        public void Draw()
        {
            Color colour = Color.White;
            spriteBatch.Begin();
            Room.spriteBatch.Draw(texture, Pos, colour);
            spriteBatch.End();
        }

        public void RoomFight_click(object sender, System.EventArgs e)
        {
            Random random = new Random();
            Game1.self._backgroundColour = new Color(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
        }
    }
}
