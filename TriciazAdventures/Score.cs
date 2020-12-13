using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TriciazAdventures
{
    public class Score : DrawableGameComponent
    {
        protected SpriteBatch spriteBatch;

        private SpriteFont font;
        private string scoreCounter;
        private Vector2 position;
        private Color textColor;

        public string ScoreCounter { get => scoreCounter; set => scoreCounter = value; }

        public Score(Game game, SpriteBatch spriteBatch, SpriteFont font, Vector2 position, Color textColor) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.font = font;
            this.position = position;
            this.textColor = textColor;
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(font, scoreCounter.ToString(), position, textColor);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {

            scoreCounter = Math.Round(gameTime.TotalGameTime.TotalSeconds, 2).ToString();
            base.Update(gameTime);
        }
    }
}
