using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TriciazAdventures
{
    public class TriciazCharacter : Character
    {

        private const int ROW = 4;
        private const int COL = 4;
        private const int FRAMING_SPEED = 3;
        private const float GRAVITY = 1;
        private const float INCREMENT_YSPEED = -28;

        private Vector2 triciazYSpeed;
        private SoundEffect jumpSound;

        public bool isColliding = false;

        float startY = 0;
        bool isJumping;
        KeyboardState ks;

        public TriciazCharacter(Game game, SpriteBatch spriteBatch, Texture2D tex, Vector2 triciazXSpeed, Vector2 triciazYSpeed, SoundEffect jumpSound, Vector2 position)
            : base(game, spriteBatch, tex, triciazXSpeed, ROW, COL, FRAMING_SPEED, position)
        {
            position = new Vector2(frameDimension.X, Shared.stage.Y - frameDimension.Y);

            this.position.X = position.X - frameDimension.X;
            this.position.Y = position.Y;

            this.triciazYSpeed = triciazYSpeed;
            startY = position.Y;
            isJumping = false;
            this.jumpSound = jumpSound;
        }

        public override void Update(GameTime gameTime)
        {
            UpdateFrames();
            MoveHorizontal();

            ks = Keyboard.GetState();

            if (isJumping)
            {
                ProcessJump();
            }
            else if (ks.IsKeyDown(Keys.Up))
            {
                StartJump();
            }

            base.Update(gameTime);
        }

        private void MoveHorizontal()
        {
            KeyboardState ks = Keyboard.GetState();

            if (ks.IsKeyDown(Keys.Left))
            {
                position -= xSpeed;

                if (position.X < 0)
                {
                    position.X = 0;
                }

            }
            if (ks.IsKeyDown(Keys.Right))
            {
                position += xSpeed;

                if (position.X > Shared.stage.X - tex.Width / COL)
                {
                    position.X = Shared.stage.X - tex.Width / COL;
                }
            }
        }
        private void ProcessJump()
        {
            position.Y += triciazYSpeed.Y;
            triciazYSpeed.Y += GRAVITY;

            if (position.Y >= startY)
            {
                triciazYSpeed.Y = 0;
                position.Y = startY;
                isJumping = false;
            }
        }

        private void StartJump()
        {
            isJumping = true;
            triciazYSpeed.Y += INCREMENT_YSPEED;
            jumpSound.Play();

        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
