using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RPG
{
    class DamageString
    {
        SpriteFont textFont = Game1.self.Content.Load<SpriteFont>("text");
        string text;
        Vector2 pos;
        Color color;
        SpriteBatch sprite;
        Timer AM;
        public int x = 1;
        public DamageString(SpriteBatch sprite, string text, Vector2 pos, Color color)
        {
            this.sprite = sprite;
            this.pos = pos;
            this.text = text;
            this.color = color;
        }

        private void Timer(object sender)
        {
            x = x + 1;
            AM.Dispose();
        }

        public void Draw()
        {
            TimerCallback SbrosMonstra = new TimerCallback(Timer);
            AM = new Timer(SbrosMonstra, null, 1000, 1000);
            if (this.x >= 40)
            {
                this.color = Color.Transparent;
            }
            sprite.DrawString(textFont, text, new Vector2(pos.X, pos.Y-(int)(x)), this.color);
        }
    }
}
