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
    public class Collision : GameComponent
    {
        private TriciazCharacter triciaz;
        private BluebleCharacter blueble;
        private SoundEffect damageSound;
        

        Vector2 initSpeed;
        Vector2 initPosition;
        private bool isColliding;
        private int reduceLife;
        public bool IsColliding { get => isColliding; set => isColliding = value; }
        public int ReduceLife { get => reduceLife; set => reduceLife = value; }

        public Collision(Game game, TriciazCharacter triciaz, BluebleCharacter blueble, SoundEffect damageSound) : base(game)
        {
            this.triciaz = triciaz;
            this.blueble = blueble;
            this.damageSound = damageSound;

            initSpeed = triciaz.XSpeed;
            initPosition = triciaz.Position;
            isColliding = false;
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
                reduceLife++;
                isColliding = true;
                triciaz.isColliding = true;

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
