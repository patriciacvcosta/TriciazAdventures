using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Threading;

namespace TriciazAdventures
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Song gameTheme;
        bool isGameThemePlaying = false;
        bool isGameOverPlaying = false;
        //TriciazAnimation triciaz;

        private StartScene startScene;
        private ActionScene actionScene;
        private HowToPlayScene howToPlayScene;
        private AboutScene aboutScene;
        private GameOverScene gameOverScene;
        private HighestScoreScene highestScoreScene;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            IsMouseVisible = true;

            graphics.PreferredBackBufferWidth = 1280;  // set this value to the desired width of your window
            graphics.PreferredBackBufferHeight = 720;   // set this value to the desired height of your window
            graphics.ApplyChanges();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            Shared.stage = new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            gameTheme = this.Content.Load<Song>("Sounds/staticscenessound2");
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            startScene = new StartScene(this, spriteBatch);
            this.Components.Add(startScene);

            gameOverScene = new GameOverScene(this, spriteBatch);
            this.Components.Add(gameOverScene);

            actionScene = new ActionScene(this, spriteBatch, gameOverScene);
            this.Components.Add(actionScene);

            howToPlayScene = new HowToPlayScene(this, spriteBatch);
            this.Components.Add(howToPlayScene);

            aboutScene = new AboutScene(this, spriteBatch);
            this.Components.Add(aboutScene);

            highestScoreScene = new HighestScoreScene(this, spriteBatch, actionScene.score);
            this.Components.Add(highestScoreScene);

            startScene.ShowScene();


        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            //    Exit();

            // TODO: Add your update logic here

            int selectedIndex = 0;
            int gameOverIndex = 0;

            KeyboardState ks = Keyboard.GetState();
            

            if (startScene.Enabled)
            {
                if (!isGameThemePlaying)
                {
                    MediaPlayer.IsRepeating = true;
                    MediaPlayer.Play(gameTheme);
                    isGameThemePlaying = true;
                }
                selectedIndex = startScene.Menu.SelectedIndex;
                if (selectedIndex == 0 && ks.IsKeyDown(Keys.Enter))
                {
                    gameTime.TotalGameTime = new System.TimeSpan(0);
                    isGameThemePlaying = false;
                    startScene.HideScene();
                    actionScene.ShowScene();
                    MediaPlayer.IsRepeating = true;
                    MediaPlayer.Play(actionScene.GameSound);


                }
                if (selectedIndex == 1 && ks.IsKeyDown(Keys.Enter))
                {
                    startScene.HideScene();
                    howToPlayScene.ShowScene();

                }
                if (selectedIndex == 2 && ks.IsKeyDown(Keys.Enter))
                {
                    startScene.HideScene();
                    highestScoreScene = new HighestScoreScene(this, spriteBatch, actionScene.score);
                    this.Components.Add(highestScoreScene);
                    highestScoreScene.ShowScene();
                }
                if (selectedIndex == 3 && ks.IsKeyDown(Keys.Enter))
                {
                    aboutScene.HideScene();
                    aboutScene.ShowScene();
                }
                if (selectedIndex == 4 && ks.IsKeyDown(Keys.Enter))
                {
                    Exit();
                }
            }
            if (actionScene.Enabled)
            {
                //gameOverScene.HideScene();
                //gameOverScene.Enabled = false;
                if (ks.IsKeyDown(Keys.Escape))
                {
                    actionScene.HideScene();
                    startScene.ShowScene();
                    MediaPlayer.Play(gameTheme);
                }
            }
            if (gameOverScene.Enabled)
            {
                gameOverIndex = gameOverScene.Menu.SelectedIndex;
                if (!isGameOverPlaying)
                {
                    gameOverScene.GameOverSound.Play();
                    isGameOverPlaying = true;
                }
                if (gameOverIndex == 0 && ks.IsKeyDown(Keys.Enter))
                {
                    ResetGame();
                    actionScene.HideScene();
                    startScene.Enabled = true;
                    startScene.ShowScene();                    
                    Thread.Sleep(200);
                }
                if (gameOverIndex == 1 && ks.IsKeyDown(Keys.Enter))
                {
                    ResetGame();
                    MediaPlayer.IsRepeating = true;
                    MediaPlayer.Play(actionScene.GameSound);
                    gameTime.TotalGameTime = new System.TimeSpan(0);
                    actionScene.Enabled = true;
                    actionScene.ShowScene();
                }

            }
            if (howToPlayScene.Enabled)
            {
                if (ks.IsKeyDown(Keys.Escape))
                {
                    howToPlayScene.HideScene();
                    startScene.ShowScene();
                }
            }
            if (aboutScene.Enabled)
            {
                if (ks.IsKeyDown(Keys.Escape))
                {
                    aboutScene.HideScene();
                    startScene.ShowScene();
                }
            }
            if (highestScoreScene.Enabled)
            {
                if (ks.IsKeyDown(Keys.Escape))
                {
                    highestScoreScene.HideScene();
                    startScene.ShowScene();
                }
            }


            base.Update(gameTime);
        }

        private void ResetGame()
        {
            //gameOverScene.GameOverSound.Dispose();
            gameOverScene.HideScene();
            gameOverScene.Enabled = false;
            this.Components.Remove(gameOverScene);
            this.Components.Remove(actionScene);
            gameOverScene = new GameOverScene(this, spriteBatch);
            actionScene = new ActionScene(this, spriteBatch, gameOverScene);
            this.Components.Add(gameOverScene);
            this.Components.Add(actionScene);
            isGameOverPlaying = false;
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
