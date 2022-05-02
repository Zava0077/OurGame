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
    class Skeleton : Room
    {
        public static List<Skeleton> skeletons = new List<Skeleton>();
        private MouseState _currentMouse;
        private MouseState _previousMouse;
        public event EventHandler Click;
        private bool _isHovering;
        public bool Clicked { get; private set; }
        public static Texture2D texture { get; set; }
        int idRoom;
        Vector2 Pos;
        public Skeleton(Vector2 Pos, int idRoom)
        {
            this.idRoom = idRoom;
            this.Pos = Pos;
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
}