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
    public class GameScene : DrawableGameComponent
    {
        private List<GameComponent> scenes;
        public List<GameComponent> Scenes { get => scenes; set => scenes = value; }

        public virtual void ShowScene()
        {
            this.Enabled = true;
            this.Visible = true;

        }
        public virtual void HideScene()
        {
            this.Enabled = false;
            this.Visible = false;

        }

        public GameScene(Game game) : base(game)
        {
            scenes = new List<GameComponent>();
            HideScene();
        }


        public override void Draw(GameTime gameTime)
        {
            DrawableGameComponent component = null;

            foreach (GameComponent item in scenes)
            {
                if (item is DrawableGameComponent)
                {
                    component = (DrawableGameComponent)item;

                    if (component.Visible)
                    {
                        component.Draw(gameTime);
                    }
                }
            }

            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            foreach (GameComponent item in scenes)
            {
                if (item.Enabled)
                {
                    item.Update(gameTime);
                }
            }

            base.Update(gameTime);
        }
    }
}
