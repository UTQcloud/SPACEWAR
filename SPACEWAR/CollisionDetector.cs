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
        
        public void checkNear(Spaceship player, List<Enemy> enemies)
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

            foreach (var bullet in bullets)
            {
                foreach (var enemy in enemies)
                {
                    if (Raylib.CheckCollisionRecs(bullet.BulletCol(), enemy.EnemyCol()))
                    {
                        Console.WriteLine("Bullet hit an enemy!");
                    }
                }
            }

        }
        public void checkEnemyBullet(List<Bullet> enemybullet, Spaceship player)
        {
            foreach (var bullet in enemybullet)
            {
                if (Raylib.CheckCollisionRecs(bullet.BulletCol(), player.SpaceshipCol()))
                {
                    Console.WriteLine("Enemy bullet hit player!");
                }
            }
        }
    }
}
