using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace TriciazAdventures
{
    public class GameOverScene : GameScene
    {
        private SpriteBatch spriteBatch;
        private Texture2D tex;
        private MenuComponent menu;
        private SoundEffect gameOverSound;


        private Texture2D nameInput;
        private Rectangle inputNameRect;

        public SoundEffect GameOverSound { get => gameOverSound; set => gameOverSound = value; }
        public MenuComponent Menu { get => menu; set => menu = value; }

        private string[] menuItems = { "Main Menu", "Play Again" };

        public GameOverScene(Game game, SpriteBatch spriteBatch) : base(game)
        {
            this.spriteBatch = spriteBatch;
            tex = game.Content.Load<Texture2D>("Images/Backgrounds/game-over2");
            nameInput = game.Content.Load<Texture2D>("Images/GameRun/nameInput");
            SpriteFont regularFont = game.Content.Load<SpriteFont>("Fonts/RegularFont");
            SpriteFont highlightFont = game.Content.Load<SpriteFont>("Fonts/HighlightFont");
            gameOverSound = game.Content.Load<SoundEffect>("Sounds/lose2");

            inputNameRect = new Rectangle(0, 0, nameInput.Width, nameInput.Height);
            menu = new MenuComponent(game, spriteBatch, regularFont, highlightFont, menuItems, menuItems[0]);
            this.Scenes.Add(menu);
        }


        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(tex, Vector2.Zero, Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            MediaPlayer.Stop();


            base.Update(gameTime);
        }
    }
}
