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

        public SoundEffect GameOverSound { get => gameOverSound; set => gameOverSound = value; }
        public MenuComponent Menu { get => menu; set => menu = value; }

        private string[] menuItems = { "Main Menu", "Play Again" };

        public GameOverScene(Game game, SpriteBatch spriteBatch) : base(game)
        {
            this.spriteBatch = spriteBatch;
            tex = game.Content.Load<Texture2D>("Images/Backgrounds/game-over2");
            SpriteFont regularFont = game.Content.Load<SpriteFont>("Fonts/GameOverFont");
            SpriteFont highlightFont = game.Content.Load<SpriteFont>("Fonts/GameOverHighlightFont");
            gameOverSound = game.Content.Load<SoundEffect>("Sounds/lose2");

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
