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
        bool isBreastPlateSlot;
        bool isHelmetSlot;
        int currentId;
        bool isSlotsAreAble = true;
        bool isLeggingsSlot;
        bool isWeaponSlot;
        bool isShieldSlot;
        bool isAtrefactSlot;
        bool isRuneSlot;
        public static List<ArmorSlot> ChangeList = new List<ArmorSlot>();

        public ArmorSlot(Vector2 Pos, int idSlot, Texture2D texture, Rectangle Rectangle2, bool isEmpty, int currentClassOfItem, int currentTypeOfItem, bool isBreastPlateSlot, bool isHelmetSlot, bool isLeggingsSlot, bool isWeaponSlot, bool isShieldSlot, bool isAtrefactSlot, bool isRuneSlot)
        {
            this.idSlot = idSlot;
            this.Pos = Pos;
            this.texture = texture;
            this.Rectangle2 = Rectangle2;
            this.isEmpty = isEmpty;
            this.currentClassOfItem = currentClassOfItem;
            this.currentTypeOfItem = currentTypeOfItem;
            this.isBreastPlateSlot = isBreastPlateSlot;
            this.isHelmetSlot = isHelmetSlot;
            this.isLeggingsSlot = isLeggingsSlot;
            this.isWeaponSlot = isWeaponSlot;
            this.isShieldSlot = isShieldSlot;
            this.isAtrefactSlot = isAtrefactSlot;
            this.isRuneSlot = isRuneSlot;
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
            var mouseRectangle = new Rectangle(_currentMouse.X, _currentMouse.Y, 1, 1);
            ArmorSlots[1].isHelmetSlot = true;
            ArmorSlots[4].isWeaponSlot = true;
            ArmorSlots[5].isBreastPlateSlot = true;
            ArmorSlots[6].isShieldSlot = true;
            ArmorSlots[9].isLeggingsSlot = true;
            IsArmorOn();
            for (int id = 0; id < SecondInventory.CountSlotX * SecondInventory.CountSlotY; id++)
            {
                if (id == 0 || id == 2 || id == 8 || id == 10)
                    ArmorSlots[id].isAtrefactSlot = true;
                if (id % 4 == 0)
                    ArmorSlots[id].isRuneSlot = true;
            }
            _isHovering = false;
            if (mouseRectangle.Intersects(CollisionRectangle))
            {
                _isHovering = true;
                currentId = this.idSlot;
                if (_currentMouse.LeftButton == ButtonState.Released && _previousMouse.LeftButton == ButtonState.Pressed)
                {
                    if ((Slot.checkerCurrentClassOfItem == 2 || Slot.checkerCurrentClassOfItem == 4 || Slot.checkerCurrentClassOfItem == 1 || Slot.checkerCurrentClassOfItem == 0))
                    {
                        if (Slot.checkerCurrentClassOfItem == 2)
                        {
                            if (Slot.checkerCurrentTypeOfItem == 0 && ArmorSlots[currentId].isHelmetSlot == true)
                                ItemScramble(this.idSlot, Rectangle2);

                            if (Slot.checkerCurrentTypeOfItem == 1 && ArmorSlots[currentId].isShieldSlot == true)
                                ItemScramble(this.idSlot, Rectangle2);
                            if (Slot.checkerCurrentTypeOfItem == 2 && ArmorSlots[currentId].isBreastPlateSlot == true)
                                ItemScramble(this.idSlot, Rectangle2);
                            if (Slot.checkerCurrentTypeOfItem == 3 && ArmorSlots[currentId].isLeggingsSlot == true)
                                ItemScramble(this.idSlot, Rectangle2);
                        }
                        else if (Slot.checkerCurrentClassOfItem == 4)
                        {
                            if (Slot.checkerCurrentTypeOfItem == 0 && ArmorSlots[currentId].isAtrefactSlot == true)
                                ItemScramble(this.idSlot, Rectangle2);
                            IsArmorOn();
                        }
                        else if (Slot.checkerCurrentClassOfItem == 1)
                        {
                            if (Slot.checkerCurrentTypeOfItem == 0 && ArmorSlots[currentId].isWeaponSlot == true)
                                ItemScramble(this.idSlot, Rectangle2);
                            IsArmorOn();
                        }
                        else
                        ItemScramble(this.idSlot, Rectangle2);
                        IsArmorOn();
                    }
                /*    if (Slot.checkerCurrentClassOfItem == 4 || Slot.checkerCurrentClassOfItem == 0)
                    {
                        if (Slot.checkerCurrentTypeOfItem == 0 && ArmorSlots[currentId].isAtrefactSlot == true)
                            ItemScramble(this.idSlot, Rectangle2);
                        IsArmorOn(this.idSlot);
                    }
                    else
                             if (Slot.checkerCurrentClassOfItem == 1)
                    {
                        if (Slot.checkerCurrentTypeOfItem == 0 && ArmorSlots[currentId].isWeaponSlot == true)
                            ItemScramble(this.idSlot, Rectangle2);
                        IsArmorOn(this.idSlot);
                    } */
                }
                if (Keyboard.GetState().IsKeyDown(Keys.LeftShift) || Keyboard.GetState().IsKeyDown(Keys.RightShift))
                    if (_currentMouse.LeftButton == ButtonState.Released && _previousMouse.LeftButton == ButtonState.Pressed)
                    {
                        /*        if (Slot.checkerCurrentClassOfItem == 2 || Slot.checkerCurrentClassOfItem == 0)
                                    if (Slot.Slots[Slot.currentId].currentClassOfItem == 2)
                                        if (Slot.Slots[Slot.currentId].currentTypeOfItem == 0)
                                            ShiftItemScramble(Slot.currentId, 0);
                                if (Slot.Slots[Slot.currentId].currentTypeOfItem == 1)
                                    ShiftItemScramble(Slot.currentId, 4); */
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
        public void ShiftItemScramble(int currentId, int idSlotForCheck)
        {
            Slot.self.VarRectangle = Slot.Slots[currentId].Rectangle2;
            Slot.Slots[currentId].Rectangle2 = ArmorSlots[idSlotForCheck].Rectangle2;
            ArmorSlots[idSlotForCheck].Rectangle2 = VarRectangle;

            Slot.varCurrentClassOfItem = Slot.Slots[currentId].currentClassOfItem;
            Slot.Slots[currentId].currentClassOfItem = ArmorSlots[idSlotForCheck].currentClassOfItem;
            ArmorSlots[idSlotForCheck].currentClassOfItem = Slot.varCurrentClassOfItem;

            Slot.self.varCurrentTypeOfItem = Slot.Slots[currentId].currentTypeOfItem;
            Slot.Slots[currentId].currentTypeOfItem = ArmorSlots[idSlotForCheck].currentTypeOfItem;
            ArmorSlots[idSlotForCheck].currentTypeOfItem = Slot.self.varCurrentTypeOfItem;
        }
        public void IsArmorOn()
        {
            for(int id = 0; id < SecondInventory.CountSlotX * SecondInventory.CountSlotY; id++)
            {
                switch (ArmorSlots[id].currentClassOfItem)
                {
                    case 0:
                        Game1.self.PlayerDefence = 0;
                        break;
                    case 1:
                        Player.player.Attack += 5;
                        break;
                    case 2:
                        switch (ArmorSlots[id].currentTypeOfItem)
                        {
                            case 0:
                                Player.headDefense = 2;
                                break;
                            case 2:
                                Player.bodyDefense = 4;
                                break;
                            case 3:
                                Player.leggingsDefense = 2;
                                break;
                        }
                        break;
                    case 4:
                        switch (ArmorSlots[id].currentTypeOfItem)
                        {
                            case 0:
                                Game1.self.PlayerDefence /= 2;
                                Player.player.AttackSpeed -= 500;
                                break;
                        }
                        break;
                }
            }
        }
    }
}
