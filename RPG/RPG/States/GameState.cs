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
            Room.Update();
        }
    }
}
