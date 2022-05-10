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
    class Skeleton : Room
    {
        public static List<Skeleton> skeletons = new List<Skeleton>();
        private MouseState _currentMouse;
        private MouseState _previousMouse;
        public event EventHandler Click;
        private bool _isHovering;
        public double Hp = 30;
        public double Attack = 5;
        public double AttackSpeed = 2000;

        public bool Clicked { get; private set; }
        Texture2D texture { get; set; }
        int idRoom;
        Vector2 Pos;
        public Skeleton(Vector2 Pos, int idRoom, Texture2D texture)
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

        Random rnd = new Random();
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
                        Player.player.PlayerHP -= rnd.Next(8, 15);
                        Player.player.Exp += rnd.Next(40, 100);
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
                            Fight fight = new Fight(this.AttackSpeed, this.Hp, this.Attack, rnd.Next(50, 100));
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
                Room.spriteBatch.Draw(texture, Pos, new Rectangle(195, 0, 64, 64), Color.Gray);
                Player.Draw(spriteBatch, Pos, texture, Color.White);
            }
            else
            {
                Player.Draw(spriteBatch, Pos, texture, Color.Transparent);
                Room.spriteBatch.Draw(texture, Pos, new Rectangle(195, 0, 64, 64), color);
            }
            spriteBatch.End();
        }
    }
}
