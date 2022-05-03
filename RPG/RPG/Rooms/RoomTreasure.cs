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

        Texture2D texture { get; set; }
        private MouseState _currentMouse;
        private MouseState _previousMouse;
        public event EventHandler Click;
        private bool _isHovering;
        public bool Clicked { get; private set; }

        public RoomTreasure(Vector2 pos, int idRoom, Texture2D texture)
        {
            this.idRoom = idRoom;
            this.Pos = pos;
            this.texture = texture;
        }

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Pos.X, (int)Pos.Y, 64, 64);
            }
        }


        Random rnd = new Random();
        bool ButtonPressede = false;
        Color color = Color.White;
        public void Update()
        {
            _previousMouse = _currentMouse;
            _currentMouse = Mouse.GetState();

            var mouseRectangle = new Rectangle(_currentMouse.X, _currentMouse.Y, 1, 1);

            _isHovering = false;
            if (this.ButtonPressede)
            {
                color = Color.Gray;
            }
            if (mouseRectangle.Intersects(Rectangle))
            {
                _isHovering = true;
                if (_currentMouse.LeftButton == ButtonState.Released && _previousMouse.LeftButton == ButtonState.Pressed)
                {
                    if (Game1.self.isFirstsquare == true)
                    {
                        Game1.self.squareId = this.idRoom;
                        Game1.self.rightsquareId = this.idRoom + 1;
                        Game1.self.leftsquareId = this.idRoom - 1;
                        Game1.self.upsquareId = this.idRoom - Room.CoutRoomX;
                        Game1.self.downsquareId = this.idRoom + Room.CoutRoomX;
                        Game1.self.PlayerHP -= rnd.Next(8, 15);
                        Game1.self.Exp += rnd.Next(40, 100);
                        this.ButtonPressede = true;
                        Game1.self.isFirstsquare = false;
                    }
                    else if (this.idRoom == Game1.self.rightsquareId || this.idRoom == Game1.self.leftsquareId || this.idRoom == Game1.self.upsquareId || this.idRoom == Game1.self.downsquareId)
                    {
                        Game1.self.squareId = this.idRoom;
                        Game1.self.rightsquareId = this.idRoom + 1;
                        Game1.self.leftsquareId = this.idRoom - 1;
                        Game1.self.upsquareId = this.idRoom - Room.CoutRoomX;
                        Game1.self.downsquareId = this.idRoom + Room.CoutRoomX;
                        if (this.ButtonPressede == false)
                        {
                            Game1.self.PlayerHP -= rnd.Next(8, 15);
                            Game1.self.Exp += rnd.Next(40, 100);
                        }
                        this.ButtonPressede = true;
                    }
                }

            }
        }

        public void Draw()
        {
            spriteBatch.Begin();
            Room.spriteBatch.Draw(texture, Pos, new Rectangle(325, 0, 64, 64), color);
            spriteBatch.End();
        }
    }
}