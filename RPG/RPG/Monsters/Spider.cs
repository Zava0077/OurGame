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
    class Spider : Room
    {
        public static List<Spider> Spiders = new List<Spider>();
        private MouseState _currentMouse;
        private MouseState _previousMouse;
        public event EventHandler Click;
        private bool _isHovering;
        Random rnd = new Random();
        public double Hp = 20+(Floor.numberFloor*5);
        public double AttackMax = 6 + (int)(2 * (Floor.numberFloor / 3));
        public double AttackMin = 3 + (int)(1.5 * (Floor.numberFloor / 3));
        public double AttackSpeed = 1500;
        private string NameMonstra = "Spider";

        public bool Clicked { get; private set; }
        Texture2D texture { get; set; }
        int idRoom;
        Vector2 Pos;
        public Spider(Vector2 Pos, int idRoom,Texture2D texture)
        {
            this.idRoom = idRoom;
            this.Pos = Pos;
            this.texture = texture;
        }

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Pos.X, (int)Pos.Y, 64, 64);
            }
        }

        bool ButtonPressede = false;
        Color color = Color.Transparent;
        static int d = 0;
        static int c = 0;
        public void Update()
        {
            _previousMouse = _currentMouse;
            _currentMouse = Mouse.GetState();

            var mouseRectangle = new Rectangle(_currentMouse.X, _currentMouse.Y, 1, 1);

            if (Game1.self.upsquareId == this.idRoom || Game1.self.downsquareId == this.idRoom || Game1.self.leftsquareId == this.idRoom || Game1.self.rightsquareId == this.idRoom)
            {
                color = Color.White;
            }
            _isHovering = false;
            if (this.ButtonPressede || Game1.self.squareId == this.idRoom)
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
                        Player.player.PlayerHP -= rnd.Next(8, 10);
                        Player.player.Exp += rnd.Next(20, 60);
                        this.ButtonPressede = true;
                        Game1.self.isFirstsquare = false;
                        if (this.idRoom % CoutRoomX == 0)
                        {
                            d = this.idRoom / CoutRoomX;
                        }
                        if (this.idRoom == Room.CoutRoomX * d)
                        {
                            Game1.self.leftsquareId = -1;
                        }
                        if (this.idRoom == (CoutRoomX - 1) + (CoutRoomX * (int)((double)this.idRoom / 11.0) - CoutRoomX))
                        {
                            Game1.self.rightsquareId = -1;
                        }

                    }
                    else if (this.idRoom == Game1.self.rightsquareId || this.idRoom == Game1.self.leftsquareId || this.idRoom == Game1.self.upsquareId || this.idRoom == Game1.self.downsquareId)
                    {
                        Game1.self.squareId = this.idRoom;
                        Game1.self.rightsquareId = this.idRoom + 1;
                        Game1.self.leftsquareId = this.idRoom - 1;
                        Game1.self.upsquareId = this.idRoom - Room.CoutRoomX;
                        Game1.self.downsquareId = this.idRoom + Room.CoutRoomX;
                        if (this.idRoom % CoutRoomX == 0)
                        {
                            d = this.idRoom / CoutRoomX;
                        }
                        if (this.idRoom == Room.CoutRoomX * d)
                        {
                            Game1.self.leftsquareId = -1;
                        }
                        if (this.idRoom == (CoutRoomX - 1) + (CoutRoomX * (int)((double)this.idRoom / 11.0) - CoutRoomX))
                        {
                            Game1.self.rightsquareId = -1;
                        }
                        if (this.ButtonPressede == false)
                        {
                            Fight fight = new Fight(this.AttackSpeed, this.Hp, this.AttackMin, this.AttackMax, rnd.Next(25+(Floor.numberFloor*5), 50 + (Floor.numberFloor * 10)),this.NameMonstra);
                            Fight.isFight = true;
                        }
                        this.ButtonPressede = true;
                    }
                }
            }
        }

        public void Draw()
        {
            spriteBatch.Begin();
            if (Game1.self.squareId == this.idRoom)
            {
                Room.spriteBatch.Draw(texture, Pos, new Rectangle(0, 0, 64, 64), Color.Gray);
                Player.Draw(spriteBatch, Pos, texture, Color.White);
            }
            else
            {
                Player.Draw(spriteBatch, Pos, texture, Color.Transparent);
                Room.spriteBatch.Draw(texture, Pos, new Rectangle(0, 0, 64, 64), color);
            }
            spriteBatch.End();
        }
    }
}
