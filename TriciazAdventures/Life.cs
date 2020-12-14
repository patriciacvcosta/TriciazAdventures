using System;
using System.Collections.Generic;
using System.IO;
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
    public class Life : DrawableGameComponent
    {
        protected SpriteBatch spriteBatch;

        private Vector2 initPosition;
        private Texture2D heart;
        private const int INITIAL_LIFE = 5;
        private Collision collision;
        private Vector2 position;
        private int currentLife;
        private ActionScene actionScene;
        GameOverScene gameOverScene;
        int space;

        public int CurrentLife { get => currentLife; set => currentLife = value; }

        public Life(Game game, SpriteBatch spriteBatch, Texture2D heart, Vector2 initPosition, Collision collision, ActionScene actionScene,
            GameOverScene gameOverScene) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.heart = heart;
            this.initPosition = initPosition;
            this.collision = collision;
            this.actionScene = actionScene;
            this.gameOverScene = gameOverScene;

            currentLife = INITIAL_LIFE;
        }

        public override void Draw(GameTime gameTime)
        {
            currentLife = INITIAL_LIFE - collision.ReduceLife;

            spriteBatch.Begin();

            for (int i = 0; i < currentLife; i++)
            {
                space = heart.Width * i;
                position.X = initPosition.X + space;
                position.Y = initPosition.Y;
                spriteBatch.Draw(heart, position, Color.White);
            }
            spriteBatch.End();


            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            if (currentLife == 0)
            {
                GameOver();
            }

            base.Update(gameTime);
        }

        private void GameOver()
        {
            actionScene.Enabled = false;
            gameOverScene.Enabled = true;
            gameOverScene.ShowScene();
        }

    }
}
