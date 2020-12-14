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
    public class EnemyCharacter : Character
    {
        protected const int ROW = 7;
        protected const int COL = 4;
        private const int FRAMING_SPEED = 1;
        private const int MIN_XSPEED = 3;
        private const int MAX_XSPEED = 13;
        private int delay;

        int speed;
        Random random = new Random();

        public EnemyCharacter(Game game, SpriteBatch spriteBatch, Texture2D tex, Vector2 xspeed, int delay, Vector2 position, int rows, int cols)
            : base(game, spriteBatch, tex, xspeed, rows, cols, FRAMING_SPEED, position)
        {
            this.delay = delay;
            this.position.X = position.X - frameDimension.X + delay;
            this.position.Y = position.Y - frameDimension.Y;
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            speed = random.Next(MIN_XSPEED, MAX_XSPEED);
            position.X -= speed;

            if (position.X < -frameDimension.X)
            {
                position.X = Shared.stage.X + delay;
            }

            base.Update(gameTime);
        }
    }
}
