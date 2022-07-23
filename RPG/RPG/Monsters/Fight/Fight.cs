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
        static private Vector2 Pos = new Vector2(200, 226);
        private static Random rnd = new Random();
        public static bool isFight;
        public static Texture2D texture;
        public static Texture2D Animation;
        public static Texture2D HPBarMonstra;
        private static string NameMonstr;
        public static bool Timer = false;
        public static Timer AM;
        public static Timer AP;
        public static Timer SbrosM;
        public static Timer SbrosP;
        private static double AttackaSpeedMonstra;
        private static double HPaMonstra;
        private static double AttackaMonstraMax;
        private static double AttackaMonstraMin;
        private static double Damage;
        private static double Damage1;
        private static int exp;
        private static Rectangle rectangleMonstra;
        private static Rectangle rectanglePlayer;
        private static bool Attack;
        private static int MaxHPMonstra;
        public static SpriteBatch sprite;
        public static List<DamageString> damageString = new List<DamageString>();

        public Fight(double AttackSpeedMonstra, double HPMonstra, double AttackMonstraMin,double AttackMonstraMax, int expa,string NameMonstra)
        {
            AttackaMonstraMax = AttackMonstraMax;
            AttackaMonstraMin = AttackMonstraMin;
            AttackaSpeedMonstra = AttackSpeedMonstra;
            HPaMonstra = HPMonstra;
            MaxHPMonstra = (int)HPMonstra;
            exp = expa;
            NameMonstr = NameMonstra;
            switch (NameMonstr)
            {
                case "Rat":
                    {
                        rectangleMonstra = new Rectangle(0, 258, 64, 128);
                        break;
                    }
                case "Skeleton":
                    {
                        rectangleMonstra = new Rectangle(0, 129, 64, 128);
                        break;
                    }
                case "Spider":
                    {
                        rectangleMonstra = new Rectangle(0, 387, 64, 128);
                        break;
                    }
            }
            rectanglePlayer = new Rectangle(0,0,64,128);
        }

        public static void Update()
        {
            TimerCallback tm = new TimerCallback(AttackMonstr);
            AM = new Timer(tm, null, (int)AttackaSpeedMonstra, (int)AttackaSpeedMonstra);
            TimerCallback attackPlayer = new TimerCallback(AttackPlayer);
            AP = new Timer (attackPlayer, null, (int)Player.player.AttackSpeed, (int)Player.player.AttackSpeed);
            Timer = true;
        }

        private static void AttackMonstr(object sender)
        {
            Damage = rnd.Next((int)AttackaMonstraMin, (int)AttackaMonstraMax+1);
            Player.player.PlayerHP = Player.player.PlayerHP - Damage;
            damageString.Add(new DamageString(sprite, Convert.ToString(Damage), new Vector2(370, 250), Color.Red));
            rectangleMonstra.X = 65;
            TimerCallback SbrosMonstra = new TimerCallback(SbrosMonstr);
            SbrosM = new Timer(SbrosMonstra, null, 500, 500);
            if (Player.player.PlayerHP <= 0)
            {
                isFight = false;
            }
        }

        private static void SbrosMonstr(object sender)
        {
            SbrosM.Dispose();
            switch (NameMonstr)
            {
                case "Rat":
                    {
                        rectangleMonstra = new Rectangle(0, 258, 64, 128);
                        break;
                    }
                case "Skeleton":
                    {
                        rectangleMonstra = new Rectangle(0, 129, 64, 128);
                        break;
                    }
                case "Spider":
                    {
                        rectangleMonstra = new Rectangle(0, 387, 64, 128);
                        break;
                    }
            }
        }

        private static void SbrosPlayer(object sender)
        {
            SbrosP.Dispose();
            rectanglePlayer = new Rectangle(0,0,64,128);
        }
        private static void AttackPlayer(object sender)
        {
            Damage1 = rnd.Next((int)Player.player.AttackMin,(int)Player.player.AttackMax);
            HPaMonstra = HPaMonstra - Damage1;
            damageString.Add(new DamageString(sprite, Convert.ToString(Damage1), new Vector2(530, 250), Color.Red));
            TimerCallback SbrosPlay = new TimerCallback(SbrosPlayer);
            SbrosP = new Timer(SbrosPlayer, null, 500, 500);
            rectanglePlayer.X = 65;
            if (HPaMonstra <= 0)
            {
                HPaMonstra = 10;
                Player.player.Exp += exp;
                isFight = false;
            }
        }

        public static void Draw(SpriteBatch sprite)
        {
            if (isFight == true)
            {
                sprite.Draw(texture, new Rectangle(75,125,Convert.ToInt32(texture.Width*1.5),Convert.ToInt32(texture.Height*1.5)), Color.White);
                sprite.Draw(Animation,new Vector2(300,250), rectanglePlayer, Color.White);
                sprite.Draw(Animation,new Vector2(600,250), rectangleMonstra, Color.White);
                sprite.Draw(HPBarMonstra, new Vector2(570, 230), new Rectangle(200, 50, (int)((124.0 / MaxHPMonstra) * HPaMonstra), HPBarMonstra.Height), Color.Red);
                sprite.DrawString(Game1.self.Content.Load<SpriteFont>("text"), Convert.ToString(HPaMonstra), new Vector2(622, 227), Color.Black);
                foreach (DamageString damageString in damageString)
                {
                    damageString.Draw();
                }
            }
        }
    }
}
