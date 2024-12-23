using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SPACEWAR
{
    internal class Bullet
    {
        private List<Enemy> enemies;
        private float grow { get; set; }
  
        private double speed { get; set; }
        private int damage { get; set; }
        private int direction { get; set; }
        public Vector2 position { get; set; }
        private float bulletSizeY = 20f;

        private float bulletSizeX= 10f;
        private bool isBoss { get; set; }
       
        public Bullet(Vector2 startPosition, double Speed, int Damage, int Direction,bool isBoss)
        {
            position = startPosition;
            speed = Speed;
            damage = Damage;
            direction = Direction;
           
            this.isBoss = isBoss;
            grow = 50f;
        }
        public void move()
        {
            

            Raylib.DrawRectangle((int)position.X-(int)(bulletSizeX / 2), (int)position.Y - (int)(bulletSizeY / 2), (int)bulletSizeX, (int)bulletSizeY, Color.Red);

            if (isBoss == true)
            {
                bulletSizeX += grow * Raylib.GetFrameTime();
                bulletSizeY += grow * Raylib.GetFrameTime();
               
            }
            switch (direction)
            {
                case 0:
                    position = new Vector2(position.X, position.Y + (float)speed);
                    break;
                case 1:
                    position = new Vector2(position.X, position.Y - (float)speed);
                    break;
            }

           
        }

        
        public Rectangle BulletCol()
        {
            return new Rectangle(position.X, position.Y, bulletSizeX, bulletSizeY);
        }
        public void onhit(int bulletwho,List<Enemy> enemies,Spaceship player)
        {
          
            switch (bulletwho)
            {
                case 0:
                    {
                        player.TakeDamage(damage);

                        Console.WriteLine($"Player Health: {player.health}");

                    }
                    break;
                case 1:
                    {
                        foreach (var enemy in enemies)
                        {
                            if (Raylib.CheckCollisionRecs(BulletCol(), enemy.EnemyCol())) 
                            {
                                enemy.TakeDamage(damage);
                               
                            }
                        }
                    }
                    break;

            }
        }



    }
}
