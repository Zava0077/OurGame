
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RPG
{
    public class Menu
    {
        public Texture2D exit;
        public Texture2D settings;
        public Texture2D play;
        public Texture2D test;

        public Vector2 v;
        public Vector2 v1;
        public Vector2 v2;
        public Vector2 v3;


        public Color color; //цвет задника кнопок
        public Color newMenuColor = Color.WhiteSmoke; //цвет нового открытого меню

        public bool isMousePressed = false;
        public bool isMenuSettings = false;

        public Menu() //пустой конструктор класса
        {

        }

        public void Exit()
        {
            Game1.self.Exit(); //и типо выход))) БОЖЕ ИЗИ!!
        }

        public void LoadContent()
        {
          /*  exit = Game1.self.Content.Load<Texture2D>("button");
            settings = Game1.self.Content.Load<Texture2D>("settings");
            play = Game1.self.Content.Load<Texture2D>("play");
            test = Game1.self.Content.Load<Texture2D>("робокот"); */ // потом
        }

        public void Sprite(Vector2 v, Vector2 v1, Vector2 v2, Vector2 v3, SpriteBatch spriteBatch, Texture2D exit ,Texture2D settings, Texture2D play,Texture2D test, Color color, Color nMC)
        {
            nMC = newMenuColor;
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                isMousePressed = true;
            if (isMousePressed == true)
                color = Color.Transparent;
            spriteBatch.Begin();
            spriteBatch.Draw(play, v, color);
            spriteBatch.Draw(settings, v1, color);
            spriteBatch.Draw(exit, v2, color);
            spriteBatch.End();
        }

        public void SettingsMenu(Vector2 v3, SpriteBatch spriteBatch, Texture2D t, Color nMC, bool isMenuSettings) // Меню настроек
        {
            nMC = newMenuColor;
            if (isMenuSettings == true)
            {   
                spriteBatch.Begin();
                spriteBatch.Draw(test, v3, newMenuColor);
                spriteBatch.End();
            }
        }

        public void ButtonFunction(Vector3 cursor, int Width, int Height, Vector2 v ,Vector2 v1, Vector2 v2, Vector2 vec3, SpriteBatch spriteBatch, Texture2D e, Texture2D s, Texture2D p, Texture2D test, Color color, Color nMC)
        {
            int offset = 125; // Смещение по вертикали
            int depth = 65; // Расстояние между кнопками

            vec3 = v3;

            Color nul = Color.Transparent; // пустой цвет
            nMC = newMenuColor;
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                if (cursor.X > (Width / 2) - 130 & cursor.X < (Width / 2) + offset)
                {
                    if (cursor.Y > (Height / 3) - offset & cursor.Y < ((Height / 3) + (Height / 3) - (offset + depth)))// Играть
                        Sprite(v, v1, v2,vec3, spriteBatch, e, s, p,test, nul, newMenuColor); 
                    else if (cursor.Y > (Height / 3) * 2 - offset & cursor.Y < ((Height / 3) + (Height / 3) * 2 - (offset + depth))) // Настройки(Мб сложность)
                    {
                        Sprite(v, v1, v2,vec3, spriteBatch, e, s, p,test, nul, newMenuColor); //стираем меню
                        isMenuSettings = true;
                        SettingsMenu(vec3, spriteBatch, test, newMenuColor, isMenuSettings); //рисуем кота
                    }
                    else if (cursor.Y > (Height) - offset & cursor.Y < ((Height / 3) + (Height) - (offset + depth)))
                        Exit(); //Выход
                }
            }
        }
    }
}
