using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SPACEWAR
{
    internal abstract class Enemy
    {
        public Vector2 Position { get; set; }
        protected int Health { get; set; }
        protected double Speed { get; set; }
        protected Texture2D Texture { get; set; }

        public List<Bullet> bullets { get; set; }
        protected int spawnx { get; set; }
        protected int spawny { get; set; }
        protected int Damage { get; set; }


        public Enemy(Vector2 position, int health, double speed, int damage, string texturePath)
        {
            Position = position;
            Health = health;
            Speed = speed;
            Damage = damage;
            Texture = Raylib.LoadTexture(texturePath);
        }
        public abstract void Move(int playerx, int playery);
        public abstract void Draw();

    }
}
