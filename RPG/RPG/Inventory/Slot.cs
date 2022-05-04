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
    class Slot : Inventory
    {
        public static List<Slot> Slots = new List<Slot>();
        private MouseState _currentMouse;
        private MouseState _previousMouse;
        public event EventHandler Click;
        private bool _isHovering;
        public bool Clicked { get; private set; }
        Texture2D texture { get; set; }
        int idSlot;
        Vector2 Pos; //позиция клетки с крысой
        public Slot(Vector2 Pos,int idSlot,Texture2D texture)
        {
            this.idSlot = idSlot;
            this.Pos = Pos;
            this.texture = texture;
        }

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Pos.X, (int)Pos.Y, 32, 32);
            }
        }

        Color color = Color.White;
        static int d = 0;
        static int c = 0;
        static int id = 8;
        public static int Displacement;
        public void Update()
        {
            _previousMouse = _currentMouse;
            _currentMouse = Mouse.GetState();

            var mouseRectangle = new Rectangle(_currentMouse.X, _currentMouse.Y, 1,1);
            if (_isHovering)
            {
                color = Color.Gray;
                Displacement = 0;
            }
            else
            {
                color = Color.White;
                Displacement = 0;
            }
     
            _isHovering = false;
            if (mouseRectangle.Intersects(Rectangle))
            {
                _isHovering = true;
                color = Color.Gray;


                if (_currentMouse.LeftButton == ButtonState.Released && _previousMouse.LeftButton == ButtonState.Pressed)
                {
                    
                }
            }
        }


        public void Draw()
        {
            spriteBatch.Begin();
            Inventory.spriteBatch.Draw(texture, Pos,new Rectangle(id*Game1.self.connst+8+Displacement,0,32,32), color);
            spriteBatch.End();
        }
    }
}
