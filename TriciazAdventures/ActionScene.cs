using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace TriciazAdventures
{
    public class ActionScene : GameScene
    {
        private SpriteBatch spriteBatch;
        private TriciazAnimation triciaz;
        private ScrollingBackground scrollingBackground;
        private Song gameSound;
        public Song GameSound { get => gameSound; set => gameSound = value; }
        //GraphicsDeviceManager graphics;

        public ActionScene(Game game, SpriteBatch spriteBatch) : base(game)
        {
            this.spriteBatch = spriteBatch;

            Texture2D backGroundTex = game.Content.Load<Texture2D>("Images/Backgrounds/floresta2.2");
            Rectangle srcRect = new Rectangle(0, 0, backGroundTex.Width, backGroundTex.Height);
            Vector2 pos = new Vector2(0, Shared.stage.Y - srcRect.Height);
            Vector2 speed = new Vector2(2, 0);
            GameSound = game.Content.Load<Song>("Sounds/trilha_jogo");

            scrollingBackground = new ScrollingBackground(game, spriteBatch, backGroundTex, pos, srcRect, speed, GameSound);
            
            Texture2D triciaTex = game.Content.Load<Texture2D>("Images/Characters/Triciaz2.2");
            Vector2 triciaXSpeed = new Vector2(4, 0);
            Vector2 triciaYSpeed = new Vector2(0, 4);

            triciaz = new TriciazAnimation(game, spriteBatch, triciaTex, triciaXSpeed, triciaYSpeed, 1);

            this.Scenes.Add(scrollingBackground);
            this.Scenes.Add(triciaz);

        }



        //override show method to make sure the bat will be t the start point everytime the game is started

    }
}
