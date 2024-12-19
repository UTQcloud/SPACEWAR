using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPACEWAR
{
    internal class CollisionDetector
    {
        public void checkCollision(Spaceship player, List<Enemy> enemies)
        {
           
            foreach (var enemy in enemies)
            {
                if (Raylib.CheckCollisionRecs(player.SpaceshipCol(),enemy.EnemyCol()))
                {
                    
                    Console.WriteLine("Player hit an enemy!");
                    
                }
            }
        }
        public void checkCollision(List<Bullet> bullets, List<Enemy> enemies)
        {

        }
    }
}
