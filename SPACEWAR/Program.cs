using Raylib_cs;
using System.Numerics;
using System.ComponentModel;
using System.Text;

namespace SPACEWAR;

class Program
{

    public const int screenWidth = 1280;
    public const int screenHeight = 720;


    

    public static void Main()
    {

        Raylib.InitWindow(screenWidth, screenHeight, "Spacewar");
        Raylib.SetTargetFPS(60);
        Texture2D background = Raylib.LoadTexture("resources/spacebg.png");

        Game game = new Game();
        string playText = "PLAY";
        string skoreText = "Scoreboard";
        int fontSize = 60;
        int playTextWidth = Raylib.MeasureText(playText, fontSize);
        int playTextHeight = fontSize;
        int skoreTextWidth = Raylib.MeasureText(skoreText, fontSize);
        int skoreTextHeight = fontSize;


        Rectangle playButton = new Rectangle(screenWidth / 2 - playTextWidth / 2,screenHeight / 2 - playTextWidth / 2, playTextWidth, playTextHeight);
        Rectangle skorButton = new Rectangle(screenWidth / 2 - skoreTextWidth / 2, screenHeight / 2 +150 / 2, skoreTextWidth, skoreTextHeight);

        bool inputMode =false;
        StringBuilder playerName = new StringBuilder();
        bool showScores = false;

        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Black);
            Raylib.DrawTexture(background, screenWidth / 2 - background.Width / 2, screenHeight / 2 - background.Height / 2, Color.White);
            


            if (inputMode)
            {
                Raylib.DrawText("Enter your name:", screenWidth / 2 - Raylib.MeasureText("Enter your name:", fontSize) / 2, 100, fontSize, Color.White);
                Raylib.DrawText(playerName.ToString(), screenWidth / 2 - Raylib.MeasureText(playerName.ToString(), fontSize) / 2, 200, fontSize, Color.White);

                
                int key = Raylib.GetKeyPressed();
                if (key > 0)
                {
                    if (key == (int)KeyboardKey.Backspace && playerName.Length > 0)
                    {
                        playerName.Remove(playerName.Length - 1, 1); 

                    }
                    else if (key == (int)KeyboardKey.Enter && playerName.Length > 0)
                    {
                        inputMode = false;
                        
                        game.StartGame(playerName.ToString());
                        game.UpdateGame();
                        playerName.Clear();
                    }
                    else if (key != (int)KeyboardKey.Backspace && key != (int)KeyboardKey.Enter)
                    {
                        playerName.Append((char)key);
                    }
                }
            }
            else if (showScores)
            {
               
                var scores = game.GetScores();
                Raylib.DrawText("SCORES", screenWidth / 2 - Raylib.MeasureText("SCORES", fontSize) / 2, 50, fontSize, Color.White);
                int yOffset = 150;

                foreach (var score in scores)
                {
                    Raylib.DrawText(score, screenWidth / 2 - Raylib.MeasureText(score, 30) / 2, yOffset, 30, Color.White);
                    yOffset += 40;
                }

                Raylib.DrawText("Press Backspace to go back", screenWidth / 2 - Raylib.MeasureText("Press Backspace to go back", 20) / 2, screenHeight - 50, 20, Color.White);

                if (Raylib.IsKeyPressed(KeyboardKey.Backspace))
                {
                    showScores = false;
                }
            }
            else
            {
                Raylib.DrawText(playText, (int)playButton.X, (int)playButton.Y, fontSize, Color.White);
                Raylib.DrawText(skoreText, (int)skorButton.X, (int)skorButton.Y, fontSize, Color.White);
                Raylib.DrawText("Spacewar", screenWidth / 2 - Raylib.MeasureText("Spacewar", fontSize) / 2, (int)playButton.Y - 150, fontSize, Color.White);
                if (Raylib.IsMouseButtonPressed(MouseButton.Left))
                {
                    Vector2 mousePosition = Raylib.GetMousePosition();
                    if (Raylib.CheckCollisionPointRec(mousePosition, playButton))
                    {
                        inputMode = true;

                    }
                    if (Raylib.CheckCollisionPointRec(mousePosition, skorButton))
                    {
                       showScores=true;
                    }
                }
            }

            Raylib.EndDrawing();
            
        }
        Raylib.CloseWindow();
        

    }
}

