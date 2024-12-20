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
        public Spaceship Player { get; set; }
        private double speed { get; set; }
        private int damage { get; set; }
        private int direction { get; set; }
        public Vector2 position { get; set; }



        public Bullet(Vector2 startPosition, double Speed, int Damage, int Direction)
        {
            position = startPosition;
            speed = Speed;
            damage = Damage;
            direction = Direction;
            Player = new Spaceship();
            
        }
        public void move()
        {
            Raylib.DrawRectangle((int)position.X, (int)position.Y, 10, 20, Color.Red);
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
            return new Rectangle(position.X, position.Y, 10, 20);
        }
        public void onhit(int bulletwho,List<Enemy> enemies)
        {
            switch (bulletwho)
            {
                case 0:
                    {
                        Player.TakeDamage(damage);

                        Console.WriteLine($"Player Health: {Player.GetHealth()}");

                    }
                    break;
                case 1:
                    {
                        foreach (var enemy in enemies)
                        {
                            Console.WriteLine($"Enemy Health: {enemy.GetHealth()}   Enemy type:{enemy.GetType()}");
                          
                            enemy.TakeDamage(damage);
                            break;
                        }
                    }
                    break;

            }
        }



    }
}
