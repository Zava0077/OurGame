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
    class ChoosingMenu : MiniMenu
    {
        public static List<ChoosingMenu> Buttons = new List<ChoosingMenu>();
        public MouseState _currentMouse;
        private MouseState _previousMouse;
        public event EventHandler Click;
        public bool _isHovering;
        public bool Clicked { get; private set; }
        Texture2D texture { get; set; }
        public int idBtn;
        public Vector2 Pos;
        public Rectangle Rectangle;
        public Rectangle secondRectangle;
        public int currentBtn;
        public Color color = Color.White;
        public bool isMenuOpened = false;
        public ChoosingMenu(Rectangle secondRectangle, int idBtn, Texture2D texture, Rectangle Rectangle)
        {
            this.secondRectangle = secondRectangle;
            this.idBtn = idBtn;
            this.texture = texture;
            self = this;
            this.Rectangle = Rectangle;
        }
        public Vector2 newPos = Vector2.Zero;
        public static ChoosingMenu self;
        public Rectangle mouseRect;
        public void Update()
        {
            _previousMouse = _currentMouse;
            _currentMouse = Mouse.GetState();
            var mouseRectangle = new Rectangle(_currentMouse.X, _currentMouse.Y, 1, 1);
            mouseRect = mouseRectangle;
            _isHovering = false;
            for (int i = 0; i < MiniMenu.maxButtons; i++)
            {
                if (mouseRectangle.Intersects(Buttons[i].secondRectangle) && !Slot.self._isHovering && isMenuOpened)
                {
                    _isHovering = true;
                    currentBtn = this.idBtn;
                    if (isMenuOpened)
                        Slot.Slots[Slot.currentId]._isHovering = false;
                    if (Buttons[i].isMenuOpened)
                        Buttons[i].color = Color.Gray;
                    else
                        Buttons[i].color = Color.Transparent;
                }
                else if (isMenuOpened)
                    color = Color.White;
                if (_isHovering && _currentMouse.LeftButton == ButtonState.Released && _previousMouse.LeftButton == ButtonState.Pressed)
                    ;
            }
        }
        public void Draw()
        {
            MiniMenu.spriteBatch.Begin();
       /*     if (isMenuOpened)
                color = Color.White;
            else
                color = Color.Transparent; */
            MiniMenu.spriteBatch.Draw(texture, secondRectangle, Rectangle, color);
            MiniMenu.spriteBatch.End();
        }
        public void ClickChecker(Vector2 _lastMousePos, bool isMenuOpened)
        {
            this.isMenuOpened = isMenuOpened;
            int id = 0;
            if (isMenuOpened)
                for (; id < MiniMenu.maxButtons; id++)
                {
                    Buttons[id].secondRectangle = new Rectangle((int)(_lastMousePos.X + Buttons[id].Pos.X + (id * 70)) + 10, (int)(_lastMousePos.Y + Buttons[id].Pos.Y + 10), 64, 32);
                    Buttons[id].isMenuOpened = true;
                }
        }
    }
}
