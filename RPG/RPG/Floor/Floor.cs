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
    class Floor
    {
        public static int numberFloor = 1;
        public static SpriteBatch spriteBatch;

        public static void newFloor(int idRoom)
        {
            RoomTreasure.TreasureRoom.Clear();
            RoomHeal.HealRoom.Clear();
            Rat.Rats.Clear();
            Skeleton.skeletons.Clear();
            Spider.Spiders.Clear();
            RoomRandomItem.RoomRandomItems.Clear();
            RoomRandomTrap.RoomRandomTraps.Clear();
            numberFloor++;
            Room.spriteBatch = spriteBatch;
            Room.Init(spriteBatch);
        }
    }
}
