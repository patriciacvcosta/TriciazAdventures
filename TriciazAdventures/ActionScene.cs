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
    public class ActionScene : GameScene
    {
        private SpriteBatch spriteBatch;
        private TriciazAnimation triciaz;
        private ScrollingBackground scrollingBackground;

        //GraphicsDeviceManager graphics;

        public ActionScene(Game game, SpriteBatch spriteBatch) : base(game)
        {
            this.spriteBatch = spriteBatch;

            Vector2 stage = new Vector2(1280, 720);

            Texture2D backGroundTex = game.Content.Load<Texture2D>("Images/Backgrounds/floresta2.2");
            Rectangle srcRect = new Rectangle(0, 0, backGroundTex.Width, backGroundTex.Height);
            Vector2 pos = new Vector2(0, stage.Y - srcRect.Height);
            Vector2 speed = new Vector2(2, 0);

            scrollingBackground = new ScrollingBackground(game, spriteBatch, backGroundTex, pos, srcRect, speed);

            Texture2D triciaTex = game.Content.Load<Texture2D>("Images/Characters/Triciaz2.2");
            Vector2 triciaXSpeed = new Vector2(4, 0);
            Vector2 triciaYSpeed = new Vector2(0, 4);

            triciaz = new TriciazAnimation(game, spriteBatch, triciaTex, triciaXSpeed, triciaYSpeed, stage, 1);

            this.Scenes.Add(scrollingBackground);
            this.Scenes.Add(triciaz);

        }


        //override show method to make sure the bat will be t the start point everytime the game is started

    }
}
