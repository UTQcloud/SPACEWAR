using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SPACEWAR
{
    internal class BasicEnemy : Enemy
    {
        private float timer = 4f;
        private Vector2 direction ;
        public BasicEnemy() : base(position: new Vector2(Raylib.GetRandomValue(0, Raylib.GetScreenWidth()), Raylib.GetRandomValue(0, Raylib.GetScreenHeight() / 2)), health: 50, speed: 1f, damage: 10, texturePath: "resources/basicEnemy.png")
        {
        }

        public override void Move(int playerx, int playery)
        {
            timer += Raylib.GetFrameTime();
           
            if (timer > 5f)
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


}
