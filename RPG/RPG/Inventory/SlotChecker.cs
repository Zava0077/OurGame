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
    class SlotChecker : Inventory
    {
        public static List<Slot> Slots = new List<Slot>();
        private MouseState _currentMouse;
        private MouseState _previousMouse;
        public event EventHandler Click;
        private bool _isHovering;
        public bool Clicked { get; private set; }
        Texture2D texture { get; set; }
        public static int row = 0;
        public static int collumn = 0;
        public static int constt = 32;
        public static int idSlotForCheck = 99;
        public static Vector2 OldPos = Vector2.Zero;
        public static Vector2 Pos { get; set; }
        public SlotChecker(int idSlot, Vector2 vector)
        {
            idSlotForCheck = idSlot;
            self = this;
            Pos = vector;
        }

        public static Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Pos.X, (int)Pos.Y, 18, 18);
            }
        }

        Color color = Color.White;
        static int id = 8;
        public static int Displacement;
        public static SlotChecker self;

        public void Update()
        {
            _previousMouse = _currentMouse;
            _currentMouse = Mouse.GetState();

            var mouseRectangle = new Rectangle(_currentMouse.X, _currentMouse.Y, 1,1);
            if (_isHovering)
            {
                color = Color.Gray;
                Displacement = 0;
            }
            _isHovering = false;
            if (mouseRectangle.Intersects(Rectangle))
            {
                _isHovering = true;
                color = Color.Gray;


                if (_currentMouse.LeftButton == ButtonState.Released && _previousMouse.LeftButton == ButtonState.Pressed)
                {
                    
                }
            }
        }
    }
}
