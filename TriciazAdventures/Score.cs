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
        private string scoreMsg;
        private Vector2 position;
        private Color textColor;

        public string ScoreMsg { get => scoreMsg; set => scoreMsg = value; }

        public Score(Game game, SpriteBatch spriteBatch, SpriteFont font, Vector2 position, string scoreMsg, Color textColor) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.font = font;
            this.position = position;
            this.scoreMsg = scoreMsg;
            this.textColor = textColor;
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(font, scoreMsg, position, textColor);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
