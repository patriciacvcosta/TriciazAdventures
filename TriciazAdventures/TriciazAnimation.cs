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
        private Vector2 ySpeed;
        private Vector2 stage;
        private Vector2 dimension;
        private List<Rectangle> frames;
        private int frameIndex = -1;
        private int framingSpeed;
        private int framingSpeedCounter;
        private const int ROW = 4;
        private const int COL = 4;

        public Vector2 InitPosition { get => initPosition; set => initPosition = value; }

        public TriciazAnimation(Game game, SpriteBatch spriteBatch, Texture2D tex, Vector2 xspeed, Vector2 yspeed, Vector2 stage, int framingSpeed) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.tex = tex;
            this.initPosition = new Vector2(stage.X / 2 - 1150 / 2, stage.Y - 160);
            this.xSpeed = xspeed;
            this.ySpeed = yspeed;
            this.stage = stage;
            this.framingSpeed = framingSpeed;
            dimension = new Vector2(tex.Width / COL, tex.Height / ROW);

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
                    int x = j * (int)dimension.X;
                    int y = i * (int)dimension.Y;
                    Rectangle r = new Rectangle(x, y, (int)dimension.X, (int)dimension.Y);
                    frames.Add(r);
                }
            }
        }

        public void StartFrame()
        {
            frameIndex = -1;
            this.Enabled = true;
            this.Visible = true;

        }
        //public void hide()
        //{
        //    this.Enabled = false;
        //    this.Visible = false;
        //}

        public override void Draw(GameTime gameTime)
        {
            if (frameIndex >= 0)
            {
                spriteBatch.Begin();
                //version 4
                spriteBatch.Draw(tex, InitPosition, frames[frameIndex], Color.White);
                spriteBatch.End();

            }
            //spriteBatch.Begin();

            //spriteBatch.Draw(tex, position, Color.White);

            //spriteBatch.End();

            base.Draw(gameTime);

        }

        public override void Update(GameTime gameTime)
        {
            UpdateFrames();
            MoveHorizontal();
            MoveVertical();
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
                    frameIndex = -1;
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

                if (initPosition.X > stage.X - tex.Width/COL)
                {
                    initPosition.X = stage.X - tex.Width / COL;
                }
            }
        }
        private void MoveVertical()
        {
            KeyboardState ks = Keyboard.GetState();

            if (ks.IsKeyDown(Keys.Up))
            {
                initPosition -= ySpeed;

                if (initPosition.Y < stage.Y - 160*2)
                {
                    initPosition.Y = stage.Y - 160;
                }

            }
            //if (ks.IsKeyDown(Keys.Right))
            //{
            //    initPosition += speed;

            //    if (initPosition.X > stage.X - tex.Width / COL)
            //    {
            //        initPosition.X = stage.X - tex.Width / COL;
            //    }
            //}
        }
    }
}
