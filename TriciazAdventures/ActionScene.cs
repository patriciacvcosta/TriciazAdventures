using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace TriciazAdventures
{
    public class ActionScene : GameScene
    {
        private SpriteBatch spriteBatch;
        private TriciazCharacter triciaz;
        private BluebleCharacter blueble;
        private ScrollingBackground scrollingBackground;
        private Collision charsCollision;
        private Score score;
        private Life life;
        private GameOverScene gameOverScene;
        private Song gameSound;
        public Song GameSound { get => gameSound; set => gameSound = value; }

        private const float GRAVITY = 28;

        public ActionScene(Game game, SpriteBatch spriteBatch, GameOverScene gameOverScene) : base(game)
        {
            this.spriteBatch = spriteBatch;

            Texture2D backGroundTex = game.Content.Load<Texture2D>("Images/Backgrounds/floresta2.2");
            Rectangle srcRect = new Rectangle(0, 0, backGroundTex.Width, backGroundTex.Height);
            Vector2 pos = new Vector2(0, Shared.stage.Y - srcRect.Height);
            Vector2 speed = new Vector2(2, 0);
            Texture2D triciaTex = game.Content.Load<Texture2D>("Images/Characters/Triciaz2.2");
            Texture2D bluebleTex = game.Content.Load<Texture2D>("Images/Characters/blueble");
            GameSound = game.Content.Load<Song>("Sounds/trilha_jogo");
            SoundEffect damageSound = game.Content.Load<SoundEffect>("Sounds/damage");
            SoundEffect jumpSound = game.Content.Load<SoundEffect>("Sounds/jump3");
            Texture2D heart = game.Content.Load<Texture2D>("Images/GameRun/life");
            SpriteFont font = game.Content.Load<SpriteFont>("Fonts/ScoreFont");

            scrollingBackground = new ScrollingBackground(game, spriteBatch, backGroundTex, pos, srcRect, speed, GameSound);

            Vector2 triciaXSpeed = new Vector2(4, 0);
            Vector2 triciaYSpeed = new Vector2(0, 0);
            Vector2 gravity = new Vector2(0, GRAVITY);
            triciaz = new TriciazCharacter(game, spriteBatch, triciaTex, triciaXSpeed, triciaYSpeed, gravity, jumpSound);

            Vector2 bluebleXSpeed = new Vector2(8, 0);
            blueble = new BluebleCharacter(game, spriteBatch, bluebleTex, bluebleXSpeed);

            charsCollision = new Collision(game, triciaz, blueble, damageSound);

            this.gameOverScene = gameOverScene;
            life = new Life(game, spriteBatch, heart, new Vector2(5, 5), charsCollision, this, this.gameOverScene);

            score = new Score(game, spriteBatch, font, new Vector2(Shared.stage.X - 120, 10), "", Color.Cornsilk);



            this.Scenes.Add(scrollingBackground);
            this.Scenes.Add(triciaz);
            this.Scenes.Add(blueble);
            this.Scenes.Add(charsCollision);
            this.Scenes.Add(score);
            this.Scenes.Add(life);
            this.Scenes.Add(gameOverScene);


        }

        public override void Update(GameTime gameTime)
        {
            score.ScoreMsg = "[" + Math.Round(gameTime.TotalGameTime.TotalSeconds, 2) + "]";
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
