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
    class RoomTreasure : Room
    {
        Vector2 Pos;
        int idRoom;

<<<<<<< HEAD
        public static Texture2D texture { get; set; }
=======
        Texture2D texture { get; set; }
>>>>>>> 1b8b1a74e5d6f648d37441975f36ea9cc3b46176
        private MouseState _currentMouse;
        private MouseState _previousMouse;
        public event EventHandler Click;
        private bool _isHovering;
        public bool Clicked { get; private set; }

<<<<<<< HEAD
        public RoomTreasure(Vector2 pos, int idRoom)
        {
            this.idRoom = idRoom;
            this.Pos = pos;
=======
        public RoomTreasure(Vector2 pos, int idRoom, Texture2D texture)
        {
            this.idRoom = idRoom;
            this.Pos = pos;
            this.texture = texture;
>>>>>>> 1b8b1a74e5d6f648d37441975f36ea9cc3b46176
        }

        public Rectangle Rectangle
        {
            get
            {
<<<<<<< HEAD
                return new Rectangle((int)Pos.X, (int)Pos.Y, texture.Width, texture.Height);
            }
        }

=======
                return new Rectangle((int)Pos.X, (int)Pos.Y, 64, 64);
            }
        }

        bool ButtonPressede = false;
        Color color = Color.White;
>>>>>>> 1b8b1a74e5d6f648d37441975f36ea9cc3b46176
        public void Update()
        {
            _previousMouse = _currentMouse;
            _currentMouse = Mouse.GetState();

            var mouseRectangle = new Rectangle(_currentMouse.X, _currentMouse.Y, 1, 1);

            _isHovering = false;
<<<<<<< HEAD

=======
            if (this.ButtonPressede)
            {
                color = Color.Gray;
            }
>>>>>>> 1b8b1a74e5d6f648d37441975f36ea9cc3b46176
            if (mouseRectangle.Intersects(Rectangle))
            {
                _isHovering = true;

                if (_currentMouse.LeftButton == ButtonState.Released && _previousMouse.LeftButton == ButtonState.Pressed)
                {
<<<<<<< HEAD

                }
            }
        }
        public void Draw()
        {
            spriteBatch.Begin();
            Room.spriteBatch.Draw(texture,Pos,Color.White);
=======
                    this.ButtonPressede = true;
                }
            }
        }

        public void Draw()
        {
            spriteBatch.Begin();
            Room.spriteBatch.Draw(texture, Pos, new Rectangle(65, 0, 64, 64), color);
>>>>>>> 1b8b1a74e5d6f648d37441975f36ea9cc3b46176
            spriteBatch.End();
        }
    }
}