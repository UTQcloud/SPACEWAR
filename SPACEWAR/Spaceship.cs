using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;
using static System.Net.Mime.MediaTypeNames;

namespace SPACEWAR
{
    internal class Spaceship
    {
        private Texture2D texture { get; set; }


       public int health { get; set;}
        private int damage { get; set; }
        private double speed { get; set; }
        public List<Bullet> bullets { get; set; }
        public double posX { get; set; }
        public double posY { get; set; }
        public Vector2 position;
        private bool isBoss = false;
        public Spaceship()
        {
            health = 100;
            damage = 10;
            speed = 5;
            bullets = new List<Bullet>();
            texture = Raylib.LoadTexture("resources/spaceship.png");
            posX = 200;
            posY = 360;

        }
        
        public void spawn(int x, int y)
        {
            posX = x;
            posY = y;
            position = new Vector2((float)posX, (float)posY);
            Raylib.DrawTextureEx(texture, position, 0, (float)0.12, Color.White);
        }
        public void Move()
        {
            position = new Vector2((float)posX, (float)posY);

            Raylib.DrawTextureEx(texture, position, 0, (float)0.12, Color.White);
            if (Raylib.IsKeyDown(KeyboardKey.W) && posY > 0) posY -= speed;
            if (Raylib.IsKeyDown(KeyboardKey.S) && posY < Raylib.GetScreenHeight() - texture.Height * 0.12f) posY += speed;
            if (Raylib.IsKeyDown(KeyboardKey.A) && posX > 0) posX -= speed;
            if (Raylib.IsKeyDown(KeyboardKey.D) && posX < Raylib.GetScreenWidth() - texture.Width * 0.12f) posX += speed;


        }
        public void Shoot()
        {
            if (Raylib.IsKeyPressed(KeyboardKey.Space))
            {
                bullets.Add(new Bullet(new Vector2((float)posX + texture.Width * 0.05f, (float)posY), 7, damage, 1,isBoss));
            }
            foreach (var bullet in bullets)
            {
                bullet.move();
            }
        }
        public Rectangle SpaceshipCol() { return new Rectangle((float)posX, (float)posY, texture.Width * 0.12f, texture.Height * 0.12f); }



       

        public void TakeDamage(int amount)
        {
            Console.WriteLine($"Player health before damage: {health}");
            health -= amount;
            Console.WriteLine($"Player health after damage: {health}");  // Debug log
            Console.WriteLine($"amount {amount}");  // Debug log
        }
       
    }
}
