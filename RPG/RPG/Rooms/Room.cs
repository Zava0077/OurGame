﻿using System;
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
        public static int CoutRoomX = 12;
        public static int CoutRoomY = 9;
        static public SpriteBatch spriteBatch { get; set; }

        public static List<RoomTreasure> TreasureRoom = new List<RoomTreasure>();
        public static List<RoomHeal> HealRoom = new List<RoomHeal>();
        static public SpriteFont spriteFont { get; set; }
        public static int[] NumberRoom;
        public static int idRoom { get; set; }
        public static Texture2D textureAllRooms { get; set; }

        static public int[] Random(int min, int max)
        {
            Random rnd = new Random();
            int[] NumberRoom = new int[CoutRoomX*CoutRoomY];

            for (int i = 0; i < NumberRoom.Length; i++)
            {
                int random = rnd.Next(min, max);
                NumberRoom[i] = random;
            }
            return NumberRoom;
        }
        static public void Init(SpriteBatch spriteBatch)
        {
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
                        break;
                    case 2:
                        switch (idMonstra)
                        {
                            case 1:
                                {
                                    Rat.Rats.Add(new Rat(new Vector2(das + (x * Otstup), das + (y * Otstup)), idRoom, textureAllRooms));
                                    break;
                                }
                            case 2:
                                {
                                    Skeleton.skeletons.Add(new Skeleton(new Vector2(das + (x * Otstup), das + (y * Otstup)), idRoom, textureAllRooms));
                                    break;
                                }
                            case 3:
                                {
                                    Spider.Spiders.Add(new Spider(new Vector2(das + (x * Otstup), das + (y * Otstup)), idRoom, textureAllRooms));
                                    break;
                                }
                        }
                        break;
                    case 3:
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
                        break;
                }
            }
        }

        static public void Draw()
        {
            foreach (RoomTreasure room in TreasureRoom)
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
            foreach (RoomRandomItem room in RoomRandomItem.RoomRandomItems)
            {
                room.Draw();
            }
            foreach (RoomRandomTrap room in RoomRandomTrap.RoomRandomTraps)
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
