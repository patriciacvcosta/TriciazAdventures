using System;
using System.Collections.Generic;
using System.IO;
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
        private double scoreCounter;
        private Vector2 position;
        private Color textColor;
        private Life life;


        public List<double> ScoreList = new List<double>();
        public double ScoreCounter { get => scoreCounter; set => scoreCounter = value; }

        public Score(Game game, SpriteBatch spriteBatch, SpriteFont font, Vector2 position, Color textColor, Life life) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.font = font;
            this.position = position;
            this.textColor = textColor;
            this.life = life;
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

            scoreCounter = Math.Round(gameTime.TotalGameTime.TotalSeconds, 2);
            if (life.CurrentLife == 0)
            {
                GetScoresFromFile();
                SaveScore();

            }

            base.Update(gameTime);
        }

        private void SaveScore()
        {
            ScoreList.Add(scoreCounter);

            try
            {
                using (StreamWriter writer = new StreamWriter(@"test.txt"))
                {
                    for (int i = 0; i < ScoreList.Count; i++)
                    {
                        writer.WriteLine(ScoreList[i]);
                    }

                }
            }
            catch (Exception)
            {
                MessageBox.Show("The Adventures Of Triciaz", "Something went wrong... Score wasn't saved.", new List<string>() { "Ok" });
            }
        }

        public void GetScoresFromFile()
        {
            ScoreList.Clear();
            try
            {
                using (StreamReader reader = new StreamReader(@"test.txt"))
                {
                    while (!reader.EndOfStream)
                    {
                        ScoreList.Add(Convert.ToDouble(reader.ReadLine()));

                    }
                }
            }
            catch (Exception)
            {

                MessageBox.Show("The Adventures Of Triciaz", "Something went wrong... Scores couldn't be read.", new List<string>() { "Ok" });
            }
        }
    }
}
