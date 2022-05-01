using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RPG
{
    public class Menu
    {
        public string[] Stats = new string[] { "Menu", "Settings", "Play", "Exit" };
        public string CurrentStatus;

        public Texture2D exit;
        
        public Texture2D settings;
        public Texture2D play;
        public Texture2D test;
        public Texture2D back;
        public SpriteFont font;

        public Vector2 v;
        public Vector2 v1;
        public Vector2 v2;
        public Vector2 v3;
        public Vector2 backv;


        public Color color; //цвет задника кнопок
        public Color newMenuColor = Color.WhiteSmoke; //цвет нового открытого меню

        public bool isMousePressed = false;
        public bool isMenuSettings = false;
        public bool clickFromMenu = true;

        int count = 0;

        public Menu() //пустой конструктор класса
        {

        }

        public void Exit()
        {
            Game1.self.Exit(); //и типо выход))) БОЖЕ ИЗИ!!
        }

        public void LoadContent()
        {

        }

        public void Sprite(Vector2 v, Vector2 v1, Vector2 v2, Vector2 v3, SpriteBatch spriteBatch, Texture2D exit, Texture2D settings, Texture2D play, Texture2D test, Color color, Color nMC, bool IsMousePressed)
        {
            CurrentStatus = Stats[0];
            nMC = newMenuColor;
            if (IsMousePressed == true)
                color = Color.Transparent;
            else
            {
                spriteBatch.Begin();
                spriteBatch.Draw(play, v, color);
                spriteBatch.Draw(settings, v1, color);
                spriteBatch.Draw(exit, v2, color);
                spriteBatch.End();
            }
        }

        public void SettingsMenu(Vector2 v3, SpriteBatch spriteBatch, Texture2D t, Color nMC, bool isMenuSettings, bool QuitProcess) // Меню настроек
        {
            nMC = newMenuColor;
            if (isMenuSettings == true)
            {
                CurrentStatus = Stats[1];
                spriteBatch.Begin();
                spriteBatch.Draw(test, v3, newMenuColor);
                spriteBatch.Draw(back, backv, newMenuColor);
                spriteBatch.End();
            }
            else
                nMC = Color.Transparent;
            if (QuitProcess == true)
                Exit();
        }

        public void ButtonFunction(Vector3 cursor, int Width, int Height, Vector2 v, Vector2 v1, Vector2 v2, Vector2 vec3, SpriteBatch spriteBatch, Texture2D e, Texture2D s, Texture2D p, Texture2D test, Color color, Color nMC)
        {
            int offset = 125; // Смещение по вертикали
            int depth = 65; // Расстояние между кнопками

            vec3 = v3;

            Color nul = Color.Transparent; // пустой цвет
            nMC = newMenuColor;

            if (isMenuSettings == true)
                CurrentStatus = Stats[1];

            int count = 0;

       /*     if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                if (cursor.X > (Width / 2) - 130 & cursor.X < (Width / 2) + offset)
                {
                    if (cursor.Y > (Height / 3) - offset & cursor.Y < ((Height / 3) + (Height / 3) - (offset + depth)))// Играть
                    {
                        isMousePressed = true;
                        Sprite(v, v1, v2, vec3, spriteBatch, e, s, p, test, nul, newMenuColor, isMousePressed); //стираем меню
                        clickFromMenu = false;
                    }
                    if (cursor.Y > (Height / 3) * 2 - offset & cursor.Y < ((Height / 3) + (Height / 3) * 2 - (offset + depth))) // Настройки(Мб сложность)
                    {
                        isMousePressed = true;
                        Sprite(v, v1, v2, v3, spriteBatch, exit, settings, play, test, nul, newMenuColor, isMousePressed); //стираем меню
                        isMenuSettings = true;
                        SettingsMenu(v3, spriteBatch, test, newMenuColor, isMenuSettings, false); //рисуем кота и кнопку
                        clickFromMenu = false;
                    }
                    if (cursor.Y > (Height) - offset & cursor.Y < ((Height / 3) + (Height) - (offset + depth)))
                    {
                        if (CurrentStatus == Stats[0] && clickFromMenu == true && (count == 0 || count == 3))
                        {
                            Exit();
                        }
                        if (cursor.Y > (Height) - offset & cursor.Y < ((Height / 3) + (Height) - (offset + depth)))
                        {
                            count++;
                            isMousePressed = false;
                            SettingsMenu(vec3, spriteBatch, test, newMenuColor, isMenuSettings, false); //стираем кота и кнопку
                            Sprite(v, v1, v2, vec3, spriteBatch, e, s, p, test, nMC, newMenuColor, isMousePressed); //рисуем меню
                            isMenuSettings = false;
                            CurrentStatus = Stats[0];
                        }
                    }
                }
            }
            */
            if (CurrentStatus == Stats[3])
                SettingsMenu(vec3, spriteBatch, test, newMenuColor, isMenuSettings, true);
        }

        public void Play(Vector2 vec3, SpriteBatch spriteBatch, Texture2D e, Texture2D s, Texture2D p, Color nul)
        {
            isMousePressed = true;
            Sprite(v, v1, v2, vec3, spriteBatch, e, s, p, test, nul, newMenuColor, isMousePressed); //стираем меню
            clickFromMenu = false;
        }

        public void Settings(SpriteBatch spriteBatch, Color nul)
        {
            isMousePressed = true;
            Sprite(v, v1, v2, v3, spriteBatch, exit, settings, play, test, nul, newMenuColor, isMousePressed); //стираем меню
            isMenuSettings = true;
            SettingsMenu(v3, spriteBatch, test, newMenuColor, isMenuSettings, false); //рисуем кота и кнопку
            clickFromMenu = false;
        }

        public void BackFromSettings(Vector2 vec3, SpriteBatch spriteBatch, Texture2D e, Texture2D s, Texture2D p, Color nMC)
        {
            isMousePressed = false;
            SettingsMenu(vec3, spriteBatch, test, newMenuColor, isMenuSettings, false); //стираем кота и кнопку
            Sprite(v, v1, v2, vec3, spriteBatch, e, s, p, test, nMC, newMenuColor, isMousePressed); //рисуем меню
            isMenuSettings = false;
            CurrentStatus = Stats[0];
        }
    }
}


