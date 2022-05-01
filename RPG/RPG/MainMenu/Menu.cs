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

        public Color color; 

        public bool isMousePressed = false;
        public bool isMenuSettings = false;
        public bool clickFromMenu = true;


        public Menu() 
        {

        }

        public void LoadContent()
        {

        }
    }
}


