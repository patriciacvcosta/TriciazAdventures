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
        //private SoundEffect hitSound;


        Vector2 initSpeed;

        Color initTriciazColor;

        public Collision(Game game, TriciazCharacter triciaz, BluebleCharacter blueble) : base(game)
        {
            this.triciaz = triciaz;
            this.blueble = blueble;
            //this.hitSound = hitSound;

            initSpeed = triciaz.XSpeed;
            initTriciazColor = triciaz.Color;
        }

        public override void Update(GameTime gameTime)
        {
            Rectangle triciazRect = triciaz.GetCharBoundary();
            Rectangle bluebleRect = blueble.GetCharBoundary();
            Vector2 decreasedSpeed = new Vector2(0,0);

            if (triciazRect.Intersects(bluebleRect))
            {
                triciaz.XSpeed = decreasedSpeed;
                //triciaz.Color = Color.Coral;

                //ball.Speed = new Vector2(ball.Speed.X, -ball.Speed.Y);
                //hitSound.Play();
            }
            else
            {
                triciaz.XSpeed = initSpeed;
                //triciaz.Color = initTriciazColor;

            }


            base.Update(gameTime);
        }
    }
}
