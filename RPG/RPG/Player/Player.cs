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
    public class Player
    {
        public static Player player;
        public Player()
        {
            player = this;
        }
        public string Name { get; set; }
        public double MaxHP = 100;
        public double PlayerHP = 100;
        public double Exp = 1;
        public int PlayerLVL = 0;
        public int PrevLVL = 0;
        public double MaxExp = 100;
        public double AttackMax = 5;
        public double AttackMin = 3;
        public double AttackSpeed = 2000;
        private int expOffset = 38;

        public static void LevelUP()
        {
            int ostatok = (int)(player.Exp - player.MaxExp);
            player.expOffset *= (Player.player.PlayerLVL/5);
            player.MaxExp = player.MaxExp + player.expOffset;
            player.PlayerLVL++;
            player.MaxHP += 10;
            player.AttackMax += 2;
            player.AttackMin += 1;
            player.Exp = 0+ostatok;
        }

        public static void Draw(SpriteBatch sprite,Vector2 Pos,Texture2D texture,Color color)
        {
            sprite.Draw(texture, Pos - new Vector2(-16, -16), new Rectangle(33, 130, 31, 31), color);
        }
    }
}
