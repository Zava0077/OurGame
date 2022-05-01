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
        public static List<RoomFight> FightRoom = new List<RoomFight>();
        static public SpriteFont spriteFont { get; set; }
        public static int[] NumberRoom;
        public static int Ha {get;set;}
        private static int s;
        static public void Init(SpriteBatch spriteBatch)
        {
            int y = 0;
            int CoutRoomX = 8;
            int Otstup = 110;
            int das = 65;
            Room.spriteBatch = spriteBatch;
            for (int i = 0; i < Ha;i++)
            {
                y++;
                if (y % CoutRoomX == 0)
                {
                    y = 0;
                }
            }
            if (Ha == CoutRoomX) 
                s = Otstup;
            if (Ha == CoutRoomX*2) 
            { s = Otstup; s = s * 2; }
            if (Ha == CoutRoomX*3) 
            { s = Otstup; s = s * 3; }
            if (Ha == CoutRoomX*4) 
            { s = Otstup; s = s * 4; }

            switch (NumberRoom[Ha])
            {
                case 1:
                    TreasureRoom.Add(new RoomTreasure(new Vector2(das+(y * Otstup), 20 +s)));
                    break;
                case 2:
                    FightRoom.Add(new RoomFight(new Vector2(das+(y * Otstup), 20 +s)));
                    break;
                case 3:
                    HealRoom.Add(new RoomHeal(new Vector2(das+(y * Otstup), 20 +s)));
                    break;
            }
        }

        static public void Draw()
        {
            foreach(RoomTreasure room in TreasureRoom)
            {
                room.Draw();
            }
            foreach (RoomFight room in FightRoom)
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
