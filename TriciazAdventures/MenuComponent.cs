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
    public class MenuComponent : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private SpriteFont normalFont;
        private SpriteFont selectedFont;
        private List<string> menuItems;
        private Vector2 textDimension;
        private int selectedIndex = 0;

        public int SelectedIndex { get => selectedIndex; set => selectedIndex = value; }

        private Vector2 position;
        private Color normalColor = Color.Black;
        private Color selectedColor = Color.Purple;

        private KeyboardState oldState;

        public MenuComponent(Game game, SpriteBatch spriteBatch, SpriteFont normalFont, SpriteFont selectedFont, string[] menus, string text) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.normalFont = normalFont;
            this.selectedFont = selectedFont;
            menuItems = menus.ToList<string>();
            textDimension = normalFont.MeasureString(text);

            position = new Vector2(Shared.stage.X / 2 - textDimension.X / 2, Shared.stage.Y / 2 - 70);
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState ks = Keyboard.GetState();

            if (ks.IsKeyDown(Keys.Down) && oldState.IsKeyUp(Keys.Down))
            {
                selectedIndex++;

                if (selectedIndex == menuItems.Count)
                {
                    selectedIndex = 0;
                }
            }

            if (ks.IsKeyDown(Keys.Up) && oldState.IsKeyUp(Keys.Up))
            {
                selectedIndex--;

                if (selectedIndex == -1)
                {
                    selectedIndex = menuItems.Count - 1;
                }
            }

            oldState = ks;

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            Vector2 temp = position;

            spriteBatch.Begin();

            for (int i = 0; i < menuItems.Count; i++)
            {
                if (selectedIndex == i)
                {
                    spriteBatch.DrawString(selectedFont, menuItems[i], temp, selectedColor);
                    temp.Y += selectedFont.LineSpacing;
                }
                else
                {
                    spriteBatch.DrawString(normalFont, menuItems[i], temp, normalColor);
                    temp.Y += normalFont.LineSpacing;

                }
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
