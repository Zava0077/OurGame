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
        Texture2D exit;
        Texture2D settings;
        Texture2D play;

        public void Exit()
        {
            Game1.self.Exit(); //и типо выход))) БОЖЕ ИЗИ!!
        }

        public void LoadContent()
        {
            exit = Game1.self.Content.Load<Texture2D>("button");
            settings = Game1.self.Content.Load<Texture2D>("settings");
            play = Game1.self.Content.Load<Texture2D>("play");
        }

        public void Sprite(Vector2 Vector, Vector2 Vector1, Vector2 Vector2, SpriteBatch spriteBatch, Texture2D e ,Texture2D s, Texture2D p)
        {   
            spriteBatch.Begin();
            spriteBatch.Draw(play, Vector, Color.WhiteSmoke);
            spriteBatch.Draw(s, Vector1, Color.WhiteSmoke);
            spriteBatch.Draw(e, Vector2, Color.WhiteSmoke);
            spriteBatch.End();
        }

        public void ButtonFunction(Vector3 cursor, int Width, int Height)
        {
            int offset = 125; // Смещение по вертикали
            int depth = 65; // Расстояние между кнопками
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
