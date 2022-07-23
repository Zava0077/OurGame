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
        public static List<Player> Buffs = new List<Player>();
        public static Player player;
        public double buff0;
        public double buff1;
        public double buff2;
        public double buff3;
        public double buff4;
        public double buff5;
        public double buff6;
        public double buff7;
        public double fireResist;
        public double coldResist;
        public double elecResist;
        public double otravResist;
        public int idBuff;
        public int critChance;
        public Player(double buff0, double buff1, double buff2, int idBuff, double buff3, double buff4, double buff5, double buff6, double buff7)
        {
            player = this;
            this.buff0 = buff0; //баф ячейки
            this.buff1 = buff1; //баф на нижний/верхний слот
            this.buff2 = buff2; //баф на другой из соседних слотов
            this.buff3 = buff3; //резист от огня
            this.buff4 = buff4; //резист от холода
            this.buff5 = buff5; //резист от эл-ва
            this.buff6 = buff6; //резист от отравления
            this.buff7 = buff7; //шанс крита
            this.idBuff = idBuff;
        }
        public void BuffsControl()
        {
            for(int id = 0; id < SecondInventory.CountSlotX * SecondInventory.CountSlotY; id++)
            {
                Buffs.Add(new Player(0, 0, 0, id, 0, 0, 0, 0, 0));
            }
        }
        public void IsArmorOn()
        {
            for (int id = 0; id < SecondInventory.CountSlotX * SecondInventory.CountSlotY; id++)
            {
                switch (ArmorSlot.ArmorSlots[id].currentClassOfItem)
                {
                    case 0:
                        Buffs[id].buff1 = 0;
                        Buffs[id].buff2 = 0;
                        break;
                    case 1: //оружие
                        Buffs[id].buff1 = 5;
                        Buffs[id].buff2 = 0;
                        Buffs[id].buff7 = 4;
                        break;
                    case 2: //броня
                        switch (ArmorSlot.ArmorSlots[id].currentTypeOfItem)
                        {
                            case 0:
                                headDefense = 2;
                                break;
                            case 2:
                                bodyDefense = 4;
                                break;
                            case 3:
                                leggingsDefense = 2;
                                break;
                        }
                        break;
                    case 4:
                        switch (ArmorSlot.ArmorSlots[id].currentTypeOfItem)
                        {
                            case 0: //сильно увеличивает скорость аттаки и уменьшает защиту
                                Buffs[id].buff1 = 1.5;
                                Buffs[id].buff2 = 0.5;
                                break;
                            case 1: //увеличивает рез от огня
                                Buffs[id].buff3 = 5;
                                break;
                            case 2: //увеличивает рез от холода
                                Buffs[id].buff4 = 5;
                                break;
                            case 3: //увеличивает урон и шанс крита
                                Buffs[id].buff1 = 1.25;
                                Buffs[id].buff7 = 15;
                                break;
                        }
                        break;
                }
            }
            wholeDefense = headDefense + bodyDefense + leggingsDefense;
            critChance = (int)Buffs[0].buff7 + (int)Buffs[4].buff7 + (int)Buffs[8].buff7;
        }
        public string Name { get; set; }
        public double MaxHP = 100;
        public double PlayerHP = 100;
        public double Exp = 1;
        public int PlayerLVL = 0;
        public int PrevLVL = 0;
        public double MaxExp = 100;
        public double Attack = 5; //добавить изменяемые переменные totalAttack, totalAttackSpeed, и т.д, вычисляемые по формулам
        public double AttackSpeed = 2000;
        public int PlayerMoney = 0;
        private int expOffset = 28;
        public static int headDefense = 0;
        public static int bodyDefense = 0;
        public static int leggingsDefense = 0;
        public static int wholeDefense = headDefense + bodyDefense + leggingsDefense;

        public static void LevelUP()
        {
            int ostatok = (int)(player.Exp - player.MaxExp);
            player.expOffset *= 2;
            player.MaxExp = player.MaxExp + player.expOffset;
            player.PlayerLVL++;
            player.MaxHP += 10;
            player.Attack += 2;
            player.Exp = 0 + ostatok;
        }

        public static void Draw(SpriteBatch sprite,Vector2 Pos,Texture2D texture,Color color)
        {
            sprite.Draw(texture, Pos - new Vector2(-16, -16), new Rectangle(33, 130, 31, 31), color);
        }
    }
}
