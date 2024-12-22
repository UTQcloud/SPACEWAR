using Raylib_cs;

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
        private bool hasUpdatedEnemies = false;
        Texture2D background = Raylib.LoadTexture("resources/spacebg.png");
        public Game()
        {
            Player = new Spaceship();
            CollisionDetector = new CollisionDetector();

        }


        public void StartGame()
        {


            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Black);
            Raylib.DrawTexture(background, 0, 0, Color.White);

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
                Player.DrawSpaceshipCollision();
                UpdateEnemies();

                CollisionDetector.checkNear(Player, enemies);
                CollisionDetector.checkCollision(Player.bullets, enemies);



                foreach (var enemy in enemies)
                {


                    CollisionDetector.checkEnemyBullet(enemy.enemybullet, Player, enemies);
                    enemy.Attack();
                    enemy.Move((int)Player.posX, (int)Player.posY);
                    enemy.DrawCollisionBox(Color.Red);
                }
                for (int i = enemies.Count - 1; i >= 0; i--)
                {
                    if (enemies[i].GetHealth() <= 0)
                    {
                        enemies[i].Destroy(enemies);
                        destroyedEnemy += 1;
                    }
                }


                if (Player.GetHealth() <= 0)
                {
                    EndGame();
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
            Raylib.EndDrawing();


            while (!Raylib.IsKeyPressed(KeyboardKey.Enter) && !Raylib.WindowShouldClose()) { }
            Raylib.CloseWindow();
        }
    }


}

