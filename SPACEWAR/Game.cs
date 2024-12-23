using Raylib_cs;
using System.IO;
namespace SPACEWAR
{
    internal class Game
    {

        public Spaceship Player { get; set; }
        private List<Enemy> enemies;

        public CollisionDetector CollisionDetector { get; set; }
        private int screenWidth = 1280;
        private int screenHeight = 720;
        private int destroyedEnemy = 0;
        private bool scoreWritten = false;
        public string playername ;
        public int score = 0;
        private bool hasUpdatedEnemies = false;
        Texture2D background = Raylib.LoadTexture("resources/spacebg.png");
        public Game()
        {
            Player = new Spaceship();
            CollisionDetector = new CollisionDetector();

        }


        public void StartGame(string playerName)
        {


            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Black);
            Raylib.DrawTexture(background, 0, 0, Color.White);
            playername = playerName ;
            Player.spawn(560, 560);


            enemies = new List<Enemy>()
            { new basicEnemy(),
              new basicEnemy(),
              new basicEnemy()
            };

            




            foreach (var enemy in enemies)
            {
                enemy.Draw();

            }



            Raylib.EndDrawing();


        }
        public void UpdateEnemies()
        {
           
            if (destroyedEnemy == 3 && !hasUpdatedEnemies)
            {
                enemies = new List<Enemy>()
                {
                    new fastEnemy(),
                    new fastEnemy(),
                    new strongEnemy()
                };
                hasUpdatedEnemies = true;
            }
            else if (destroyedEnemy == 6 && hasUpdatedEnemies)
            {
                enemies = new List<Enemy>()
                {
                    new bossEnemy()
                };
                hasUpdatedEnemies = false; 
            }
        }
        public void UpdateGame()
        {
            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();

                Raylib.ClearBackground(Color.Black);
                Raylib.DrawTexture(background, 0, 0, Color.White);

                Player.Move();
                Player.Shoot();
                
                UpdateEnemies();

                CollisionDetector.checkNear(Player, enemies);
                CollisionDetector.checkCollision(Player.bullets, enemies,Player);



                foreach (var enemy in enemies)
                {


                    CollisionDetector.checkEnemyBullet(enemy.enemybullet, Player, enemies);
                    enemy.Attack();
                    enemy.Move((int)Player.posX, (int)Player.posY);
                  
                }
                for (int i = enemies.Count - 1; i >= 0; i--)
                {
                    if (enemies[i].GetHealth() <= 0)
                    {
                        enemies[i].Destroy(enemies);
                        destroyedEnemy += 1;
                        if (destroyedEnemy < 4) { score += 100; }
                        if (destroyedEnemy < 7&&destroyedEnemy>3) { score += 200; }
                        if (destroyedEnemy < 8 && destroyedEnemy >6) { score += 300; }
                    }   
                }
                int playerNameWidth = Raylib.MeasureText($"Player: {playername}", 20);
                Raylib.DrawText($"Health: {Player.health}", 10, 10, 40, Color.White);
                Raylib.DrawText($"Player: {playername}", screenWidth - playerNameWidth - 10, 10, 20, Color.White);
                if (Player.health <= 0)
                {
                    EndGame();
                   
                    if (Raylib.IsKeyPressed(KeyboardKey.Enter))
                    {
                        ResetGame();
                        break;
                    }
                }
                if (destroyedEnemy == 7)
                {
                    Raylib.DrawText("YOU WIN", Raylib.GetScreenWidth() / 2 - 80, Raylib.GetScreenHeight() / 2 - 20, 40, Color.White);
                    Raylib.DrawText("Press Enter to exit", Raylib.GetScreenWidth() / 2 - 100, Raylib.GetScreenHeight() / 2 + 20, 20, Color.White);
                    Raylib.DrawText("Your score is: " + (score + Player.health), Raylib.GetScreenWidth() / 2 - 90, Raylib.GetScreenHeight() / 2 + 60, 20, Color.White);
                    if (!scoreWritten)
                    {
                        string filePath = "PlayerScores.txt";
                        using (StreamWriter writer = new StreamWriter(filePath, true))
                        {
                            writer.WriteLine($"{playername}, {score}");
                        }
                        scoreWritten = true;
                    }
                }
                if (Raylib.IsKeyPressed(KeyboardKey.Enter) && destroyedEnemy == 7)
                {
                    ResetGame();
                    break;

                }
                Raylib.EndDrawing();
            }
           
        }
        public void EndGame()
        {
            Raylib.BeginDrawing();
            Raylib.DrawTexture(background, 0, 0, Color.White);
            Raylib.DrawText("GAME OVER", Raylib.GetScreenWidth() / 2 - 100, Raylib.GetScreenHeight() / 2 - 20, 40, Color.White);
            Raylib.DrawText("Press Enter to exit", Raylib.GetScreenWidth() / 2 - 100, Raylib.GetScreenHeight() / 2 + 20, 20, Color.White);
            if (!scoreWritten)
            {
                string filePath = "PlayerScores.txt";
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine($"{playername}, {score}");
                }
                scoreWritten = true;
            }

        }
        public List<string> GetScores()
        {
            string filePath = "PlayerScores.txt";
            List<string> scores = new List<string>();

            if (File.Exists(filePath))
            {
                scores = File.ReadAllLines(filePath).ToList();
            }

            return scores;
        }
        public void ResetGame()
        {
            Player = new Spaceship();
            enemies = new List<Enemy>()
            {
                new basicEnemy(),
                new basicEnemy(),
                new basicEnemy()
            };
            destroyedEnemy = 0;
            hasUpdatedEnemies = false;
            
            score = 0;
        }




    }


}

