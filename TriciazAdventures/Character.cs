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
    public class Character : DrawableGameComponent
    {
        protected SpriteBatch spriteBatch;
        protected Texture2D tex;

        protected Vector2 position;
        protected Vector2 xSpeed;
        protected Vector2 frameDimension;
        protected List<Rectangle> frames;
        protected int frameIndex = 0;
        protected int framingSpeed;
        protected int framingSpeedCounter;
        protected int row;
        protected int col;

        public Vector2 XSpeed { get => xSpeed; set => xSpeed = value; }
        public Vector2 Position { get => position; set => position = value; }

        public Character(Game game, SpriteBatch spriteBatch, Texture2D tex, Vector2 xspeed, int rows, int cols, int framingSpeed) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.tex = tex;
            this.xSpeed = xspeed;
            this.framingSpeed = framingSpeed;
            this.row = rows;
            this.col = cols;

            frameDimension = new Vector2(tex.Width / col, tex.Height / row);

            StartFrame();
            GenerateFrames();
        }

        public override void Draw(GameTime gameTime)
        {
            if (frameIndex >= 0)
            {
                spriteBatch.Begin();

                spriteBatch.Draw(tex, position, frames[frameIndex], Color.White);
                spriteBatch.End();

            }

            base.Draw(gameTime);

        }
        public override void Update(GameTime gameTime)
        {
            UpdateFrames();
            base.Update(gameTime);

        }

        /// <summary>
        /// 
        /// </summary>
        protected void GenerateFrames()
        {
            frames = new List<Rectangle>();
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    int x = j * (int)frameDimension.X;
                    int y = i * (int)frameDimension.Y;
                    Rectangle r = new Rectangle(x, y, (int)frameDimension.X, (int)frameDimension.Y);
                    frames.Add(r);
                }
            }
        }


        protected void StartFrame()
        {
            frameIndex = 0;
            this.Enabled = true;
            this.Visible = true;

        }


        protected void UpdateFrames()
        {
            framingSpeedCounter++;
            if (framingSpeedCounter > framingSpeed)
            {
                frameIndex++;
                if (frameIndex > row * col - 1)
                {
                    frameIndex = 0;
                }

                framingSpeedCounter = 0;
            }
        }


        public Rectangle GetCharBoundary()
        {
            return new Rectangle((int)position.X, (int)position.Y, (int)frameDimension.X, (int)frameDimension.Y);
        }

    }
}
