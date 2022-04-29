using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RPG
{
    public class Menu
    {
        
        public void Exit()
        {
            Game1.self.Exit(); //и типо выход))) БОЖЕ ИЗИ!!
        }
        public void ButtonFunction(Vector3 cursor, int Width, int Height)
        {
            int offset = 125;
            int depth = 65;
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                if (cursor.X > (Width / 2) - 130 & cursor.X < (Width / 2) + offset)
                {
                    if (cursor.Y > (Height / 3) - offset & cursor.Y < ((Height / 3) + (Height / 3) - (offset + depth)))
                        ; // Играть
                    else if (cursor.Y > (Height / 3) * 2 - offset & cursor.Y < ((Height / 3) + (Height / 3) * 2 - (offset + depth)))
                        ; // Настройки(Мб сложность)
                    else if (cursor.Y > (Height) - offset & cursor.Y < ((Height / 3) + (Height) - (offset + depth)))
                        Exit(); //Выход
                }

            }
        }

    }
}
