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
    class Slot : Inventory
    {
        public static List<Slot> Slots = new List<Slot>();
        private MouseState _currentMouse;
        private MouseState _previousMouse;
        public event EventHandler Click;
        private bool _isHovering;
        private bool _isCheckerHovering;
        public bool Clicked { get; private set; }
        Texture2D texture { get; set; }
        public int idSlot;
        public Vector2 Pos;
        Rectangle Rectangle2;
        public static List<Slot> ChangeList = new List<Slot>();
        public Slot(Vector2 Pos,int idSlot,Texture2D texture,Rectangle Rectangle2)
        {
            this.idSlot = idSlot;
            this.Pos = Pos;
            this.texture = texture;
            self = this;
            this.Rectangle2 = Rectangle2;
        }
        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Pos.X, (int)Pos.Y, 32, 32);
            }
        }

        public void Init()
        {

        }
        Color color = Color.White;
        static int d = 0;
        static int c = 0;
        static int id = 8;
        public static int Displacement = 0;
        public static Slot self;
        public static int currentId = SlotChecker.idSlotForCheck;
        public static int row = (int)(currentId / CountSlotX);
        public static int collumn = currentId % CountSlotX;

        public void Update()
        {
            _previousMouse = _currentMouse;
            _currentMouse = Mouse.GetState();

            SlotChecker sltchk = new SlotChecker(SlotChecker.idSlotForCheck, new Vector2((Game1.self.Window.ClientBounds.Width - 288) + SlotChecker.constt * Slot.collumn, 20 + SlotChecker.constt * Slot.row));
            var mouseRectangle = new Rectangle(_currentMouse.X, _currentMouse.Y, 1,1);
            var checkerRectangle = new Rectangle((Game1.self.Window.ClientBounds.Width - 288) + SlotChecker.constt * Slot.collumn, 20 + SlotChecker.constt * Slot.row,1, 1);
            _isCheckerHovering = false;
            _isHovering = false;
            if (checkerRectangle.Intersects(Rectangle))
            {
                _isCheckerHovering = true;
                
            }
            if (mouseRectangle.Intersects(Rectangle))
            {
                _isHovering = true;
                if (_currentMouse.LeftButton == ButtonState.Released && _previousMouse.LeftButton == ButtonState.Pressed)
                {

                }
            }
        }
        public void Draw()
        {
            spriteBatch.Begin();

            Inventory.spriteBatch.Draw(texture, new Vector2 (Pos.X,Pos.Y), new Rectangle(id * Game1.self.connst + 8 + Displacement, 0, 32, 32), color);
            Inventory.spriteBatch.Draw(texture, new Vector2((Game1.self.Window.ClientBounds.Width - 288) + SlotChecker.constt * Slot.collumn, 20 + SlotChecker.constt * Slot.row), new Rectangle(0, 0, 5, 5), Color.White); //прорисовка Слотчекера
            spriteBatch.End();
        }
    }
}
