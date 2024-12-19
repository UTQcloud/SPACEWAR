using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace SPACEWAR
{
    internal class fastEnemy : Enemy
    {
        private float timer = 3f;
        private Vector2 direction ;
         
        public fastEnemy() : base(position: new Vector2(Raylib.GetRandomValue(0, Raylib.GetScreenWidth()), Raylib.GetRandomValue(0, Raylib.GetScreenHeight() / 3)), health: 50, speed: 3f, damage: 10, texturePath: "resources/fastEnemy.png", scale:0.25f)
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
            Raylib.DrawTextureEx(Texture, Position, 0, Scale, Color.White);
            
        }
        public override void Draw()
        {
            

            Raylib.DrawTextureEx(Texture, Position, 0,Scale, Color.White);
        }


    }
    internal class basicEnemy : Enemy
    {
        private float timer = 1f;
        private Vector2 direction;
        private Vector2 position;
        
        public basicEnemy() : base(position: new Vector2(Raylib.GetRandomValue(0, Raylib.GetScreenWidth()), Raylib.GetRandomValue(0, Raylib.GetScreenHeight() / 3)), health: 50, speed: 2f, damage: 10, texturePath: "resources/basicEnemy.png", scale: 0.25f)
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
            Raylib.DrawTextureEx(Texture, position, 0, Scale, Color.White);
            Position = position;    

        }
        public override void Draw()
        {


            Raylib.DrawTextureEx(Texture, Position, 0, Scale, Color.White);
        }
        
    }



    internal class strongEnemy : Enemy {
       
            private float timer = 0f;
        private Vector2 direction;
            public strongEnemy() : base(position: new Vector2(Raylib.GetRandomValue(0, Raylib.GetScreenWidth()), Raylib.GetRandomValue(0, Raylib.GetScreenHeight() / 3)), health: 100, speed: 1.5f, damage: 20, texturePath: "resources/strongEnemy.png", scale: 0.15f)
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
                Raylib.DrawTextureEx(Texture, Position, 0, Scale, Color.White);

            }
            public override void Draw()
            {


                Raylib.DrawTextureEx(Texture, Position, 0, Scale, Color.White);
            }

        }
    }

