using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TriciazAdventures
{
    class Collision : GameComponent
    {
        private TriciazCharacter triciaz;
        private BluebleCharacter blueble;
        private SoundEffect damageSound;
        private Texture2D tex;

        Vector2 initSpeed;
        Vector2 initPosition;
        bool isColliding;

        //Color[] regTriciazColor;
        //Color collidedColor;
        //Color initTriciazColor;

        public Collision(Game game, TriciazCharacter triciaz, BluebleCharacter blueble, SoundEffect damageSound) : base(game)
        {
            this.triciaz = triciaz;
            this.blueble = blueble;
            this.damageSound = damageSound;

            initSpeed = triciaz.XSpeed;
            initPosition = triciaz.Position;
            isColliding = false;
            //this.collidedColor = new Color(0.5f, 0.5f, 0.5f, 1f);

            //tex = triciaz.Tex;
            //regTriciazColor = new Color[tex.Width * tex.Height];
            //tex.GetData(regTriciazColor);

            //collidedColor = Color.Red;
            //initTriciazColor = triciaz.TriciazColor;
        }

        public override void Update(GameTime gameTime)
        {
            Rectangle triciazRect = triciaz.GetCharBoundary();
            Rectangle bluebleRect = blueble.GetCharBoundary();
            Vector2 decreasedSpeed = new Vector2(1, 0);
            Vector2 collided = new Vector2(2, 0);

            if (triciazRect.Intersects(bluebleRect) && !isColliding)
            {
                triciaz.XSpeed = decreasedSpeed;
                triciaz.Position -= collided;
                damageSound.Play();
                isColliding = true;
                //for (int i = 0; i < regTriciazColor.Length; i++)
                //{
                //    if (regTriciazColor[i] == initTriciazColor)
                //        regTriciazColor[i] = collidedColor;
                //}

                //regTriciazColor[4 * tex.Width + 3] = Color.Red;
                //tex.SetData(regTriciazColor);

                //ball.Speed = new Vector2(ball.Speed.X, -ball.Speed.Y);


            }
            else if (triciazRect.Intersects(bluebleRect))
            {
                triciaz.XSpeed = decreasedSpeed;
                triciaz.Position -= collided;
            }
            else if (!triciazRect.Intersects(bluebleRect))
            {
                isColliding = false;
                triciaz.XSpeed = initSpeed;
            }


            base.Update(gameTime);
        }
    }
}
