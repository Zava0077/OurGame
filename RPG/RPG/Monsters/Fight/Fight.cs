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
    class Fight
    {
        static private Vector2 Pos = new Vector2(100, 100);
        public static bool isFight;
        public static Texture2D texture;
        public static string NameMonstra;
        public static bool Timer = false;
        public static Timer AM;
        public static Timer AP;
        private static double AttackaSpeedMonstra;
        private static double HPaMonstra;
        private static double AttackaMonstra;
        private static int exp;

        public Fight(double AttackSpeedMonstra, double HPMonstra, double AttackMonstra, int expa)
        {
            AttackaMonstra = AttackMonstra;
            AttackaSpeedMonstra = AttackSpeedMonstra;
            HPaMonstra = HPMonstra;
            exp = expa;
        }

        public static void Update()
        {
            TimerCallback tm = new TimerCallback(AttackMonstr);
            AM = new Timer(tm, null, (int)AttackaSpeedMonstra, (int)AttackaSpeedMonstra);
            TimerCallback attackPlayer = new TimerCallback(AttackPlayer);
            AP = new Timer (attackPlayer, null, (int)(Player.player.AttackSpeed /* Player.Buffs[0].buff2 * Player.Buffs[8].buff2 */), (int)Player.player.AttackSpeed);
            Timer = true;
        }

        private static void AttackMonstr(object sender)
        {
            Player.player.PlayerHP = Player.player.PlayerHP - AttackaMonstra;
            if (Player.player.PlayerHP <= 0)
            {
                isFight = false;
            }
        }
        private static void AttackPlayer(object sender)
        {
            HPaMonstra = HPaMonstra - (int)Player.player.Attack - (int)(Player.Buffs[4].buff1 * (Player.Buffs[0].buff1 + Player.Buffs[8].buff1)) - CriticalAttack(Player.player.critChance);
            if (HPaMonstra <= 0)
            {
                HPaMonstra = 10;
                Player.player.Exp += exp;
                isFight = false;
            }
        }
        static Random rnd = new Random();
        private static int CriticalAttack(int critChance)
        {
            if (rnd.Next(0, 100) <= critChance)
            {
                return rnd.Next(5, 20);
            }
            else return 0;
        }
        public static void Draw(SpriteBatch sprite)
        {
            if (isFight == true)
            {
                sprite.Draw(texture, Pos, Color.White);
                if (NameMonstra == "Skeleton")
                {
                    sprite.Draw(texture, new Vector2(550, 250), new Rectangle(195, 0, 64, 64), Color.White);
                }
                if (NameMonstra == "Rat")
                {
                    sprite.Draw(texture, new Vector2(550, 250), new Rectangle(130, 0, 64, 64), Color.White);
                }
                if (NameMonstra == "Spider")
                {
                    sprite.Draw(texture, new Vector2(550, 250), new Rectangle(0, 0, 64, 64), Color.White);
                }
            }
        }
    }
}
