using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RPG
{
    public class GameState : State
    {
        private List<Component> _components;

        SpriteBatch spriteBatch;
        public GameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content, SpriteBatch spriteBatch) : base(game, graphicsDevice, content)
        {
            Room.textureAllRooms = _content.Load<Texture2D>("TextureRoom");
            Inventory.textureAllSlots = _content.Load<Texture2D>("TextureRoom");
            Room.Init(spriteBatch);
            SecondInventory.Init(spriteBatch);
            Inventory.Init(spriteBatch);
            
            var hpBarTexture = _content.Load<Texture2D>("hp-bar");
            var expBarTexture = _content.Load<Texture2D>("exp-bar");
            var textFont = _content.Load<SpriteFont>("text");

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

            _components = new List<Component>()
            {
                hpBar,
                expBar,
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
            if (Game1.self.PlayerHP >= Game1.self.MaxHP)
                Game1.self.PlayerHP = Game1.self.MaxHP;
            if (Game1.self.Exp >= Game1.self.MaxExp)
            {     
                expOffset *= 2;
                int ostatok = (int)(Game1.self.Exp - Game1.self.MaxExp);
                Game1.self.MaxHP += 5;
                if(Game1.self.PlayerLVL % 10 == 0)
                    Game1.self.MaxHP += 5;
                Game1.self.Exp = 0+ostatok;
                Game1.self.PlayerLVL++;
                Game1.self.MaxExp += expOffset;
            }
            Room.Draw();
            SecondInventory.Draw();
            Inventory.Draw();
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
            Room.Update();
            SecondInventory.Update();
            Inventory.Update();
        }
    }
}
