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
        private List<Component> _components;
        SpriteBatch SpriteBatch;
        public GameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content, SpriteBatch spriteBatch) : base(game, graphicsDevice, content)
        {


            Skeleton.texture = _content.Load<Texture2D>("Skeleton");
            Rat.texture = _content.Load<Texture2D>("Rat");
            RoomTreasure.texture = _content.Load<Texture2D>("Treasure");
            RoomHeal.texture = _content.Load<Texture2D>("Heal");
            Spider.texture = _content.Load<Texture2D>("Spider");
            Room.Init(spriteBatch);
            
            var hpBarTexture = _content.Load<Texture2D>("hp-bar");
            var expBarTexture = _content.Load<Texture2D>("exp-bar");
            var textFont = _content.Load<SpriteFont>("text");
            var levelBoxTexture = _content.Load<Texture2D>("levelNumber");

            var hpBar = new SpriteLoad2(hpBarTexture, textFont)
            {
                Position = new Vector2(_game.Window.ClientBounds.Width / 2, _game.Window.ClientBounds.Height / 2 + 300),
                Text = "",
            };
            var expBar = new ExpBarLoad(expBarTexture, textFont)
            {
                Position = new Vector2(_game.Window.ClientBounds.Width / 2, _game.Window.ClientBounds.Height / 2 + 350),
                Text = "",
            };

            var levelBox = new SpriteLoad(levelBoxTexture, textFont)
            {
                Position = new Vector2((_game.Window.ClientBounds.Width / 2) - 50, _game.Window.ClientBounds.Height / 2 + 300),
                Text = "",
            };

            
            _components = new List<Component>()
            {
                hpBar,
                expBar,
                levelBox,
            };
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {

            var expBarTexture = _content.Load<Texture2D>("exp-bar");
            var textFont = _content.Load<SpriteFont>("text");
            ExpBarLoad ebl = new ExpBarLoad(expBarTexture, textFont);
            spriteBatch.Begin(); 
            foreach (var component in _components)
                component.Draw(gameTime, spriteBatch);

            int expOffset = 28;
            if (Game1.self.Exp >= Game1.self.MaxExp)
            {
                expOffset *= 2;
                Game1.self.Exp = 1;
                Game1.self.PlayerLVL++;
                Game1.self.MaxExp += expOffset;
                //ebl.x = (Game1.self.MaxExp/Game1.self.Exp)*100;
            }
            

            
            Room.Draw();
            spriteBatch.DrawString(textFont, Game1.self.PlayerLVL.ToString(), new Vector2((_game.Window.ClientBounds.Width / 2) - 50, _game.Window.ClientBounds.Height / 2 + 300), Color.Black);
            spriteBatch.End();
        }

        public override void PostUpdate(GameTime gameTime)
        {

        }

        public override void Update(GameTime gameTime)
        {
            foreach (var component in _components)
                component.Update(gameTime);

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
        }
    }
}
