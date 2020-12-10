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
    public class Life : DrawableGameComponent
    {
        protected SpriteBatch spriteBatch;

        private Vector2 initPosition;
        private Texture2D heart;
        private const int INITIAL_LIFE = 5;
        private Collision collision;
        private Vector2 position;
        private int currentLife;

        int space;

        public int CurrentLife { get => currentLife; set => currentLife = value; }

        public Life(Game game, SpriteBatch spriteBatch, Texture2D heart, Vector2 initPosition, Collision collision) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.heart = heart;
            this.initPosition = initPosition;
            this.collision = collision;

        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            for (int i = 0; i < INITIAL_LIFE - collision.ReduceLife; i++)
            {
                space = heart.Width * i;
                position.X = initPosition.X + space;
                position.Y = initPosition.Y;
                spriteBatch.Draw(heart, position, Color.White);
            }
            spriteBatch.End();

            currentLife = INITIAL_LIFE - collision.ReduceLife;

            base.Draw(gameTime);
        }

    }
}
