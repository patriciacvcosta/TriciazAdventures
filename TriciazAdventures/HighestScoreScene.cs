using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace TriciazAdventures
{
    public class HighestScoreScene : GameScene
    {
        private SpriteBatch spriteBatch;
        private Texture2D tex;
        private Score score;
        SpriteFont regularFont;
        Vector2 position;

        public List<double> highestScores = new List<double>();
        public HighestScoreScene(Game game, SpriteBatch spriteBatch, Score score) : base(game)
        {
            this.spriteBatch = spriteBatch;
            tex = game.Content.Load<Texture2D>("Images/Backgrounds/highestscore");
            regularFont = game.Content.Load<SpriteFont>("Fonts/RegularFont");
            this.score = score;
            position = new Vector2(583, 200);
            score.GetScoresFromFile();
            highestScores = score.ScoreList.OrderByDescending(s => s).Take(10).ToList();
        }

        public override void Draw(GameTime gameTime)
        {
            Vector2 temp = position;
            spriteBatch.Begin();

            spriteBatch.Draw(tex, Vector2.Zero, Color.White);
            foreach (var item in highestScores)
            {
                spriteBatch.DrawString(regularFont, "[" + item + "]", temp, Color.Cornsilk);
                temp.Y += regularFont.LineSpacing;
            }            

            spriteBatch.End();

            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {


            base.Update(gameTime);
        }
    }
}
