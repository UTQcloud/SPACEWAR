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
                    
                   player.TakeDamage(10); break;
                    
                }
            }
        }
        public void checkCollision(List<Bullet> bullets, List<Enemy> enemies,Spaceship player)
        {
            List<Bullet> bulletsToRemove = new List<Bullet>();
            foreach (var bullet in bullets)
            {
                foreach (var enemy in enemies)
                {
                    if (Raylib.CheckCollisionRecs(bullet.BulletCol(), enemy.EnemyCol()))
                    {
                        bullet.onhit(1, enemies,player);
                        bulletsToRemove.Add(bullet);
                    }
                }
            }
            foreach (var bullet in bulletsToRemove)
            {
                bullets.Remove(bullet);
            }
        }
        public void checkEnemyBullet(List<Bullet> enemybullet, Spaceship player, List<Enemy> enemies)
        { 
            List<Bullet> bulletsToRemove = new List<Bullet>();
            foreach (var bullet in enemybullet)
            {
                
                if (Raylib.CheckCollisionRecs(bullet.BulletCol(), player.SpaceshipCol()) )
                {
                    bullet.onhit(0, enemies,player);  
                    bulletsToRemove.Add(bullet);
                }
            }
            foreach (var bullet in bulletsToRemove)
            {
                enemybullet.Remove(bullet);  
            }
        }
    }
}
