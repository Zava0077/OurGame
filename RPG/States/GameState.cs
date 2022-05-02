using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace RPG
{
    public class GameState : State
    {
        SpriteBatch SpriteBatch;

        public GameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content,SpriteBatch spriteBatch) : base(game, graphicsDevice, content)
        {
            Room.textureAllRooms = _content.Load<Texture2D>("TextureRoom");
            Room.Init(spriteBatch);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            Room.Draw();
            spriteBatch.End();
        }

        public override void PostUpdate(GameTime gameTime)
        {
        }

        public override void Update(GameTime gameTime)
        {
            foreach (RoomTreasure room in Room.TreasureRoom)
            {
                room.Update();
            }
            foreach (Rat room in Rat.Rats)
            {
                room.Update();
            }
            foreach (Skeleton room in Skeleton.skeletons)
            {
                room.Update();
            }
            foreach (Spider room in Spider.Spiders)
            {
                room.Update();
            }
            foreach (RoomHeal room in Room.HealRoom)
            {
                room.Update();
            }
            foreach (RoomRandomItem room in RoomRandomItem.RoomRandomItems)
            {
                room.Update();
            }
            foreach (RoomRandomTrap room in RoomRandomTrap.RoomRandomTraps)
            {
                room.Update();
            }
        }
    }
}
