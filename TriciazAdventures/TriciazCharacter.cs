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
    public class TriciazCharacter : Character
    {

        private const int ROW = 4;
        private const int COL = 4;
        private const int FRAMING_SPEED  = 3;
        private const float INCREMENT_YSPEED = 1;
        private Vector2 jumpingSpeed;
        private Vector2 gravity;

        //private Color[] colorData;
        //private Color triciazColor;

        float startY = 0;
        bool isJumping;
        KeyboardState ks;

        //public Color[] ColorData { get => colorData; set => colorData = value; }
        //public Color TriciazColor { get => triciazColor; set => triciazColor = value; }

        public TriciazCharacter(Game game, SpriteBatch spriteBatch, Texture2D tex, Vector2 xspeed, Vector2 jumpingSpeed, Vector2 gravity) 
            : base(game, spriteBatch, tex, xspeed, ROW, COL, FRAMING_SPEED)
        {
            position = new Vector2(frameDimension.X, Shared.stage.Y - frameDimension.Y);
            this.jumpingSpeed = jumpingSpeed;
            this.gravity = gravity;
            startY = position.Y;
            isJumping = false;


            //triciazColor = Color.White;
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
        private void MoveUp()
        {
            position += jumpingSpeed;
            jumpingSpeed.Y += INCREMENT_YSPEED;

            if (position.Y >= startY)
            {
                position.Y = startY;
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
