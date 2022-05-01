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
        public GameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {


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
                room.Click += room.RoomTreasure_click;
                room.Update();
            }
            foreach (RoomFight room in Room.FightRoom)
            {
                room.Click += room.RoomFight_click;
                room.Update();
            }
            foreach (RoomHeal room in Room.HealRoom)
            {
                room.Click += room.RoomHeal_click;
                room.Update();
            }
        }
    }
}
