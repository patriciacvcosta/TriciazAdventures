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
    public class TriciazAnimation : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private Texture2D tex;

        private Vector2 initPosition;
        private Vector2 xSpeed;
        private Vector2 jumpingSpeed;
        private Vector2 gravity;
        private Vector2 frameDimension;
        private List<Rectangle> frames;
        private int frameIndex = 0;
        private int framingSpeed;
        private int framingSpeedCounter;
        private const int ROW = 4;
        private const int COL = 4;
        
        private const float INCREMENT_SPEED = 1;

        float startY = 0;
        bool isJumping;
        KeyboardState ks;

        public TriciazAnimation(Game game, SpriteBatch spriteBatch, Texture2D tex, Vector2 xspeed, Vector2 jumpingSpeed, Vector2 gravity, int framingSpeed) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.tex = tex;
            initPosition = new Vector2(Shared.stage.X / 2 - 1150 / 2, Shared.stage.Y - 160);
            this.xSpeed = xspeed;
            this.jumpingSpeed = jumpingSpeed;
            this.gravity = gravity;
            this.framingSpeed = framingSpeed;

            frameDimension = new Vector2(tex.Width / COL, tex.Height / ROW);            
            startY = initPosition.Y;
            isJumping = false;

            StartFrame();
            GenerateFrames();
        }

        private void GenerateFrames()
        {
            frames = new List<Rectangle>();
            for (int i = 0; i < ROW; i++)
            {
                for (int j = 0; j < COL; j++)
                {
                    int x = j * (int)frameDimension.X;
                    int y = i * (int)frameDimension.Y;
                    Rectangle r = new Rectangle(x, y, (int)frameDimension.X, (int)frameDimension.Y);
                    frames.Add(r);
                }
            }
        }

        public void StartFrame()
        {
            frameIndex = 0;
            this.Enabled = true;
            this.Visible = true;

        }

        public override void Draw(GameTime gameTime)
        {
            if (frameIndex >= 0)
            {
                spriteBatch.Begin();

                spriteBatch.Draw(tex, initPosition, frames[frameIndex], Color.White);
                spriteBatch.End();

            }

            base.Draw(gameTime);

        }

        public override void Update(GameTime gameTime)
        {
            UpdateFrames();
            MoveHorizontal();

            ks = Keyboard.GetState();

            if (isJumping)
            {
                MoveUp();
            }
            else
            {
                ApplyGravity();
            }           

            base.Update(gameTime);
            
        }

        private void UpdateFrames()
        {
            framingSpeedCounter++;
            if (framingSpeedCounter > framingSpeed)
            {
                frameIndex++;
                if (frameIndex > ROW * COL - 1)
                {
                    frameIndex = 0;
                }

                framingSpeedCounter = 0;
            }
        }

        private void MoveHorizontal()
        {
            KeyboardState ks = Keyboard.GetState();

            if (ks.IsKeyDown(Keys.Left))
            {
                initPosition -= xSpeed;

                if (initPosition.X < 0)
                {
                    initPosition.X = 0;
                }

            }
            if (ks.IsKeyDown(Keys.Right))
            {
                initPosition += xSpeed;

                if (initPosition.X > Shared.stage.X - tex.Width / COL)
                {
                    initPosition.X = Shared.stage.X - tex.Width / COL;
                }
            }
        }
        private void MoveUp()
        {
            initPosition += jumpingSpeed;
            jumpingSpeed.Y += INCREMENT_SPEED;

            if (initPosition.Y >= startY)
            {
                initPosition.Y = startY;
                isJumping = false;

            }
        }

        private void ApplyGravity()
        {
            if (ks.IsKeyDown(Keys.Up))
            {
                isJumping = true;
                jumpingSpeed -= gravity;
            }

        }
    }
}
