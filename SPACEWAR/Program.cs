using Raylib_cs;
using System.Numerics;
using System.ComponentModel;

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
         

        string playText = "PLAY";
        string skoreText = "Scoreboard";
        int fontSize = 60;
        int playTextWidth = Raylib.MeasureText(playText, fontSize);
        int playTextHeight = fontSize;
        int skoreTextWidth = Raylib.MeasureText(skoreText, fontSize);
        int skoreTextHeight = fontSize;


        Rectangle playButton = new Rectangle(screenWidth / 2 - playTextWidth / 2,screenHeight / 2 - playTextWidth / 2, playTextWidth, playTextHeight);
        Rectangle skorButton = new Rectangle(screenWidth / 2 - skoreTextWidth / 2, screenHeight / 2 +150 / 2, skoreTextWidth, skoreTextHeight);

        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Black);
            Raylib.DrawTexture(background, screenWidth / 2 - background.Width / 2, screenHeight / 2 - background.Height / 2, Color.White);
             Raylib.DrawText(playText,(int)playButton.X,(int)playButton.Y,fontSize,Color.White);
             Raylib.DrawText(skoreText, (int)skorButton.X, (int)skorButton.Y, fontSize, Color.White);
            Raylib.DrawText("Spacewar", screenWidth / 2 - Raylib.MeasureText("Spacewar", fontSize) / 2, (int)playButton.Y - 150, fontSize, Color.White);
            if (Raylib.IsMouseButtonPressed(MouseButton.Left))
            {
                Vector2 mousePosition = Raylib.GetMousePosition();
                if (Raylib.CheckCollisionPointRec(mousePosition, playButton))
                {
                    Game game = new Game();
                    game.StartGame();
                    game.UpdateGame();
                }
               
                if (Raylib.CheckCollisionPointRec(mousePosition, skorButton))
                {
                    Console.WriteLine("Skore button clicked!");

                }

            }



            Raylib.EndDrawing();
            
        }
        Raylib.CloseWindow();
        

    }
}