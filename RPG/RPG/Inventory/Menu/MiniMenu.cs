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
    public class MiniMenu
    {
        public static int maxButtons = 2;
        static public SpriteBatch spriteBatch { get; set; }
        public static MouseState currentMouse;
        public static MouseState previousMouse;
        static public SpriteFont spriteFont { get; set; }
        public static int idBtn { get; set; }
        public static Texture2D texture = Game1.self.Content.Load<Texture2D>("TextureRoom");

        static public void Init(SpriteBatch spriteBatch)
        {
            idBtn = 0;
            int Otstup = 70;
            MiniMenu.spriteBatch = spriteBatch;
            for (; idBtn < maxButtons; idBtn++)
            {
                ChoosingMenu.Buttons.Add(new ChoosingMenu(new Rectangle(Otstup * idBtn, 0, 64, 32), idBtn, texture, new Rectangle(256, 0, 64, 32)));
            }
        }
        static public void Update()
        {
            foreach (ChoosingMenu btn in ChoosingMenu.Buttons)
            {
                btn.Update();
            }
        }
        static public void Draw()
        {
            foreach (ChoosingMenu btn in ChoosingMenu.Buttons)
            {
                btn.Draw();
            }
        }
    }
}
