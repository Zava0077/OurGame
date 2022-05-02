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
    class Room
    {
        static public SpriteBatch spriteBatch { get; set; }
        public static List<RoomTreasure> TreasureRoom = new List<RoomTreasure>();
        public static List<RoomHeal> HealRoom = new List<RoomHeal>();
        static public SpriteFont spriteFont { get; set; }
        public static int[] NumberRoom;
        public static int idRoom {get;set;}
        private static int s;
        static public int[] Random(int min, int max)
        {
            Random rnd = new Random();
            int[] NumberRoom = new int[40];

            for (int i = 0; i < NumberRoom.Length; i++)
            {
                int random = rnd.Next(min, max);
                NumberRoom[i] = random;
            }
            return NumberRoom;
        }
        static public void Init(SpriteBatch spriteBatch)
        {
            int y = 0;
            int CoutRoomX = 8;
            int Otstup = 140;
            int das = 45;
            Random rnd = new Random();
            NumberRoom = Random(1, 4);
            for (idRoom = 0; idRoom < 40;idRoom++) 
            {
                int idMonstra = rnd.Next(1, 3 + 1);
                Room.spriteBatch = spriteBatch;
                for (int i = 0; i < idRoom; i++)
                {
                    y++;
                    if (y % CoutRoomX == 0)
                    {
                        y = 0;
                    }
                }
                if (idRoom == CoutRoomX)
                    s = Otstup;
                if (idRoom == CoutRoomX * 2)
                { s = Otstup; s = s * 2; }
                if (idRoom == CoutRoomX * 3)
                { s = Otstup; s = s * 3; }
                if (idRoom == CoutRoomX * 4)
                { s = Otstup; s = s * 4; }

                switch (NumberRoom[idRoom])
                {
                    case 1:
                        TreasureRoom.Add(new RoomTreasure(new Vector2(das + (y * Otstup), 20 + s), idRoom));
                        break;
                    case 2:
                        switch (idMonstra)
                        {
                            case 1:
                                {
                                    Rat.Rats.Add(new Rat(new Vector2(das + (y * Otstup), 20 + s), idRoom));
                                    break;
                                }
                            case 2:
                                {
                                    Skeleton.skeletons.Add(new Skeleton(new Vector2(das + (y * Otstup), 20 + s), idRoom));
                                    break;
                                }
                            case 3:
                                {
                                    Spider.Spiders.Add(new Spider(new Vector2(das + (y * Otstup), 20 + s), idRoom));
                                    break;
                                }
                        }
                        break;
                    case 3:
                        HealRoom.Add(new RoomHeal(new Vector2(das + (y * Otstup), 20 + s), idRoom));
                        break;
                    case 4:
                        HealRoom.Add(new RoomHeal(new Vector2(das + (y * Otstup), 20 + s), idRoom));
                        break;
                }
            }
        }

        static public void Draw()
        {
            foreach(RoomTreasure room in TreasureRoom)
            {
                room.Draw();
            }
            
            foreach (Rat room in Rat.Rats)
            {
                room.Draw();
            }
            foreach (Skeleton room in Skeleton.skeletons)
            {
                room.Draw();
            }
            foreach (Spider room in Spider.Spiders)
            {
                room.Draw();
            }
            foreach (RoomHeal room in HealRoom)
            {
                room.Draw();
            }
        }

    }

}
