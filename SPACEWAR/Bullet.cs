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
        }
        public void move()
        {
            Raylib.DrawCircle((int)position.X, (int)position.Y, 5, Color.Red);
            switch (direction)
            {
                case 0:
                    position = new Vector2(position.X, position.Y - (float)speed);
                    break;
                case 1:
                    position = new Vector2(position.X, position.Y - (float)speed);
                    break;
            }
        }
        public void onhit()
        {

        }
    }



}
