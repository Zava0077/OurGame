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
    class Rat : Room
    {
<<<<<<< HEAD
        int i = 0;
=======
>>>>>>> 1b8b1a74e5d6f648d37441975f36ea9cc3b46176
        public static List<Rat> Rats = new List<Rat>();
        private MouseState _currentMouse;
        private MouseState _previousMouse;
        public event EventHandler Click;
        private bool _isHovering;
        public bool Clicked { get; private set; }
<<<<<<< HEAD
        public static Texture2D texture { get; set; }
        int idRoom;
        Vector2 Pos;
        public Rat(Vector2 Pos,int idRoom)
        {
            this.idRoom = idRoom;
            this.Pos = Pos;
=======
        Texture2D texture { get; set; }
        int idRoom;
        Vector2 Pos;
        public Rat(Vector2 Pos,int idRoom,Texture2D texture)
        {
            this.idRoom = idRoom;
            this.Pos = Pos;
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

        Random rnd = new Random();
        bool ButtonPressede = false;
        Color color = Color.White;
>>>>>>> 1b8b1a74e5d6f648d37441975f36ea9cc3b46176
        public void Update()
        {
            _previousMouse = _currentMouse;
            _currentMouse = Mouse.GetState();

<<<<<<< HEAD
            Random rnd = new Random();



            var mouseRectangle = new Rectangle(_currentMouse.X, _currentMouse.Y, 1, 1);

            _isHovering = false;

=======
            var mouseRectangle = new Rectangle(_currentMouse.X, _currentMouse.Y, 1, 1);

            _isHovering = false;
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
=======
                    this.ButtonPressede = true;
>>>>>>> 1b8b1a74e5d6f648d37441975f36ea9cc3b46176
                    Game1.self.PlayerHP -= rnd.Next(3, 7);
                    Game1.self.Exp += rnd.Next(15, 25);
                }
            }
        }

        public void Draw()
        {
            spriteBatch.Begin();
<<<<<<< HEAD
            Room.spriteBatch.Draw(texture, Pos, Color.White);
=======
            Room.spriteBatch.Draw(texture, Pos,new Rectangle(130,0,64,64), color);
>>>>>>> 1b8b1a74e5d6f648d37441975f36ea9cc3b46176
            spriteBatch.End();
        }
    }
}
