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
<<<<<<< HEAD
        static public SpriteBatch spriteBatch { get; set; }
=======
        public static int CoutRoomX = 12;
        public static int CoutRoomY = 9;
        static public SpriteBatch spriteBatch { get; set; }

>>>>>>> 1b8b1a74e5d6f648d37441975f36ea9cc3b46176
        public static List<RoomTreasure> TreasureRoom = new List<RoomTreasure>();
        public static List<RoomHeal> HealRoom = new List<RoomHeal>();
        static public SpriteFont spriteFont { get; set; }
        public static int[] NumberRoom;
<<<<<<< HEAD
        public static int idRoom {get;set;}
        private static int s;
        static public int[] Random(int min, int max)
        {
            Random rnd = new Random();
            int[] NumberRoom = new int[40];
=======
        public static int idRoom { get; set; }
        public static Texture2D textureAllRooms { get; set; }

        static public int[] Random(int min, int max)
        {
            Random rnd = new Random();
            int[] NumberRoom = new int[CoutRoomX*CoutRoomY];
>>>>>>> 1b8b1a74e5d6f648d37441975f36ea9cc3b46176

            for (int i = 0; i < NumberRoom.Length; i++)
            {
                int random = rnd.Next(min, max);
                NumberRoom[i] = random;
            }
            return NumberRoom;
        }
        static public void Init(SpriteBatch spriteBatch)
        {
<<<<<<< HEAD
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
=======
            int x = 0;
            int y = -1;
            idRoom = 0;
            int Otstup = 70;
            int das = 40;
            Room.spriteBatch = spriteBatch;
            Random rnd = new Random();
            NumberRoom = Random(1, 4+1);
            for (; idRoom < CoutRoomX*CoutRoomY; idRoom++)
            {
                x++;
                if (idRoom % CoutRoomX == 0)
                {
                    x = 0;
                    y++;
                }
                int idMonstra = rnd.Next(1, 3+1);
                int idRandom = rnd.Next(1, 3);
                switch (NumberRoom[idRoom])
                {
                    case 1:
                        TreasureRoom.Add(new RoomTreasure(new Vector2(das + (x * Otstup), das+(y*Otstup)), idRoom, textureAllRooms));
>>>>>>> 1b8b1a74e5d6f648d37441975f36ea9cc3b46176
                        break;
                    case 2:
                        switch (idMonstra)
                        {
                            case 1:
                                {
<<<<<<< HEAD
                                    Rat.Rats.Add(new Rat(new Vector2(das + (y * Otstup), 20 + s), idRoom));
=======
                                    Rat.Rats.Add(new Rat(new Vector2(das + (x * Otstup), das + (y * Otstup)), idRoom, textureAllRooms));
>>>>>>> 1b8b1a74e5d6f648d37441975f36ea9cc3b46176
                                    break;
                                }
                            case 2:
                                {
<<<<<<< HEAD
                                    Skeleton.skeletons.Add(new Skeleton(new Vector2(das + (y * Otstup), 20 + s), idRoom));
=======
                                    Skeleton.skeletons.Add(new Skeleton(new Vector2(das + (x * Otstup), das + (y * Otstup)), idRoom, textureAllRooms));
>>>>>>> 1b8b1a74e5d6f648d37441975f36ea9cc3b46176
                                    break;
                                }
                            case 3:
                                {
<<<<<<< HEAD
                                    Spider.Spiders.Add(new Spider(new Vector2(das + (y * Otstup), 20 + s), idRoom));
=======
                                    Spider.Spiders.Add(new Spider(new Vector2(das + (x * Otstup), das + (y * Otstup)), idRoom, textureAllRooms));
>>>>>>> 1b8b1a74e5d6f648d37441975f36ea9cc3b46176
                                    break;
                                }
                        }
                        break;
                    case 3:
<<<<<<< HEAD
                        HealRoom.Add(new RoomHeal(new Vector2(das + (y * Otstup), 20 + s), idRoom));
                        break;
                    case 4:
                        HealRoom.Add(new RoomHeal(new Vector2(das + (y * Otstup), 20 + s), idRoom));
=======
                        HealRoom.Add(new RoomHeal(new Vector2(das + (x * Otstup), das + (y * Otstup)), idRoom, textureAllRooms));
                        break;
                    case 4:
                        switch (idRandom)
                        {
                            case 1:
                                {
                                    RoomRandomTrap.RoomRandomTraps.Add(new RoomRandomTrap(new Vector2(das + (x * Otstup), das + (y * Otstup)), idRoom, textureAllRooms));
                                    break;
                                }
                            case 2:
                                {
                                    RoomRandomItem.RoomRandomItems.Add(new RoomRandomItem(new Vector2(das + (x * Otstup), das + (y * Otstup)), idRoom, textureAllRooms));
                                    break;
                                }
                            case 3:
                                {

                                    break;
                                }
                        }
>>>>>>> 1b8b1a74e5d6f648d37441975f36ea9cc3b46176
                        break;
                }
            }
        }

        static public void Draw()
        {
<<<<<<< HEAD
            foreach(RoomTreasure room in TreasureRoom)
            {
                room.Draw();
            }
            
=======
            foreach (RoomTreasure room in TreasureRoom)
            {
                room.Draw();
            }
>>>>>>> 1b8b1a74e5d6f648d37441975f36ea9cc3b46176
            foreach (Rat room in Rat.Rats)
            {
                room.Draw();
            }
            foreach (Skeleton room in Skeleton.skeletons)
            {
                room.Draw();
            }
<<<<<<< HEAD
=======
            foreach (RoomRandomItem room in RoomRandomItem.RoomRandomItems)
            {
                room.Draw();
            }
            foreach (RoomRandomTrap room in RoomRandomTrap.RoomRandomTraps)
            {
                room.Draw();
            }
>>>>>>> 1b8b1a74e5d6f648d37441975f36ea9cc3b46176
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
