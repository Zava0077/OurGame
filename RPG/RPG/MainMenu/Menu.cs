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

        public int bittonWidth;
        public int Width;
        public int Height;
        public int texWidth;
        public int texHeight;
        public int offset;

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

        }

        public void SettingsMenu(Vector2 v3, SpriteBatch spriteBatch, Texture2D t, Color nMC, bool isMenuSettings, bool QuitProcess) // Меню настроек
        {

        }

        public void ButtonFunction(Vector3 cursor, int Width, int Height, Vector2 v, Vector2 v1, Vector2 v2, Vector2 vec3, SpriteBatch spriteBatch, Texture2D e, Texture2D s, Texture2D p, Texture2D test, Color color, Color nMC)
        {
            
        }

        public void Play(Vector2 vec3, SpriteBatch spriteBatch, Texture2D e, Texture2D s, Texture2D p, Color nul)
        {
            
        }
    }
}


