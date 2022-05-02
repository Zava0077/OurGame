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
            Skeleton.texture = _content.Load<Texture2D>("Skeleton");
            Rat.texture = _content.Load<Texture2D>("Rat");
            RoomTreasure.texture = _content.Load<Texture2D>("Treasure");
            RoomHeal.texture = _content.Load<Texture2D>("Heal");
            Spider.texture = _content.Load<Texture2D>("Spider");
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
                room.Click += room.RoomTreasure_click;
            }
            foreach (Rat room in Rat.Rats)
            {
                room.Update();
                room.Click += room.Rat_click;
            }
            foreach (Skeleton room in Skeleton.skeletons)
            {
                room.Update();
                room.Click += room.Skeleton_click;
            }
            foreach (Spider room in Spider.Spiders)
            {
                room.Update();
                room.Click += room.Spider_click;
            }
            foreach (RoomHeal room in Room.HealRoom)
            {
                room.Update();
                room.Click += room.RoomHeal_click;
            }
        }
    }
}
