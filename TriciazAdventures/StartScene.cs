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
    public class StartScene : GameScene
    {
        private SpriteBatch spriteBatch;
        private SpriteFont gameTitle;
        private Vector2 titlePosition;
        private Vector2 titleDimension;
        private Texture2D menuBackGroundTex;
        private MenuComponent menu;
        public MenuComponent Menu { get => menu; set => menu = value; }

        private string[] menuItems = { "Start Game!", "How To Play", "Highest Scores", "About", "Quit" };
        private string title = "The Adventures Of Triciaz";

        public StartScene(Game game, SpriteBatch spriteBatch) : base(game)
        {
            this.spriteBatch = spriteBatch;

            SpriteFont regularFont = game.Content.Load<SpriteFont>("Fonts/RegularFont");
            SpriteFont highlightFont = game.Content.Load<SpriteFont>("Fonts/HighlightFont");
            menuBackGroundTex = game.Content.Load<Texture2D>("Images/Backgrounds/mainscreen2");
            gameTitle = game.Content.Load<SpriteFont>("Fonts/TitleFont");

            titleDimension = gameTitle.MeasureString(title);
            titlePosition = new Vector2(Shared.stage.X / 2 - titleDimension.X / 2, titleDimension.Y);
            menu = new MenuComponent(game, spriteBatch, regularFont, highlightFont, menuItems, menuItems[2]);

            this.Scenes.Add(menu);

        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(menuBackGroundTex, Vector2.Zero, Color.White);
            spriteBatch.DrawString(gameTitle, title, titlePosition, Color.Black);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
