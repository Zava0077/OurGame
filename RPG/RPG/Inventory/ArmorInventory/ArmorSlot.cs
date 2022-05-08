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
    class ArmorSlot : SecondInventory
    {
        public static List<ArmorSlot> ArmorSlots = new List<ArmorSlot>();
        private MouseState _currentMouse;
        private MouseState _previousMouse;
        public event EventHandler Click;
        private bool _isHovering;
        public bool Clicked { get; private set; }
        Texture2D texture { get; set; }
        public int idSlot;
        public Vector2 Pos;
        public Rectangle Rectangle2;
        public Rectangle VarRectangle;
        public bool isEmpty;
        public bool varCheckerIsEmpty;
        public int currentClassOfItem;
        public int currentTypeOfItem;
        public static List<ArmorSlot> ChangeList = new List<ArmorSlot>();

        public ArmorSlot(Vector2 Pos, int idSlot, Texture2D texture, Rectangle Rectangle2, bool isEmpty, int currentClassOfItem, int currentTypeOfItem)
        {
            this.idSlot = idSlot;
            this.Pos = Pos;
            this.texture = texture;
            this.Rectangle2 = Rectangle2;
            this.isEmpty = isEmpty;
            this.currentClassOfItem = currentClassOfItem;
            this.currentTypeOfItem = currentTypeOfItem;
        }
        public Rectangle CollisionRectangle
        {
            get
            {
                return new Rectangle((int)Pos.X, (int)Pos.Y, 64, 64);
            }
        }
        Color color = Color.White;
        public static int id = 8;
        public void Update()
        {
            _previousMouse = _currentMouse;
            _currentMouse = Mouse.GetState();

            if (ArmorSlots[this.idSlot].currentClassOfItem != 0)
                ArmorSlots[this.idSlot].isEmpty = false;
            var mouseRectangle = new Rectangle(_currentMouse.X, _currentMouse.Y, 1, 1);
            _isHovering = false;
            if (mouseRectangle.Intersects(CollisionRectangle))
            {
                _isHovering = true;

                if (_currentMouse.LeftButton == ButtonState.Released && _previousMouse.LeftButton == ButtonState.Pressed)
                {
                    if (Slot.checkerCurrentClassOfItem == 2 || Slot.checkerCurrentClassOfItem == 0)
                        ItemScramble(this.idSlot, Rectangle2);
                }
            }
        }
        public void Draw()
        {
            spriteBatch.Begin();
            if (_isHovering)
                color = Color.Gray;
            else
                color = Color.White;
            SecondInventory.spriteBatch.Draw(texture, new Vector2(Pos.X, Pos.Y), Rectangle2, color);
            spriteBatch.End();
        }
        public void ItemScramble(int currentId, Rectangle Rectangle2)
        {
            VarRectangle = ArmorSlots[currentId].Rectangle2;
            ArmorSlots[currentId].Rectangle2 = Slot.SlotCheckerRectangleValue;
            Slot.SlotCheckerRectangleValue = VarRectangle;

            Slot.varCurrentClassOfItem = ArmorSlots[currentId].currentClassOfItem;
            ArmorSlots[currentId].currentClassOfItem = Slot.checkerCurrentClassOfItem;
            Slot.checkerCurrentClassOfItem = Slot.varCurrentClassOfItem;

            Slot.self.varCurrentTypeOfItem = ArmorSlots[currentId].currentTypeOfItem;
            ArmorSlots[currentId].currentTypeOfItem = Slot.checkerCurrentTypeOfItem;
            Slot.checkerCurrentTypeOfItem = Slot.self.varCurrentTypeOfItem;
        }
    }
}
