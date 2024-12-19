using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SPACEWAR
{
    internal class fastEnemy : Enemy
    {
        private float timer = 3f;
        private Vector2 direction ;
        public fastEnemy() : base(position: new Vector2(Raylib.GetRandomValue(0, Raylib.GetScreenWidth()), Raylib.GetRandomValue(0, Raylib.GetScreenHeight() / 2)), health: 50, speed: 3f, damage: 10, texturePath: "resources/fastEnemy.png")
        {
        }

        public override void Move(int playerx, int playery)
        {
            timer += Raylib.GetFrameTime();
           
            if (timer > 3f)
            {
                timer = 0f;
               
               Vector2 newdirection = new Vector2(playerx - Position.X, playery - Position.Y);

                direction = Vector2.Normalize(newdirection);
            }
            
          
            Position += direction * (float)Speed;
            Raylib.DrawTextureEx(Texture, Position, 0, (float)0.25, Color.White);
            
        }
        public override void Draw()
        {
            

            Raylib.DrawTextureEx(Texture, Position, 0, (float)0.25, Color.White);
        }


    }
    internal class basicEnemy : Enemy
    {
        private float timer = 1f;
        private Vector2 direction;
        private Vector2 position;
        public basicEnemy() : base(position: new Vector2(Raylib.GetRandomValue(0, Raylib.GetScreenWidth()), Raylib.GetRandomValue(0, Raylib.GetScreenHeight() / 2)), health: 50, speed: 2f, damage: 10, texturePath: "resources/basicEnemy.png")
        {
           position = Position;
        }
        public override void Move(int playerx, int playery)
        {
            timer += Raylib.GetFrameTime();

            if(timer > 2f ||playerx==position.X) {
            if (playerx > position.X)
            {
                direction.X = 1;
            }
            else if (playerx < position.X )
            {
                direction.X = -1;
            }
            if (Math.Abs(((float)playerx - (float)position.X)) < 50) { direction.X = 0;direction.Y = 0; }
                    timer = 0f;
            }
           




            position += direction * (float)Speed;
            Raylib.DrawTextureEx(Texture, position, 0, 0.25f, Color.White);

        }
        public override void Draw()
        {


            Raylib.DrawTextureEx(Texture, Position, 0, (float)0.25, Color.White);
        }
    }
}
