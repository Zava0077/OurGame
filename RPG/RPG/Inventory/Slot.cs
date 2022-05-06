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
        public string[] classOfItem = new string[] { "Null", "Weapon", "Armor", "Potion" };
        public int currentClassOfItem;
        public string[] typeOfPotion = new string[] {"Small HealthPotion", "HealthPotion"};
        public int currentTypeOfPotion;
        public bool Clicked { get; private set; }
        Texture2D texture { get; set; }
        public int idSlot;
        public Vector2 Pos;
        public Rectangle Rectangle2;
        public bool isEmpty;
        public static List<Slot> ChangeList = new List<Slot>();
        public Slot(Vector2 Pos,int idSlot,Texture2D texture,Rectangle Rectangle2,bool isEmpty, int classOfItem, int currentTypeOfPotion)
        {
            this.idSlot = idSlot;
            this.Pos = Pos;
            this.texture = texture;
            self = this;
            this.Rectangle2 = Rectangle2;
            this.isEmpty = isEmpty;
            this.currentClassOfItem = classOfItem;
            this.currentTypeOfPotion = currentTypeOfPotion;
        }
        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Pos.X, (int)Pos.Y, 64, 64);
            }
        }

        public void Init()
        {

        }
        Color color = Color.White;
        static int d = 0;
        static int c = 0;
        public int count = 0;
        public static int id = 8;
        public static int Displacement = 0;
        public static Slot self;
        public int idSlotForCheck = 0;
        public static int currentId = SlotChecker.idSlotForCheck;
        public static int row = (int)(currentId / CountSlotX);
        public static int collumn = currentId % CountSlotX;
        Menu mn = new Menu();

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
                currentId = this.idSlot;
                _isHovering = true;
                if (_currentMouse.LeftButton == ButtonState.Released && _previousMouse.LeftButton == ButtonState.Pressed)
                {
                    if (Slots[currentId].isEmpty == false)
                    {
                        SlotReact(Slots[idSlotForCheck].currentClassOfItem, Slots[idSlotForCheck].currentTypeOfPotion,this.idSlot);
                    }
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
            Inventory.spriteBatch.Draw(texture, new Vector2 (Pos.X,Pos.Y), Rectangle2, color);
            Inventory.spriteBatch.Draw(texture, new Vector2((Game1.self.Window.ClientBounds.Width - 288) + SlotChecker.constt * Slot.collumn, 20 + SlotChecker.constt * Slot.row), new Rectangle(0, 0, 5, 5), Color.White); //прорисовка Слотчекера
            spriteBatch.End();
        }
        public void EmptySlot()
        {
            int i = 0;

            while (Slots[i].isEmpty == false)
            {
                for (i = 0; i < (CountSlotX * CountSlotY)-1;)
                {
                    i++;
                    idSlotForCheck = i;
                    if (Slots[i].isEmpty == true)
                        i = (CountSlotX * CountSlotY) - 1;
                }
            }
            if (Slots[0].isEmpty == true)
                idSlotForCheck = 0;
        }
        public int GetEmptySlot()
        {
            EmptySlot();
            return idSlotForCheck;
        }
        public void ClassOfItem(int currentClassOfItem, int currentTypeOfPotion)
        {
            idSlotForCheck = GetEmptySlot();
            switch (currentClassOfItem)
            {
                case 0:
                    Slots[idSlotForCheck].Rectangle2 = new Rectangle(8 * Game1.self.connst + 8, 0, 64, 64);
                    Slots[idSlotForCheck].isEmpty = false;
                    break;
                case 3:
                    switch (currentTypeOfPotion)
                    {
                        case 0:
                            Slots[idSlotForCheck].Rectangle2 = new Rectangle(0, 65, 64, 64);
                            Slots[idSlotForCheck].isEmpty = false;
                            break;
                        case 1:
                            Slots[idSlotForCheck].Rectangle2 = new Rectangle(8 * Game1.self.connst + 8 + 65, 0, 64, 64);
                            Slots[idSlotForCheck].isEmpty = false;
                            break;
                    }
                    break;
            }
        }
        public void SlotReact(int i, int j, int currentId)
        {
            i = Slots[currentId].currentClassOfItem;
            j = Slots[currentId].currentTypeOfPotion;
            switch (i)
            {
                case 0:
                    Slots[currentId].Rectangle2 = new Rectangle(8 * Game1.self.connst + 8, 0, 64, 64);
                    Slots[currentId].isEmpty = true;
                    break;
                case 3:
                    switch (j)
                    {
                        case 0:
                            Slots[currentId].Rectangle2 = new Rectangle(8 * Game1.self.connst + 8, 0, 64, 64);
                            Game1.self.PlayerHP += 20;
                            Slots[currentId].isEmpty = true;
                            break;
                        case 1:
                            Slots[currentId].Rectangle2 = new Rectangle(8 * Game1.self.connst + 8, 0, 64, 64);
                            Slots[currentId].isEmpty = true;
                            Game1.self.PlayerHP += 45;
                            break;
                    }
                    break;
            }
        }
    }
}
