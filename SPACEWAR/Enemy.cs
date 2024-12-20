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
        protected float Scale { get; set; }
        protected Vector2 Position { get; set; }
        protected int Health { get; set; }
        protected double Speed { get; set; }
        protected Texture2D Texture { get; set; }

        public List<Bullet> enemybullet { get; set; }
        protected int spawnx { get; set; }
        protected int spawny { get; set; }
        protected int Damage { get; set; }


        public Enemy(Vector2 position, int health, double speed, int damage, string texturePath,float scale)
        {
            Position = position;
            Health = health;
            Speed = speed;
            Damage = damage;
            Scale = scale;
            Texture = Raylib.LoadTexture(texturePath);
            enemybullet = new List<Bullet>();
        }
        public Rectangle EnemyCol()
        {

            
                float scaledWidth = Texture.Width * Scale;
                float scaledHeight = Texture.Height * Scale;
                return new Rectangle(Position.X, Position.Y, scaledWidth, scaledHeight);
            
        }
        public abstract void Move(int playerx, int playery);
        public abstract void Draw();
        public abstract void Attack();
        public void DrawCollisionBox(Color color)
        {
            Rectangle collisionBox = EnemyCol();
            Raylib.DrawRectangleLinesEx(collisionBox, 2, color); // Kenar kalınlığı 2 olan bir dikdörtgen çizer
        }
        public void TakeDamage(int damage)
        {
            Health -= damage;
           
        }
        public void Destroy(List<Enemy> enemyList)
        {

           
            if (enemyList.Contains(this))
            {
                enemyList.Remove(this);
               
                Console.WriteLine("Enemy Destroyed");
            }
        

        }
        public int GetHealth()
        {
            return Health;
        }
    }
}
