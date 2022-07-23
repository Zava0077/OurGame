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
    class Gate : Room
    {
        public static Gate gate;
        Vector2 Pos;
        Texture2D texture { get; set; }
        int idRoom;
        private MouseState _currentMouse;
        private MouseState _previousMouse;
        public event EventHandler Click;
        private bool _isHovering;
        bool PlayerHere;



        public Gate(Vector2 pos, int idRoom, Texture2D texture)
        {
            this.Pos = pos;
            this.idRoom = idRoom;
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
        Color color = Color.Transparent;
        static int d = 0;

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
                        PlayerHere = true;
                        Game1.self.squareId = this.idRoom;
                        Game1.self.rightsquareId = this.idRoom + 1;
                        Game1.self.leftsquareId = this.idRoom - 1;
                        Game1.self.upsquareId = this.idRoom - Room.CoutRoomX;
                        Game1.self.downsquareId = this.idRoom + Room.CoutRoomX;
                        Player.player.PlayerHP += rnd.Next(10, 25);
                        this.ButtonPressede = true;
                        Game1.self.isFirstsquare = false;
                        if (this.idRoom % CoutRoomX == 0)
                        {
                            d = this.idRoom / CoutRoomX;
                        }
                        if (this.idRoom == Room.CoutRoomX * d)
                        {
                            Game1.self.leftsquareId = 0;
                        }
                        if (this.idRoom == (CoutRoomX - 1) + (CoutRoomX * (int)((double)this.idRoom / (CoutRoomX - 1)) - CoutRoomX))
                        {
                            Game1.self.rightsquareId = 0;
                        }

                    }
                    else if (this.idRoom == Game1.self.rightsquareId || this.idRoom == Game1.self.leftsquareId || this.idRoom == Game1.self.upsquareId || this.idRoom == Game1.self.downsquareId)
                    {
                        PlayerHere = true;
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
                            Game1.self.leftsquareId = 0;
                        }
                        if (this.idRoom == (CoutRoomX - 1) + (CoutRoomX * (int)((double)this.idRoom / (CoutRoomX - 1)) - CoutRoomX))
                        {
                            Game1.self.rightsquareId = 0;
                        }
                        if (this.ButtonPressede == false)
                        {
                            Floor.newFloor(Game1.self.squareId);
                        }
                        this.ButtonPressede = true;
                    }
                }
            }
        }

        public void Draw()
        {
            spriteBatch.Begin();
            Room.spriteBatch.Draw(texture, Pos, new Rectangle(0, 195, 64, 64), color);
            if (Game1.self.squareId == this.idRoom)
            {
                Player.Draw(spriteBatch, Pos, texture, Color.White);
            }
            else { Player.Draw(spriteBatch, Pos, texture, Color.Transparent); }
            spriteBatch.End();
        }
    }
}
