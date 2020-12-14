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
using Microsoft.Xna.Framework.Media;

namespace TriciazAdventures
{
    public class ActionScene : GameScene
    {
        private SpriteBatch spriteBatch;
        private TriciazCharacter triciaz;
        private EnemyCharacter blueble;
        private EnemyCharacter flyingBlueble;
        private EnemyCharacter troll;
        private List<EnemyCharacter> enemiesCollision1 = new List<EnemyCharacter>();
        private List<EnemyCharacter> enemiesCollision2 = new List<EnemyCharacter>();
        private ScrollingBackground levelOneBackground;
        private ScrollingBackground levelTwoBackground;
        private ScrollingBackground levelOneBackgroundMessage;
        private ScrollingBackground levelTwoBackgroundMessage;
        private Collision charsCollision;
        private Collision charsCollision2;
        public Score score;
        public Score score2;
        private Life life;
        private Life life2;
        private GameOverScene gameOverScene;
        private Song gameSound;
        public Song GameSound { get => gameSound; set => gameSound = value; }
        SpriteFont font;

        Texture2D levelTwoTex;
        Texture2D levelTwoLetters;
        Texture2D levelOneLetters;

        bool isSecondLevelOn = false;

        public ActionScene(Game game, SpriteBatch spriteBatch, GameOverScene gameOverScene) : base(game)
        {
            this.spriteBatch = spriteBatch;

            Texture2D levelOneTex = game.Content.Load<Texture2D>("Images/Backgrounds/floresta2.2");
            levelTwoTex = game.Content.Load<Texture2D>("Images/Backgrounds/floresta3");
            levelOneLetters = game.Content.Load<Texture2D>("Images/GameRun/levelOne");
            levelTwoLetters = game.Content.Load<Texture2D>("Images/GameRun/levelTwo");
            Rectangle srcRect = new Rectangle(0, 0, levelOneTex.Width, levelOneTex.Height);
            Vector2 pos = new Vector2(0, Shared.stage.Y - srcRect.Height);
            Vector2 speed = new Vector2(2, 0);
            Texture2D triciaTex = game.Content.Load<Texture2D>("Images/Characters/Triciaz2.2");
            Texture2D bluebleTex = game.Content.Load<Texture2D>("Images/Characters/blueble");
            Texture2D flyingBluebleTex = game.Content.Load<Texture2D>("Images/Characters/flyingdrop2");
            Texture2D trollTex = game.Content.Load<Texture2D>("Images/Characters/troll2");
            GameSound = game.Content.Load<Song>("Sounds/trilha_jogo");
            SoundEffect damageSound = game.Content.Load<SoundEffect>("Sounds/damage");
            SoundEffect jumpSound = game.Content.Load<SoundEffect>("Sounds/jump3");
            Texture2D heart = game.Content.Load<Texture2D>("Images/GameRun/life");
            font = game.Content.Load<SpriteFont>("Fonts/ScoreFont");

            levelOneBackground = new ScrollingBackground(game, spriteBatch, levelOneTex, pos, srcRect, speed, GameSound);
            levelTwoBackground = new ScrollingBackground(game, spriteBatch, levelTwoTex, pos, srcRect, speed, GameSound);
            levelOneBackgroundMessage = new ScrollingBackground(game, spriteBatch, levelOneLetters, pos, srcRect, speed, GameSound);
            levelTwoBackgroundMessage = new ScrollingBackground(game, spriteBatch, levelTwoLetters, pos, srcRect, speed, GameSound);

            Vector2 triciaXSpeed = new Vector2(4, 0);
            Vector2 triciaYSpeed = new Vector2(0, 0);
            Vector2 triciazPosition = new Vector2(0, Shared.stage.Y);

            triciaz = new TriciazCharacter(game, spriteBatch, triciaTex, triciaXSpeed, triciaYSpeed, jumpSound, triciazPosition);

            Vector2 bluebleXSpeed = new Vector2(8, 0);
            Vector2 blueblePosition = new Vector2(Shared.stage.X, Shared.stage.Y);
            blueble = new EnemyCharacter(game, spriteBatch, bluebleTex, bluebleXSpeed, 0, blueblePosition, 7, 4);
            enemiesCollision1.Add(blueble);

            Vector2 flyingBluebleXSpeed = new Vector2(10, 0);
            Vector2 flyingBlueblePosition = new Vector2(Shared.stage.X, Shared.stage.Y - 450);
            flyingBlueble = new EnemyCharacter(game, spriteBatch, flyingBluebleTex, bluebleXSpeed, 2100, flyingBlueblePosition, 5, 3);

            Vector2 trollXSpeed = new Vector2(4, 0);
            Vector2 trollPosition = new Vector2(Shared.stage.X, Shared.stage.Y + 5);
            troll = new EnemyCharacter(game, spriteBatch, trollTex, trollXSpeed, 1600, trollPosition, 5, 5);
            enemiesCollision2.Add(flyingBlueble);
            enemiesCollision2.Add(troll);


            charsCollision = new Collision(game, triciaz, enemiesCollision1, damageSound);
            charsCollision2 = new Collision(game, triciaz, enemiesCollision2, damageSound);

            this.gameOverScene = gameOverScene;
            life = new Life(game, spriteBatch, heart, new Vector2(5, 5), charsCollision, this, this.gameOverScene);
            life2 = new Life(game, spriteBatch, heart, new Vector2(5, 5), charsCollision2, this, this.gameOverScene);

            score = new Score(game, spriteBatch, font, new Vector2(Shared.stage.X - 120, 10), Color.Cornsilk, life);
            score2 = new Score(game, spriteBatch, font, new Vector2(Shared.stage.X - 120, 10), Color.Cornsilk, life2);


            this.Scenes.Add(levelTwoBackground);
            this.Scenes.Add(levelTwoBackgroundMessage);
            this.Scenes.Add(levelOneBackground);
            this.Scenes.Add(levelOneBackgroundMessage);
            this.Scenes.Add(triciaz);
            this.Scenes.Add(blueble);
            this.Scenes.Add(charsCollision);
            this.Scenes.Add(score);
            this.Scenes.Add(life);
            this.Scenes.Add(gameOverScene);
        }

        public override void Update(GameTime gameTime)
        {
            if (score.ScoreCounter > 3)
            {
                this.Scenes.Remove(levelOneBackgroundMessage);
            }
            if (score.ScoreCounter > 10 && blueble.Position.X < 0)
            {
                this.Scenes.Remove(levelOneBackground);
                if (!isSecondLevelOn)
                {
                    this.Scenes.Add(flyingBlueble);
                    this.Scenes.Add(troll);
                    this.Scenes.Add(charsCollision2);
                    this.Scenes.Add(score2);
                    this.Scenes.Add(life2);

                    this.Scenes.Remove(blueble);
                    this.Scenes.Remove(life);
                    this.Scenes.Remove(charsCollision);
                    isSecondLevelOn = true;
                }

            }
            if (score.ScoreCounter > 15)
            {
                this.Scenes.Remove(levelTwoBackgroundMessage);

            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {            
            base.Draw(gameTime);
        }
    }
}
