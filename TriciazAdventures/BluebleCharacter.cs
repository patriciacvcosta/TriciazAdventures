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
    class BluebleCharacter : Character
    {
        protected const int ROW = 7;
        protected const int COL = 4;
        private const int FRAMING_SPEED = 1;

        private const int MIN_XSPEED = 1;
        private const int MAX_XSPEED = 20;
        int speed;
        Random random;

        public BluebleCharacter(Game game, SpriteBatch spriteBatch, Texture2D tex, Vector2 xspeed) 
            : base(game, spriteBatch, tex, xspeed, ROW, COL, FRAMING_SPEED)
        {
            position = new Vector2(Shared.stage.X - frameDimension.X, Shared.stage.Y - frameDimension.Y);

            random = new Random();
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            speed = random.Next(MIN_XSPEED, MAX_XSPEED);
            position.X -= speed;

            if (position.X < 0)
            {
                position.X = Shared.stage.X;
            }

            base.Update(gameTime);
        }
    }
}
