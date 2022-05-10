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
        public Player player = new Player();
        SpriteBatch spriteBatch;
        public GameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content, SpriteBatch spriteBatch) : base(game, graphicsDevice, content)
        {
            Room.textureAllRooms = _content.Load<Texture2D>("TextureRoom");
            Inventory.textureAllSlots = _content.Load<Texture2D>("TextureRoom");
            Fight.texture = _content.Load<Texture2D>("TextureRoom");
            Floor.spriteBatch = spriteBatch;
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
            if (player.PlayerHP >= player.MaxHP)
                player.PlayerHP = player.MaxHP;
            if (player.Exp >= player.MaxExp)
            {
                Player.LevelUP();
            }
            if (Fight.isFight == true)
            {
                Fight.Draw(spriteBatch);
            }
            Nothing.nothing.Draw();
            Room.Draw();
            SecondInventory.Draw();
            Inventory.Draw();
            spriteBatch.DrawString(textFont, Player.player.PlayerLVL.ToString(), new Vector2((_game.Window.ClientBounds.Width / 2) - 50, _game.Window.ClientBounds.Height / 2 + 300), Color.Black);
            spriteBatch.End();
        }

        public override void PostUpdate(GameTime gameTime)
        {

        }

        public override void Update(GameTime gameTime)
        {
            if (Fight.isFight == true && Fight.Timer == false)
            {
                Fight.Update();
            }
            if (Fight.isFight == false && Fight.Timer == true)
            {
                Fight.AM.Dispose();
                Fight.AP.Dispose();
                Fight.Timer = false;
            }
            foreach (var component in _components)
                component.Update(gameTime);
            Nothing.nothing.Update();
            Room.Update();
            SecondInventory.Update();
            Inventory.Update();
        }
    }
}
