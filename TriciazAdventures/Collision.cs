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
        private List<EnemyCharacter> enemies;
        private SoundEffect damageSound;
        

        Vector2 initSpeed;
        Vector2 initPosition;
        private bool isColliding;
        private EnemyCharacter enemyColliding;
        private int reduceLife;
        public bool IsColliding { get => isColliding; set => isColliding = value; }
        public int ReduceLife { get => reduceLife; set => reduceLife = value; }

        public Collision(Game game, TriciazCharacter triciaz, List<EnemyCharacter> enemies, SoundEffect damageSound) : base(game)
        {
            this.triciaz = triciaz;
            this.enemies = enemies;
            this.damageSound = damageSound;

            initSpeed = triciaz.XSpeed;
            initPosition = triciaz.Position;
            isColliding = false;
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var enemy in enemies)
            {
                Rectangle triciazRect = triciaz.GetCharBoundary();
                Rectangle enemyRect = enemy.GetCharBoundary();
                Vector2 decreasedSpeed = new Vector2(1, 0);
                Vector2 collided = new Vector2(2, 0);

                if (triciazRect.Intersects(enemyRect) && !isColliding)
                {
                    triciaz.XSpeed = decreasedSpeed;
                    triciaz.Position -= collided;
                    damageSound.Play();
                    reduceLife++;
                    isColliding = true;
                    triciaz.isColliding = true;
                    enemyColliding = enemy;
                }
                else if (triciazRect.Intersects(enemyRect))
                {
                    triciaz.XSpeed = decreasedSpeed;
                    triciaz.Position -= collided;
                }
                else if (!triciazRect.Intersects(enemyRect) && enemyColliding == enemy)
                {
                    isColliding = false;
                    triciaz.XSpeed = initSpeed;
                    enemyColliding = null;
                } 
            }


            base.Update(gameTime);
        }
    }
}
