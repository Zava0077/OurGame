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
    class SecondInventory
    {
        public static int CountSlotX = 4;
        public static int CountSlotY = 3;
        static public SpriteBatch spriteBatch { get; set; }
        public static MouseState currentMouse;
        public static MouseState previousMouse;
        static public SpriteFont spriteFont { get; set; }
        public static int idArmorSlot { get; set; }
        public static Texture2D texture = Game1.self.Content.Load<Texture2D>("TextureRoom");

        static public void Init(SpriteBatch spriteBatch)
        {
            int x = 0;
            int y = -1;
            idArmorSlot = 0;
            int Otstup = 70;
            int das = 30;
            SecondInventory.spriteBatch = spriteBatch;
            for (; idArmorSlot < CountSlotX * CountSlotY; idArmorSlot++)
            {
                x++;
                if (idArmorSlot % CountSlotX == 0)
                {
                    x = 0;
                    y++;
                }
                ArmorSlot.ArmorSlots.Add(new ArmorSlot(new Vector2(((x * Otstup)) + Game1.self.Window.ClientBounds.Width - CountSlotX * 32 - Otstup * 2 - das, das + (y * Otstup) + 10), idArmorSlot, texture, new Rectangle(8 * Game1.self.connst + 8, 0, 64, 64), true, 0, 0, false, false, false, false, false,false, false));
            } 
        }
        public static void Update()
        {
            previousMouse = currentMouse;
            currentMouse = Mouse.GetState();
            foreach (ArmorSlot Armorslot in ArmorSlot.ArmorSlots)
            {
                Armorslot.Update();
            }
        }
        public static void Draw()
        {
            foreach (ArmorSlot Armorslot in ArmorSlot.ArmorSlots)
            {
                Armorslot.Draw();
            }
        }
    }
}
