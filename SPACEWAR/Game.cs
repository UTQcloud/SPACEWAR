using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SPACEWAR
{
    internal class Game
    {
        
        public Spaceship Player { get; set; }
        private List<Enemy> enemies;

        private int screenWidth=1280;
        private int screenHeight=720;
        Texture2D background = Raylib.LoadTexture("resources/spacebg.png");
        public Game()
        {
            Player = new Spaceship();
        }


        public void StartGame()
        {
            
           
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.Black);
                Raylib.DrawTexture(background, 0, 0, Color.White);
                
                Player.spawn(560,560);
                

                enemies = new List<Enemy>
                {
                    new BasicEnemy(),
                    new BasicEnemy()
                    
                };
            foreach (var enemy in enemies)
            {
                enemy.Draw();
            }



            Raylib.EndDrawing();
           

        }
        public void UpdateGame() {
            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
               
                Raylib.ClearBackground(Color.Black);
                Raylib.DrawTexture(background, 0, 0, Color.White);

                Player.Move();
                Player.Shoot();



                
                foreach (var enemy in enemies)
                {

                    enemy.Move((int)Player.posX,(int)Player.posY);

                }
               
                Raylib.EndDrawing();
            }
            }
    }
}
