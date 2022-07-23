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
        public static int count = 0;

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
        Color color = Color.Transparent;
        static int d = 0;
        static int c = 0;
        int idSlotForCheck = 0;
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
                int rndItem = rnd.Next(0, 100);
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
                        Game1.self.Exp += rnd.Next(20, 50);
                        this.ButtonPressede = true;
                        Game1.self.isFirstsquare = false;
                        if(!Slot.self.isInventoryFull)
                            if (rndItem < 40)
                                Slot.self.ClassOfItem(3, 2, 0);
                            else if (rndItem < 70)
                            {
                                Slot.self.ClassOfItem(3, 0, 0);
                            }
                            else if (rndItem > 80)
                                Slot.self.ClassOfItem(3, 1, 0);
                            else
                                Slot.self.ClassOfItem(2, 0, 0);
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
                        Slot.row = 0;
                        Slot.collumn = 0;

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
                            count++;
                            Game1.self.Exp += rnd.Next(20, 50);
                            if (rndItem > 20)
                                Player.player.PlayerMoney += 5;
                            else
                                Player.player.PlayerMoney += 15; //тут крч монетки падают с сундука ок?
                            if (!Slot.self.isInventoryFull)
                            {
                                if (rndItem < 5)
                                    Slot.self.ClassOfItem(3, 2, 0);
                                else if (rndItem < 10)
                                {
                                    Slot.self.ClassOfItem(3, 0, 0);
                                }
                                else if (rndItem < 15)
                                    Slot.self.ClassOfItem(3, 1, 0);
                                else if (rndItem < 20)
                                    Slot.self.ClassOfItem(2, 0, 0);
                                else if (rndItem < 25)
                                    Slot.self.ClassOfItem(2, 1, 0);
                                else if (rndItem < 35)
                                    Slot.self.ClassOfItem(1, 0, 0);
                                else if (rndItem < 45)
                                    Slot.self.ClassOfItem(2, 2, 0);
                                else if (rndItem < 60)
                                    Slot.self.ClassOfItem(2, 3, 0);
                                else if (rndItem < 65)
                                    Slot.self.ClassOfItem(4, 0, 0);
                                else if (rndItem < 75)
                                    Slot.self.ClassOfItem(4, 1, 0);
                                else if (rndItem < 85)
                                    Slot.self.ClassOfItem(4, 2, 0);
                                else 
                                    Slot.self.ClassOfItem(4, 3, 0);
                            }
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
                Room.spriteBatch.Draw(texture, Pos, new Rectangle(325, 0, 64, 64), Color.Gray);
                Player.Draw(spriteBatch, Pos, texture, Color.White);
            }
            else
            {
                Player.Draw(spriteBatch, Pos, texture, Color.Transparent);
                Room.spriteBatch.Draw(texture, Pos, new Rectangle(325, 0, 64, 64), color);
            }
            spriteBatch.End();
        }
        
    }
}