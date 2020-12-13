using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TriciazAdventures
{
    public class PlayerNameInput : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private Texture2D inputName;
        private Rectangle inputNameRect;
        private Texture2D nameInput;
        public PlayerNameInput(Game game, ContentManager contentManager) : base(game)
        {
            //load the inputname textbox content
            //set the rectangle size based on the inputname content width and height

            nameInput = game.Content.Load<Texture2D>("Images/GameRun/nameInput");
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            //draw the inputname, rectangle, color.white
            spriteBatch.Draw(nameInput, new Vector2(Shared.stage.X / 4, Shared.stage.Y / 4), Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

    }
}
