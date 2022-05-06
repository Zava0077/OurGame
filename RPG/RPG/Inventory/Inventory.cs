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
    class Inventory
    {
        public static int CountSlotX = 4;
        public static int CountSlotY = 6;
        static public SpriteBatch spriteBatch { get; set; }
        public static MouseState currentMouse;
        public static MouseState previousMouse;
        static public SpriteFont spriteFont { get; set; }
        public static int idSlot { get; set; }
        public static Texture2D textureAllSlots { get; set; }

        static public void Init(SpriteBatch spriteBatch)
        {
            int x = 0;
            int y = -1;
            idSlot = 0;
            int Otstup = 70;
            int das = 30;
            Inventory.spriteBatch = spriteBatch;
            for (; idSlot < CountSlotX * CountSlotY; idSlot++)
            {
                x++;
                if (idSlot % CountSlotX == 0)
                {
                    x = 0;
                    y++;
                }
                Slot.Slots.Add(new Slot(new Vector2(((x * Otstup)) + Game1.self.Window.ClientBounds.Width - CountSlotX * 32 - Otstup * 2 - das, das + (y * Otstup)+ Otstup+das+120), idSlot, textureAllSlots, new Rectangle(8 * Game1.self.connst + 8, 0, 64, 64), true, 0, 0));
            }
        }
        static public void Update()
        {
            previousMouse = currentMouse;
            currentMouse = Mouse.GetState();
            foreach (Slot slot in Slot.Slots)
            {
                slot.Update();
            }
        }
        static public void Draw()
        {
            foreach (Slot slot in Slot.Slots)
            {
                slot.Draw();
            }
        }
    }
}
