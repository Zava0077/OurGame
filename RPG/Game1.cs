using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    enum Stat
    {
        MainScreen,
        Game,
        Final
    }
    public class Game1 : Game
    {
        static public int[] Random(int min, int max)
        {
            Random rnd = new Random();
            int[] NumberRoom = new int[40];

            for (int i = 0; i < NumberRoom.Length; i++)
            {
                int random = rnd.Next(min, max);
                NumberRoom[i] = random;
            }
            return NumberRoom;
        }
        private Color _backgroundColour = Color.CornflowerBlue;
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private SpriteFont spriteFont;
        Stat status=Stat.MainScreen;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = 1000;
            graphics.PreferredBackBufferHeight = 850;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            spriteFont = Content.Load<SpriteFont>("File");
            RoomFight.texture = Content.Load<Texture2D>("Fight");
            RoomTreasure.texture = Content.Load<Texture2D>("Treasure");
            RoomHeal.texture = Content.Load<Texture2D>("Heal");
            Room.NumberRoom = Random(1,4);
            for(int i = 0; i < 40; i++)
            {
                Room.Ha = i;
                Room.Init(spriteBatch);
            }
        }
        private void RoomTreasure_click(object sender, System.EventArgs e)
        {
            Random random = new Random();
            _backgroundColour = new Color(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
        }
        private void RoomFight_click(object sender, System.EventArgs e)
        {
            Random random = new Random();
            _backgroundColour = new Color(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
        }
        private void RoomHeal_click(object sender, System.EventArgs e)
        {
            Random random = new Random();
            _backgroundColour = new Color(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
        }

        protected override void Update(GameTime gameTime)
        {
            switch (status)
            {
                case Stat.MainScreen:
                    {
                        foreach (RoomTreasure room in Room.TreasureRoom)
                        {
                            room.Click += RoomTreasure_click;
                            room.Update();
                        }
                        foreach (RoomFight room in Room.FightRoom)
                        {
                            room.Click += RoomFight_click;
                            room.Update();
                        }
                        foreach (RoomHeal room in Room.HealRoom)
                        {
                            room.Click += RoomHeal_click;
                            room.Update();
                        }
                        break;
                    }
                case Stat.Game:
                    {

                        break;
                    }
            }
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(_backgroundColour);
            spriteBatch.Begin();
            switch (status)
            {
                case Stat.MainScreen:
                    {
                        Room.Draw();
                        break;
                    }
                case Stat.Game:
                    {

                        break;
                    }
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
